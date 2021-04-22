using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Packets;
using System.Threading;
using PcapDotNet.Core;
using System.Windows.Forms;
using System.Timers;

namespace Sorat_PSIP_project
{
    class Switch
    {
        private static System.Timers.Timer TTimer = new System.Timers.Timer(1000);
        public bool isRunning = false;
        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void Tiktok(object source, ElapsedEventArgs e)
        {
            ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
            lock(MacTable)
            {
                foreach (ListViewItem item in MacTable.Items)
                {
                    if (Int32.Parse(item.SubItems[2].Text) <= 0)
                    {
                        MacTable.Items.Remove(item);
                    }
                    else
                    {
                        int tmp = Int32.Parse(item.SubItems[2].Text);
                        tmp--;
                        item.SubItems[2].Text = tmp.ToString();
                    }
                }
            }
        }

        public void UpdateMac(string Mac, string portNr)
        {
            ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
            NumericUpDown timer = Application.OpenForms["mainForm"].Controls["numericUpDown1"] as NumericUpDown;
            Boolean foundMatch = false;
            string timerVal = timer.Value.ToString();
            //timer pre zaznamy v mac tabulke
            if (TTimer.Enabled == false)
            {
                TTimer.Elapsed += Tiktok;
                TTimer.AutoReset = true;
                TTimer.Enabled = true;
            }
            //hladam mac adresu v mac tabulke
            lock(MacTable)
            {
                foreach (ListViewItem item in MacTable.Items)
                {
                    //ak sa najde zhoda -> záznam s danou mac adresou už existuje -> resetujem timer
                    if (item.Text.Equals(Mac))
                    {
                        item.SubItems[2].Text = timer.Value.ToString();
                        foundMatch = true;
                    }
                    //vymena portov -> zaznam už je v mac tabulke ale port z ktorého mi prišiel je iný ako ten v tabuľke -> updatujem port
                    if (item.Text.Equals(Mac) && !(item.SubItems[1].Text.Equals(portNr)))
                    {
                        item.SubItems[1].Text = portNr;
                    }
                }
                //ak záznam v mac tabulke ešte neexistuje -> vytvorím nový záznam
                if (!foundMatch)
                {
                    MacTable.Items.Add(new ListViewItem(new string[] { Mac, portNr, timerVal }));
                }
            }                 
        }

        public string FindDstInTable(string dstMac)
        {
            ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
            foreach (ListViewItem item in MacTable.Items)
            {
                if (item.Text.Equals(dstMac))
                {
                    return item.SubItems[1].Text;
                }
            }
            return "0";
        }

        public void UpdateListView(string portIN, string portOUT, string itemName)
        {
            ListView statistics = Application.OpenForms["mainForm"].Controls["listView1"] as ListView;
            //portINidx -> index of column PORT 1/2 IN
            var portINidx = statistics.Columns[portIN].Index;
            var protocolIdx = statistics.Columns["Protocol"].Index;
            if (portOUT.Equals(""))
            {
                foreach (ListViewItem item in statistics.Items)
                {
                    try
                    {
                        if (item.SubItems[protocolIdx].Text == itemName)
                        {
                            var nr = Int32.Parse(item.SubItems[portINidx].Text);
                            nr++;
                            item.SubItems[portINidx].Text = nr.ToString();
                        }
                    }
                    catch { }
                }
            }
            else
            {
                var portOUTidx = statistics.Columns[portOUT].Index;
                foreach (ListViewItem item in statistics.Items)
                {
                    try
                    {
                        if (item.SubItems[protocolIdx].Text == itemName)
                        {
                            var nr1 = Int32.Parse(item.SubItems[portINidx].Text);
                            nr1++;
                            var nr2 = Int32.Parse(item.SubItems[portOUTidx].Text);
                            nr2++;
                            item.SubItems[portINidx].Text = nr1.ToString();
                            item.SubItems[portOUTidx].Text = nr2.ToString();
                        }
                    }
                    catch { }
                }
            }
        }

        public void UpdateStatistics(Packet packet, string portIN, string portOUT)
        {
            if (packet.DataLink.Kind == DataLinkKind.Ethernet)
            {
                UpdateListView(portIN, portOUT, "Ethernet II");
            }
            if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.Arp)
            {
                UpdateListView(portIN, portOUT, "ARP");
            }
            if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.IpV4)
            {
                UpdateListView(portIN, portOUT, "IP");
            }
            if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.InternetControlMessageProtocol)
            {
                UpdateListView(portIN, portOUT, "ICMP");
            }
            if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp)
            {
                UpdateListView(portIN, portOUT, "TCP");
            }
            if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Udp)
            {
                UpdateListView(portIN, portOUT, "UDP");
            }
            //todo eror is datagram?
            if (packet.Ethernet.IpV4.Tcp.Http.Version == PcapDotNet.Packets.Http.HttpVersion.Version11)
            {
                UpdateListView(portIN, portOUT, "HTTP");
            }
        }

        public void Start_comunication(PacketCommunicator p1, PacketCommunicator p2)
        {
            TextBox txtB1 = Application.OpenForms["mainForm"].Controls["textBox1"] as TextBox;
            Thread th1 = new Thread(() =>
            {
                Packet packet;
                do
                {
                    //p1 from GNS3 loopback1
                    PacketCommunicatorReceiveResult result = p1.ReceivePacket(out packet);
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout: continue;
                        case PacketCommunicatorReceiveResult.Ok:
                            //updatuje mac tabuľku
                            UpdateMac(packet.Ethernet.Source.ToString(), "1");
                            //hľadá zhodu medzi dst mac a záznamami v mac tabulke
                            var port = FindDstInTable(packet.Ethernet.Destination.ToString());
                            switch (port)
                            {
                                case "1":
                                    txtB1.Text += "Packet thrown away\r\n";
                                    UpdateStatistics(packet, "Port1IN", "");
                                    break;
                                case "2":
                                    //updatuje štatistiky
                                    UpdateStatistics(packet, "Port1IN", "Port2OUT");
                                    txtB1.Text += "Received packet on PORT 1 -> sending to PORT 2\r\n";
                                    p2.SendPacket(packet);
                                    break;
                                case "0":
                                    //updatuje štatistiky
                                    UpdateStatistics(packet, "Port1IN", "Port2OUT");
                                    txtB1.Text += "Received packet on PORT 1 -> BROADCAST\r\n";
                                    p2.SendPacket(packet);
                                    break;
                            }
                            break;
                        default:
                            throw new InvalidOperationException(result + "This shouldn't be here -> error");
                    }
                } while (isRunning);
            });
            Thread th2 = new Thread(() =>
            {
                Packet packet;
                do
                {
                    //p2 from GNS3 loopback2
                    PacketCommunicatorReceiveResult result = p2.ReceivePacket(out packet);
                    switch (result)
                    {
                        case PacketCommunicatorReceiveResult.Timeout: continue;
                        case PacketCommunicatorReceiveResult.Ok:
                            //updatuje mac tabuľku
                            UpdateMac(packet.Ethernet.Source.ToString(), "2");
                            //hľadá zhodu medzi dst mac a záznamami v mac tabulke
                            var port = FindDstInTable(packet.Ethernet.Destination.ToString());
                            switch (port)
                            {
                                case "1":
                                    //updatuje štatistiky
                                    UpdateStatistics(packet, "Port2IN", "Port1OUT");
                                    txtB1.Text += "Received packet on PORT 2 -> sending to PORT 1\r\n";
                                    p1.SendPacket(packet);
                                    break;
                                case "2":
                                    txtB1.Text += "Packet thrown away\r\n";
                                    UpdateStatistics(packet, "Port2IN", "");
                                    break;
                                case "0":
                                    UpdateStatistics(packet, "Port2IN", "Port1OUT");
                                    txtB1.Text += "Received packet on PORT 2 -> BROADCAST\r\n";
                                    p1.SendPacket(packet);
                                    break;
                            }
                            break;
                        default:
                            throw new InvalidOperationException(result + "This shouldn't be here -> error");
                    }
                } while (isRunning);
            });
            th1.Start();
            th2.Start();
        }
    }
}

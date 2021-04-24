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
        private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
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
            cacheLock.EnterWriteLock();
            try
            {
                ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
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
            finally
            {
                cacheLock.ExitWriteLock();
            }
        }

        public void UpdateMac(string srcMac, string portNr)
        {
            //timer pre zaznamy v mac tabulke
            if (TTimer.Enabled == false)
            {
                TTimer.Elapsed += Tiktok;
                TTimer.AutoReset = true;
                TTimer.Enabled = true;
            }
            //hladam mac adresu v mac tabulke
            cacheLock.EnterWriteLock();
            try
            {
                ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
                NumericUpDown timer = Application.OpenForms["mainForm"].Controls["numericUpDown1"] as NumericUpDown;
                Boolean foundMatch = false;
                string timerVal = timer.Value.ToString();
                foreach (ListViewItem item in MacTable.Items)
                {
                    //ak sa najde zhoda -> záznam s danou mac adresou už existuje -> resetujem timer
                    if (item.Text.Equals(srcMac))
                    {
                        item.SubItems[2].Text = timer.Value.ToString();
                        foundMatch = true;
                    }
                    //vymena portov -> zaznam už je v mac tabulke ale port z ktorého mi prišiel je iný ako ten v tabuľke -> updatujem port
                    if (item.Text.Equals(srcMac) && !(item.SubItems[1].Text.Equals(portNr)))
                    {
                        item.SubItems[1].Text = portNr;
                    }
                }
                //ak záznam v mac tabulke ešte neexistuje -> vytvorím nový záznam
                if (!foundMatch)
                {
                    MacTable.Items.Add(new ListViewItem(new string[] { srcMac, portNr, timerVal }));
                }
            }
            finally
            {
                cacheLock.ExitWriteLock();
            }                        
        }

        public string FindDstInTable(string dstMac)
        {
            cacheLock.EnterReadLock();
            try
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
            finally
            {
                cacheLock.ExitReadLock();
            }
        }

        public void UpdateListView(string portIN, string portOUT, List<string> itemNames)
        {
            ListView statistics = Application.OpenForms["mainForm"].Controls["listView1"] as ListView;
            //portINidx -> index of column PORT 1/2 IN
            var portINidx = statistics.Columns[portIN].Index;
            var protocolIdx = statistics.Columns["Protocol"].Index;
            if (portOUT.Equals(""))
            {
                foreach(string itemName in itemNames)
                {
                    foreach (ListViewItem item in statistics.Items)
                    {
                        try
                        {
                            if (item.SubItems[protocolIdx].Text == itemName)
                            {
                                //var nr = Int32.Parse(item.SubItems[portINidx].Text);
                                //nr++;
                                //item.SubItems[portINidx].Text = nr.ToString();
                                item.SubItems[portINidx].Text = (Int32.Parse(item.SubItems[portINidx].Text)+1).ToString();
                                break;
                            }
                        }
                        catch { }
                    }
                }
                
            }
            else
            {
                var portOUTidx = statistics.Columns[portOUT].Index;
                foreach(string itemName in itemNames)
                {
                    foreach (ListViewItem item in statistics.Items)
                    {
                        try
                        {
                            if (item.SubItems[protocolIdx].Text == itemName)
                            {
                                //var nr1 = Int32.Parse(item.SubItems[portINidx].Text);
                                //nr1++;
                                //var nr2 = Int32.Parse(item.SubItems[portOUTidx].Text);
                                //nr2++;
                                //item.SubItems[portINidx].Text = nr1.ToString();
                                //item.SubItems[portOUTidx].Text = nr2.ToString();
                                item.SubItems[portINidx].Text = (Int32.Parse(item.SubItems[portINidx].Text) + 1).ToString();
                                item.SubItems[portOUTidx].Text = (Int32.Parse(item.SubItems[portOUTidx].Text) + 1).ToString();
                                break;
                            }
                        }
                        catch { }
                    }
                }
            }
        }

        public void UpdateStatistics(Packet packet, string portIN, string portOUT)
        {
            //Ethernet->IP->{ICMP, TCP->http, UDP}
            List<string> itemsToUpdate = new List<string>();
            if (packet.DataLink.Kind == DataLinkKind.Ethernet)
            {
                itemsToUpdate.Add("Ethernet II");
                if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.IpV4)
                {
                    itemsToUpdate.Add("IP");
                    if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.InternetControlMessageProtocol)
                    {
                        itemsToUpdate.Add("ICMP");
                    }
                    else if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp)
                    {
                        itemsToUpdate.Add("TCP");
                        if (packet.Ethernet.IpV4.Tcp.SourcePort == 80 || packet.Ethernet.IpV4.Tcp.DestinationPort == 80)
                        {
                            itemsToUpdate.Add("HTTP");
                        }
                    }
                    else if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Udp)
                    {
                        itemsToUpdate.Add("UDP");
                    }
                }
            }
            //ARP
            else if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.Arp)
            {
                itemsToUpdate.Add("ARP");               
            }
            if (itemsToUpdate.Count > 0)
                UpdateListView(portIN, portOUT, itemsToUpdate);
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
                            UpdateMac(packet.Ethernet.Source.ToString(),"2");
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

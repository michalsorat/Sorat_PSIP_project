using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PcapDotNet.Packets;
using System.Threading;
using PcapDotNet.Core;
using System.Windows.Forms;

namespace Sorat_PSIP_project
{
    class Switch
    {
        public bool isRunning = false;
        public void Start()
        {
            isRunning = true;
        }

        public void Stop()
        {
            isRunning = false;
        }

        public void UpdateMac(string Mac, string portNr)
        {
            ListView MacTable = Application.OpenForms["mainForm"].Controls["listView2"] as ListView;
            NumericUpDown timer = Application.OpenForms["mainForm"].Controls["numericUpDown1"] as NumericUpDown;
            string timerVal = timer.Value.ToString();
            //ak Mac tabulka obsahuje nejake zaznamy
            if (MacTable.Items.Count > 0)
            {
                //hladam mac adresu v mac tabulke
                foreach (ListViewItem item in MacTable.Items)
                {
                    if (item.Text == Mac)
                    {
                        item.SubItems[2].Text = timer.Value.ToString();
                        return;
                    }
                }
            }
            MacTable.Items.Add(new ListViewItem(new string[] { Mac, portNr, timerVal }));
        }

        public void UpdateListView(string portIN, string portOUT, string itemName)
        {
            ListView statistics = Application.OpenForms["mainForm"].Controls["listView1"] as ListView;
            //portINidx -> index of column PORT 1/2 IN
            var portINidx = statistics.Columns[portIN].Index;
            //portOUTidx -> index of column PORT 1/2 OUT
            var portOUTidx = statistics.Columns[portOUT].Index;
            var protocolIdx = statistics.Columns["Protocol"].Index;
            
            foreach (ListViewItem item in statistics.Items)
            {
                if (item.SubItems[protocolIdx].Text == itemName)
                {
                    var nr = Int32.Parse(item.SubItems[portINidx].Text);
                    nr++;
                    item.SubItems[portINidx].Text = nr.ToString();
                    item.SubItems[portOUTidx].Text = nr.ToString();
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
                            txtB1.Text += "Received packet on PORT 1 -> sending to PORT 2\r\n";
                            UpdateStatistics(packet, "Port1IN", "Port2OUT");
                            UpdateMac(packet.Ethernet.Source.ToString(), "1");
                            p2.SendPacket(packet);
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
                            txtB1.Text += "Received packet on PORT 2 -> sending to PORT 1\r\n";
                            UpdateStatistics(packet, "Port2IN", "Port1OUT");
                            p1.SendPacket(packet);
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

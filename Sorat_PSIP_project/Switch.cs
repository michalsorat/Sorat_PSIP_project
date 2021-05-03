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

        public void UpdateStatistics(string portIN, string portOUT, List<string> itemNames)
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

        public List<string> FindProtocols(Packet packet)
        {
            //Ethernet->IP->{ICMP, TCP->http, UDP}
            List<string> protocolList = new List<string>();
            if (packet.DataLink.Kind == DataLinkKind.Ethernet)
            {
                protocolList.Add("Ethernet II");
                if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.IpV4)
                {
                    protocolList.Add("IP");
                    if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.InternetControlMessageProtocol)
                    {
                        protocolList.Add("ICMP");
                    }
                    else if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Tcp)
                    {
                        protocolList.Add("TCP");
                        if (packet.Ethernet.IpV4.Tcp.SourcePort == 80 || packet.Ethernet.IpV4.Tcp.DestinationPort == 80)
                        {
                            protocolList.Add("HTTP");
                        }
                    }
                    else if (packet.Ethernet.IpV4.Protocol == PcapDotNet.Packets.IpV4.IpV4Protocol.Udp)
                    {
                        protocolList.Add("UDP");
                    }
                }
            }
            //ARP
            else if (packet.Ethernet.EtherType == PcapDotNet.Packets.Ethernet.EthernetType.Arp)
            {
                protocolList.Add("ARP");               
            }
            return protocolList;
        }

        public Boolean ApplyFilter(List<string> protocolsOfPacket, string portNr, Packet packet)
        {
            ListView filterTable = Application.OpenForms["mainForm"].Controls["filterTable"] as ListView;
            if (filterTable == null)
                return true;
            cacheLock.EnterReadLock();
            try
            {
                var protocolColumn = filterTable.Columns["protocolFilter"].Index;
                var macDirColumn = filterTable.Columns["macAddDir"].Index;
                var macAddColumn = filterTable.Columns["macAdd"].Index;
                var ipDirColumn = filterTable.Columns["ipAddDir"].Index;
                var ipAddColumn = filterTable.Columns["ipAdd"].Index;
                var x = "";
                if (portNr.Equals("Port1IN") || portNr.Equals("Port2IN"))
                    x = "IN";
                else if (portNr.Equals("Port1OUT") || portNr.Equals("Port2OUT"))
                    x = "OUT";
                switch (x)
                {
                    case ("IN"):
                        //check if protocol of packet is in filterTable (if yes -> return false)
                        foreach (ListViewItem filter in filterTable.Items)
                        {
                            var ipAdd = filter.SubItems[ipAddColumn].Text;
                            var macAdd = filter.SubItems[macAddColumn].Text;
                            //ak sa source ip alebo mac adresa rovna s ip alebo mac adresou nastavenou vo filtry
                            if ((packet.Ethernet.Source.ToString().Equals(macAdd) && filter.SubItems[macDirColumn].Text.Equals("Source")) || (packet.IpV4.Source.ToString().Equals(ipAdd) && filter.SubItems[ipDirColumn].Text.Equals("Source")))
                            {
                                //check if protocol of packet is in filterTable (if yes -> return false)
                                foreach (string protocol in protocolsOfPacket)
                                {
                                    if (protocol.Equals(filter.SubItems[protocolColumn].Text))
                                        return false;
                                }
                            }
                        }
                        return true;
                    case ("OUT"):
                        foreach (ListViewItem filter in filterTable.Items)
                        {
                            var ipAdd = filter.SubItems[ipAddColumn].Text;
                            var macAdd = filter.SubItems[macAddColumn].Text;
                            //ak sa destination ip alebo mac adresa rovna s ip alebo mac adresou nastavenou vo filtry
                            if ((packet.Ethernet.Destination.ToString().Equals(macAdd) && filter.SubItems[macDirColumn].Text.Equals("Destination")) || (packet.IpV4.Destination.ToString().Equals(ipAdd) && filter.SubItems[ipDirColumn].Text.Equals("Destination")))
                            {
                                //check if protocol of packet is in filterTable (if yes -> return false)
                                foreach (string protocol in protocolsOfPacket)
                                {
                                    if (protocol.Equals(filter.SubItems[protocolColumn].Text))
                                        return false;
                                }
                            }
                        }
                        return true;
                    case (""):
                        break;
                }
                return true;
            }
            finally
            {
                cacheLock.ExitReadLock();
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
                            var protocolList = FindProtocols(packet);
                            if (ApplyFilter(protocolList, "Port1IN", packet))
                            {
                                //updatuje mac tabuľku
                                UpdateMac(packet.Ethernet.Source.ToString(), "1");
                                //hľadá zhodu medzi dst mac a záznamami v mac tabulke
                                var port = FindDstInTable(packet.Ethernet.Destination.ToString());
                                switch (port)
                                {
                                    case "1":
                                        if (ApplyFilter(protocolList, "Port1OUT", packet))
                                        {
                                            //updatuje štatistiky
                                            UpdateStatistics("Port1IN", "", protocolList);
                                            txtB1.Text += "Packet thrown away\r\n";
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 1 OUT applied\r\n";
                                        break;
                                    case "2":
                                        //updatuje štatistiky
                                        if (ApplyFilter(protocolList, "Port1OUT", packet))
                                        {
                                            UpdateStatistics("Port1IN", "Port2OUT", protocolList);
                                            txtB1.Text += "Received packet on PORT 1 -> sending to PORT 2\r\n";
                                            p2.SendPacket(packet);
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 1 OUT applied\r\n";
                                        break;
                                    case "0":
                                        //updatuje štatistiky
                                        if (ApplyFilter(protocolList, "Port1OUT", packet))
                                        {
                                            UpdateStatistics("Port1IN", "Port2OUT", protocolList);
                                            txtB1.Text += "Received packet on PORT 1 -> BROADCAST\r\n";
                                            p2.SendPacket(packet);
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 1 OUT applied\r\n";
                                        break;
                                }
                            }
                            else
                                txtB1.Text += "Protocol on port 1 IN applied\r\n";
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
                            var protocolList = FindProtocols(packet);
                            if (ApplyFilter(protocolList, "Port2IN", packet))
                            {
                                //updatuje mac tabuľku
                                UpdateMac(packet.Ethernet.Source.ToString(), "2");
                                //hľadá zhodu medzi dst mac a záznamami v mac tabulke
                                var port = FindDstInTable(packet.Ethernet.Destination.ToString());
                                switch (port)
                                {
                                    case "1":
                                        //updatuje štatistiky
                                        if (ApplyFilter(protocolList, "Port2OUT", packet))
                                        {
                                            UpdateStatistics("Port2IN", "Port1OUT", protocolList);
                                            txtB1.Text += "Received packet on PORT 2 -> sending to PORT 1\r\n";
                                            p1.SendPacket(packet);
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 2 OUT applied\r\n";
                                        break;
                                    case "2":
                                        if (ApplyFilter(protocolList, "Port2OUT", packet))
                                        {
                                            txtB1.Text += "Packet thrown away\r\n";
                                            UpdateStatistics("Port2IN", "", protocolList);
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 2 OUT applied\r\n";
                                        break;
                                    case "0":
                                        if (ApplyFilter(protocolList, "Port2OUT", packet))
                                        {
                                            UpdateStatistics("Port2IN", "Port1OUT", protocolList);
                                            txtB1.Text += "Received packet on PORT 2 -> BROADCAST\r\n";
                                            p1.SendPacket(packet);
                                        }
                                        else
                                            txtB1.Text += "Protocol on port 2 OUT applied\r\n";
                                        break;
                                }
                            }
                            else
                                txtB1.Text += "Protocol on port 2 IN applied\r\n";
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

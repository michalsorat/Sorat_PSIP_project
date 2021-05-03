using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PcapDotNet.Core;
using SharpPcap.LibPcap;

namespace Sorat_PSIP_project
{
    public partial class mainForm : Form
    {
        PacketDevice LoopB1, LoopB2;
        PacketCommunicator p1, p2;
        int id = 1;
        Switch sw = new Switch();
        LibPcapLiveDeviceList devices = LibPcapLiveDeviceList.Instance;
        IList<LivePacketDevice> allDevices = LivePacketDevice.AllLocalMachine;

        public mainForm()
        {
            InitializeComponent();
        }
        
        private void StartRB_CheckedChanged(object sender, EventArgs e)
        {
            sw.Start();
            sw.Start_comunication(p1, p2);
        }
        
        private void StopRB_CheckedChanged(object sender, EventArgs e)
        {
            sw.Stop();
        }
        
        private void StartStopGB_Enter(object sender, EventArgs e)
        {
        
        }

        private void ClearBtn_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Interface1CB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Interface2CB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void ChooseInterface1_Click(object sender, EventArgs e)
        {

        }

        private void ChooseInterface2_Click(object sender, EventArgs e)
        {
        
        }

        //select btn interface 1
        private void SelectInterface1Btn_Click(object sender, EventArgs e)
        {
            LoopB1 = allDevices[comboBox1.SelectedIndex];
            p1 = LoopB1.Open(1000, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, 1);
        }
        //select btn interface 2
        private void SelectInterface2Btn_Click(object sender, EventArgs e)
        {
            LoopB2 = allDevices[comboBox2.SelectedIndex];
            p2 = LoopB2.Open(1000, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, 1);
        }

        private void StatisticsLbl_Click(object sender, EventArgs e)
        {

        }

        private void MacTableLV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TimerLbl_Click(object sender, EventArgs e)
        {

        }

        private void TimerNumericUpDown_ValueChanged(object sender, EventArgs e)
        {

        }

        private void MacTableLbl_Click(object sender, EventArgs e)
        {

        }

        private void ClearMacTableBtn_Click(object sender, EventArgs e)
        {
            listView2.Items.Clear();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void portFilterCB_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void dirFilter_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string[] row = { id.ToString(), protFilterCB.SelectedItem.ToString(), dirFilter.SelectedItem.ToString(), portFilterCB.SelectedItem.ToString(), macDirCB.SelectedItem.ToString(), macAddrTxt.Text, ipDirCB.SelectedItem.ToString(), ipAddrTxt.Text };
                id++;
                var listViewItem = new ListViewItem(row);
                filterTable.Items.Add(listViewItem);
                warningLbl.Visible = false;
            }
            catch (NullReferenceException)
            {
                warningLbl.Visible = true;
            }
        }

        private void warningLbl_Click(object sender, EventArgs e)
        {

        }

        private void delAllFilters_Click(object sender, EventArgs e)
        {
            filterTable.Items.Clear();
        }

        private void macDirCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void filterTable_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void delFilterBtn_Click(object sender, EventArgs e)
        {
            var idForDelete = idDelTxt.Text;
            var id = filterTable.Columns["ID"].Index;
            foreach(ListViewItem item in filterTable.Items)
            {
                if (idForDelete.Equals(item.SubItems[id].Text))
                    item.Remove();
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void StatisticsLW_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Control.CheckForIllegalCrossThreadCalls = false;
            foreach (LibPcapLiveDevice device in devices)
            {
                if (!device.Interface.Addresses.Exists(a => a != null && a.Addr != null && a.Addr.ipAddress != null)) continue;
                var devInterface = device.Interface;
                var friendlyName = devInterface.FriendlyName;
                comboBox1.Items.Add(friendlyName);
                comboBox2.Items.Add(friendlyName);
            }        
        }
    }
}

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
        private void SelectInterface1Lbl_Click(object sender, EventArgs e)
        {
            LoopB1 = allDevices[comboBox1.SelectedIndex];
            p1 = LoopB1.Open(1000, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, 1);
        }
        //select btn interface 2
        private void SelectInterface2Lbl_Click(object sender, EventArgs e)
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

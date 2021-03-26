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
        
        private void RadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            sw.Start();
            sw.Start_comunication(p1, p2);
        }
        
        private void RadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            sw.Stop();
        }
        
        private void GroupBox1_Enter(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //select btn interface 1
        private void button2_Click(object sender, EventArgs e)
        {
            LoopB1 = allDevices[comboBox1.SelectedIndex];
            p1 = LoopB1.Open(1000, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, 1);
        }
        //select btn interface 2
        private void button3_Click(object sender, EventArgs e)
        {
            LoopB2 = allDevices[comboBox2.SelectedIndex];
            p2 = LoopB2.Open(1000, PacketDeviceOpenAttributes.Promiscuous | PacketDeviceOpenAttributes.NoCaptureLocal, 1);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
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

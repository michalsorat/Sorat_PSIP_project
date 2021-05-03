
namespace Sorat_PSIP_project
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Ethernet II",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem(new string[] {
            "ARP",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem(new string[] {
            "IP",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem11 = new System.Windows.Forms.ListViewItem(new string[] {
            "ICMP",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem12 = new System.Windows.Forms.ListViewItem(new string[] {
            "UDP",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem13 = new System.Windows.Forms.ListViewItem(new string[] {
            "TCP",
            "0",
            "0",
            "0",
            "0"}, -1);
            System.Windows.Forms.ListViewItem listViewItem14 = new System.Windows.Forms.ListViewItem(new string[] {
            "HTTP",
            "0",
            "0",
            "0",
            "0"}, -1);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.Protocol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port1IN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port1OUT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port2IN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port2OUT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.MAC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Port = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Timer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.filterTable = new System.Windows.Forms.ListView();
            this.ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.portDirection = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.protocolFilter = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.macAddDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.macAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipAddDir = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ipAdd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.portFilterCB = new System.Windows.Forms.ComboBox();
            this.dirFilter = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.protFilterCB = new System.Windows.Forms.ComboBox();
            this.macDirCB = new System.Windows.Forms.ComboBox();
            this.ipDirCB = new System.Windows.Forms.ComboBox();
            this.macAddrTxt = new System.Windows.Forms.TextBox();
            this.ipAddrTxt = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.idDelTxt = new System.Windows.Forms.TextBox();
            this.delFilterBtn = new System.Windows.Forms.Button();
            this.label16 = new System.Windows.Forms.Label();
            this.filterBtn = new System.Windows.Forms.Button();
            this.warningLbl = new System.Windows.Forms.Label();
            this.delAllFilters = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButton2);
            this.groupBox1.Controls.Add(this.radioButton1);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(255, 32);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(102, 97);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Start/stop";
            this.groupBox1.Enter += new System.EventHandler(this.StartStopGB_Enter);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Checked = true;
            this.radioButton2.Location = new System.Drawing.Point(12, 61);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(54, 20);
            this.radioButton2.TabIndex = 1;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Stop";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.StopRB_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(12, 32);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(55, 20);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.Text = "Start";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.StartRB_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(694, 389);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(64, 22);
            this.button1.TabIndex = 4;
            this.button1.Text = "clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ClearBtn_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Protocol,
            this.Port1IN,
            this.Port1OUT,
            this.Port2IN,
            this.Port2OUT});
            this.listView1.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem8,
            listViewItem9,
            listViewItem10,
            listViewItem11,
            listViewItem12,
            listViewItem13,
            listViewItem14});
            this.listView1.Location = new System.Drawing.Point(11, 236);
            this.listView1.Margin = new System.Windows.Forms.Padding(2);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(411, 149);
            this.listView1.TabIndex = 5;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.StatisticsLW_SelectedIndexChanged);
            // 
            // Protocol
            // 
            this.Protocol.Name = "Protocol";
            this.Protocol.Text = "Protocol";
            this.Protocol.Width = 83;
            // 
            // Port1IN
            // 
            this.Port1IN.Name = "Port1IN";
            this.Port1IN.Tag = "";
            this.Port1IN.Text = "Port 1 IN";
            this.Port1IN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port1IN.Width = 80;
            // 
            // Port1OUT
            // 
            this.Port1OUT.Name = "Port1OUT";
            this.Port1OUT.Tag = "";
            this.Port1OUT.Text = "Port 1 OUT";
            this.Port1OUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port1OUT.Width = 80;
            // 
            // Port2IN
            // 
            this.Port2IN.Name = "Port2IN";
            this.Port2IN.Tag = "";
            this.Port2IN.Text = "Port 2 IN";
            this.Port2IN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port2IN.Width = 80;
            // 
            // Port2OUT
            // 
            this.Port2OUT.Name = "Port2OUT";
            this.Port2OUT.Tag = "";
            this.Port2OUT.Text = "Port 2 OUT";
            this.Port2OUT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port2OUT.Width = 80;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(436, 236);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox1.Size = new System.Drawing.Size(328, 149);
            this.textBox1.TabIndex = 6;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(36, 48);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(179, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.Interface1CB_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(36, 132);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(179, 21);
            this.comboBox2.TabIndex = 8;
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.Interface2CB_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(33, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 16);
            this.label1.TabIndex = 9;
            this.label1.Text = "Choose interface 1";
            this.label1.Click += new System.EventHandler(this.ChooseInterface1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(33, 116);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(122, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "Choose interface 2";
            this.label2.Click += new System.EventHandler(this.ChooseInterface2_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(140, 75);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 11;
            this.button2.Text = "Select";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.SelectInterface1Btn_Click);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(140, 159);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 12;
            this.button3.Text = "Select";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.SelectInterface2Btn_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 208);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(162, 30);
            this.label3.TabIndex = 13;
            this.label3.Text = "Statistics";
            this.label3.Click += new System.EventHandler(this.StatisticsLbl_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(492, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 23);
            this.label4.TabIndex = 15;
            this.label4.Text = "Mac Table";
            this.label4.Click += new System.EventHandler(this.MacTableLbl_Click);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.MAC,
            this.Port,
            this.Timer});
            this.listView2.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(486, 58);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(272, 131);
            this.listView2.TabIndex = 16;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.MacTableLV_SelectedIndexChanged);
            // 
            // MAC
            // 
            this.MAC.Name = "MAC";
            this.MAC.Text = "MAC address";
            this.MAC.Width = 131;
            // 
            // Port
            // 
            this.Port.Name = "Port";
            this.Port.Text = "Source Port";
            this.Port.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Port.Width = 76;
            // 
            // Timer
            // 
            this.Timer.Name = "Timer";
            this.Timer.Text = "Timer";
            this.Timer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDown1.Location = new System.Drawing.Point(385, 84);
            this.numericUpDown1.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDown1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(75, 28);
            this.numericUpDown1.TabIndex = 17;
            this.numericUpDown1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.TimerNumericUpDown_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(393, 60);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 21);
            this.label5.TabIndex = 19;
            this.label5.Text = "Timer";
            this.label5.Click += new System.EventHandler(this.TimerLbl_Click);
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(683, 195);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 20;
            this.button5.Text = "Clear Table";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ClearMacTableBtn_Click);
            // 
            // filterTable
            // 
            this.filterTable.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ID,
            this.protocolFilter,
            this.portDirection,
            this.portFilter,
            this.macAddDir,
            this.macAdd,
            this.ipAddDir,
            this.ipAdd});
            this.filterTable.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterTable.GridLines = true;
            this.filterTable.HideSelection = false;
            this.filterTable.Location = new System.Drawing.Point(779, 238);
            this.filterTable.Name = "filterTable";
            this.filterTable.Size = new System.Drawing.Size(540, 146);
            this.filterTable.TabIndex = 21;
            this.filterTable.UseCompatibleStateImageBehavior = false;
            this.filterTable.View = System.Windows.Forms.View.Details;
            this.filterTable.SelectedIndexChanged += new System.EventHandler(this.filterTable_SelectedIndexChanged);
            // 
            // ID
            // 
            this.ID.Name = "ID";
            this.ID.Text = "ID";
            this.ID.Width = 27;
            // 
            // portFilter
            // 
            this.portFilter.Name = "portFilter";
            this.portFilter.Text = "Port";
            this.portFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portFilter.Width = 44;
            // 
            // portDirection
            // 
            this.portDirection.Name = "portDirection";
            this.portDirection.Text = "IN/OUT";
            this.portDirection.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.portDirection.Width = 55;
            // 
            // protocolFilter
            // 
            this.protocolFilter.Name = "protocolFilter";
            this.protocolFilter.Text = "Protocol";
            this.protocolFilter.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.protocolFilter.Width = 67;
            // 
            // macAddDir
            // 
            this.macAddDir.Name = "macAddDir";
            this.macAddDir.Text = "Mac direction";
            this.macAddDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.macAddDir.Width = 82;
            // 
            // macAdd
            // 
            this.macAdd.Name = "macAdd";
            this.macAdd.Text = "Mac address";
            this.macAdd.Width = 81;
            // 
            // ipAddDir
            // 
            this.ipAddDir.Name = "ipAddDir";
            this.ipAddDir.Text = "IP direction";
            this.ipAddDir.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ipAddDir.Width = 92;
            // 
            // ipAdd
            // 
            this.ipAdd.Name = "ipAdd";
            this.ipAdd.Text = "IP address";
            this.ipAdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ipAdd.Width = 88;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(819, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 16);
            this.label6.TabIndex = 22;
            this.label6.Text = "Port";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // portFilterCB
            // 
            this.portFilterCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.portFilterCB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.portFilterCB.FormattingEnabled = true;
            this.portFilterCB.Items.AddRange(new object[] {
            "Loopback 1",
            "Loopback 2"});
            this.portFilterCB.Location = new System.Drawing.Point(821, 86);
            this.portFilterCB.Name = "portFilterCB";
            this.portFilterCB.Size = new System.Drawing.Size(121, 21);
            this.portFilterCB.TabIndex = 23;
            this.portFilterCB.SelectedIndexChanged += new System.EventHandler(this.portFilterCB_SelectedIndexChanged);
            // 
            // dirFilter
            // 
            this.dirFilter.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.dirFilter.FormattingEnabled = true;
            this.dirFilter.Items.AddRange(new object[] {
            "IN",
            "OUT"});
            this.dirFilter.Location = new System.Drawing.Point(822, 132);
            this.dirFilter.Name = "dirFilter";
            this.dirFilter.Size = new System.Drawing.Size(121, 21);
            this.dirFilter.TabIndex = 24;
            this.dirFilter.SelectedIndexChanged += new System.EventHandler(this.dirFilter_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(819, 113);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 16);
            this.label7.TabIndex = 25;
            this.label7.Text = "Direction";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Tai Le", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(818, 32);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(55, 23);
            this.label8.TabIndex = 26;
            this.label8.Text = "Filter";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(819, 163);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 16);
            this.label9.TabIndex = 27;
            this.label9.Text = "Protocol";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(989, 113);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(65, 16);
            this.label10.TabIndex = 28;
            this.label10.Text = "Direction";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(989, 63);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(57, 16);
            this.label11.TabIndex = 29;
            this.label11.Text = "Address";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(1152, 63);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(57, 16);
            this.label12.TabIndex = 30;
            this.label12.Text = "Address";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(1153, 113);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(65, 16);
            this.label13.TabIndex = 31;
            this.label13.Text = "Direction";
            // 
            // protFilterCB
            // 
            this.protFilterCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.protFilterCB.FormattingEnabled = true;
            this.protFilterCB.Items.AddRange(new object[] {
            "Ethernet II",
            "ARP",
            "IP",
            "ICMP",
            "UDP",
            "TCP",
            "Http"});
            this.protFilterCB.Location = new System.Drawing.Point(821, 182);
            this.protFilterCB.Name = "protFilterCB";
            this.protFilterCB.Size = new System.Drawing.Size(121, 21);
            this.protFilterCB.TabIndex = 32;
            this.protFilterCB.SelectedIndexChanged += new System.EventHandler(this.comboBox5_SelectedIndexChanged);
            // 
            // macDirCB
            // 
            this.macDirCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.macDirCB.FormattingEnabled = true;
            this.macDirCB.Items.AddRange(new object[] {
            "",
            "Destination",
            "Source"});
            this.macDirCB.Location = new System.Drawing.Point(992, 132);
            this.macDirCB.Name = "macDirCB";
            this.macDirCB.Size = new System.Drawing.Size(121, 21);
            this.macDirCB.TabIndex = 33;
            this.macDirCB.SelectedIndexChanged += new System.EventHandler(this.macDirCB_SelectedIndexChanged);
            // 
            // ipDirCB
            // 
            this.ipDirCB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ipDirCB.FormattingEnabled = true;
            this.ipDirCB.Items.AddRange(new object[] {
            "",
            "Destination",
            "Source"});
            this.ipDirCB.Location = new System.Drawing.Point(1155, 132);
            this.ipDirCB.Name = "ipDirCB";
            this.ipDirCB.Size = new System.Drawing.Size(121, 21);
            this.ipDirCB.TabIndex = 34;
            // 
            // macAddrTxt
            // 
            this.macAddrTxt.Location = new System.Drawing.Point(992, 86);
            this.macAddrTxt.Name = "macAddrTxt";
            this.macAddrTxt.Size = new System.Drawing.Size(121, 20);
            this.macAddrTxt.TabIndex = 36;
            // 
            // ipAddrTxt
            // 
            this.ipAddrTxt.Location = new System.Drawing.Point(1155, 86);
            this.ipAddrTxt.Name = "ipAddrTxt";
            this.ipAddrTxt.Size = new System.Drawing.Size(121, 20);
            this.ipAddrTxt.TabIndex = 37;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(988, 34);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(104, 21);
            this.label14.TabIndex = 38;
            this.label14.Text = "Mac address";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Tai Le", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(1151, 34);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 21);
            this.label15.TabIndex = 39;
            this.label15.Text = "IP address";
            // 
            // idDelTxt
            // 
            this.idDelTxt.Location = new System.Drawing.Point(859, 389);
            this.idDelTxt.Name = "idDelTxt";
            this.idDelTxt.Size = new System.Drawing.Size(50, 20);
            this.idDelTxt.TabIndex = 40;
            this.idDelTxt.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // delFilterBtn
            // 
            this.delFilterBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delFilterBtn.Location = new System.Drawing.Point(915, 387);
            this.delFilterBtn.Name = "delFilterBtn";
            this.delFilterBtn.Size = new System.Drawing.Size(75, 23);
            this.delFilterBtn.TabIndex = 41;
            this.delFilterBtn.Text = "Delete filter";
            this.delFilterBtn.UseVisualStyleBackColor = true;
            this.delFilterBtn.Click += new System.EventHandler(this.delFilterBtn_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(782, 393);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(71, 16);
            this.label16.TabIndex = 42;
            this.label16.Text = "Choose ID";
            // 
            // filterBtn
            // 
            this.filterBtn.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.filterBtn.Location = new System.Drawing.Point(1080, 180);
            this.filterBtn.Name = "filterBtn";
            this.filterBtn.Size = new System.Drawing.Size(112, 23);
            this.filterBtn.TabIndex = 43;
            this.filterBtn.Text = "ADD this filter";
            this.filterBtn.UseVisualStyleBackColor = true;
            this.filterBtn.Click += new System.EventHandler(this.filterBtn_Click);
            // 
            // warningLbl
            // 
            this.warningLbl.AutoSize = true;
            this.warningLbl.BackColor = System.Drawing.Color.Transparent;
            this.warningLbl.Font = new System.Drawing.Font("Microsoft Tai Le", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.warningLbl.ForeColor = System.Drawing.Color.Red;
            this.warningLbl.Location = new System.Drawing.Point(1090, 208);
            this.warningLbl.Name = "warningLbl";
            this.warningLbl.Size = new System.Drawing.Size(92, 16);
            this.warningLbl.TabIndex = 44;
            this.warningLbl.Text = "Unfilled data!";
            this.warningLbl.Visible = false;
            this.warningLbl.Click += new System.EventHandler(this.warningLbl_Click);
            // 
            // delAllFilters
            // 
            this.delAllFilters.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.delAllFilters.Location = new System.Drawing.Point(1244, 387);
            this.delAllFilters.Name = "delAllFilters";
            this.delAllFilters.Size = new System.Drawing.Size(75, 23);
            this.delAllFilters.TabIndex = 45;
            this.delAllFilters.Text = "Delete all";
            this.delAllFilters.UseVisualStyleBackColor = true;
            this.delAllFilters.Click += new System.EventHandler(this.delAllFilters_Click);
            // 
            // mainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1338, 432);
            this.Controls.Add(this.delAllFilters);
            this.Controls.Add(this.warningLbl);
            this.Controls.Add(this.filterBtn);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.delFilterBtn);
            this.Controls.Add(this.idDelTxt);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.ipAddrTxt);
            this.Controls.Add(this.macAddrTxt);
            this.Controls.Add(this.ipDirCB);
            this.Controls.Add(this.macDirCB);
            this.Controls.Add(this.protFilterCB);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dirFilter);
            this.Controls.Add(this.portFilterCB);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.filterTable);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.listView2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "mainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "Switch";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader Port1IN;
        private System.Windows.Forms.ColumnHeader Port1OUT;
        private System.Windows.Forms.ColumnHeader Port2IN;
        private System.Windows.Forms.ColumnHeader Port2OUT;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ColumnHeader Protocol;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ColumnHeader MAC;
        private System.Windows.Forms.ColumnHeader Port;
        private System.Windows.Forms.ColumnHeader Timer;
        private System.Windows.Forms.ListView filterTable;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox portFilterCB;
        private System.Windows.Forms.ColumnHeader ID;
        private System.Windows.Forms.ColumnHeader portFilter;
        private System.Windows.Forms.ColumnHeader portDirection;
        private System.Windows.Forms.ColumnHeader protocolFilter;
        private System.Windows.Forms.ColumnHeader macAddDir;
        private System.Windows.Forms.ColumnHeader macAdd;
        private System.Windows.Forms.ColumnHeader ipAddDir;
        private System.Windows.Forms.ColumnHeader ipAdd;
        private System.Windows.Forms.ComboBox dirFilter;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox protFilterCB;
        private System.Windows.Forms.ComboBox macDirCB;
        private System.Windows.Forms.ComboBox ipDirCB;
        private System.Windows.Forms.TextBox macAddrTxt;
        private System.Windows.Forms.TextBox ipAddrTxt;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox idDelTxt;
        private System.Windows.Forms.Button delFilterBtn;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button filterBtn;
        private System.Windows.Forms.Label warningLbl;
        private System.Windows.Forms.Button delAllFilters;
    }
}


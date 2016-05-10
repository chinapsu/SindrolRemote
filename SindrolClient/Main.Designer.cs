namespace SindrolClient
{
    partial class Main
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.lkLabel = new System.Windows.Forms.LinkLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.controlGroup = new System.Windows.Forms.GroupBox();
            this.btnStartControl = new System.Windows.Forms.Button();
            this.numClientSn = new System.Windows.Forms.MaskedTextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).BeginInit();
            this.groupControl.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.controlGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.textPort);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textIP);
            this.groupBox1.Controls.Add(this.btnDisconn);
            this.groupBox1.Controls.Add(this.btnConn);
            this.groupBox1.Location = new System.Drawing.Point(12, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(525, 76);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "连接";
            // 
            // textPort
            // 
            this.textPort.Location = new System.Drawing.Point(278, 32);
            this.textPort.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.textPort.Name = "textPort";
            this.textPort.Size = new System.Drawing.Size(56, 21);
            this.textPort.TabIndex = 8;
            this.textPort.Value = new decimal(new int[] {
            1991,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(231, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "端口：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "服务器IP地址：";
            // 
            // textIP
            // 
            this.textIP.Location = new System.Drawing.Point(109, 32);
            this.textIP.Name = "textIP";
            this.textIP.Size = new System.Drawing.Size(107, 21);
            this.textIP.TabIndex = 2;
            this.textIP.Text = "123.56.121.148";
            // 
            // btnDisconn
            // 
            this.btnDisconn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconn.Enabled = false;
            this.btnDisconn.Location = new System.Drawing.Point(452, 24);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(65, 32);
            this.btnDisconn.TabIndex = 1;
            this.btnDisconn.Text = "断开";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
            // 
            // btnConn
            // 
            this.btnConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConn.Location = new System.Drawing.Point(381, 24);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(65, 32);
            this.btnConn.TabIndex = 1;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // groupControl
            // 
            this.groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl.Controls.Add(this.lkLabel);
            this.groupControl.Enabled = false;
            this.groupControl.Location = new System.Drawing.Point(12, 91);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(525, 74);
            this.groupControl.TabIndex = 4;
            this.groupControl.TabStop = false;
            this.groupControl.Text = "本机编号-点击复制";
            // 
            // lkLabel
            // 
            this.lkLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lkLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(128)))));
            this.lkLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lkLabel.DisabledLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lkLabel.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lkLabel.Location = new System.Drawing.Point(38, 24);
            this.lkLabel.Name = "lkLabel";
            this.lkLabel.Size = new System.Drawing.Size(449, 35);
            this.lkLabel.TabIndex = 7;
            this.lkLabel.TabStop = true;
            this.lkLabel.Text = "0000000000000000";
            this.lkLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lkLabel_LinkClicked);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 177);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(548, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 17);
            this.toolStripStatusLabel1.Text = "消息：";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(20, 17);
            this.lbStatus.Text = "无";
            // 
            // controlGroup
            // 
            this.controlGroup.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.controlGroup.BackColor = System.Drawing.SystemColors.Control;
            this.controlGroup.Controls.Add(this.btnStartControl);
            this.controlGroup.Controls.Add(this.numClientSn);
            this.controlGroup.Enabled = false;
            this.controlGroup.Location = new System.Drawing.Point(12, 171);
            this.controlGroup.Name = "controlGroup";
            this.controlGroup.Size = new System.Drawing.Size(524, 0);
            this.controlGroup.TabIndex = 7;
            this.controlGroup.TabStop = false;
            this.controlGroup.Text = "输入对方机器编号以进行连接";
            // 
            // btnStartControl
            // 
            this.btnStartControl.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnStartControl.Location = new System.Drawing.Point(206, 76);
            this.btnStartControl.Name = "btnStartControl";
            this.btnStartControl.Size = new System.Drawing.Size(112, 35);
            this.btnStartControl.TabIndex = 14;
            this.btnStartControl.Text = "开始连接";
            this.btnStartControl.UseVisualStyleBackColor = true;
            this.btnStartControl.Click += new System.EventHandler(this.btnStartControl_Click);
            // 
            // numClientSn
            // 
            this.numClientSn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.numClientSn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numClientSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numClientSn.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numClientSn.ForeColor = System.Drawing.Color.Magenta;
            this.numClientSn.Location = new System.Drawing.Point(38, 31);
            this.numClientSn.Mask = "0000000000000000";
            this.numClientSn.Name = "numClientSn";
            this.numClientSn.PromptChar = '-';
            this.numClientSn.Size = new System.Drawing.Size(449, 35);
            this.numClientSn.TabIndex = 13;
            this.numClientSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 199);
            this.Controls.Add(this.controlGroup);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "远程控制软件【中爱城市团队专用】";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.controlGroup.ResumeLayout(false);
            this.controlGroup.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown textPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.LinkLabel lkLabel;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.GroupBox controlGroup;
        private System.Windows.Forms.MaskedTextBox numClientSn;
        private System.Windows.Forms.Button btnStartControl;
    }
}


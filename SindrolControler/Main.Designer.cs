namespace SindrolControler
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
            this.btnStartControl = new System.Windows.Forms.Button();
            this.btnConn = new System.Windows.Forms.Button();
            this.btnDisconn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textPort = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.groupControl = new System.Windows.Forms.GroupBox();
            this.numClientSn = new System.Windows.Forms.MaskedTextBox();
            this.btnStopControl = new System.Windows.Forms.Button();
            this.picture = new System.Windows.Forms.PictureBox();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnFullScreen = new System.Windows.Forms.ToolStripSplitButton();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).BeginInit();
            this.groupControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).BeginInit();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStartControl
            // 
            this.btnStartControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartControl.Location = new System.Drawing.Point(314, 27);
            this.btnStartControl.Name = "btnStartControl";
            this.btnStartControl.Size = new System.Drawing.Size(65, 32);
            this.btnStartControl.TabIndex = 0;
            this.btnStartControl.Text = "开始控制";
            this.btnStartControl.UseVisualStyleBackColor = true;
            this.btnStartControl.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnConn
            // 
            this.btnConn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnConn.Location = new System.Drawing.Point(478, 24);
            this.btnConn.Name = "btnConn";
            this.btnConn.Size = new System.Drawing.Size(65, 32);
            this.btnConn.TabIndex = 1;
            this.btnConn.Text = "连接";
            this.btnConn.UseVisualStyleBackColor = true;
            this.btnConn.Click += new System.EventHandler(this.btnConn_Click);
            // 
            // btnDisconn
            // 
            this.btnDisconn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDisconn.Enabled = false;
            this.btnDisconn.Location = new System.Drawing.Point(549, 24);
            this.btnDisconn.Name = "btnDisconn";
            this.btnDisconn.Size = new System.Drawing.Size(65, 32);
            this.btnDisconn.TabIndex = 1;
            this.btnDisconn.Text = "断开";
            this.btnDisconn.UseVisualStyleBackColor = true;
            this.btnDisconn.Click += new System.EventHandler(this.btnDisconn_Click);
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
            this.groupBox1.Location = new System.Drawing.Point(13, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(622, 76);
            this.groupBox1.TabIndex = 2;
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
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 35);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "请输入被控端编号：";
            // 
            // groupControl
            // 
            this.groupControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupControl.Controls.Add(this.numClientSn);
            this.groupControl.Controls.Add(this.btnStopControl);
            this.groupControl.Controls.Add(this.btnStartControl);
            this.groupControl.Controls.Add(this.label3);
            this.groupControl.Enabled = false;
            this.groupControl.Location = new System.Drawing.Point(641, 12);
            this.groupControl.Name = "groupControl";
            this.groupControl.Size = new System.Drawing.Size(473, 74);
            this.groupControl.TabIndex = 3;
            this.groupControl.TabStop = false;
            this.groupControl.Text = "控制";
            // 
            // numClientSn
            // 
            this.numClientSn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numClientSn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.numClientSn.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numClientSn.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.numClientSn.Location = new System.Drawing.Point(140, 31);
            this.numClientSn.Mask = "0000000000000000";
            this.numClientSn.Name = "numClientSn";
            this.numClientSn.PromptChar = '-';
            this.numClientSn.Size = new System.Drawing.Size(168, 23);
            this.numClientSn.TabIndex = 11;
            this.numClientSn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnStopControl
            // 
            this.btnStopControl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStopControl.Enabled = false;
            this.btnStopControl.Location = new System.Drawing.Point(385, 27);
            this.btnStopControl.Name = "btnStopControl";
            this.btnStopControl.Size = new System.Drawing.Size(65, 32);
            this.btnStopControl.TabIndex = 0;
            this.btnStopControl.Text = "停止控制";
            this.btnStopControl.UseVisualStyleBackColor = true;
            this.btnStopControl.Click += new System.EventHandler(this.btnStopControl_Click);
            // 
            // picture
            // 
            this.picture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picture.BackColor = System.Drawing.Color.Black;
            this.picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picture.Location = new System.Drawing.Point(12, 90);
            this.picture.Name = "picture";
            this.picture.Size = new System.Drawing.Size(1101, 501);
            this.picture.TabIndex = 4;
            this.picture.TabStop = false;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.lbStatus,
            this.toolStripStatusLabel2,
            this.btnFullScreen});
            this.statusStrip.Location = new System.Drawing.Point(0, 593);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1126, 23);
            this.statusStrip.TabIndex = 5;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(44, 18);
            this.toolStripStatusLabel1.Text = "状态：";
            // 
            // lbStatus
            // 
            this.lbStatus.Name = "lbStatus";
            this.lbStatus.Size = new System.Drawing.Size(20, 18);
            this.lbStatus.Text = "无";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(868, 18);
            this.toolStripStatusLabel2.Spring = true;
            // 
            // btnFullScreen
            // 
            this.btnFullScreen.Image = ((System.Drawing.Image)(resources.GetObject("btnFullScreen.Image")));
            this.btnFullScreen.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFullScreen.Name = "btnFullScreen";
            this.btnFullScreen.Size = new System.Drawing.Size(148, 21);
            this.btnFullScreen.Text = "请按下鼠标滑轮全屏";
            this.btnFullScreen.ToolTipText = "点击全屏/取消全屏";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1126, 616);
            this.Controls.Add(this.picture);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.groupControl);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "控制端";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.textPort)).EndInit();
            this.groupControl.ResumeLayout(false);
            this.groupControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picture)).EndInit();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartControl;
        private System.Windows.Forms.Button btnConn;
        private System.Windows.Forms.Button btnDisconn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textIP;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown textPort;
        private System.Windows.Forms.GroupBox groupControl;
        private System.Windows.Forms.PictureBox picture;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel lbStatus;
        private System.Windows.Forms.Button btnStopControl;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
        private System.Windows.Forms.ToolStripSplitButton btnFullScreen;
        private System.Windows.Forms.MaskedTextBox numClientSn;
    }
}


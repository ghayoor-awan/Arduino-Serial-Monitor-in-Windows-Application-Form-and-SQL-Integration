namespace Ports
{
    partial class Ports
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
            this.components = new System.ComponentModel.Container();
            this.connectBT = new System.Windows.Forms.Button();
            this.disconnectBT = new System.Windows.Forms.Button();
            this.clearBT = new System.Windows.Forms.Button();
            this.scanBT = new System.Windows.Forms.Button();
            this.sendBT = new System.Windows.Forms.Button();
            this.comportCB = new System.Windows.Forms.ComboBox();
            this.baudrateCB = new System.Windows.Forms.ComboBox();
            this.incomingTB = new System.Windows.Forms.RichTextBox();
            this.outgoingTB = new System.Windows.Forms.RichTextBox();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
            // 
            // connectBT
            // 
            this.connectBT.Location = new System.Drawing.Point(22, 198);
            this.connectBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.connectBT.Name = "connectBT";
            this.connectBT.Size = new System.Drawing.Size(86, 53);
            this.connectBT.TabIndex = 0;
            this.connectBT.Text = "CONNECT";
            this.connectBT.UseVisualStyleBackColor = true;
            this.connectBT.Click += new System.EventHandler(this.connectBT_Click);
            // 
            // disconnectBT
            // 
            this.disconnectBT.Enabled = false;
            this.disconnectBT.Location = new System.Drawing.Point(22, 256);
            this.disconnectBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.disconnectBT.Name = "disconnectBT";
            this.disconnectBT.Size = new System.Drawing.Size(86, 53);
            this.disconnectBT.TabIndex = 1;
            this.disconnectBT.Text = "DISCONNECT";
            this.disconnectBT.UseVisualStyleBackColor = true;
            this.disconnectBT.Click += new System.EventHandler(this.disconnectBT_Click);
            // 
            // clearBT
            // 
            this.clearBT.Location = new System.Drawing.Point(258, 198);
            this.clearBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.clearBT.Name = "clearBT";
            this.clearBT.Size = new System.Drawing.Size(86, 53);
            this.clearBT.TabIndex = 2;
            this.clearBT.Text = "CLEAR";
            this.clearBT.UseVisualStyleBackColor = true;
            this.clearBT.Click += new System.EventHandler(this.clearBT_Click);
            // 
            // scanBT
            // 
            this.scanBT.Location = new System.Drawing.Point(140, 228);
            this.scanBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.scanBT.Name = "scanBT";
            this.scanBT.Size = new System.Drawing.Size(86, 53);
            this.scanBT.TabIndex = 3;
            this.scanBT.Text = "SCAN";
            this.scanBT.UseVisualStyleBackColor = true;
            this.scanBT.Click += new System.EventHandler(this.scanBT_Click);
            // 
            // sendBT
            // 
            this.sendBT.Enabled = false;
            this.sendBT.Location = new System.Drawing.Point(258, 256);
            this.sendBT.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.sendBT.Name = "sendBT";
            this.sendBT.Size = new System.Drawing.Size(86, 53);
            this.sendBT.TabIndex = 4;
            this.sendBT.Text = "SEND";
            this.sendBT.UseVisualStyleBackColor = true;
            this.sendBT.Click += new System.EventHandler(this.sendBT_Click);
            // 
            // comportCB
            // 
            this.comportCB.FormattingEnabled = true;
            this.comportCB.Location = new System.Drawing.Point(22, 156);
            this.comportCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.comportCB.Name = "comportCB";
            this.comportCB.Size = new System.Drawing.Size(146, 21);
            this.comportCB.TabIndex = 5;
            // 
            // baudrateCB
            // 
            this.baudrateCB.FormattingEnabled = true;
            this.baudrateCB.Items.AddRange(new object[] {
            "9600",
            "115200"});
            this.baudrateCB.Location = new System.Drawing.Point(198, 156);
            this.baudrateCB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.baudrateCB.Name = "baudrateCB";
            this.baudrateCB.Size = new System.Drawing.Size(146, 21);
            this.baudrateCB.TabIndex = 6;
            // 
            // incomingTB
            // 
            this.incomingTB.Location = new System.Drawing.Point(22, 19);
            this.incomingTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.incomingTB.Name = "incomingTB";
            this.incomingTB.Size = new System.Drawing.Size(150, 126);
            this.incomingTB.TabIndex = 7;
            this.incomingTB.Text = "";
            // 
            // outgoingTB
            // 
            this.outgoingTB.Location = new System.Drawing.Point(198, 19);
            this.outgoingTB.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.outgoingTB.Name = "outgoingTB";
            this.outgoingTB.Size = new System.Drawing.Size(150, 126);
            this.outgoingTB.TabIndex = 8;
            this.outgoingTB.Text = "";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // Ports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 327);
            this.Controls.Add(this.outgoingTB);
            this.Controls.Add(this.incomingTB);
            this.Controls.Add(this.baudrateCB);
            this.Controls.Add(this.comportCB);
            this.Controls.Add(this.sendBT);
            this.Controls.Add(this.scanBT);
            this.Controls.Add(this.clearBT);
            this.Controls.Add(this.disconnectBT);
            this.Controls.Add(this.connectBT);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Ports";
            this.Text = "Ports";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button connectBT;
        private System.Windows.Forms.Button disconnectBT;
        private System.Windows.Forms.Button clearBT;
        private System.Windows.Forms.Button scanBT;
        private System.Windows.Forms.Button sendBT;
        private System.Windows.Forms.ComboBox comportCB;
        private System.Windows.Forms.ComboBox baudrateCB;
        private System.Windows.Forms.RichTextBox incomingTB;
        private System.Windows.Forms.RichTextBox outgoingTB;
        private System.IO.Ports.SerialPort serialPort1;
    }
}


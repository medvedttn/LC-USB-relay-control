namespace LC_USB_relay_control
{
    partial class frmMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.label1 = new System.Windows.Forms.Label();
            this.cmbCOMPort = new System.Windows.Forms.ComboBox();
            this.lblPortStatus = new System.Windows.Forms.Label();
            this.btnOpenRelay = new System.Windows.Forms.Button();
            this.btnCloseRelay = new System.Windows.Forms.Button();
            this.btnDisconnectPort = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select COM-port:";
            // 
            // cmbCOMPort
            // 
            this.cmbCOMPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCOMPort.FormattingEnabled = true;
            this.cmbCOMPort.Location = new System.Drawing.Point(107, 10);
            this.cmbCOMPort.Name = "cmbCOMPort";
            this.cmbCOMPort.Size = new System.Drawing.Size(121, 21);
            this.cmbCOMPort.TabIndex = 1;
            this.cmbCOMPort.SelectedIndexChanged += new System.EventHandler(this.cmbCOMPort_SelectedIndexChanged);
            // 
            // lblPortStatus
            // 
            this.lblPortStatus.Location = new System.Drawing.Point(16, 44);
            this.lblPortStatus.Name = "lblPortStatus";
            this.lblPortStatus.Size = new System.Drawing.Size(212, 23);
            this.lblPortStatus.TabIndex = 2;
            this.lblPortStatus.Text = "Select Port...";
            // 
            // btnOpenRelay
            // 
            this.btnOpenRelay.Location = new System.Drawing.Point(19, 71);
            this.btnOpenRelay.Name = "btnOpenRelay";
            this.btnOpenRelay.Size = new System.Drawing.Size(90, 23);
            this.btnOpenRelay.TabIndex = 3;
            this.btnOpenRelay.Text = "ON";
            this.btnOpenRelay.UseVisualStyleBackColor = true;
            this.btnOpenRelay.Click += new System.EventHandler(this.btnOpenRelay_Click);
            // 
            // btnCloseRelay
            // 
            this.btnCloseRelay.Location = new System.Drawing.Point(116, 71);
            this.btnCloseRelay.Name = "btnCloseRelay";
            this.btnCloseRelay.Size = new System.Drawing.Size(75, 23);
            this.btnCloseRelay.TabIndex = 4;
            this.btnCloseRelay.Text = "OFF";
            this.btnCloseRelay.UseVisualStyleBackColor = true;
            this.btnCloseRelay.Click += new System.EventHandler(this.btnCloseRelay_Click);
            // 
            // btnDisconnectPort
            // 
            this.btnDisconnectPort.Location = new System.Drawing.Point(19, 114);
            this.btnDisconnectPort.Name = "btnDisconnectPort";
            this.btnDisconnectPort.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnectPort.TabIndex = 5;
            this.btnDisconnectPort.Text = "Close Port";
            this.btnDisconnectPort.UseVisualStyleBackColor = true;
            this.btnDisconnectPort.Click += new System.EventHandler(this.btnDisconnectPort_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 149);
            this.Controls.Add(this.btnDisconnectPort);
            this.Controls.Add(this.btnCloseRelay);
            this.Controls.Add(this.btnOpenRelay);
            this.Controls.Add(this.lblPortStatus);
            this.Controls.Add(this.cmbCOMPort);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LC USB-relay control v1.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbCOMPort;
        private System.Windows.Forms.Label lblPortStatus;
        private System.Windows.Forms.Button btnOpenRelay;
        private System.Windows.Forms.Button btnCloseRelay;
        private System.Windows.Forms.Button btnDisconnectPort;
    }
}


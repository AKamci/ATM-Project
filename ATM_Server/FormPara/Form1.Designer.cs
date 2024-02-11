namespace FormPara
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txttoplam = new System.Windows.Forms.TextBox();
            this.txtbes = new System.Windows.Forms.TextBox();
            this.txton = new System.Windows.Forms.TextBox();
            this.txtyirmi = new System.Windows.Forms.TextBox();
            this.txtelli = new System.Windows.Forms.TextBox();
            this.txtyuz = new System.Windows.Forms.TextBox();
            this.ikiyuz = new System.Windows.Forms.TextBox();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.prtDoc = new System.Drawing.Printing.PrintDocument();
            this.btnyenile = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // txttoplam
            // 
            this.txttoplam.Location = new System.Drawing.Point(163, 621);
            this.txttoplam.Name = "txttoplam";
            this.txttoplam.Size = new System.Drawing.Size(955, 39);
            this.txttoplam.TabIndex = 1;
            // 
            // txtbes
            // 
            this.txtbes.Location = new System.Drawing.Point(918, 380);
            this.txtbes.Name = "txtbes";
            this.txtbes.Size = new System.Drawing.Size(200, 39);
            this.txtbes.TabIndex = 2;
            // 
            // txton
            // 
            this.txton.Location = new System.Drawing.Point(918, 152);
            this.txton.Name = "txton";
            this.txton.Size = new System.Drawing.Size(200, 39);
            this.txton.TabIndex = 3;
            // 
            // txtyirmi
            // 
            this.txtyirmi.Location = new System.Drawing.Point(538, 380);
            this.txtyirmi.Name = "txtyirmi";
            this.txtyirmi.Size = new System.Drawing.Size(200, 39);
            this.txtyirmi.TabIndex = 4;
            // 
            // txtelli
            // 
            this.txtelli.Location = new System.Drawing.Point(538, 152);
            this.txtelli.Name = "txtelli";
            this.txtelli.Size = new System.Drawing.Size(200, 39);
            this.txtelli.TabIndex = 5;
            // 
            // txtyuz
            // 
            this.txtyuz.Location = new System.Drawing.Point(163, 380);
            this.txtyuz.Name = "txtyuz";
            this.txtyuz.Size = new System.Drawing.Size(200, 39);
            this.txtyuz.TabIndex = 6;
            // 
            // ikiyuz
            // 
            this.ikiyuz.Location = new System.Drawing.Point(163, 152);
            this.ikiyuz.Name = "ikiyuz";
            this.ikiyuz.Size = new System.Drawing.Size(200, 39);
            this.ikiyuz.TabIndex = 7;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // btnyenile
            // 
            this.btnyenile.Location = new System.Drawing.Point(394, 831);
            this.btnyenile.Name = "btnyenile";
            this.btnyenile.Size = new System.Drawing.Size(424, 93);
            this.btnyenile.TabIndex = 8;
            this.btnyenile.Text = "Yenile";
            this.btnyenile.UseVisualStyleBackColor = true;
            this.btnyenile.Click += new System.EventHandler(this.btnyenile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1701, 1183);
            this.Controls.Add(this.btnyenile);
            this.Controls.Add(this.ikiyuz);
            this.Controls.Add(this.txtyuz);
            this.Controls.Add(this.txtelli);
            this.Controls.Add(this.txtyirmi);
            this.Controls.Add(this.txton);
            this.Controls.Add(this.txtbes);
            this.Controls.Add(this.txttoplam);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.WindowsDefaultBounds;
            this.Text = "BANKAMATIK";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private TextBox txttoplam;
        private TextBox txtbes;
        private TextBox txton;
        private TextBox txtyirmi;
        private TextBox txtyuz;
     
        internal TextBox txtelli;
        internal TextBox ikiyuz;
        private FileSystemWatcher fileSystemWatcher1;
        private Button btnyenile;
        private System.Drawing.Printing.PrintDocument prtDoc;
    }
}
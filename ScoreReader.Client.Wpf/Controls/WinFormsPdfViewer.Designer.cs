namespace ScoreReader.Client.Wpf.Controls
{
    partial class WinFormsPdfViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WinFormsPdfViewer));
            this.axAcrobat = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)(this.axAcrobat)).BeginInit();
            this.SuspendLayout();
            // 
            // axAcrobat
            // 
            this.axAcrobat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axAcrobat.Enabled = true;
            this.axAcrobat.Location = new System.Drawing.Point(0, 0);
            this.axAcrobat.Name = "axAcrobat";
            this.axAcrobat.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axAcrobat.OcxState")));
            this.axAcrobat.Size = new System.Drawing.Size(150, 150);
            this.axAcrobat.TabIndex = 0;
            // 
            // WinFormPdfHost
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.axAcrobat);
            this.Name = "WinFormsPdfViewer";
            ((System.ComponentModel.ISupportInitialize)(this.axAcrobat)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public AxAcroPDFLib.AxAcroPDF axAcrobat;

    }
}

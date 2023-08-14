namespace YKCJ_Diaper
{
    partial class frmExpandView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmExpandView));
            this.CdpDisplayer = new Cognex.VisionPro.Display.CogDisplay();
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // CdpDisplayer
            // 
            this.CdpDisplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpDisplayer.Location = new System.Drawing.Point(0, 0);
            this.CdpDisplayer.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpDisplayer.MouseWheelSensitivity = 1D;
            this.CdpDisplayer.Name = "CdpDisplayer";
            this.CdpDisplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpDisplayer.OcxState")));
            this.CdpDisplayer.Size = new System.Drawing.Size(775, 552);
            this.CdpDisplayer.TabIndex = 43;
            // 
            // frmExpandView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 552);
            this.Controls.Add(this.CdpDisplayer);
            this.Name = "frmExpandView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "확장 화면";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Cognex.VisionPro.Display.CogDisplay CdpDisplayer;
    }
}
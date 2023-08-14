namespace YKCJ_Diaper
{
    partial class UcMain
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcMain));
            this.PnlLeft = new Jhjo.Component.CPanel();
            this.LblRight = new Jhjo.Component.CLabel();
            this.LblLeft = new Jhjo.Component.CLabel();
            this.CdpDisplayer = new Cognex.VisionPro.Display.CogDisplay();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.PnlSubScreen = new Jhjo.Component.CPanel();
            this.PnlLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlLeft
            // 
            this.PnlLeft.BDrawBorderBottom = false;
            this.PnlLeft.BDrawBorderLeft = false;
            this.PnlLeft.BDrawBorderRight = false;
            this.PnlLeft.BDrawBorderTop = false;
            this.PnlLeft.Controls.Add(this.LblRight);
            this.PnlLeft.Controls.Add(this.LblLeft);
            this.PnlLeft.Controls.Add(this.CdpDisplayer);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(540, 672);
            this.PnlLeft.TabIndex = 0;
            // 
            // LblRight
            // 
            this.LblRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblRight.BackColor = System.Drawing.Color.White;
            this.LblRight.BDrawBorderBottom = true;
            this.LblRight.BDrawBorderLeft = true;
            this.LblRight.BDrawBorderRight = false;
            this.LblRight.BDrawBorderTop = false;
            this.LblRight.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblRight.ForeColor = System.Drawing.Color.Black;
            this.LblRight.Location = new System.Drawing.Point(470, 0);
            this.LblRight.Name = "LblRight";
            this.LblRight.OBorderColor = System.Drawing.Color.Black;
            this.LblRight.Size = new System.Drawing.Size(70, 28);
            this.LblRight.TabIndex = 7;
            this.LblRight.Text = "O/S";
            this.LblRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblLeft
            // 
            this.LblLeft.BackColor = System.Drawing.Color.White;
            this.LblLeft.BDrawBorderBottom = true;
            this.LblLeft.BDrawBorderLeft = false;
            this.LblLeft.BDrawBorderRight = true;
            this.LblLeft.BDrawBorderTop = false;
            this.LblLeft.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblLeft.ForeColor = System.Drawing.Color.Black;
            this.LblLeft.Location = new System.Drawing.Point(0, 0);
            this.LblLeft.Name = "LblLeft";
            this.LblLeft.OBorderColor = System.Drawing.Color.Black;
            this.LblLeft.Size = new System.Drawing.Size(70, 28);
            this.LblLeft.TabIndex = 7;
            this.LblLeft.Text = "D/S";
            this.LblLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CdpDisplayer
            // 
            this.CdpDisplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpDisplayer.Location = new System.Drawing.Point(0, 0);
            this.CdpDisplayer.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpDisplayer.MouseWheelSensitivity = 1D;
            this.CdpDisplayer.Name = "CdpDisplayer";
            this.CdpDisplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpDisplayer.OcxState")));
            this.CdpDisplayer.Size = new System.Drawing.Size(540, 672);
            this.CdpDisplayer.TabIndex = 0;
            // 
            // Splitter
            // 
            this.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Splitter.Location = new System.Drawing.Point(540, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(4, 672);
            this.Splitter.TabIndex = 1;
            this.Splitter.TabStop = false;
            this.Splitter.LocationChanged += new System.EventHandler(this.Splitter_LocationChanged);
            this.Splitter.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Splitter_MouseDoubleClick);
            // 
            // PnlSubScreen
            // 
            this.PnlSubScreen.BDrawBorderBottom = false;
            this.PnlSubScreen.BDrawBorderLeft = true;
            this.PnlSubScreen.BDrawBorderRight = false;
            this.PnlSubScreen.BDrawBorderTop = false;
            this.PnlSubScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlSubScreen.Location = new System.Drawing.Point(544, 0);
            this.PnlSubScreen.Name = "PnlSubScreen";
            this.PnlSubScreen.Size = new System.Drawing.Size(480, 672);
            this.PnlSubScreen.TabIndex = 0;
            // 
            // UcMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlSubScreen);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.PnlLeft);
            this.Name = "UcMain";
            this.PnlLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlLeft;
        private System.Windows.Forms.Splitter Splitter;
        private Jhjo.Component.CPanel PnlSubScreen;
        private Cognex.VisionPro.Display.CogDisplay CdpDisplayer;
        private Jhjo.Component.CLabel LblRight;
        private Jhjo.Component.CLabel LblLeft;
    }
}

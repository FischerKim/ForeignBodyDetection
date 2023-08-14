namespace YKCJ_Diaper
{
    partial class frmLoad
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
            this.BtnSelect = new System.Windows.Forms.Button();
            this.PnlMiddle = new Jhjo.Component.CPanel();
            this.LblIP = new Jhjo.Component.CLabel();
            this.LblTitleIP = new Jhjo.Component.CLabel();
            this.LblTitleCamInfo = new Jhjo.Component.CLabel();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.BtnEnter = new System.Windows.Forms.Button();
            this.BtnExit = new System.Windows.Forms.Button();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlTop = new Jhjo.Component.CPanel();
            this.PnlMiddle.SuspendLayout();
            this.PnlButton.SuspendLayout();
            this.PnlTop.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnSelect
            // 
            this.BtnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelect.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelect.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSelect.ForeColor = System.Drawing.Color.White;
            this.BtnSelect.Location = new System.Drawing.Point(147, 58);
            this.BtnSelect.Name = "BtnSelect";
            this.BtnSelect.Size = new System.Drawing.Size(100, 35);
            this.BtnSelect.TabIndex = 4;
            this.BtnSelect.Text = "카메라 설정";
            this.BtnSelect.UseVisualStyleBackColor = false;
            this.BtnSelect.Click += new System.EventHandler(this.BtnSelect_Click);
            // 
            // PnlMiddle
            // 
            this.PnlMiddle.BDrawBorderBottom = false;
            this.PnlMiddle.BDrawBorderLeft = false;
            this.PnlMiddle.BDrawBorderRight = false;
            this.PnlMiddle.BDrawBorderTop = false;
            this.PnlMiddle.Controls.Add(this.BtnSelect);
            this.PnlMiddle.Controls.Add(this.LblIP);
            this.PnlMiddle.Controls.Add(this.LblTitleIP);
            this.PnlMiddle.Controls.Add(this.LblTitleCamInfo);
            this.PnlMiddle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMiddle.Location = new System.Drawing.Point(0, 28);
            this.PnlMiddle.Name = "PnlMiddle";
            this.PnlMiddle.Size = new System.Drawing.Size(250, 96);
            this.PnlMiddle.TabIndex = 12;
            // 
            // LblIP
            // 
            this.LblIP.BackColor = System.Drawing.Color.White;
            this.LblIP.BDrawBorderBottom = true;
            this.LblIP.BDrawBorderLeft = false;
            this.LblIP.BDrawBorderRight = false;
            this.LblIP.BDrawBorderTop = false;
            this.LblIP.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblIP.ForeColor = System.Drawing.Color.Black;
            this.LblIP.Location = new System.Drawing.Point(100, 28);
            this.LblIP.Name = "LblIP";
            this.LblIP.OBorderColor = System.Drawing.Color.Black;
            this.LblIP.Size = new System.Drawing.Size(150, 28);
            this.LblIP.TabIndex = 7;
            this.LblIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleIP
            // 
            this.LblTitleIP.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleIP.BDrawBorderBottom = true;
            this.LblTitleIP.BDrawBorderLeft = false;
            this.LblTitleIP.BDrawBorderRight = true;
            this.LblTitleIP.BDrawBorderTop = false;
            this.LblTitleIP.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleIP.ForeColor = System.Drawing.Color.White;
            this.LblTitleIP.Location = new System.Drawing.Point(0, 28);
            this.LblTitleIP.Name = "LblTitleIP";
            this.LblTitleIP.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleIP.Size = new System.Drawing.Size(100, 28);
            this.LblTitleIP.TabIndex = 6;
            this.LblTitleIP.Text = "IP";
            this.LblTitleIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleCamInfo
            // 
            this.LblTitleCamInfo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCamInfo.BDrawBorderBottom = true;
            this.LblTitleCamInfo.BDrawBorderLeft = false;
            this.LblTitleCamInfo.BDrawBorderRight = false;
            this.LblTitleCamInfo.BDrawBorderTop = false;
            this.LblTitleCamInfo.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCamInfo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamInfo.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamInfo.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamInfo.Name = "LblTitleCamInfo";
            this.LblTitleCamInfo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCamInfo.Size = new System.Drawing.Size(250, 28);
            this.LblTitleCamInfo.TabIndex = 4;
            this.LblTitleCamInfo.Text = "카메라";
            this.LblTitleCamInfo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnEnter);
            this.PnlButton.Controls.Add(this.BtnExit);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 124);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(250, 40);
            this.PnlButton.TabIndex = 13;
            // 
            // BtnEnter
            // 
            this.BtnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnEnter.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnEnter.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnEnter.ForeColor = System.Drawing.Color.White;
            this.BtnEnter.Location = new System.Drawing.Point(41, 3);
            this.BtnEnter.Name = "BtnEnter";
            this.BtnEnter.Size = new System.Drawing.Size(100, 35);
            this.BtnEnter.TabIndex = 4;
            this.BtnEnter.Text = "확인";
            this.BtnEnter.UseVisualStyleBackColor = false;
            this.BtnEnter.Click += new System.EventHandler(this.BtnEnter_Click);
            // 
            // BtnExit
            // 
            this.BtnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnExit.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.White;
            this.BtnExit.Location = new System.Drawing.Point(147, 3);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(100, 35);
            this.BtnExit.TabIndex = 4;
            this.BtnExit.Text = "종료";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitle.BDrawBorderBottom = true;
            this.LblTitle.BDrawBorderLeft = false;
            this.LblTitle.BDrawBorderRight = false;
            this.LblTitle.BDrawBorderTop = false;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OBorderColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(250, 28);
            this.LblTitle.TabIndex = 0;
            this.LblTitle.Text = "유한킴벌리 Vision";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlTop
            // 
            this.PnlTop.BDrawBorderBottom = false;
            this.PnlTop.BDrawBorderLeft = false;
            this.PnlTop.BDrawBorderRight = false;
            this.PnlTop.BDrawBorderTop = false;
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(250, 28);
            this.PnlTop.TabIndex = 11;
            // 
            // frmLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(250, 164);
            this.Controls.Add(this.PnlMiddle);
            this.Controls.Add(this.PnlButton);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoad";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "로드 화면";
            this.Load += new System.EventHandler(this.frmLoad_Load);
            this.PnlMiddle.ResumeLayout(false);
            this.PnlButton.ResumeLayout(false);
            this.PnlTop.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnSelect;
        private Jhjo.Component.CPanel PnlMiddle;
        private Jhjo.Component.CLabel LblIP;
        private Jhjo.Component.CLabel LblTitleIP;
        private Jhjo.Component.CLabel LblTitleCamInfo;
        private Jhjo.Component.CPanel PnlButton;
        private System.Windows.Forms.Button BtnEnter;
        private System.Windows.Forms.Button BtnExit;
        private Jhjo.Component.CLabel LblTitle;
        private Jhjo.Component.CPanel PnlTop;
    }
}
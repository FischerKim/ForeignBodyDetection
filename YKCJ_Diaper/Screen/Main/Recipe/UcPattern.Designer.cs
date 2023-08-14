namespace YKCJ_Diaper
{
    partial class UcPattern
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcPattern));
            this.CdpTrain = new Cognex.VisionPro.Display.CogDisplay();
            this.NudMinScore = new System.Windows.Forms.NumericUpDown();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.ChkEnabled = new System.Windows.Forms.CheckBox();
            this.BtnShow = new System.Windows.Forms.Button();
            this.BtnTrain = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.CmbMD = new System.Windows.Forms.ComboBox();
            this.CmbCD = new System.Windows.Forms.ComboBox();
            this.CmbCopyNo = new System.Windows.Forms.ComboBox();
            this.CmbNo = new System.Windows.Forms.ComboBox();
            this.LblTitleMD = new Jhjo.Component.CLabel();
            this.LblTitleMinScore = new Jhjo.Component.CLabel();
            this.LblTitleTrain = new Jhjo.Component.CLabel();
            this.LblTitleDescription = new Jhjo.Component.CLabel();
            this.LblTitleEnabled = new Jhjo.Component.CLabel();
            this.LblTitleNo = new Jhjo.Component.CLabel();
            this.LblTitleCopyNo = new Jhjo.Component.CLabel();
            this.LblTitleCD = new Jhjo.Component.CLabel();
            this.PnlScreen = new Jhjo.Component.CPanel();
            this.NudNo = new System.Windows.Forms.NumericUpDown();
            this.CmbIOSignal = new System.Windows.Forms.ComboBox();
            this.LblTitlePattern = new Jhjo.Component.CLabel();
            this.LblTitleIOSignal = new Jhjo.Component.CLabel();
            ((System.ComponentModel.ISupportInitialize)(this.CdpTrain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMinScore)).BeginInit();
            this.PnlScreen.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNo)).BeginInit();
            this.SuspendLayout();
            // 
            // CdpTrain
            // 
            this.CdpTrain.Location = new System.Drawing.Point(0, 170);
            this.CdpTrain.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpTrain.MouseWheelSensitivity = 1D;
            this.CdpTrain.Name = "CdpTrain";
            this.CdpTrain.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpTrain.OcxState")));
            this.CdpTrain.Size = new System.Drawing.Size(230, 128);
            this.CdpTrain.TabIndex = 42;
            // 
            // NudMinScore
            // 
            this.NudMinScore.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudMinScore.Location = new System.Drawing.Point(96, 338);
            this.NudMinScore.Name = "NudMinScore";
            this.NudMinScore.Size = new System.Drawing.Size(130, 25);
            this.NudMinScore.TabIndex = 41;
            this.NudMinScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtDescription.Location = new System.Drawing.Point(96, 114);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(130, 25);
            this.TxtDescription.TabIndex = 40;
            // 
            // ChkEnabled
            // 
            this.ChkEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkEnabled.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkEnabled.ForeColor = System.Drawing.Color.White;
            this.ChkEnabled.Location = new System.Drawing.Point(96, 84);
            this.ChkEnabled.Name = "ChkEnabled";
            this.ChkEnabled.Size = new System.Drawing.Size(130, 28);
            this.ChkEnabled.TabIndex = 39;
            this.ChkEnabled.Text = "사용";
            this.ChkEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkEnabled.UseVisualStyleBackColor = false;
            this.ChkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabled_CheckedChanged);
            // 
            // BtnShow
            // 
            this.BtnShow.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnShow.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnShow.ForeColor = System.Drawing.Color.White;
            this.BtnShow.Location = new System.Drawing.Point(20, 299);
            this.BtnShow.Name = "BtnShow";
            this.BtnShow.Size = new System.Drawing.Size(100, 35);
            this.BtnShow.TabIndex = 37;
            this.BtnShow.Text = "패턴영역";
            this.BtnShow.UseVisualStyleBackColor = false;
            this.BtnShow.Click += new System.EventHandler(this.BtnShow_Click);
            // 
            // BtnTrain
            // 
            this.BtnTrain.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnTrain.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnTrain.ForeColor = System.Drawing.Color.White;
            this.BtnTrain.Location = new System.Drawing.Point(126, 299);
            this.BtnTrain.Name = "BtnTrain";
            this.BtnTrain.Size = new System.Drawing.Size(100, 35);
            this.BtnTrain.TabIndex = 37;
            this.BtnTrain.Text = "트레인";
            this.BtnTrain.UseVisualStyleBackColor = false;
            this.BtnTrain.Click += new System.EventHandler(this.BtnTrain_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCopy.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Image = global::YKCJ_Diaper.Properties.Resources.Copy;
            this.BtnCopy.Location = new System.Drawing.Point(176, 31);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(50, 50);
            this.BtnCopy.TabIndex = 37;
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // CmbMD
            // 
            this.CmbMD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMD.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbMD.FormattingEnabled = true;
            this.CmbMD.Location = new System.Drawing.Point(96, 394);
            this.CmbMD.Name = "CmbMD";
            this.CmbMD.Size = new System.Drawing.Size(130, 25);
            this.CmbMD.TabIndex = 29;
            // 
            // CmbCD
            // 
            this.CmbCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCD.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbCD.FormattingEnabled = true;
            this.CmbCD.Location = new System.Drawing.Point(96, 422);
            this.CmbCD.Name = "CmbCD";
            this.CmbCD.Size = new System.Drawing.Size(130, 25);
            this.CmbCD.TabIndex = 33;
            // 
            // CmbCopyNo
            // 
            this.CmbCopyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCopyNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbCopyNo.FormattingEnabled = true;
            this.CmbCopyNo.Location = new System.Drawing.Point(96, 58);
            this.CmbCopyNo.Name = "CmbCopyNo";
            this.CmbCopyNo.Size = new System.Drawing.Size(75, 25);
            this.CmbCopyNo.TabIndex = 34;
            // 
            // CmbNo
            // 
            this.CmbNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbNo.FormattingEnabled = true;
            this.CmbNo.Location = new System.Drawing.Point(96, 30);
            this.CmbNo.Name = "CmbNo";
            this.CmbNo.Size = new System.Drawing.Size(58, 25);
            this.CmbNo.TabIndex = 28;
            this.CmbNo.SelectedIndexChanged += new System.EventHandler(this.CmbNo_SelectedIndexChanged);
            // 
            // LblTitleMD
            // 
            this.LblTitleMD.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleMD.BDrawBorderBottom = true;
            this.LblTitleMD.BDrawBorderLeft = true;
            this.LblTitleMD.BDrawBorderRight = true;
            this.LblTitleMD.BDrawBorderTop = false;
            this.LblTitleMD.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleMD.ForeColor = System.Drawing.Color.White;
            this.LblTitleMD.Location = new System.Drawing.Point(0, 392);
            this.LblTitleMD.Name = "LblTitleMD";
            this.LblTitleMD.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleMD.Size = new System.Drawing.Size(90, 28);
            this.LblTitleMD.TabIndex = 20;
            this.LblTitleMD.Text = "가로 Align";
            this.LblTitleMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleMinScore
            // 
            this.LblTitleMinScore.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleMinScore.BDrawBorderBottom = true;
            this.LblTitleMinScore.BDrawBorderLeft = true;
            this.LblTitleMinScore.BDrawBorderRight = true;
            this.LblTitleMinScore.BDrawBorderTop = true;
            this.LblTitleMinScore.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleMinScore.ForeColor = System.Drawing.Color.White;
            this.LblTitleMinScore.Location = new System.Drawing.Point(0, 336);
            this.LblTitleMinScore.Name = "LblTitleMinScore";
            this.LblTitleMinScore.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleMinScore.Size = new System.Drawing.Size(90, 28);
            this.LblTitleMinScore.TabIndex = 16;
            this.LblTitleMinScore.Text = "최소 점수";
            this.LblTitleMinScore.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleTrain
            // 
            this.LblTitleTrain.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleTrain.BDrawBorderBottom = true;
            this.LblTitleTrain.BDrawBorderLeft = true;
            this.LblTitleTrain.BDrawBorderRight = true;
            this.LblTitleTrain.BDrawBorderTop = true;
            this.LblTitleTrain.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleTrain.ForeColor = System.Drawing.Color.White;
            this.LblTitleTrain.Location = new System.Drawing.Point(0, 140);
            this.LblTitleTrain.Name = "LblTitleTrain";
            this.LblTitleTrain.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleTrain.Size = new System.Drawing.Size(230, 30);
            this.LblTitleTrain.TabIndex = 26;
            this.LblTitleTrain.Text = "패턴 이미지";
            this.LblTitleTrain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleDescription
            // 
            this.LblTitleDescription.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleDescription.BDrawBorderBottom = false;
            this.LblTitleDescription.BDrawBorderLeft = true;
            this.LblTitleDescription.BDrawBorderRight = true;
            this.LblTitleDescription.BDrawBorderTop = false;
            this.LblTitleDescription.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleDescription.ForeColor = System.Drawing.Color.White;
            this.LblTitleDescription.Location = new System.Drawing.Point(0, 112);
            this.LblTitleDescription.Name = "LblTitleDescription";
            this.LblTitleDescription.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleDescription.Size = new System.Drawing.Size(90, 28);
            this.LblTitleDescription.TabIndex = 27;
            this.LblTitleDescription.Text = "설명";
            this.LblTitleDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleEnabled
            // 
            this.LblTitleEnabled.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleEnabled.BDrawBorderBottom = true;
            this.LblTitleEnabled.BDrawBorderLeft = true;
            this.LblTitleEnabled.BDrawBorderRight = true;
            this.LblTitleEnabled.BDrawBorderTop = false;
            this.LblTitleEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleEnabled.ForeColor = System.Drawing.Color.White;
            this.LblTitleEnabled.Location = new System.Drawing.Point(0, 84);
            this.LblTitleEnabled.Name = "LblTitleEnabled";
            this.LblTitleEnabled.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEnabled.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEnabled.TabIndex = 22;
            this.LblTitleEnabled.Text = "사용 여부";
            this.LblTitleEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleNo
            // 
            this.LblTitleNo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleNo.BDrawBorderBottom = true;
            this.LblTitleNo.BDrawBorderLeft = true;
            this.LblTitleNo.BDrawBorderRight = true;
            this.LblTitleNo.BDrawBorderTop = false;
            this.LblTitleNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleNo.ForeColor = System.Drawing.Color.White;
            this.LblTitleNo.Location = new System.Drawing.Point(0, 28);
            this.LblTitleNo.Name = "LblTitleNo";
            this.LblTitleNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleNo.TabIndex = 23;
            this.LblTitleNo.Text = "번호";
            this.LblTitleNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCopyNo
            // 
            this.LblTitleCopyNo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCopyNo.BDrawBorderBottom = true;
            this.LblTitleCopyNo.BDrawBorderLeft = true;
            this.LblTitleCopyNo.BDrawBorderRight = true;
            this.LblTitleCopyNo.BDrawBorderTop = false;
            this.LblTitleCopyNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCopyNo.ForeColor = System.Drawing.Color.White;
            this.LblTitleCopyNo.Location = new System.Drawing.Point(0, 56);
            this.LblTitleCopyNo.Name = "LblTitleCopyNo";
            this.LblTitleCopyNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCopyNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCopyNo.TabIndex = 24;
            this.LblTitleCopyNo.Text = "복사 번호";
            this.LblTitleCopyNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCD
            // 
            this.LblTitleCD.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCD.BDrawBorderBottom = false;
            this.LblTitleCD.BDrawBorderLeft = true;
            this.LblTitleCD.BDrawBorderRight = true;
            this.LblTitleCD.BDrawBorderTop = false;
            this.LblTitleCD.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCD.ForeColor = System.Drawing.Color.White;
            this.LblTitleCD.Location = new System.Drawing.Point(0, 420);
            this.LblTitleCD.Name = "LblTitleCD";
            this.LblTitleCD.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCD.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCD.TabIndex = 19;
            this.LblTitleCD.Text = "세로 Align";
            this.LblTitleCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlScreen
            // 
            this.PnlScreen.BDrawBorderBottom = false;
            this.PnlScreen.BDrawBorderLeft = true;
            this.PnlScreen.BDrawBorderRight = true;
            this.PnlScreen.BDrawBorderTop = false;
            this.PnlScreen.Controls.Add(this.CmbNo);
            this.PnlScreen.Controls.Add(this.NudNo);
            this.PnlScreen.Controls.Add(this.CmbIOSignal);
            this.PnlScreen.Controls.Add(this.LblTitlePattern);
            this.PnlScreen.Controls.Add(this.CdpTrain);
            this.PnlScreen.Controls.Add(this.LblTitleCopyNo);
            this.PnlScreen.Controls.Add(this.NudMinScore);
            this.PnlScreen.Controls.Add(this.LblTitleNo);
            this.PnlScreen.Controls.Add(this.TxtDescription);
            this.PnlScreen.Controls.Add(this.LblTitleEnabled);
            this.PnlScreen.Controls.Add(this.ChkEnabled);
            this.PnlScreen.Controls.Add(this.LblTitleDescription);
            this.PnlScreen.Controls.Add(this.BtnShow);
            this.PnlScreen.Controls.Add(this.LblTitleTrain);
            this.PnlScreen.Controls.Add(this.BtnTrain);
            this.PnlScreen.Controls.Add(this.LblTitleMinScore);
            this.PnlScreen.Controls.Add(this.BtnCopy);
            this.PnlScreen.Controls.Add(this.LblTitleMD);
            this.PnlScreen.Controls.Add(this.CmbMD);
            this.PnlScreen.Controls.Add(this.LblTitleIOSignal);
            this.PnlScreen.Controls.Add(this.LblTitleCD);
            this.PnlScreen.Controls.Add(this.CmbCD);
            this.PnlScreen.Controls.Add(this.CmbCopyNo);
            this.PnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlScreen.Location = new System.Drawing.Point(0, 0);
            this.PnlScreen.Name = "PnlScreen";
            this.PnlScreen.Size = new System.Drawing.Size(230, 448);
            this.PnlScreen.TabIndex = 43;
            // 
            // NudNo
            // 
            this.NudNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudNo.Location = new System.Drawing.Point(122, 30);
            this.NudNo.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.NudNo.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudNo.Name = "NudNo";
            this.NudNo.ReadOnly = true;
            this.NudNo.Size = new System.Drawing.Size(49, 25);
            this.NudNo.TabIndex = 44;
            this.NudNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudNo.ValueChanged += new System.EventHandler(this.NudNo_ValueChanged);
            // 
            // CmbIOSignal
            // 
            this.CmbIOSignal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbIOSignal.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbIOSignal.FormattingEnabled = true;
            this.CmbIOSignal.Items.AddRange(new object[] {
            "없음",
            "TOOL1",
            "TOOL2",
            "TOOL3",
            "TOOL4",
            "TOOL5",
            "TOOL6",
            "TOOL7",
            "TOOL8",
            "TOOL9",
            "TOOL10",
            "TOOL11",
            "TOOL12"});
            this.CmbIOSignal.Location = new System.Drawing.Point(96, 366);
            this.CmbIOSignal.Name = "CmbIOSignal";
            this.CmbIOSignal.Size = new System.Drawing.Size(130, 25);
            this.CmbIOSignal.TabIndex = 43;
            // 
            // LblTitlePattern
            // 
            this.LblTitlePattern.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitlePattern.BDrawBorderBottom = true;
            this.LblTitlePattern.BDrawBorderLeft = true;
            this.LblTitlePattern.BDrawBorderRight = true;
            this.LblTitlePattern.BDrawBorderTop = false;
            this.LblTitlePattern.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitlePattern.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitlePattern.ForeColor = System.Drawing.Color.White;
            this.LblTitlePattern.Location = new System.Drawing.Point(0, 0);
            this.LblTitlePattern.Name = "LblTitlePattern";
            this.LblTitlePattern.OBorderColor = System.Drawing.Color.Black;
            this.LblTitlePattern.Size = new System.Drawing.Size(230, 28);
            this.LblTitlePattern.TabIndex = 15;
            this.LblTitlePattern.Text = "패턴";
            this.LblTitlePattern.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleIOSignal
            // 
            this.LblTitleIOSignal.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleIOSignal.BDrawBorderBottom = true;
            this.LblTitleIOSignal.BDrawBorderLeft = true;
            this.LblTitleIOSignal.BDrawBorderRight = true;
            this.LblTitleIOSignal.BDrawBorderTop = false;
            this.LblTitleIOSignal.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleIOSignal.ForeColor = System.Drawing.Color.White;
            this.LblTitleIOSignal.Location = new System.Drawing.Point(0, 364);
            this.LblTitleIOSignal.Name = "LblTitleIOSignal";
            this.LblTitleIOSignal.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleIOSignal.Size = new System.Drawing.Size(90, 28);
            this.LblTitleIOSignal.TabIndex = 19;
            this.LblTitleIOSignal.Text = "NG 신호";
            this.LblTitleIOSignal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UcPattern
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlScreen);
            this.Name = "UcPattern";
            ((System.ComponentModel.ISupportInitialize)(this.CdpTrain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMinScore)).EndInit();
            this.PnlScreen.ResumeLayout(false);
            this.PnlScreen.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudNo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NudMinScore;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.CheckBox ChkEnabled;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.ComboBox CmbMD;
        private System.Windows.Forms.ComboBox CmbCD;
        private System.Windows.Forms.ComboBox CmbCopyNo;
        private System.Windows.Forms.ComboBox CmbNo;
        private Jhjo.Component.CLabel LblTitleMD;
        private Jhjo.Component.CLabel LblTitleMinScore;
        private Jhjo.Component.CLabel LblTitleTrain;
        private Jhjo.Component.CLabel LblTitleDescription;
        private Jhjo.Component.CLabel LblTitleEnabled;
        private Jhjo.Component.CLabel LblTitleNo;
        private Jhjo.Component.CLabel LblTitleCopyNo;
        private Cognex.VisionPro.Display.CogDisplay CdpTrain;
        private System.Windows.Forms.Button BtnTrain;
        private System.Windows.Forms.Button BtnShow;
        private Jhjo.Component.CLabel LblTitleCD;
        private Jhjo.Component.CPanel PnlScreen;
        private Jhjo.Component.CLabel LblTitlePattern;
        private Jhjo.Component.CLabel LblTitleIOSignal;
        private System.Windows.Forms.ComboBox CmbIOSignal;
        private System.Windows.Forms.NumericUpDown NudNo;
    }
}

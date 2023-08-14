namespace YKCJ_Diaper
{
    partial class UcMDCD
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
            this.PnlMDCD = new Jhjo.Component.CPanel();
            this.CmbNo = new System.Windows.Forms.ComboBox();
            this.LblTitleToolParam = new Jhjo.Component.CLabel();
            this.NudHalfPixel = new System.Windows.Forms.NumericUpDown();
            this.LblTitleKind = new Jhjo.Component.CLabel();
            this.NudNo = new System.Windows.Forms.NumericUpDown();
            this.NudConstThreshold = new System.Windows.Forms.NumericUpDown();
            this.LblTitleCopyNo = new Jhjo.Component.CLabel();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.LblTitleNo = new Jhjo.Component.CLabel();
            this.ChkPriority = new System.Windows.Forms.CheckBox();
            this.ChkEnabled = new System.Windows.Forms.CheckBox();
            this.LblTitleEnabled = new Jhjo.Component.CLabel();
            this.BtnTop = new System.Windows.Forms.Button();
            this.LblTitleDescription = new Jhjo.Component.CLabel();
            this.BtnInspect = new System.Windows.Forms.Button();
            this.LblTitlePolarity = new Jhjo.Component.CLabel();
            this.BtnBottom = new System.Windows.Forms.Button();
            this.LblTitleConstThreashold = new Jhjo.Component.CLabel();
            this.BtnRight = new System.Windows.Forms.Button();
            this.LblTitleHalfPixel = new Jhjo.Component.CLabel();
            this.BtnLeft = new System.Windows.Forms.Button();
            this.LblTitlePriority = new Jhjo.Component.CLabel();
            this.LblTitleROI = new Jhjo.Component.CLabel();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.CmbPolarity = new System.Windows.Forms.ComboBox();
            this.CmbKind = new System.Windows.Forms.ComboBox();
            this.CmbCopyNo = new System.Windows.Forms.ComboBox();
            this.PnlMDCD.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudHalfPixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudConstThreshold)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlMDCD
            // 
            this.PnlMDCD.BDrawBorderBottom = false;
            this.PnlMDCD.BDrawBorderLeft = true;
            this.PnlMDCD.BDrawBorderRight = true;
            this.PnlMDCD.BDrawBorderTop = false;
            this.PnlMDCD.Controls.Add(this.CmbNo);
            this.PnlMDCD.Controls.Add(this.LblTitleToolParam);
            this.PnlMDCD.Controls.Add(this.NudHalfPixel);
            this.PnlMDCD.Controls.Add(this.LblTitleKind);
            this.PnlMDCD.Controls.Add(this.NudNo);
            this.PnlMDCD.Controls.Add(this.NudConstThreshold);
            this.PnlMDCD.Controls.Add(this.LblTitleCopyNo);
            this.PnlMDCD.Controls.Add(this.TxtDescription);
            this.PnlMDCD.Controls.Add(this.LblTitleNo);
            this.PnlMDCD.Controls.Add(this.ChkPriority);
            this.PnlMDCD.Controls.Add(this.ChkEnabled);
            this.PnlMDCD.Controls.Add(this.LblTitleEnabled);
            this.PnlMDCD.Controls.Add(this.BtnTop);
            this.PnlMDCD.Controls.Add(this.LblTitleDescription);
            this.PnlMDCD.Controls.Add(this.BtnInspect);
            this.PnlMDCD.Controls.Add(this.LblTitlePolarity);
            this.PnlMDCD.Controls.Add(this.BtnBottom);
            this.PnlMDCD.Controls.Add(this.LblTitleConstThreashold);
            this.PnlMDCD.Controls.Add(this.BtnRight);
            this.PnlMDCD.Controls.Add(this.LblTitleHalfPixel);
            this.PnlMDCD.Controls.Add(this.BtnLeft);
            this.PnlMDCD.Controls.Add(this.LblTitlePriority);
            this.PnlMDCD.Controls.Add(this.LblTitleROI);
            this.PnlMDCD.Controls.Add(this.BtnCopy);
            this.PnlMDCD.Controls.Add(this.CmbPolarity);
            this.PnlMDCD.Controls.Add(this.CmbKind);
            this.PnlMDCD.Controls.Add(this.CmbCopyNo);
            this.PnlMDCD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMDCD.Location = new System.Drawing.Point(0, 0);
            this.PnlMDCD.Name = "PnlMDCD";
            this.PnlMDCD.Size = new System.Drawing.Size(230, 448);
            this.PnlMDCD.TabIndex = 44;
            // 
            // CmbNo
            // 
            this.CmbNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbNo.FormattingEnabled = true;
            this.CmbNo.Location = new System.Drawing.Point(96, 58);
            this.CmbNo.Name = "CmbNo";
            this.CmbNo.Size = new System.Drawing.Size(58, 25);
            this.CmbNo.TabIndex = 28;
            this.CmbNo.SelectedIndexChanged += new System.EventHandler(this.CmbNo_SelectedIndexChanged);
            // 
            // LblTitleToolParam
            // 
            this.LblTitleToolParam.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleToolParam.BDrawBorderBottom = true;
            this.LblTitleToolParam.BDrawBorderLeft = true;
            this.LblTitleToolParam.BDrawBorderRight = true;
            this.LblTitleToolParam.BDrawBorderTop = false;
            this.LblTitleToolParam.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleToolParam.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleToolParam.ForeColor = System.Drawing.Color.White;
            this.LblTitleToolParam.Location = new System.Drawing.Point(0, 0);
            this.LblTitleToolParam.Name = "LblTitleToolParam";
            this.LblTitleToolParam.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleToolParam.Size = new System.Drawing.Size(230, 28);
            this.LblTitleToolParam.TabIndex = 15;
            this.LblTitleToolParam.Text = "자동 Align";
            this.LblTitleToolParam.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NudHalfPixel
            // 
            this.NudHalfPixel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudHalfPixel.Location = new System.Drawing.Point(96, 226);
            this.NudHalfPixel.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NudHalfPixel.Name = "NudHalfPixel";
            this.NudHalfPixel.Size = new System.Drawing.Size(130, 25);
            this.NudHalfPixel.TabIndex = 42;
            this.NudHalfPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LblTitleKind
            // 
            this.LblTitleKind.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleKind.BDrawBorderBottom = true;
            this.LblTitleKind.BDrawBorderLeft = true;
            this.LblTitleKind.BDrawBorderRight = true;
            this.LblTitleKind.BDrawBorderTop = false;
            this.LblTitleKind.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleKind.ForeColor = System.Drawing.Color.White;
            this.LblTitleKind.Location = new System.Drawing.Point(0, 28);
            this.LblTitleKind.Name = "LblTitleKind";
            this.LblTitleKind.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleKind.Size = new System.Drawing.Size(90, 28);
            this.LblTitleKind.TabIndex = 23;
            this.LblTitleKind.Text = "유형";
            this.LblTitleKind.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // NudNo
            // 
            this.NudNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudNo.Location = new System.Drawing.Point(122, 58);
            this.NudNo.Maximum = new decimal(new int[] {
            5,
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
            this.NudNo.TabIndex = 43;
            this.NudNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudNo.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudNo.ValueChanged += new System.EventHandler(this.NudNo_ValueChanged);
            // 
            // NudConstThreshold
            // 
            this.NudConstThreshold.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudConstThreshold.Location = new System.Drawing.Point(96, 198);
            this.NudConstThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudConstThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudConstThreshold.Name = "NudConstThreshold";
            this.NudConstThreshold.Size = new System.Drawing.Size(130, 25);
            this.NudConstThreshold.TabIndex = 43;
            this.NudConstThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudConstThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
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
            this.LblTitleCopyNo.Location = new System.Drawing.Point(0, 84);
            this.LblTitleCopyNo.Name = "LblTitleCopyNo";
            this.LblTitleCopyNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCopyNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCopyNo.TabIndex = 24;
            this.LblTitleCopyNo.Text = "복사 번호";
            this.LblTitleCopyNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtDescription.Location = new System.Drawing.Point(96, 142);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(130, 25);
            this.TxtDescription.TabIndex = 40;
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
            this.LblTitleNo.Location = new System.Drawing.Point(0, 56);
            this.LblTitleNo.Name = "LblTitleNo";
            this.LblTitleNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleNo.TabIndex = 23;
            this.LblTitleNo.Text = "번호";
            this.LblTitleNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ChkPriority
            // 
            this.ChkPriority.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkPriority.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkPriority.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkPriority.ForeColor = System.Drawing.Color.White;
            this.ChkPriority.Location = new System.Drawing.Point(96, 252);
            this.ChkPriority.Name = "ChkPriority";
            this.ChkPriority.Size = new System.Drawing.Size(130, 28);
            this.ChkPriority.TabIndex = 39;
            this.ChkPriority.Text = "위치";
            this.ChkPriority.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkPriority.UseVisualStyleBackColor = false;
            this.ChkPriority.CheckedChanged += new System.EventHandler(this.ChkPriority_CheckedChanged);
            // 
            // ChkEnabled
            // 
            this.ChkEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkEnabled.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkEnabled.ForeColor = System.Drawing.Color.White;
            this.ChkEnabled.Location = new System.Drawing.Point(96, 112);
            this.ChkEnabled.Name = "ChkEnabled";
            this.ChkEnabled.Size = new System.Drawing.Size(130, 28);
            this.ChkEnabled.TabIndex = 39;
            this.ChkEnabled.Text = "사용";
            this.ChkEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkEnabled.UseVisualStyleBackColor = false;
            this.ChkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabled_CheckedChanged);
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
            this.LblTitleEnabled.Location = new System.Drawing.Point(0, 112);
            this.LblTitleEnabled.Name = "LblTitleEnabled";
            this.LblTitleEnabled.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEnabled.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEnabled.TabIndex = 22;
            this.LblTitleEnabled.Text = "사용 여부";
            this.LblTitleEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnTop
            // 
            this.BtnTop.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnTop.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnTop.ForeColor = System.Drawing.Color.White;
            this.BtnTop.Location = new System.Drawing.Point(162, 279);
            this.BtnTop.Name = "BtnTop";
            this.BtnTop.Size = new System.Drawing.Size(33, 30);
            this.BtnTop.TabIndex = 37;
            this.BtnTop.Tag = "TOP";
            this.BtnTop.Text = "▲";
            this.BtnTop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnTop.UseVisualStyleBackColor = false;
            this.BtnTop.Click += new System.EventHandler(this.BtnDirection_Click);
            // 
            // LblTitleDescription
            // 
            this.LblTitleDescription.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleDescription.BDrawBorderBottom = true;
            this.LblTitleDescription.BDrawBorderLeft = true;
            this.LblTitleDescription.BDrawBorderRight = true;
            this.LblTitleDescription.BDrawBorderTop = false;
            this.LblTitleDescription.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleDescription.ForeColor = System.Drawing.Color.White;
            this.LblTitleDescription.Location = new System.Drawing.Point(0, 140);
            this.LblTitleDescription.Name = "LblTitleDescription";
            this.LblTitleDescription.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleDescription.Size = new System.Drawing.Size(90, 28);
            this.LblTitleDescription.TabIndex = 27;
            this.LblTitleDescription.Text = "설명";
            this.LblTitleDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnInspect
            // 
            this.BtnInspect.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnInspect.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnInspect.ForeColor = System.Drawing.Color.White;
            this.BtnInspect.Location = new System.Drawing.Point(128, 311);
            this.BtnInspect.Name = "BtnInspect";
            this.BtnInspect.Size = new System.Drawing.Size(100, 35);
            this.BtnInspect.TabIndex = 37;
            this.BtnInspect.Text = "검사";
            this.BtnInspect.UseVisualStyleBackColor = false;
            this.BtnInspect.Click += new System.EventHandler(this.BtnInspect_Click);
            // 
            // LblTitlePolarity
            // 
            this.LblTitlePolarity.BackColor = System.Drawing.Color.DimGray;
            this.LblTitlePolarity.BDrawBorderBottom = true;
            this.LblTitlePolarity.BDrawBorderLeft = true;
            this.LblTitlePolarity.BDrawBorderRight = true;
            this.LblTitlePolarity.BDrawBorderTop = false;
            this.LblTitlePolarity.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitlePolarity.ForeColor = System.Drawing.Color.White;
            this.LblTitlePolarity.Location = new System.Drawing.Point(0, 168);
            this.LblTitlePolarity.Name = "LblTitlePolarity";
            this.LblTitlePolarity.OBorderColor = System.Drawing.Color.Black;
            this.LblTitlePolarity.Size = new System.Drawing.Size(90, 28);
            this.LblTitlePolarity.TabIndex = 26;
            this.LblTitlePolarity.Text = "명암 방향";
            this.LblTitlePolarity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnBottom
            // 
            this.BtnBottom.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBottom.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnBottom.ForeColor = System.Drawing.Color.White;
            this.BtnBottom.Location = new System.Drawing.Point(195, 279);
            this.BtnBottom.Name = "BtnBottom";
            this.BtnBottom.Size = new System.Drawing.Size(33, 30);
            this.BtnBottom.TabIndex = 37;
            this.BtnBottom.Tag = "BOTTOM";
            this.BtnBottom.Text = "▼";
            this.BtnBottom.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnBottom.UseVisualStyleBackColor = false;
            this.BtnBottom.Click += new System.EventHandler(this.BtnDirection_Click);
            // 
            // LblTitleConstThreashold
            // 
            this.LblTitleConstThreashold.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleConstThreashold.BDrawBorderBottom = true;
            this.LblTitleConstThreashold.BDrawBorderLeft = true;
            this.LblTitleConstThreashold.BDrawBorderRight = true;
            this.LblTitleConstThreashold.BDrawBorderTop = false;
            this.LblTitleConstThreashold.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleConstThreashold.ForeColor = System.Drawing.Color.White;
            this.LblTitleConstThreashold.Location = new System.Drawing.Point(0, 196);
            this.LblTitleConstThreashold.Name = "LblTitleConstThreashold";
            this.LblTitleConstThreashold.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleConstThreashold.Size = new System.Drawing.Size(90, 28);
            this.LblTitleConstThreashold.TabIndex = 25;
            this.LblTitleConstThreashold.Text = "명암 차이";
            this.LblTitleConstThreashold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnRight
            // 
            this.BtnRight.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRight.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnRight.ForeColor = System.Drawing.Color.White;
            this.BtnRight.Location = new System.Drawing.Point(129, 279);
            this.BtnRight.Name = "BtnRight";
            this.BtnRight.Size = new System.Drawing.Size(33, 30);
            this.BtnRight.TabIndex = 37;
            this.BtnRight.Tag = "RIGHT";
            this.BtnRight.Text = "▶";
            this.BtnRight.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnRight.UseVisualStyleBackColor = false;
            this.BtnRight.Click += new System.EventHandler(this.BtnDirection_Click);
            // 
            // LblTitleHalfPixel
            // 
            this.LblTitleHalfPixel.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleHalfPixel.BDrawBorderBottom = true;
            this.LblTitleHalfPixel.BDrawBorderLeft = true;
            this.LblTitleHalfPixel.BDrawBorderRight = true;
            this.LblTitleHalfPixel.BDrawBorderTop = false;
            this.LblTitleHalfPixel.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleHalfPixel.ForeColor = System.Drawing.Color.White;
            this.LblTitleHalfPixel.Location = new System.Drawing.Point(0, 224);
            this.LblTitleHalfPixel.Name = "LblTitleHalfPixel";
            this.LblTitleHalfPixel.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleHalfPixel.Size = new System.Drawing.Size(90, 28);
            this.LblTitleHalfPixel.TabIndex = 21;
            this.LblTitleHalfPixel.Text = "연산 픽셀";
            this.LblTitleHalfPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnLeft
            // 
            this.BtnLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnLeft.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnLeft.ForeColor = System.Drawing.Color.White;
            this.BtnLeft.Location = new System.Drawing.Point(96, 279);
            this.BtnLeft.Name = "BtnLeft";
            this.BtnLeft.Size = new System.Drawing.Size(33, 30);
            this.BtnLeft.TabIndex = 37;
            this.BtnLeft.Tag = "LEFT";
            this.BtnLeft.Text = "◀";
            this.BtnLeft.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BtnLeft.UseVisualStyleBackColor = false;
            this.BtnLeft.Click += new System.EventHandler(this.BtnDirection_Click);
            // 
            // LblTitlePriority
            // 
            this.LblTitlePriority.BackColor = System.Drawing.Color.DimGray;
            this.LblTitlePriority.BDrawBorderBottom = true;
            this.LblTitlePriority.BDrawBorderLeft = true;
            this.LblTitlePriority.BDrawBorderRight = true;
            this.LblTitlePriority.BDrawBorderTop = false;
            this.LblTitlePriority.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitlePriority.ForeColor = System.Drawing.Color.White;
            this.LblTitlePriority.Location = new System.Drawing.Point(0, 252);
            this.LblTitlePriority.Name = "LblTitlePriority";
            this.LblTitlePriority.OBorderColor = System.Drawing.Color.Black;
            this.LblTitlePriority.Size = new System.Drawing.Size(90, 28);
            this.LblTitlePriority.TabIndex = 17;
            this.LblTitlePriority.Text = "우선 순위";
            this.LblTitlePriority.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleROI
            // 
            this.LblTitleROI.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleROI.BDrawBorderBottom = true;
            this.LblTitleROI.BDrawBorderLeft = true;
            this.LblTitleROI.BDrawBorderRight = true;
            this.LblTitleROI.BDrawBorderTop = false;
            this.LblTitleROI.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleROI.ForeColor = System.Drawing.Color.White;
            this.LblTitleROI.Location = new System.Drawing.Point(0, 280);
            this.LblTitleROI.Name = "LblTitleROI";
            this.LblTitleROI.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleROI.Size = new System.Drawing.Size(90, 28);
            this.LblTitleROI.TabIndex = 17;
            this.LblTitleROI.Text = "검색 방향";
            this.LblTitleROI.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCopy.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Image = global::YKCJ_Diaper.Properties.Resources.Copy;
            this.BtnCopy.Location = new System.Drawing.Point(176, 59);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(50, 50);
            this.BtnCopy.TabIndex = 37;
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // CmbPolarity
            // 
            this.CmbPolarity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbPolarity.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbPolarity.FormattingEnabled = true;
            this.CmbPolarity.Items.AddRange(new object[] {
            "밝은에서 어두운",
            "어두운에서 밝은",
            "어느 하나"});
            this.CmbPolarity.Location = new System.Drawing.Point(96, 170);
            this.CmbPolarity.Name = "CmbPolarity";
            this.CmbPolarity.Size = new System.Drawing.Size(130, 25);
            this.CmbPolarity.TabIndex = 31;
            // 
            // CmbKind
            // 
            this.CmbKind.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbKind.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbKind.FormattingEnabled = true;
            this.CmbKind.Items.AddRange(new object[] {
            "가로 맞춤",
            "세로 맞춤"});
            this.CmbKind.Location = new System.Drawing.Point(96, 30);
            this.CmbKind.Name = "CmbKind";
            this.CmbKind.Size = new System.Drawing.Size(130, 25);
            this.CmbKind.TabIndex = 28;
            this.CmbKind.SelectedIndexChanged += new System.EventHandler(this.CmbKind_SelectedIndexChanged);
            // 
            // CmbCopyNo
            // 
            this.CmbCopyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCopyNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbCopyNo.FormattingEnabled = true;
            this.CmbCopyNo.Location = new System.Drawing.Point(96, 86);
            this.CmbCopyNo.Name = "CmbCopyNo";
            this.CmbCopyNo.Size = new System.Drawing.Size(75, 25);
            this.CmbCopyNo.TabIndex = 34;
            // 
            // UcMDCD
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlMDCD);
            this.Name = "UcMDCD";
            this.PnlMDCD.ResumeLayout(false);
            this.PnlMDCD.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudHalfPixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudNo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudConstThreshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NudHalfPixel;
        private System.Windows.Forms.NumericUpDown NudConstThreshold;
        private System.Windows.Forms.TextBox TxtDescription;
        private System.Windows.Forms.CheckBox ChkEnabled;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.ComboBox CmbPolarity;
        private System.Windows.Forms.ComboBox CmbCopyNo;
        private System.Windows.Forms.ComboBox CmbNo;
        private Jhjo.Component.CLabel LblTitleROI;
        private Jhjo.Component.CLabel LblTitleHalfPixel;
        private Jhjo.Component.CLabel LblTitleConstThreashold;
        private Jhjo.Component.CLabel LblTitlePolarity;
        private Jhjo.Component.CLabel LblTitleDescription;
        private Jhjo.Component.CLabel LblTitleEnabled;
        private Jhjo.Component.CLabel LblTitleNo;
        private Jhjo.Component.CLabel LblTitleCopyNo;
        private Jhjo.Component.CLabel LblTitleKind;
        private System.Windows.Forms.ComboBox CmbKind;
        private System.Windows.Forms.Button BtnLeft;
        private System.Windows.Forms.Button BtnRight;
        private System.Windows.Forms.Button BtnBottom;
        private System.Windows.Forms.Button BtnTop;
        private System.Windows.Forms.Button BtnInspect;
        private Jhjo.Component.CPanel PnlMDCD;
        private Jhjo.Component.CLabel LblTitleToolParam;
        private System.Windows.Forms.NumericUpDown NudNo;
        private System.Windows.Forms.CheckBox ChkPriority;
        private Jhjo.Component.CLabel LblTitlePriority;
    }
}

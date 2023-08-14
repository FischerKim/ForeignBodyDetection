namespace YKCJ_Diaper
{
    partial class UcCaliper
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
            this.LblTitleCaliper = new Jhjo.Component.CLabel();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.CmbCopyNo = new System.Windows.Forms.ComboBox();
            this.CmbNo = new System.Windows.Forms.ComboBox();
            this.LblTitleNo = new Jhjo.Component.CLabel();
            this.LblTitleCopyNo = new Jhjo.Component.CLabel();
            this.LblTitleEnabled = new Jhjo.Component.CLabel();
            this.LblTitleDescription = new Jhjo.Component.CLabel();
            this.ChkEnabled = new System.Windows.Forms.CheckBox();
            this.TxtDescription = new System.Windows.Forms.TextBox();
            this.LblTitleEdge0 = new Jhjo.Component.CLabel();
            this.LblTitleEdge1 = new Jhjo.Component.CLabel();
            this.LblTitleEdgeWidth = new Jhjo.Component.CLabel();
            this.LblTitleContrastThreshold = new Jhjo.Component.CLabel();
            this.LblTitleRange = new Jhjo.Component.CLabel();
            this.LblTitleHalfPixel = new Jhjo.Component.CLabel();
            this.LblTitleMD = new Jhjo.Component.CLabel();
            this.LblTitleCD = new Jhjo.Component.CLabel();
            this.CmbEdge0 = new System.Windows.Forms.ComboBox();
            this.CmdEdge1 = new System.Windows.Forms.ComboBox();
            this.NudEdgeWidth = new System.Windows.Forms.NumericUpDown();
            this.NudContrastThreshold = new System.Windows.Forms.NumericUpDown();
            this.NudHalfPixel = new System.Windows.Forms.NumericUpDown();
            this.NudMin = new System.Windows.Forms.NumericUpDown();
            this.NudMax = new System.Windows.Forms.NumericUpDown();
            this.CmbMD = new System.Windows.Forms.ComboBox();
            this.CmbCD = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.NudEdgeWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudContrastThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHalfPixel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMax)).BeginInit();
            this.SuspendLayout();
            // 
            // LblTitleCaliper
            // 
            this.LblTitleCaliper.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleCaliper.BDrawBorderBottom = true;
            this.LblTitleCaliper.BDrawBorderLeft = false;
            this.LblTitleCaliper.BDrawBorderRight = false;
            this.LblTitleCaliper.BDrawBorderTop = false;
            this.LblTitleCaliper.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCaliper.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCaliper.ForeColor = System.Drawing.Color.White;
            this.LblTitleCaliper.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCaliper.Name = "LblTitleCaliper";
            this.LblTitleCaliper.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCaliper.Size = new System.Drawing.Size(230, 28);
            this.LblTitleCaliper.TabIndex = 6;
            this.LblTitleCaliper.Text = "캘리퍼";
            this.LblTitleCaliper.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCopy.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold);
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Image = global::YKCJ_Diaper.Properties.Resources.Copy;
            this.BtnCopy.Location = new System.Drawing.Point(176, 31);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(50, 50);
            this.BtnCopy.TabIndex = 14;
            this.BtnCopy.UseVisualStyleBackColor = false;
            // 
            // CmbCopyNo
            // 
            this.CmbCopyNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCopyNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbCopyNo.FormattingEnabled = true;
            this.CmbCopyNo.Location = new System.Drawing.Point(96, 58);
            this.CmbCopyNo.Name = "CmbCopyNo";
            this.CmbCopyNo.Size = new System.Drawing.Size(75, 25);
            this.CmbCopyNo.TabIndex = 13;
            // 
            // CmbNo
            // 
            this.CmbNo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbNo.FormattingEnabled = true;
            this.CmbNo.Location = new System.Drawing.Point(96, 30);
            this.CmbNo.Name = "CmbNo";
            this.CmbNo.Size = new System.Drawing.Size(75, 25);
            this.CmbNo.TabIndex = 12;
            // 
            // LblTitleNo
            // 
            this.LblTitleNo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleNo.BDrawBorderBottom = true;
            this.LblTitleNo.BDrawBorderLeft = false;
            this.LblTitleNo.BDrawBorderRight = true;
            this.LblTitleNo.BDrawBorderTop = false;
            this.LblTitleNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleNo.ForeColor = System.Drawing.Color.White;
            this.LblTitleNo.Location = new System.Drawing.Point(0, 28);
            this.LblTitleNo.Name = "LblTitleNo";
            this.LblTitleNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleNo.TabIndex = 10;
            this.LblTitleNo.Text = "번호";
            this.LblTitleNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCopyNo
            // 
            this.LblTitleCopyNo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCopyNo.BDrawBorderBottom = true;
            this.LblTitleCopyNo.BDrawBorderLeft = false;
            this.LblTitleCopyNo.BDrawBorderRight = true;
            this.LblTitleCopyNo.BDrawBorderTop = false;
            this.LblTitleCopyNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCopyNo.ForeColor = System.Drawing.Color.White;
            this.LblTitleCopyNo.Location = new System.Drawing.Point(0, 56);
            this.LblTitleCopyNo.Name = "LblTitleCopyNo";
            this.LblTitleCopyNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCopyNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCopyNo.TabIndex = 11;
            this.LblTitleCopyNo.Text = "복사 번호";
            this.LblTitleCopyNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleEnabled
            // 
            this.LblTitleEnabled.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleEnabled.BDrawBorderBottom = true;
            this.LblTitleEnabled.BDrawBorderLeft = false;
            this.LblTitleEnabled.BDrawBorderRight = true;
            this.LblTitleEnabled.BDrawBorderTop = false;
            this.LblTitleEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleEnabled.ForeColor = System.Drawing.Color.White;
            this.LblTitleEnabled.Location = new System.Drawing.Point(0, 84);
            this.LblTitleEnabled.Name = "LblTitleEnabled";
            this.LblTitleEnabled.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEnabled.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEnabled.TabIndex = 6;
            this.LblTitleEnabled.Text = "사용여부";
            this.LblTitleEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleDescription
            // 
            this.LblTitleDescription.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleDescription.BDrawBorderBottom = true;
            this.LblTitleDescription.BDrawBorderLeft = false;
            this.LblTitleDescription.BDrawBorderRight = true;
            this.LblTitleDescription.BDrawBorderTop = false;
            this.LblTitleDescription.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleDescription.ForeColor = System.Drawing.Color.White;
            this.LblTitleDescription.Location = new System.Drawing.Point(0, 112);
            this.LblTitleDescription.Name = "LblTitleDescription";
            this.LblTitleDescription.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleDescription.Size = new System.Drawing.Size(90, 28);
            this.LblTitleDescription.TabIndex = 6;
            this.LblTitleDescription.Text = "설명";
            this.LblTitleDescription.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
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
            this.ChkEnabled.TabIndex = 10;
            this.ChkEnabled.Text = "Enable";
            this.ChkEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkEnabled.UseVisualStyleBackColor = false;
            this.ChkEnabled.CheckedChanged += new System.EventHandler(this.ChkEnabled_CheckedChanged);
            // 
            // TxtDescription
            // 
            this.TxtDescription.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtDescription.Location = new System.Drawing.Point(96, 114);
            this.TxtDescription.Name = "TxtDescription";
            this.TxtDescription.Size = new System.Drawing.Size(130, 25);
            this.TxtDescription.TabIndex = 11;
            // 
            // LblTitleEdge0
            // 
            this.LblTitleEdge0.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleEdge0.BDrawBorderBottom = true;
            this.LblTitleEdge0.BDrawBorderLeft = false;
            this.LblTitleEdge0.BDrawBorderRight = true;
            this.LblTitleEdge0.BDrawBorderTop = false;
            this.LblTitleEdge0.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleEdge0.ForeColor = System.Drawing.Color.White;
            this.LblTitleEdge0.Location = new System.Drawing.Point(0, 140);
            this.LblTitleEdge0.Name = "LblTitleEdge0";
            this.LblTitleEdge0.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEdge0.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEdge0.TabIndex = 6;
            this.LblTitleEdge0.Text = "0 - 극성";
            this.LblTitleEdge0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleEdge1
            // 
            this.LblTitleEdge1.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleEdge1.BDrawBorderBottom = true;
            this.LblTitleEdge1.BDrawBorderLeft = false;
            this.LblTitleEdge1.BDrawBorderRight = true;
            this.LblTitleEdge1.BDrawBorderTop = false;
            this.LblTitleEdge1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleEdge1.ForeColor = System.Drawing.Color.White;
            this.LblTitleEdge1.Location = new System.Drawing.Point(0, 168);
            this.LblTitleEdge1.Name = "LblTitleEdge1";
            this.LblTitleEdge1.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEdge1.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEdge1.TabIndex = 6;
            this.LblTitleEdge1.Text = "1 - 극성";
            this.LblTitleEdge1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleEdgeWidth
            // 
            this.LblTitleEdgeWidth.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleEdgeWidth.BDrawBorderBottom = true;
            this.LblTitleEdgeWidth.BDrawBorderLeft = false;
            this.LblTitleEdgeWidth.BDrawBorderRight = true;
            this.LblTitleEdgeWidth.BDrawBorderTop = false;
            this.LblTitleEdgeWidth.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleEdgeWidth.ForeColor = System.Drawing.Color.White;
            this.LblTitleEdgeWidth.Location = new System.Drawing.Point(0, 196);
            this.LblTitleEdgeWidth.Name = "LblTitleEdgeWidth";
            this.LblTitleEdgeWidth.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleEdgeWidth.Size = new System.Drawing.Size(90, 28);
            this.LblTitleEdgeWidth.TabIndex = 6;
            this.LblTitleEdgeWidth.Text = "엣지거리";
            this.LblTitleEdgeWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleContrastThreshold
            // 
            this.LblTitleContrastThreshold.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleContrastThreshold.BDrawBorderBottom = true;
            this.LblTitleContrastThreshold.BDrawBorderLeft = false;
            this.LblTitleContrastThreshold.BDrawBorderRight = true;
            this.LblTitleContrastThreshold.BDrawBorderTop = false;
            this.LblTitleContrastThreshold.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleContrastThreshold.ForeColor = System.Drawing.Color.White;
            this.LblTitleContrastThreshold.Location = new System.Drawing.Point(0, 224);
            this.LblTitleContrastThreshold.Name = "LblTitleContrastThreshold";
            this.LblTitleContrastThreshold.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleContrastThreshold.Size = new System.Drawing.Size(90, 28);
            this.LblTitleContrastThreshold.TabIndex = 6;
            this.LblTitleContrastThreshold.Text = "임계값";
            this.LblTitleContrastThreshold.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleRange
            // 
            this.LblTitleRange.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRange.BDrawBorderBottom = true;
            this.LblTitleRange.BDrawBorderLeft = false;
            this.LblTitleRange.BDrawBorderRight = true;
            this.LblTitleRange.BDrawBorderTop = false;
            this.LblTitleRange.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRange.ForeColor = System.Drawing.Color.White;
            this.LblTitleRange.Location = new System.Drawing.Point(0, 280);
            this.LblTitleRange.Name = "LblTitleRange";
            this.LblTitleRange.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRange.Size = new System.Drawing.Size(90, 28);
            this.LblTitleRange.TabIndex = 6;
            this.LblTitleRange.Text = "범위";
            this.LblTitleRange.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleHalfPixel
            // 
            this.LblTitleHalfPixel.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleHalfPixel.BDrawBorderBottom = true;
            this.LblTitleHalfPixel.BDrawBorderLeft = false;
            this.LblTitleHalfPixel.BDrawBorderRight = true;
            this.LblTitleHalfPixel.BDrawBorderTop = false;
            this.LblTitleHalfPixel.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleHalfPixel.ForeColor = System.Drawing.Color.White;
            this.LblTitleHalfPixel.Location = new System.Drawing.Point(0, 252);
            this.LblTitleHalfPixel.Name = "LblTitleHalfPixel";
            this.LblTitleHalfPixel.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleHalfPixel.Size = new System.Drawing.Size(90, 28);
            this.LblTitleHalfPixel.TabIndex = 6;
            this.LblTitleHalfPixel.Text = "연산 픽셀 수";
            this.LblTitleHalfPixel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleMD
            // 
            this.LblTitleMD.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleMD.BDrawBorderBottom = true;
            this.LblTitleMD.BDrawBorderLeft = false;
            this.LblTitleMD.BDrawBorderRight = true;
            this.LblTitleMD.BDrawBorderTop = false;
            this.LblTitleMD.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleMD.ForeColor = System.Drawing.Color.White;
            this.LblTitleMD.Location = new System.Drawing.Point(0, 308);
            this.LblTitleMD.Name = "LblTitleMD";
            this.LblTitleMD.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleMD.Size = new System.Drawing.Size(90, 28);
            this.LblTitleMD.TabIndex = 6;
            this.LblTitleMD.Text = "가로 Align";
            this.LblTitleMD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCD
            // 
            this.LblTitleCD.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCD.BDrawBorderBottom = true;
            this.LblTitleCD.BDrawBorderLeft = false;
            this.LblTitleCD.BDrawBorderRight = true;
            this.LblTitleCD.BDrawBorderTop = false;
            this.LblTitleCD.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCD.ForeColor = System.Drawing.Color.White;
            this.LblTitleCD.Location = new System.Drawing.Point(0, 336);
            this.LblTitleCD.Name = "LblTitleCD";
            this.LblTitleCD.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCD.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCD.TabIndex = 6;
            this.LblTitleCD.Text = "세로 Align";
            this.LblTitleCD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CmbEdge0
            // 
            this.CmbEdge0.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbEdge0.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbEdge0.FormattingEnabled = true;
            this.CmbEdge0.Items.AddRange(new object[] {
            "DarkToLight",
            "LightToDark",
            "DontCare"});
            this.CmbEdge0.Location = new System.Drawing.Point(96, 142);
            this.CmbEdge0.Name = "CmbEdge0";
            this.CmbEdge0.Size = new System.Drawing.Size(130, 25);
            this.CmbEdge0.TabIndex = 32;
            // 
            // CmdEdge1
            // 
            this.CmdEdge1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmdEdge1.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmdEdge1.FormattingEnabled = true;
            this.CmdEdge1.Items.AddRange(new object[] {
            "DarkToLight",
            "LightToDark",
            "DontCare"});
            this.CmdEdge1.Location = new System.Drawing.Point(96, 170);
            this.CmdEdge1.Name = "CmdEdge1";
            this.CmdEdge1.Size = new System.Drawing.Size(130, 25);
            this.CmdEdge1.TabIndex = 32;
            // 
            // NudEdgeWidth
            // 
            this.NudEdgeWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudEdgeWidth.Location = new System.Drawing.Point(96, 198);
            this.NudEdgeWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudEdgeWidth.Name = "NudEdgeWidth";
            this.NudEdgeWidth.Size = new System.Drawing.Size(130, 25);
            this.NudEdgeWidth.TabIndex = 44;
            this.NudEdgeWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudEdgeWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudContrastThreshold
            // 
            this.NudContrastThreshold.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudContrastThreshold.Location = new System.Drawing.Point(96, 226);
            this.NudContrastThreshold.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.NudContrastThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudContrastThreshold.Name = "NudContrastThreshold";
            this.NudContrastThreshold.Size = new System.Drawing.Size(130, 25);
            this.NudContrastThreshold.TabIndex = 44;
            this.NudContrastThreshold.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudContrastThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudHalfPixel
            // 
            this.NudHalfPixel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudHalfPixel.Location = new System.Drawing.Point(96, 254);
            this.NudHalfPixel.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.NudHalfPixel.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudHalfPixel.Name = "NudHalfPixel";
            this.NudHalfPixel.Size = new System.Drawing.Size(130, 25);
            this.NudHalfPixel.TabIndex = 44;
            this.NudHalfPixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudHalfPixel.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudMin
            // 
            this.NudMin.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudMin.Location = new System.Drawing.Point(96, 282);
            this.NudMin.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudMin.Name = "NudMin";
            this.NudMin.Size = new System.Drawing.Size(62, 25);
            this.NudMin.TabIndex = 44;
            this.NudMin.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudMin.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // NudMax
            // 
            this.NudMax.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudMax.Location = new System.Drawing.Point(164, 282);
            this.NudMax.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudMax.Name = "NudMax";
            this.NudMax.Size = new System.Drawing.Size(62, 25);
            this.NudMax.TabIndex = 44;
            this.NudMax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudMax.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // CmbMD
            // 
            this.CmbMD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbMD.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbMD.FormattingEnabled = true;
            this.CmbMD.Location = new System.Drawing.Point(96, 310);
            this.CmbMD.Name = "CmbMD";
            this.CmbMD.Size = new System.Drawing.Size(130, 25);
            this.CmbMD.TabIndex = 32;
            // 
            // CmbCD
            // 
            this.CmbCD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbCD.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.CmbCD.FormattingEnabled = true;
            this.CmbCD.Location = new System.Drawing.Point(96, 338);
            this.CmbCD.Name = "CmbCD";
            this.CmbCD.Size = new System.Drawing.Size(130, 25);
            this.CmbCD.TabIndex = 32;
            // 
            // UcCaliper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.NudMax);
            this.Controls.Add(this.NudMin);
            this.Controls.Add(this.NudHalfPixel);
            this.Controls.Add(this.NudContrastThreshold);
            this.Controls.Add(this.NudEdgeWidth);
            this.Controls.Add(this.CmbCD);
            this.Controls.Add(this.CmbMD);
            this.Controls.Add(this.CmdEdge1);
            this.Controls.Add(this.CmbEdge0);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.CmbCopyNo);
            this.Controls.Add(this.CmbNo);
            this.Controls.Add(this.TxtDescription);
            this.Controls.Add(this.LblTitleNo);
            this.Controls.Add(this.LblTitleCopyNo);
            this.Controls.Add(this.ChkEnabled);
            this.Controls.Add(this.LblTitleCaliper);
            this.Controls.Add(this.LblTitleEnabled);
            this.Controls.Add(this.LblTitleCD);
            this.Controls.Add(this.LblTitleMD);
            this.Controls.Add(this.LblTitleRange);
            this.Controls.Add(this.LblTitleHalfPixel);
            this.Controls.Add(this.LblTitleContrastThreshold);
            this.Controls.Add(this.LblTitleEdgeWidth);
            this.Controls.Add(this.LblTitleEdge1);
            this.Controls.Add(this.LblTitleEdge0);
            this.Controls.Add(this.LblTitleDescription);
            this.Name = "UcCaliper";
            this.Size = new System.Drawing.Size(230, 448);
            ((System.ComponentModel.ISupportInitialize)(this.NudEdgeWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudContrastThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudHalfPixel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudMax)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Jhjo.Component.CLabel LblTitleCaliper;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.ComboBox CmbCopyNo;
        private System.Windows.Forms.ComboBox CmbNo;
        private Jhjo.Component.CLabel LblTitleNo;
        private Jhjo.Component.CLabel LblTitleCopyNo;
        private Jhjo.Component.CLabel LblTitleEnabled;
        private Jhjo.Component.CLabel LblTitleDescription;
        private System.Windows.Forms.CheckBox ChkEnabled;
        private System.Windows.Forms.TextBox TxtDescription;
        private Jhjo.Component.CLabel LblTitleEdge0;
        private Jhjo.Component.CLabel LblTitleEdge1;
        private Jhjo.Component.CLabel LblTitleEdgeWidth;
        private Jhjo.Component.CLabel LblTitleContrastThreshold;
        private Jhjo.Component.CLabel LblTitleRange;
        private Jhjo.Component.CLabel LblTitleHalfPixel;
        private Jhjo.Component.CLabel LblTitleMD;
        private Jhjo.Component.CLabel LblTitleCD;
        private System.Windows.Forms.ComboBox CmbEdge0;
        private System.Windows.Forms.ComboBox CmdEdge1;
        private System.Windows.Forms.NumericUpDown NudEdgeWidth;
        private System.Windows.Forms.NumericUpDown NudContrastThreshold;
        private System.Windows.Forms.NumericUpDown NudHalfPixel;
        private System.Windows.Forms.NumericUpDown NudMin;
        private System.Windows.Forms.NumericUpDown NudMax;
        private System.Windows.Forms.ComboBox CmbMD;
        private System.Windows.Forms.ComboBox CmbCD;
    }
}

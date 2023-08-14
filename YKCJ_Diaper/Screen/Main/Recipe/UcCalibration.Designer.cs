namespace YKCJ_Diaper
{
    partial class UcCalibration
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
            this.PnlExpandView = new Jhjo.Component.CPanel();
            this.ChkExpandView = new System.Windows.Forms.CheckBox();
            this.LblTitleExpandView = new Jhjo.Component.CLabel();
            this.PnlScale = new Jhjo.Component.CPanel();
            this.ChkScaleEnabled = new System.Windows.Forms.CheckBox();
            this.TxtScaleHeight = new System.Windows.Forms.TextBox();
            this.TxtScaleRealHeight = new System.Windows.Forms.TextBox();
            this.TxtScaleRealWidth = new System.Windows.Forms.TextBox();
            this.TxtScaleWidth = new System.Windows.Forms.TextBox();
            this.BtnScaleInspect = new System.Windows.Forms.Button();
            this.cLabel2 = new Jhjo.Component.CLabel();
            this.LblTitleScaleHeight = new Jhjo.Component.CLabel();
            this.LblTitleScaleWidth = new Jhjo.Component.CLabel();
            this.LblTitleScaleEnabled = new Jhjo.Component.CLabel();
            this.LblTitleScale = new Jhjo.Component.CLabel();
            this.PnlCalibration = new Jhjo.Component.CPanel();
            this.ChkCalibEnabled = new System.Windows.Forms.CheckBox();
            this.BtnCalibApply = new System.Windows.Forms.Button();
            this.TxtCalibPixelHeight = new System.Windows.Forms.TextBox();
            this.TxtCalibPixelWidth = new System.Windows.Forms.TextBox();
            this.BtnCalibInspect = new System.Windows.Forms.Button();
            this.NudCalibHeight = new System.Windows.Forms.NumericUpDown();
            this.NudCalibWidth = new System.Windows.Forms.NumericUpDown();
            this.cLabel1 = new Jhjo.Component.CLabel();
            this.LblCalibHeight = new Jhjo.Component.CLabel();
            this.LblTitleCalibWidth = new Jhjo.Component.CLabel();
            this.LblTitleCalibEnabled = new Jhjo.Component.CLabel();
            this.LblTitleCalibration = new Jhjo.Component.CLabel();
            this.PnlExpandView.SuspendLayout();
            this.PnlScale.SuspendLayout();
            this.PnlCalibration.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCalibHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCalibWidth)).BeginInit();
            this.SuspendLayout();
            // 
            // PnlExpandView
            // 
            this.PnlExpandView.BDrawBorderBottom = false;
            this.PnlExpandView.BDrawBorderLeft = true;
            this.PnlExpandView.BDrawBorderRight = true;
            this.PnlExpandView.BDrawBorderTop = false;
            this.PnlExpandView.Controls.Add(this.ChkExpandView);
            this.PnlExpandView.Controls.Add(this.LblTitleExpandView);
            this.PnlExpandView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlExpandView.Location = new System.Drawing.Point(0, 360);
            this.PnlExpandView.Name = "PnlExpandView";
            this.PnlExpandView.Size = new System.Drawing.Size(230, 88);
            this.PnlExpandView.TabIndex = 18;
            // 
            // ChkExpandView
            // 
            this.ChkExpandView.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkExpandView.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkExpandView.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkExpandView.ForeColor = System.Drawing.Color.White;
            this.ChkExpandView.Location = new System.Drawing.Point(3, 30);
            this.ChkExpandView.Name = "ChkExpandView";
            this.ChkExpandView.Size = new System.Drawing.Size(223, 35);
            this.ChkExpandView.TabIndex = 20;
            this.ChkExpandView.Text = "표현";
            this.ChkExpandView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkExpandView.UseVisualStyleBackColor = false;
            this.ChkExpandView.CheckedChanged += new System.EventHandler(this.ChkExpandView_CheckedChanged);
            // 
            // LblTitleExpandView
            // 
            this.LblTitleExpandView.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleExpandView.BDrawBorderBottom = true;
            this.LblTitleExpandView.BDrawBorderLeft = false;
            this.LblTitleExpandView.BDrawBorderRight = true;
            this.LblTitleExpandView.BDrawBorderTop = false;
            this.LblTitleExpandView.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleExpandView.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleExpandView.ForeColor = System.Drawing.Color.White;
            this.LblTitleExpandView.Location = new System.Drawing.Point(0, 0);
            this.LblTitleExpandView.Name = "LblTitleExpandView";
            this.LblTitleExpandView.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleExpandView.Size = new System.Drawing.Size(230, 28);
            this.LblTitleExpandView.TabIndex = 16;
            this.LblTitleExpandView.Text = "확장 화면";
            this.LblTitleExpandView.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlScale
            // 
            this.PnlScale.BDrawBorderBottom = true;
            this.PnlScale.BDrawBorderLeft = true;
            this.PnlScale.BDrawBorderRight = true;
            this.PnlScale.BDrawBorderTop = false;
            this.PnlScale.Controls.Add(this.ChkScaleEnabled);
            this.PnlScale.Controls.Add(this.TxtScaleHeight);
            this.PnlScale.Controls.Add(this.TxtScaleRealHeight);
            this.PnlScale.Controls.Add(this.TxtScaleRealWidth);
            this.PnlScale.Controls.Add(this.TxtScaleWidth);
            this.PnlScale.Controls.Add(this.BtnScaleInspect);
            this.PnlScale.Controls.Add(this.cLabel2);
            this.PnlScale.Controls.Add(this.LblTitleScaleHeight);
            this.PnlScale.Controls.Add(this.LblTitleScaleWidth);
            this.PnlScale.Controls.Add(this.LblTitleScaleEnabled);
            this.PnlScale.Controls.Add(this.LblTitleScale);
            this.PnlScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlScale.Location = new System.Drawing.Point(0, 180);
            this.PnlScale.Name = "PnlScale";
            this.PnlScale.Size = new System.Drawing.Size(230, 180);
            this.PnlScale.TabIndex = 17;
            // 
            // ChkScaleEnabled
            // 
            this.ChkScaleEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkScaleEnabled.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkScaleEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkScaleEnabled.ForeColor = System.Drawing.Color.White;
            this.ChkScaleEnabled.Location = new System.Drawing.Point(96, 28);
            this.ChkScaleEnabled.Name = "ChkScaleEnabled";
            this.ChkScaleEnabled.Size = new System.Drawing.Size(130, 28);
            this.ChkScaleEnabled.TabIndex = 40;
            this.ChkScaleEnabled.Text = "사용안함";
            this.ChkScaleEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkScaleEnabled.UseVisualStyleBackColor = false;
            this.ChkScaleEnabled.CheckedChanged += new System.EventHandler(this.ChkScaleEnabled_CheckedChanged);
            // 
            // TxtScaleHeight
            // 
            this.TxtScaleHeight.Enabled = false;
            this.TxtScaleHeight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtScaleHeight.Location = new System.Drawing.Point(96, 86);
            this.TxtScaleHeight.Name = "TxtScaleHeight";
            this.TxtScaleHeight.Size = new System.Drawing.Size(130, 25);
            this.TxtScaleHeight.TabIndex = 19;
            // 
            // TxtScaleRealHeight
            // 
            this.TxtScaleRealHeight.Enabled = false;
            this.TxtScaleRealHeight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtScaleRealHeight.Location = new System.Drawing.Point(164, 114);
            this.TxtScaleRealHeight.Name = "TxtScaleRealHeight";
            this.TxtScaleRealHeight.Size = new System.Drawing.Size(62, 25);
            this.TxtScaleRealHeight.TabIndex = 19;
            // 
            // TxtScaleRealWidth
            // 
            this.TxtScaleRealWidth.Enabled = false;
            this.TxtScaleRealWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtScaleRealWidth.Location = new System.Drawing.Point(96, 114);
            this.TxtScaleRealWidth.Name = "TxtScaleRealWidth";
            this.TxtScaleRealWidth.Size = new System.Drawing.Size(62, 25);
            this.TxtScaleRealWidth.TabIndex = 19;
            // 
            // TxtScaleWidth
            // 
            this.TxtScaleWidth.Enabled = false;
            this.TxtScaleWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtScaleWidth.Location = new System.Drawing.Point(96, 58);
            this.TxtScaleWidth.Name = "TxtScaleWidth";
            this.TxtScaleWidth.Size = new System.Drawing.Size(130, 25);
            this.TxtScaleWidth.TabIndex = 19;
            // 
            // BtnScaleInspect
            // 
            this.BtnScaleInspect.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnScaleInspect.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnScaleInspect.ForeColor = System.Drawing.Color.White;
            this.BtnScaleInspect.Location = new System.Drawing.Point(126, 142);
            this.BtnScaleInspect.Name = "BtnScaleInspect";
            this.BtnScaleInspect.Size = new System.Drawing.Size(100, 35);
            this.BtnScaleInspect.TabIndex = 23;
            this.BtnScaleInspect.Text = "검사";
            this.BtnScaleInspect.UseVisualStyleBackColor = false;
            this.BtnScaleInspect.Click += new System.EventHandler(this.BtnScaleInspect_Click);
            // 
            // cLabel2
            // 
            this.cLabel2.BackColor = System.Drawing.Color.DimGray;
            this.cLabel2.BDrawBorderBottom = true;
            this.cLabel2.BDrawBorderLeft = true;
            this.cLabel2.BDrawBorderRight = true;
            this.cLabel2.BDrawBorderTop = false;
            this.cLabel2.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.cLabel2.ForeColor = System.Drawing.Color.White;
            this.cLabel2.Location = new System.Drawing.Point(0, 112);
            this.cLabel2.Name = "cLabel2";
            this.cLabel2.OBorderColor = System.Drawing.Color.Black;
            this.cLabel2.Size = new System.Drawing.Size(90, 28);
            this.cLabel2.TabIndex = 17;
            this.cLabel2.Text = "결과 (mm)";
            this.cLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleScaleHeight
            // 
            this.LblTitleScaleHeight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleScaleHeight.BDrawBorderBottom = true;
            this.LblTitleScaleHeight.BDrawBorderLeft = true;
            this.LblTitleScaleHeight.BDrawBorderRight = true;
            this.LblTitleScaleHeight.BDrawBorderTop = false;
            this.LblTitleScaleHeight.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleScaleHeight.ForeColor = System.Drawing.Color.White;
            this.LblTitleScaleHeight.Location = new System.Drawing.Point(0, 84);
            this.LblTitleScaleHeight.Name = "LblTitleScaleHeight";
            this.LblTitleScaleHeight.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleScaleHeight.Size = new System.Drawing.Size(90, 28);
            this.LblTitleScaleHeight.TabIndex = 17;
            this.LblTitleScaleHeight.Text = "픽셀 세로";
            this.LblTitleScaleHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleScaleWidth
            // 
            this.LblTitleScaleWidth.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleScaleWidth.BDrawBorderBottom = true;
            this.LblTitleScaleWidth.BDrawBorderLeft = true;
            this.LblTitleScaleWidth.BDrawBorderRight = true;
            this.LblTitleScaleWidth.BDrawBorderTop = false;
            this.LblTitleScaleWidth.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleScaleWidth.ForeColor = System.Drawing.Color.White;
            this.LblTitleScaleWidth.Location = new System.Drawing.Point(0, 56);
            this.LblTitleScaleWidth.Name = "LblTitleScaleWidth";
            this.LblTitleScaleWidth.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleScaleWidth.Size = new System.Drawing.Size(90, 28);
            this.LblTitleScaleWidth.TabIndex = 18;
            this.LblTitleScaleWidth.Text = "픽셀 가로";
            this.LblTitleScaleWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleScaleEnabled
            // 
            this.LblTitleScaleEnabled.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleScaleEnabled.BDrawBorderBottom = true;
            this.LblTitleScaleEnabled.BDrawBorderLeft = true;
            this.LblTitleScaleEnabled.BDrawBorderRight = true;
            this.LblTitleScaleEnabled.BDrawBorderTop = false;
            this.LblTitleScaleEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleScaleEnabled.ForeColor = System.Drawing.Color.White;
            this.LblTitleScaleEnabled.Location = new System.Drawing.Point(0, 28);
            this.LblTitleScaleEnabled.Name = "LblTitleScaleEnabled";
            this.LblTitleScaleEnabled.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleScaleEnabled.Size = new System.Drawing.Size(90, 28);
            this.LblTitleScaleEnabled.TabIndex = 19;
            this.LblTitleScaleEnabled.Text = "사용 여부";
            this.LblTitleScaleEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleScale
            // 
            this.LblTitleScale.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleScale.BDrawBorderBottom = true;
            this.LblTitleScale.BDrawBorderLeft = false;
            this.LblTitleScale.BDrawBorderRight = true;
            this.LblTitleScale.BDrawBorderTop = false;
            this.LblTitleScale.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleScale.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleScale.ForeColor = System.Drawing.Color.White;
            this.LblTitleScale.Location = new System.Drawing.Point(0, 0);
            this.LblTitleScale.Name = "LblTitleScale";
            this.LblTitleScale.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleScale.Size = new System.Drawing.Size(230, 28);
            this.LblTitleScale.TabIndex = 16;
            this.LblTitleScale.Text = "실제 크기 측정";
            this.LblTitleScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlCalibration
            // 
            this.PnlCalibration.BDrawBorderBottom = true;
            this.PnlCalibration.BDrawBorderLeft = true;
            this.PnlCalibration.BDrawBorderRight = true;
            this.PnlCalibration.BDrawBorderTop = false;
            this.PnlCalibration.Controls.Add(this.ChkCalibEnabled);
            this.PnlCalibration.Controls.Add(this.BtnCalibApply);
            this.PnlCalibration.Controls.Add(this.TxtCalibPixelHeight);
            this.PnlCalibration.Controls.Add(this.TxtCalibPixelWidth);
            this.PnlCalibration.Controls.Add(this.BtnCalibInspect);
            this.PnlCalibration.Controls.Add(this.NudCalibHeight);
            this.PnlCalibration.Controls.Add(this.NudCalibWidth);
            this.PnlCalibration.Controls.Add(this.cLabel1);
            this.PnlCalibration.Controls.Add(this.LblCalibHeight);
            this.PnlCalibration.Controls.Add(this.LblTitleCalibWidth);
            this.PnlCalibration.Controls.Add(this.LblTitleCalibEnabled);
            this.PnlCalibration.Controls.Add(this.LblTitleCalibration);
            this.PnlCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlCalibration.Location = new System.Drawing.Point(0, 0);
            this.PnlCalibration.Name = "PnlCalibration";
            this.PnlCalibration.Size = new System.Drawing.Size(230, 180);
            this.PnlCalibration.TabIndex = 16;
            // 
            // ChkCalibEnabled
            // 
            this.ChkCalibEnabled.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkCalibEnabled.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkCalibEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkCalibEnabled.ForeColor = System.Drawing.Color.White;
            this.ChkCalibEnabled.Location = new System.Drawing.Point(96, 28);
            this.ChkCalibEnabled.Name = "ChkCalibEnabled";
            this.ChkCalibEnabled.Size = new System.Drawing.Size(130, 28);
            this.ChkCalibEnabled.TabIndex = 40;
            this.ChkCalibEnabled.Text = "사용안함";
            this.ChkCalibEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkCalibEnabled.UseVisualStyleBackColor = false;
            this.ChkCalibEnabled.CheckedChanged += new System.EventHandler(this.ChkCalibEnabled_CheckedChanged);
            // 
            // BtnCalibApply
            // 
            this.BtnCalibApply.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCalibApply.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCalibApply.ForeColor = System.Drawing.Color.White;
            this.BtnCalibApply.Location = new System.Drawing.Point(126, 142);
            this.BtnCalibApply.Name = "BtnCalibApply";
            this.BtnCalibApply.Size = new System.Drawing.Size(100, 35);
            this.BtnCalibApply.TabIndex = 23;
            this.BtnCalibApply.Text = "적용";
            this.BtnCalibApply.UseVisualStyleBackColor = false;
            this.BtnCalibApply.Click += new System.EventHandler(this.BtnCalibApply_Click);
            // 
            // TxtCalibPixelHeight
            // 
            this.TxtCalibPixelHeight.Enabled = false;
            this.TxtCalibPixelHeight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtCalibPixelHeight.Location = new System.Drawing.Point(164, 114);
            this.TxtCalibPixelHeight.Name = "TxtCalibPixelHeight";
            this.TxtCalibPixelHeight.Size = new System.Drawing.Size(62, 25);
            this.TxtCalibPixelHeight.TabIndex = 19;
            this.TxtCalibPixelHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // TxtCalibPixelWidth
            // 
            this.TxtCalibPixelWidth.Enabled = false;
            this.TxtCalibPixelWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtCalibPixelWidth.Location = new System.Drawing.Point(96, 114);
            this.TxtCalibPixelWidth.Name = "TxtCalibPixelWidth";
            this.TxtCalibPixelWidth.Size = new System.Drawing.Size(62, 25);
            this.TxtCalibPixelWidth.TabIndex = 19;
            this.TxtCalibPixelWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // BtnCalibInspect
            // 
            this.BtnCalibInspect.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCalibInspect.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCalibInspect.ForeColor = System.Drawing.Color.White;
            this.BtnCalibInspect.Location = new System.Drawing.Point(24, 142);
            this.BtnCalibInspect.Name = "BtnCalibInspect";
            this.BtnCalibInspect.Size = new System.Drawing.Size(100, 35);
            this.BtnCalibInspect.TabIndex = 23;
            this.BtnCalibInspect.Text = "검사";
            this.BtnCalibInspect.UseVisualStyleBackColor = false;
            this.BtnCalibInspect.Click += new System.EventHandler(this.BtnCalibInspect_Click);
            // 
            // NudCalibHeight
            // 
            this.NudCalibHeight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudCalibHeight.Location = new System.Drawing.Point(96, 86);
            this.NudCalibHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudCalibHeight.Name = "NudCalibHeight";
            this.NudCalibHeight.Size = new System.Drawing.Size(130, 25);
            this.NudCalibHeight.TabIndex = 22;
            this.NudCalibHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // NudCalibWidth
            // 
            this.NudCalibWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudCalibWidth.Location = new System.Drawing.Point(96, 58);
            this.NudCalibWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudCalibWidth.Name = "NudCalibWidth";
            this.NudCalibWidth.Size = new System.Drawing.Size(130, 25);
            this.NudCalibWidth.TabIndex = 21;
            this.NudCalibWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cLabel1
            // 
            this.cLabel1.BackColor = System.Drawing.Color.DimGray;
            this.cLabel1.BDrawBorderBottom = true;
            this.cLabel1.BDrawBorderLeft = true;
            this.cLabel1.BDrawBorderRight = true;
            this.cLabel1.BDrawBorderTop = false;
            this.cLabel1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.cLabel1.ForeColor = System.Drawing.Color.White;
            this.cLabel1.Location = new System.Drawing.Point(0, 112);
            this.cLabel1.Name = "cLabel1";
            this.cLabel1.OBorderColor = System.Drawing.Color.Black;
            this.cLabel1.Size = new System.Drawing.Size(90, 28);
            this.cLabel1.TabIndex = 17;
            this.cLabel1.Text = "결과 (mm)";
            this.cLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblCalibHeight
            // 
            this.LblCalibHeight.BackColor = System.Drawing.Color.DimGray;
            this.LblCalibHeight.BDrawBorderBottom = true;
            this.LblCalibHeight.BDrawBorderLeft = true;
            this.LblCalibHeight.BDrawBorderRight = true;
            this.LblCalibHeight.BDrawBorderTop = false;
            this.LblCalibHeight.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblCalibHeight.ForeColor = System.Drawing.Color.White;
            this.LblCalibHeight.Location = new System.Drawing.Point(0, 84);
            this.LblCalibHeight.Name = "LblCalibHeight";
            this.LblCalibHeight.OBorderColor = System.Drawing.Color.Black;
            this.LblCalibHeight.Size = new System.Drawing.Size(90, 28);
            this.LblCalibHeight.TabIndex = 17;
            this.LblCalibHeight.Text = "세로 (mm)";
            this.LblCalibHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCalibWidth
            // 
            this.LblTitleCalibWidth.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCalibWidth.BDrawBorderBottom = true;
            this.LblTitleCalibWidth.BDrawBorderLeft = true;
            this.LblTitleCalibWidth.BDrawBorderRight = true;
            this.LblTitleCalibWidth.BDrawBorderTop = false;
            this.LblTitleCalibWidth.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCalibWidth.ForeColor = System.Drawing.Color.White;
            this.LblTitleCalibWidth.Location = new System.Drawing.Point(0, 56);
            this.LblTitleCalibWidth.Name = "LblTitleCalibWidth";
            this.LblTitleCalibWidth.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCalibWidth.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCalibWidth.TabIndex = 18;
            this.LblTitleCalibWidth.Text = "가로 (mm)";
            this.LblTitleCalibWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCalibEnabled
            // 
            this.LblTitleCalibEnabled.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCalibEnabled.BDrawBorderBottom = true;
            this.LblTitleCalibEnabled.BDrawBorderLeft = true;
            this.LblTitleCalibEnabled.BDrawBorderRight = true;
            this.LblTitleCalibEnabled.BDrawBorderTop = false;
            this.LblTitleCalibEnabled.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCalibEnabled.ForeColor = System.Drawing.Color.White;
            this.LblTitleCalibEnabled.Location = new System.Drawing.Point(0, 28);
            this.LblTitleCalibEnabled.Name = "LblTitleCalibEnabled";
            this.LblTitleCalibEnabled.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCalibEnabled.Size = new System.Drawing.Size(90, 28);
            this.LblTitleCalibEnabled.TabIndex = 19;
            this.LblTitleCalibEnabled.Text = "사용 여부";
            this.LblTitleCalibEnabled.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleCalibration
            // 
            this.LblTitleCalibration.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleCalibration.BDrawBorderBottom = true;
            this.LblTitleCalibration.BDrawBorderLeft = true;
            this.LblTitleCalibration.BDrawBorderRight = true;
            this.LblTitleCalibration.BDrawBorderTop = false;
            this.LblTitleCalibration.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCalibration.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCalibration.ForeColor = System.Drawing.Color.White;
            this.LblTitleCalibration.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCalibration.Name = "LblTitleCalibration";
            this.LblTitleCalibration.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCalibration.Size = new System.Drawing.Size(230, 28);
            this.LblTitleCalibration.TabIndex = 16;
            this.LblTitleCalibration.Text = "픽셀 크기 측정";
            this.LblTitleCalibration.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // UcCalibration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlExpandView);
            this.Controls.Add(this.PnlScale);
            this.Controls.Add(this.PnlCalibration);
            this.Name = "UcCalibration";
            this.PnlExpandView.ResumeLayout(false);
            this.PnlScale.ResumeLayout(false);
            this.PnlScale.PerformLayout();
            this.PnlCalibration.ResumeLayout(false);
            this.PnlCalibration.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudCalibHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCalibWidth)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlCalibration;
        private System.Windows.Forms.Button BtnCalibInspect;
        private System.Windows.Forms.NumericUpDown NudCalibHeight;
        private System.Windows.Forms.NumericUpDown NudCalibWidth;
        private Jhjo.Component.CLabel LblCalibHeight;
        private Jhjo.Component.CLabel LblTitleCalibWidth;
        private Jhjo.Component.CLabel LblTitleCalibEnabled;
        private Jhjo.Component.CLabel LblTitleCalibration;
        private System.Windows.Forms.Button BtnCalibApply;
        private Jhjo.Component.CPanel PnlScale;
        private System.Windows.Forms.Button BtnScaleInspect;
        private Jhjo.Component.CLabel LblTitleScaleHeight;
        private Jhjo.Component.CLabel LblTitleScaleWidth;
        private Jhjo.Component.CLabel LblTitleScaleEnabled;
        private Jhjo.Component.CLabel LblTitleScale;
        private Jhjo.Component.CPanel PnlExpandView;
        private System.Windows.Forms.CheckBox ChkExpandView;
        private Jhjo.Component.CLabel LblTitleExpandView;
        private System.Windows.Forms.TextBox TxtScaleHeight;
        private System.Windows.Forms.TextBox TxtScaleWidth;
        private Jhjo.Component.CLabel cLabel1;
        private System.Windows.Forms.TextBox TxtCalibPixelHeight;
        private System.Windows.Forms.TextBox TxtCalibPixelWidth;
        private System.Windows.Forms.CheckBox ChkCalibEnabled;
        private System.Windows.Forms.CheckBox ChkScaleEnabled;
        private System.Windows.Forms.TextBox TxtScaleRealHeight;
        private System.Windows.Forms.TextBox TxtScaleRealWidth;
        private Jhjo.Component.CLabel cLabel2;
    }
}

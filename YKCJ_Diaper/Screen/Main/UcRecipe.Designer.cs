namespace YKCJ_Diaper
{
    partial class UcRecipe
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcRecipe));
            this.PnlRight = new Jhjo.Component.CPanel();
            this.PnlImage = new Jhjo.Component.CPanel();
            this.CdpDisplayer = new Cognex.VisionPro.Display.CogDisplay();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.ChkMoveAll = new System.Windows.Forms.CheckBox();
            this.BtnToolModify = new System.Windows.Forms.Button();
            this.BtnLoadImage = new System.Windows.Forms.Button();
            this.BtnToolUpdate = new System.Windows.Forms.Button();
            this.BtnRight10 = new System.Windows.Forms.Button();
            this.BtnBottom1 = new System.Windows.Forms.Button();
            this.BtnTop1 = new System.Windows.Forms.Button();
            this.BtnLeft1 = new System.Windows.Forms.Button();
            this.BtnRight1 = new System.Windows.Forms.Button();
            this.BtnBottom10 = new System.Windows.Forms.Button();
            this.BtnTop10 = new System.Windows.Forms.Button();
            this.BtnLeft10 = new System.Windows.Forms.Button();
            this.BtnCenterLine = new System.Windows.Forms.Button();
            this.PnlLeft = new Jhjo.Component.CPanel();
            this.PnlRecipe = new Jhjo.Component.CPanel();
            this.PnlScreen = new Jhjo.Component.CPanel();
            this.PnlNavigator = new Jhjo.Component.CPanel();
            this.BtnMDCD = new System.Windows.Forms.Button();
            this.BtnETC = new System.Windows.Forms.Button();
            this.BtnPattern = new System.Windows.Forms.Button();
            this.BtnBlob = new System.Windows.Forms.Button();
            this.PnlRecipeList = new Jhjo.Component.CPanel();
            this.LtbRecipe = new System.Windows.Forms.ListBox();
            this.PnlRecipeEdit = new Jhjo.Component.CPanel();
            this.BtnDelete = new System.Windows.Forms.Button();
            this.BtnAdd = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.LblTitleRecipeList = new Jhjo.Component.CLabel();
            this.ChkDisplayAll = new System.Windows.Forms.CheckBox();
            this.PnlRight.SuspendLayout();
            this.PnlImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).BeginInit();
            this.PnlButton.SuspendLayout();
            this.PnlLeft.SuspendLayout();
            this.PnlRecipe.SuspendLayout();
            this.PnlNavigator.SuspendLayout();
            this.PnlRecipeList.SuspendLayout();
            this.PnlRecipeEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlRight
            // 
            this.PnlRight.BDrawBorderBottom = false;
            this.PnlRight.BDrawBorderLeft = false;
            this.PnlRight.BDrawBorderRight = false;
            this.PnlRight.BDrawBorderTop = false;
            this.PnlRight.Controls.Add(this.PnlImage);
            this.PnlRight.Controls.Add(this.PnlButton);
            this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRight.Location = new System.Drawing.Point(230, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(350, 672);
            this.PnlRight.TabIndex = 1;
            // 
            // PnlImage
            // 
            this.PnlImage.BDrawBorderBottom = false;
            this.PnlImage.BDrawBorderLeft = false;
            this.PnlImage.BDrawBorderRight = false;
            this.PnlImage.BDrawBorderTop = false;
            this.PnlImage.Controls.Add(this.CdpDisplayer);
            this.PnlImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlImage.Location = new System.Drawing.Point(0, 0);
            this.PnlImage.Name = "PnlImage";
            this.PnlImage.Size = new System.Drawing.Size(350, 481);
            this.PnlImage.TabIndex = 0;
            // 
            // CdpDisplayer
            // 
            this.CdpDisplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpDisplayer.Location = new System.Drawing.Point(0, 0);
            this.CdpDisplayer.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpDisplayer.MouseWheelSensitivity = 1D;
            this.CdpDisplayer.Name = "CdpDisplayer";
            this.CdpDisplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpDisplayer.OcxState")));
            this.CdpDisplayer.Size = new System.Drawing.Size(350, 481);
            this.CdpDisplayer.TabIndex = 0;
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = false;
            this.PnlButton.Controls.Add(this.ChkDisplayAll);
            this.PnlButton.Controls.Add(this.ChkMoveAll);
            this.PnlButton.Controls.Add(this.BtnToolModify);
            this.PnlButton.Controls.Add(this.BtnLoadImage);
            this.PnlButton.Controls.Add(this.BtnToolUpdate);
            this.PnlButton.Controls.Add(this.BtnRight10);
            this.PnlButton.Controls.Add(this.BtnBottom1);
            this.PnlButton.Controls.Add(this.BtnTop1);
            this.PnlButton.Controls.Add(this.BtnLeft1);
            this.PnlButton.Controls.Add(this.BtnRight1);
            this.PnlButton.Controls.Add(this.BtnBottom10);
            this.PnlButton.Controls.Add(this.BtnTop10);
            this.PnlButton.Controls.Add(this.BtnLeft10);
            this.PnlButton.Controls.Add(this.BtnCenterLine);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 481);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(350, 191);
            this.PnlButton.TabIndex = 1;
            // 
            // ChkMoveAll
            // 
            this.ChkMoveAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkMoveAll.BackColor = System.Drawing.Color.SteelBlue;
            this.ChkMoveAll.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkMoveAll.ForeColor = System.Drawing.Color.White;
            this.ChkMoveAll.Location = new System.Drawing.Point(292, 3);
            this.ChkMoveAll.Name = "ChkMoveAll";
            this.ChkMoveAll.Size = new System.Drawing.Size(53, 60);
            this.ChkMoveAll.TabIndex = 41;
            this.ChkMoveAll.Text = "전체 이동";
            this.ChkMoveAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkMoveAll.UseVisualStyleBackColor = false;
            this.ChkMoveAll.CheckedChanged += new System.EventHandler(this.ChkAll_CheckedChanged);
            // 
            // BtnToolModify
            // 
            this.BtnToolModify.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnToolModify.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnToolModify.ForeColor = System.Drawing.Color.White;
            this.BtnToolModify.Location = new System.Drawing.Point(235, 127);
            this.BtnToolModify.Name = "BtnToolModify";
            this.BtnToolModify.Size = new System.Drawing.Size(110, 60);
            this.BtnToolModify.TabIndex = 9;
            this.BtnToolModify.Text = "모델 수정";
            this.BtnToolModify.UseVisualStyleBackColor = false;
            this.BtnToolModify.Click += new System.EventHandler(this.BtnToolModify_Click);
            this.BtnToolModify.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseDown);
            this.BtnToolModify.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseUp);
            // 
            // BtnLoadImage
            // 
            this.BtnLoadImage.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnLoadImage.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnLoadImage.ForeColor = System.Drawing.Color.White;
            this.BtnLoadImage.Location = new System.Drawing.Point(120, 65);
            this.BtnLoadImage.Name = "BtnLoadImage";
            this.BtnLoadImage.Size = new System.Drawing.Size(110, 60);
            this.BtnLoadImage.TabIndex = 9;
            this.BtnLoadImage.Text = "이미지  교체";
            this.BtnLoadImage.UseVisualStyleBackColor = false;
            this.BtnLoadImage.Click += new System.EventHandler(this.BtnLoadImage_Click);
            this.BtnLoadImage.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseDown);
            this.BtnLoadImage.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseUp);
            // 
            // BtnToolUpdate
            // 
            this.BtnToolUpdate.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnToolUpdate.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnToolUpdate.ForeColor = System.Drawing.Color.White;
            this.BtnToolUpdate.Location = new System.Drawing.Point(5, 127);
            this.BtnToolUpdate.Name = "BtnToolUpdate";
            this.BtnToolUpdate.Size = new System.Drawing.Size(110, 60);
            this.BtnToolUpdate.TabIndex = 9;
            this.BtnToolUpdate.Text = "모델 적용";
            this.BtnToolUpdate.UseVisualStyleBackColor = false;
            this.BtnToolUpdate.Click += new System.EventHandler(this.BtnToolUpdate_Click);
            this.BtnToolUpdate.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseDown);
            this.BtnToolUpdate.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BtnClick_MouseUp);
            // 
            // BtnRight10
            // 
            this.BtnRight10.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRight10.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRight10.ForeColor = System.Drawing.Color.White;
            this.BtnRight10.Location = new System.Drawing.Point(292, 65);
            this.BtnRight10.Name = "BtnRight10";
            this.BtnRight10.Size = new System.Drawing.Size(53, 60);
            this.BtnRight10.TabIndex = 9;
            this.BtnRight10.Tag = "RIGHT";
            this.BtnRight10.Text = "▶";
            this.BtnRight10.UseVisualStyleBackColor = false;
            this.BtnRight10.Click += new System.EventHandler(this.BtnMove10_Click);
            // 
            // BtnBottom1
            // 
            this.BtnBottom1.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBottom1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnBottom1.ForeColor = System.Drawing.Color.White;
            this.BtnBottom1.Location = new System.Drawing.Point(177, 127);
            this.BtnBottom1.Name = "BtnBottom1";
            this.BtnBottom1.Size = new System.Drawing.Size(53, 60);
            this.BtnBottom1.TabIndex = 9;
            this.BtnBottom1.Tag = "BOTTOM";
            this.BtnBottom1.Text = "↓";
            this.BtnBottom1.UseVisualStyleBackColor = false;
            this.BtnBottom1.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnTop1
            // 
            this.BtnTop1.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnTop1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnTop1.ForeColor = System.Drawing.Color.White;
            this.BtnTop1.Location = new System.Drawing.Point(177, 3);
            this.BtnTop1.Name = "BtnTop1";
            this.BtnTop1.Size = new System.Drawing.Size(53, 60);
            this.BtnTop1.TabIndex = 9;
            this.BtnTop1.Tag = "TOP";
            this.BtnTop1.Text = "↑";
            this.BtnTop1.UseVisualStyleBackColor = false;
            this.BtnTop1.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnLeft1
            // 
            this.BtnLeft1.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnLeft1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnLeft1.ForeColor = System.Drawing.Color.White;
            this.BtnLeft1.Location = new System.Drawing.Point(62, 65);
            this.BtnLeft1.Name = "BtnLeft1";
            this.BtnLeft1.Size = new System.Drawing.Size(53, 60);
            this.BtnLeft1.TabIndex = 9;
            this.BtnLeft1.Tag = "LEFT";
            this.BtnLeft1.Text = "←";
            this.BtnLeft1.UseVisualStyleBackColor = false;
            this.BtnLeft1.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnRight1
            // 
            this.BtnRight1.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRight1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRight1.ForeColor = System.Drawing.Color.White;
            this.BtnRight1.Location = new System.Drawing.Point(235, 65);
            this.BtnRight1.Name = "BtnRight1";
            this.BtnRight1.Size = new System.Drawing.Size(53, 60);
            this.BtnRight1.TabIndex = 9;
            this.BtnRight1.Tag = "RIGHT";
            this.BtnRight1.Text = "→";
            this.BtnRight1.UseVisualStyleBackColor = false;
            this.BtnRight1.Click += new System.EventHandler(this.BtnMove_Click);
            // 
            // BtnBottom10
            // 
            this.BtnBottom10.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBottom10.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnBottom10.ForeColor = System.Drawing.Color.White;
            this.BtnBottom10.Location = new System.Drawing.Point(120, 127);
            this.BtnBottom10.Name = "BtnBottom10";
            this.BtnBottom10.Size = new System.Drawing.Size(53, 60);
            this.BtnBottom10.TabIndex = 9;
            this.BtnBottom10.Tag = "BOTTOM";
            this.BtnBottom10.Text = "▼";
            this.BtnBottom10.UseVisualStyleBackColor = false;
            this.BtnBottom10.Click += new System.EventHandler(this.BtnMove10_Click);
            // 
            // BtnTop10
            // 
            this.BtnTop10.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnTop10.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnTop10.ForeColor = System.Drawing.Color.White;
            this.BtnTop10.Location = new System.Drawing.Point(120, 3);
            this.BtnTop10.Name = "BtnTop10";
            this.BtnTop10.Size = new System.Drawing.Size(53, 60);
            this.BtnTop10.TabIndex = 9;
            this.BtnTop10.Tag = "TOP";
            this.BtnTop10.Text = "▲";
            this.BtnTop10.UseVisualStyleBackColor = false;
            this.BtnTop10.Click += new System.EventHandler(this.BtnMove10_Click);
            // 
            // BtnLeft10
            // 
            this.BtnLeft10.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnLeft10.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnLeft10.ForeColor = System.Drawing.Color.White;
            this.BtnLeft10.Location = new System.Drawing.Point(5, 65);
            this.BtnLeft10.Name = "BtnLeft10";
            this.BtnLeft10.Size = new System.Drawing.Size(53, 60);
            this.BtnLeft10.TabIndex = 9;
            this.BtnLeft10.Tag = "LEFT";
            this.BtnLeft10.Text = "◀";
            this.BtnLeft10.UseVisualStyleBackColor = false;
            this.BtnLeft10.Click += new System.EventHandler(this.BtnMove10_Click);
            // 
            // BtnCenterLine
            // 
            this.BtnCenterLine.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCenterLine.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCenterLine.ForeColor = System.Drawing.Color.White;
            this.BtnCenterLine.Location = new System.Drawing.Point(5, 3);
            this.BtnCenterLine.Name = "BtnCenterLine";
            this.BtnCenterLine.Size = new System.Drawing.Size(110, 60);
            this.BtnCenterLine.TabIndex = 9;
            this.BtnCenterLine.Text = "중앙라인";
            this.BtnCenterLine.UseVisualStyleBackColor = false;
            this.BtnCenterLine.Click += new System.EventHandler(this.BtnCenterLine_Click);
            // 
            // PnlLeft
            // 
            this.PnlLeft.BDrawBorderBottom = false;
            this.PnlLeft.BDrawBorderLeft = false;
            this.PnlLeft.BDrawBorderRight = false;
            this.PnlLeft.BDrawBorderTop = false;
            this.PnlLeft.Controls.Add(this.PnlRecipe);
            this.PnlLeft.Controls.Add(this.PnlRecipeList);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(230, 672);
            this.PnlLeft.TabIndex = 0;
            // 
            // PnlRecipe
            // 
            this.PnlRecipe.BDrawBorderBottom = false;
            this.PnlRecipe.BDrawBorderLeft = false;
            this.PnlRecipe.BDrawBorderRight = false;
            this.PnlRecipe.BDrawBorderTop = false;
            this.PnlRecipe.Controls.Add(this.PnlScreen);
            this.PnlRecipe.Controls.Add(this.PnlNavigator);
            this.PnlRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRecipe.Location = new System.Drawing.Point(0, 0);
            this.PnlRecipe.Name = "PnlRecipe";
            this.PnlRecipe.Size = new System.Drawing.Size(230, 526);
            this.PnlRecipe.TabIndex = 1;
            // 
            // PnlScreen
            // 
            this.PnlScreen.BDrawBorderBottom = false;
            this.PnlScreen.BDrawBorderLeft = false;
            this.PnlScreen.BDrawBorderRight = false;
            this.PnlScreen.BDrawBorderTop = false;
            this.PnlScreen.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlScreen.Location = new System.Drawing.Point(0, 0);
            this.PnlScreen.Name = "PnlScreen";
            this.PnlScreen.Size = new System.Drawing.Size(230, 452);
            this.PnlScreen.TabIndex = 3;
            // 
            // PnlNavigator
            // 
            this.PnlNavigator.BDrawBorderBottom = false;
            this.PnlNavigator.BDrawBorderLeft = true;
            this.PnlNavigator.BDrawBorderRight = true;
            this.PnlNavigator.BDrawBorderTop = true;
            this.PnlNavigator.Controls.Add(this.BtnMDCD);
            this.PnlNavigator.Controls.Add(this.BtnETC);
            this.PnlNavigator.Controls.Add(this.BtnPattern);
            this.PnlNavigator.Controls.Add(this.BtnBlob);
            this.PnlNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlNavigator.Location = new System.Drawing.Point(0, 452);
            this.PnlNavigator.Name = "PnlNavigator";
            this.PnlNavigator.Size = new System.Drawing.Size(230, 74);
            this.PnlNavigator.TabIndex = 2;
            // 
            // BtnMDCD
            // 
            this.BtnMDCD.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnMDCD.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnMDCD.ForeColor = System.Drawing.Color.White;
            this.BtnMDCD.Location = new System.Drawing.Point(4, 38);
            this.BtnMDCD.Name = "BtnMDCD";
            this.BtnMDCD.Size = new System.Drawing.Size(110, 35);
            this.BtnMDCD.TabIndex = 9;
            this.BtnMDCD.Text = "자동 Align";
            this.BtnMDCD.UseVisualStyleBackColor = false;
            this.BtnMDCD.Click += new System.EventHandler(this.BtnMDCD_Click);
            // 
            // BtnETC
            // 
            this.BtnETC.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnETC.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnETC.ForeColor = System.Drawing.Color.White;
            this.BtnETC.Location = new System.Drawing.Point(117, 38);
            this.BtnETC.Name = "BtnETC";
            this.BtnETC.Size = new System.Drawing.Size(110, 35);
            this.BtnETC.TabIndex = 9;
            this.BtnETC.Text = "기타 설정";
            this.BtnETC.UseVisualStyleBackColor = false;
            this.BtnETC.Click += new System.EventHandler(this.BtnETC_Click);
            // 
            // BtnPattern
            // 
            this.BtnPattern.BackColor = System.Drawing.SystemColors.Control;
            this.BtnPattern.Enabled = false;
            this.BtnPattern.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnPattern.ForeColor = System.Drawing.Color.White;
            this.BtnPattern.Location = new System.Drawing.Point(117, 2);
            this.BtnPattern.Name = "BtnPattern";
            this.BtnPattern.Size = new System.Drawing.Size(110, 35);
            this.BtnPattern.TabIndex = 9;
            this.BtnPattern.Text = "패턴";
            this.BtnPattern.UseVisualStyleBackColor = false;
            this.BtnPattern.Click += new System.EventHandler(this.BtnPattern_Click);
            // 
            // BtnBlob
            // 
            this.BtnBlob.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnBlob.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnBlob.ForeColor = System.Drawing.Color.White;
            this.BtnBlob.Location = new System.Drawing.Point(4, 2);
            this.BtnBlob.Name = "BtnBlob";
            this.BtnBlob.Size = new System.Drawing.Size(110, 35);
            this.BtnBlob.TabIndex = 9;
            this.BtnBlob.Text = "블랍";
            this.BtnBlob.UseVisualStyleBackColor = false;
            this.BtnBlob.Click += new System.EventHandler(this.BtnBlob_Click);
            // 
            // PnlRecipeList
            // 
            this.PnlRecipeList.BDrawBorderBottom = false;
            this.PnlRecipeList.BDrawBorderLeft = false;
            this.PnlRecipeList.BDrawBorderRight = false;
            this.PnlRecipeList.BDrawBorderTop = false;
            this.PnlRecipeList.Controls.Add(this.LtbRecipe);
            this.PnlRecipeList.Controls.Add(this.PnlRecipeEdit);
            this.PnlRecipeList.Controls.Add(this.LblTitleRecipeList);
            this.PnlRecipeList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlRecipeList.Location = new System.Drawing.Point(0, 526);
            this.PnlRecipeList.Name = "PnlRecipeList";
            this.PnlRecipeList.Size = new System.Drawing.Size(230, 146);
            this.PnlRecipeList.TabIndex = 0;
            // 
            // LtbRecipe
            // 
            this.LtbRecipe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LtbRecipe.Font = new System.Drawing.Font("맑은 고딕", 8F);
            this.LtbRecipe.FormattingEnabled = true;
            this.LtbRecipe.IntegralHeight = false;
            this.LtbRecipe.Location = new System.Drawing.Point(0, 28);
            this.LtbRecipe.Name = "LtbRecipe";
            this.LtbRecipe.Size = new System.Drawing.Size(230, 78);
            this.LtbRecipe.TabIndex = 7;
            this.LtbRecipe.SelectedIndexChanged += new System.EventHandler(this.LtbRecipe_SelectedIndexChanged);
            // 
            // PnlRecipeEdit
            // 
            this.PnlRecipeEdit.BDrawBorderBottom = false;
            this.PnlRecipeEdit.BDrawBorderLeft = true;
            this.PnlRecipeEdit.BDrawBorderRight = true;
            this.PnlRecipeEdit.BDrawBorderTop = false;
            this.PnlRecipeEdit.Controls.Add(this.BtnDelete);
            this.PnlRecipeEdit.Controls.Add(this.BtnAdd);
            this.PnlRecipeEdit.Controls.Add(this.BtnCopy);
            this.PnlRecipeEdit.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlRecipeEdit.Location = new System.Drawing.Point(0, 106);
            this.PnlRecipeEdit.Name = "PnlRecipeEdit";
            this.PnlRecipeEdit.Size = new System.Drawing.Size(230, 40);
            this.PnlRecipeEdit.TabIndex = 8;
            // 
            // BtnDelete
            // 
            this.BtnDelete.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnDelete.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnDelete.ForeColor = System.Drawing.Color.White;
            this.BtnDelete.Location = new System.Drawing.Point(154, 3);
            this.BtnDelete.Name = "BtnDelete";
            this.BtnDelete.Size = new System.Drawing.Size(75, 35);
            this.BtnDelete.TabIndex = 9;
            this.BtnDelete.Text = "삭제";
            this.BtnDelete.UseVisualStyleBackColor = false;
            this.BtnDelete.Click += new System.EventHandler(this.BtnDelete_Click);
            // 
            // BtnAdd
            // 
            this.BtnAdd.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnAdd.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnAdd.ForeColor = System.Drawing.Color.White;
            this.BtnAdd.Location = new System.Drawing.Point(2, 3);
            this.BtnAdd.Name = "BtnAdd";
            this.BtnAdd.Size = new System.Drawing.Size(75, 35);
            this.BtnAdd.TabIndex = 9;
            this.BtnAdd.Text = "추가";
            this.BtnAdd.UseVisualStyleBackColor = false;
            this.BtnAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCopy.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCopy.ForeColor = System.Drawing.Color.White;
            this.BtnCopy.Location = new System.Drawing.Point(78, 3);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(75, 35);
            this.BtnCopy.TabIndex = 9;
            this.BtnCopy.Text = "복사";
            this.BtnCopy.UseVisualStyleBackColor = false;
            this.BtnCopy.Click += new System.EventHandler(this.BtnCopy_Click);
            // 
            // LblTitleRecipeList
            // 
            this.LblTitleRecipeList.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRecipeList.BDrawBorderBottom = true;
            this.LblTitleRecipeList.BDrawBorderLeft = false;
            this.LblTitleRecipeList.BDrawBorderRight = true;
            this.LblTitleRecipeList.BDrawBorderTop = true;
            this.LblTitleRecipeList.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleRecipeList.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRecipeList.ForeColor = System.Drawing.Color.White;
            this.LblTitleRecipeList.Location = new System.Drawing.Point(0, 0);
            this.LblTitleRecipeList.Name = "LblTitleRecipeList";
            this.LblTitleRecipeList.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRecipeList.Size = new System.Drawing.Size(230, 28);
            this.LblTitleRecipeList.TabIndex = 5;
            this.LblTitleRecipeList.Text = "모델 목록";
            this.LblTitleRecipeList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ChkDisplayAll
            // 
            this.ChkDisplayAll.Appearance = System.Windows.Forms.Appearance.Button;
            this.ChkDisplayAll.BackColor = System.Drawing.Color.ForestGreen;
            this.ChkDisplayAll.Checked = true;
            this.ChkDisplayAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ChkDisplayAll.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.ChkDisplayAll.ForeColor = System.Drawing.Color.White;
            this.ChkDisplayAll.Location = new System.Drawing.Point(235, 3);
            this.ChkDisplayAll.Name = "ChkDisplayAll";
            this.ChkDisplayAll.Size = new System.Drawing.Size(53, 60);
            this.ChkDisplayAll.TabIndex = 41;
            this.ChkDisplayAll.Text = "전체 표현";
            this.ChkDisplayAll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ChkDisplayAll.UseVisualStyleBackColor = false;
            this.ChkDisplayAll.CheckedChanged += new System.EventHandler(this.ChkDisplayAll_CheckedChanged);
            // 
            // UcRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlRight);
            this.Controls.Add(this.PnlLeft);
            this.Name = "UcRecipe";
            this.Size = new System.Drawing.Size(580, 672);
            this.PnlRight.ResumeLayout(false);
            this.PnlImage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).EndInit();
            this.PnlButton.ResumeLayout(false);
            this.PnlLeft.ResumeLayout(false);
            this.PnlRecipe.ResumeLayout(false);
            this.PnlNavigator.ResumeLayout(false);
            this.PnlRecipeList.ResumeLayout(false);
            this.PnlRecipeEdit.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlLeft;
        private Jhjo.Component.CPanel PnlRight;
        private Jhjo.Component.CPanel PnlImage;
        private Cognex.VisionPro.Display.CogDisplay CdpDisplayer;
        private Jhjo.Component.CPanel PnlButton;
        private System.Windows.Forms.Button BtnToolModify;
        private System.Windows.Forms.Button BtnLoadImage;
        private System.Windows.Forms.Button BtnToolUpdate;
        private System.Windows.Forms.Button BtnLeft10;
        private System.Windows.Forms.Button BtnCenterLine;
        private Jhjo.Component.CPanel PnlNavigator;
        private System.Windows.Forms.Button BtnETC;
        private System.Windows.Forms.Button BtnPattern;
        private System.Windows.Forms.Button BtnBlob;
        private Jhjo.Component.CPanel PnlRecipeList;
        private Jhjo.Component.CLabel LblTitleRecipeList;
        private System.Windows.Forms.ListBox LtbRecipe;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnDelete;
        private System.Windows.Forms.Button BtnAdd;
        private Jhjo.Component.CPanel PnlRecipe;
        private Jhjo.Component.CPanel PnlScreen;
        private System.Windows.Forms.Button BtnMDCD;
        private Jhjo.Component.CPanel PnlRecipeEdit;
        private System.Windows.Forms.CheckBox ChkMoveAll;
        private System.Windows.Forms.Button BtnLeft1;
        private System.Windows.Forms.Button BtnRight10;
        private System.Windows.Forms.Button BtnBottom1;
        private System.Windows.Forms.Button BtnTop1;
        private System.Windows.Forms.Button BtnRight1;
        private System.Windows.Forms.Button BtnBottom10;
        private System.Windows.Forms.Button BtnTop10;
        private System.Windows.Forms.CheckBox ChkDisplayAll;
    }
}

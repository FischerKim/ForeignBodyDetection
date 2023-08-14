namespace YKCJ_Diaper
{
    partial class frmMain
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.PnlTop = new Jhjo.Component.CPanel();
            this.LblTime = new Jhjo.Component.CLabel();
            this.BtnMinimize = new System.Windows.Forms.Button();
            this.LblReject = new Jhjo.Component.CLabel();
            this.LblProduct = new Jhjo.Component.CLabel();
            this.LblRecipe = new Jhjo.Component.CLabel();
            this.LblInspObject = new Jhjo.Component.CLabel();
            this.LblTitleRecipe = new Jhjo.Component.CLabel();
            this.LblMachine = new Jhjo.Component.CLabel();
            this.LblTitleInspObject = new Jhjo.Component.CLabel();
            this.LblTitleMachine = new Jhjo.Component.CLabel();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlNavigator = new Jhjo.Component.CPanel();
            this.BtnExit = new System.Windows.Forms.Button();
            this.BtnReport = new System.Windows.Forms.Button();
            this.BtnSubStance = new System.Windows.Forms.Button();
            this.BtnIO = new System.Windows.Forms.Button();
            this.BtnSetup = new System.Windows.Forms.Button();
            this.BtnRecipe = new System.Windows.Forms.Button();
            this.BtnHome = new System.Windows.Forms.Button();
            this.PnlBody = new Jhjo.Component.CPanel();
            this.Timer1000 = new System.Windows.Forms.Timer(this.components);
            this.PnlTop.SuspendLayout();
            this.PnlNavigator.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BDrawBorderBottom = false;
            this.PnlTop.BDrawBorderLeft = false;
            this.PnlTop.BDrawBorderRight = false;
            this.PnlTop.BDrawBorderTop = false;
            this.PnlTop.Controls.Add(this.LblTime);
            this.PnlTop.Controls.Add(this.BtnMinimize);
            this.PnlTop.Controls.Add(this.LblReject);
            this.PnlTop.Controls.Add(this.LblProduct);
            this.PnlTop.Controls.Add(this.LblRecipe);
            this.PnlTop.Controls.Add(this.LblInspObject);
            this.PnlTop.Controls.Add(this.LblTitleRecipe);
            this.PnlTop.Controls.Add(this.LblMachine);
            this.PnlTop.Controls.Add(this.LblTitleInspObject);
            this.PnlTop.Controls.Add(this.LblTitleMachine);
            this.PnlTop.Controls.Add(this.LblTitle);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(1024, 56);
            this.PnlTop.TabIndex = 0;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTime.BDrawBorderBottom = false;
            this.LblTime.BDrawBorderLeft = false;
            this.LblTime.BDrawBorderRight = true;
            this.LblTime.BDrawBorderTop = false;
            this.LblTime.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTime.ForeColor = System.Drawing.Color.White;
            this.LblTime.Location = new System.Drawing.Point(779, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.OBorderColor = System.Drawing.Color.Black;
            this.LblTime.Size = new System.Drawing.Size(200, 28);
            this.LblTime.TabIndex = 3;
            this.LblTime.Text = "2015-05-03 13:13:13";
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnMinimize
            // 
            this.BtnMinimize.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnMinimize.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.BtnMinimize.ForeColor = System.Drawing.Color.White;
            this.BtnMinimize.Location = new System.Drawing.Point(981, 1);
            this.BtnMinimize.Name = "BtnMinimize";
            this.BtnMinimize.Size = new System.Drawing.Size(40, 26);
            this.BtnMinimize.TabIndex = 3;
            this.BtnMinimize.Text = "ㅡ";
            this.BtnMinimize.UseVisualStyleBackColor = false;
            this.BtnMinimize.Click += new System.EventHandler(this.BtnMinimize_Click);
            // 
            // LblReject
            // 
            this.LblReject.BackColor = System.Drawing.Color.ForestGreen;
            this.LblReject.BDrawBorderBottom = true;
            this.LblReject.BDrawBorderLeft = false;
            this.LblReject.BDrawBorderRight = false;
            this.LblReject.BDrawBorderTop = true;
            this.LblReject.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblReject.ForeColor = System.Drawing.Color.White;
            this.LblReject.Location = new System.Drawing.Point(944, 28);
            this.LblReject.Name = "LblReject";
            this.LblReject.OBorderColor = System.Drawing.Color.Black;
            this.LblReject.Size = new System.Drawing.Size(80, 28);
            this.LblReject.TabIndex = 3;
            this.LblReject.Text = "Reject";
            this.LblReject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LblReject.Click += new System.EventHandler(this.LblReject_Click);
            // 
            // LblProduct
            // 
            this.LblProduct.BackColor = System.Drawing.Color.Lime;
            this.LblProduct.BDrawBorderBottom = true;
            this.LblProduct.BDrawBorderLeft = false;
            this.LblProduct.BDrawBorderRight = true;
            this.LblProduct.BDrawBorderTop = true;
            this.LblProduct.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblProduct.ForeColor = System.Drawing.Color.White;
            this.LblProduct.Location = new System.Drawing.Point(864, 28);
            this.LblProduct.Name = "LblProduct";
            this.LblProduct.OBorderColor = System.Drawing.Color.Black;
            this.LblProduct.Size = new System.Drawing.Size(80, 28);
            this.LblProduct.TabIndex = 3;
            this.LblProduct.Text = "정상";
            this.LblProduct.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblRecipe
            // 
            this.LblRecipe.BackColor = System.Drawing.Color.White;
            this.LblRecipe.BDrawBorderBottom = true;
            this.LblRecipe.BDrawBorderLeft = false;
            this.LblRecipe.BDrawBorderRight = true;
            this.LblRecipe.BDrawBorderTop = true;
            this.LblRecipe.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblRecipe.ForeColor = System.Drawing.Color.Black;
            this.LblRecipe.Location = new System.Drawing.Point(696, 28);
            this.LblRecipe.Name = "LblRecipe";
            this.LblRecipe.OBorderColor = System.Drawing.Color.Black;
            this.LblRecipe.Size = new System.Drawing.Size(168, 28);
            this.LblRecipe.TabIndex = 3;
            this.LblRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblInspObject
            // 
            this.LblInspObject.BackColor = System.Drawing.Color.White;
            this.LblInspObject.BDrawBorderBottom = true;
            this.LblInspObject.BDrawBorderLeft = false;
            this.LblInspObject.BDrawBorderRight = true;
            this.LblInspObject.BDrawBorderTop = true;
            this.LblInspObject.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblInspObject.ForeColor = System.Drawing.Color.Black;
            this.LblInspObject.Location = new System.Drawing.Point(408, 28);
            this.LblInspObject.Name = "LblInspObject";
            this.LblInspObject.OBorderColor = System.Drawing.Color.Black;
            this.LblInspObject.Size = new System.Drawing.Size(168, 28);
            this.LblInspObject.TabIndex = 3;
            this.LblInspObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRecipe
            // 
            this.LblTitleRecipe.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRecipe.BDrawBorderBottom = true;
            this.LblTitleRecipe.BDrawBorderLeft = false;
            this.LblTitleRecipe.BDrawBorderRight = true;
            this.LblTitleRecipe.BDrawBorderTop = true;
            this.LblTitleRecipe.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRecipe.ForeColor = System.Drawing.Color.White;
            this.LblTitleRecipe.Location = new System.Drawing.Point(576, 28);
            this.LblTitleRecipe.Name = "LblTitleRecipe";
            this.LblTitleRecipe.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRecipe.Size = new System.Drawing.Size(120, 28);
            this.LblTitleRecipe.TabIndex = 3;
            this.LblTitleRecipe.Text = "모델";
            this.LblTitleRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblMachine
            // 
            this.LblMachine.BackColor = System.Drawing.Color.White;
            this.LblMachine.BDrawBorderBottom = true;
            this.LblMachine.BDrawBorderLeft = false;
            this.LblMachine.BDrawBorderRight = true;
            this.LblMachine.BDrawBorderTop = true;
            this.LblMachine.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblMachine.ForeColor = System.Drawing.Color.Black;
            this.LblMachine.Location = new System.Drawing.Point(120, 28);
            this.LblMachine.Name = "LblMachine";
            this.LblMachine.OBorderColor = System.Drawing.Color.Black;
            this.LblMachine.Size = new System.Drawing.Size(168, 28);
            this.LblMachine.TabIndex = 3;
            this.LblMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleInspObject
            // 
            this.LblTitleInspObject.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleInspObject.BDrawBorderBottom = true;
            this.LblTitleInspObject.BDrawBorderLeft = false;
            this.LblTitleInspObject.BDrawBorderRight = true;
            this.LblTitleInspObject.BDrawBorderTop = true;
            this.LblTitleInspObject.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleInspObject.ForeColor = System.Drawing.Color.White;
            this.LblTitleInspObject.Location = new System.Drawing.Point(288, 28);
            this.LblTitleInspObject.Name = "LblTitleInspObject";
            this.LblTitleInspObject.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleInspObject.Size = new System.Drawing.Size(120, 28);
            this.LblTitleInspObject.TabIndex = 3;
            this.LblTitleInspObject.Text = "검사 항목";
            this.LblTitleInspObject.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleMachine
            // 
            this.LblTitleMachine.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleMachine.BDrawBorderBottom = true;
            this.LblTitleMachine.BDrawBorderLeft = false;
            this.LblTitleMachine.BDrawBorderRight = true;
            this.LblTitleMachine.BDrawBorderTop = true;
            this.LblTitleMachine.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleMachine.ForeColor = System.Drawing.Color.White;
            this.LblTitleMachine.Location = new System.Drawing.Point(0, 28);
            this.LblTitleMachine.Name = "LblTitleMachine";
            this.LblTitleMachine.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleMachine.Size = new System.Drawing.Size(120, 28);
            this.LblTitleMachine.TabIndex = 3;
            this.LblTitleMachine.Text = "설비";
            this.LblTitleMachine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitle.BDrawBorderBottom = false;
            this.LblTitle.BDrawBorderLeft = false;
            this.LblTitle.BDrawBorderRight = true;
            this.LblTitle.BDrawBorderTop = false;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OBorderColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(779, 28);
            this.LblTitle.TabIndex = 3;
            this.LblTitle.Text = "대곤 코퍼레이션 - 유한킴벌리 Vision Ver 3.0";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlNavigator
            // 
            this.PnlNavigator.BDrawBorderBottom = false;
            this.PnlNavigator.BDrawBorderLeft = false;
            this.PnlNavigator.BDrawBorderRight = false;
            this.PnlNavigator.BDrawBorderTop = true;
            this.PnlNavigator.Controls.Add(this.BtnExit);
            this.PnlNavigator.Controls.Add(this.BtnReport);
            this.PnlNavigator.Controls.Add(this.BtnSubStance);
            this.PnlNavigator.Controls.Add(this.BtnIO);
            this.PnlNavigator.Controls.Add(this.BtnSetup);
            this.PnlNavigator.Controls.Add(this.BtnRecipe);
            this.PnlNavigator.Controls.Add(this.BtnHome);
            this.PnlNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlNavigator.Location = new System.Drawing.Point(0, 728);
            this.PnlNavigator.Name = "PnlNavigator";
            this.PnlNavigator.Size = new System.Drawing.Size(1024, 40);
            this.PnlNavigator.TabIndex = 1;
            // 
            // BtnExit
            // 
            this.BtnExit.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnExit.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnExit.ForeColor = System.Drawing.Color.White;
            this.BtnExit.Location = new System.Drawing.Point(921, 3);
            this.BtnExit.Name = "BtnExit";
            this.BtnExit.Size = new System.Drawing.Size(100, 35);
            this.BtnExit.TabIndex = 10;
            this.BtnExit.Text = "종료";
            this.BtnExit.UseVisualStyleBackColor = false;
            this.BtnExit.Click += new System.EventHandler(this.BtnExit_Click);
            // 
            // BtnReport
            // 
            this.BtnReport.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnReport.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnReport.ForeColor = System.Drawing.Color.White;
            this.BtnReport.Location = new System.Drawing.Point(535, 3);
            this.BtnReport.Name = "BtnReport";
            this.BtnReport.Size = new System.Drawing.Size(100, 35);
            this.BtnReport.TabIndex = 10;
            this.BtnReport.Text = "보고서";
            this.BtnReport.UseVisualStyleBackColor = false;
            this.BtnReport.Click += new System.EventHandler(this.BtnReport_Click);
            // 
            // BtnSubStance
            // 
            this.BtnSubStance.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSubStance.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSubStance.ForeColor = System.Drawing.Color.White;
            this.BtnSubStance.Location = new System.Drawing.Point(323, 3);
            this.BtnSubStance.Name = "BtnSubStance";
            this.BtnSubStance.Size = new System.Drawing.Size(100, 35);
            this.BtnSubStance.TabIndex = 10;
            this.BtnSubStance.Tag = "SUBSTANCE";
            this.BtnSubStance.Text = "이물 유형";
            this.BtnSubStance.UseVisualStyleBackColor = false;
            this.BtnSubStance.Click += new System.EventHandler(this.BtnSubStance_Click);
            // 
            // BtnIO
            // 
            this.BtnIO.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnIO.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnIO.ForeColor = System.Drawing.Color.White;
            this.BtnIO.Location = new System.Drawing.Point(429, 3);
            this.BtnIO.Name = "BtnIO";
            this.BtnIO.Size = new System.Drawing.Size(100, 35);
            this.BtnIO.TabIndex = 10;
            this.BtnIO.Tag = "IO";
            this.BtnIO.Text = "입·출력";
            this.BtnIO.UseVisualStyleBackColor = false;
            this.BtnIO.Click += new System.EventHandler(this.BtnIO_Click);
            // 
            // BtnSetup
            // 
            this.BtnSetup.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSetup.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSetup.ForeColor = System.Drawing.Color.White;
            this.BtnSetup.Location = new System.Drawing.Point(217, 3);
            this.BtnSetup.Name = "BtnSetup";
            this.BtnSetup.Size = new System.Drawing.Size(100, 35);
            this.BtnSetup.TabIndex = 10;
            this.BtnSetup.Text = "옵션";
            this.BtnSetup.UseVisualStyleBackColor = false;
            this.BtnSetup.Click += new System.EventHandler(this.BtnSetup_Click);
            // 
            // BtnRecipe
            // 
            this.BtnRecipe.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnRecipe.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnRecipe.ForeColor = System.Drawing.Color.White;
            this.BtnRecipe.Location = new System.Drawing.Point(111, 3);
            this.BtnRecipe.Name = "BtnRecipe";
            this.BtnRecipe.Size = new System.Drawing.Size(100, 35);
            this.BtnRecipe.TabIndex = 10;
            this.BtnRecipe.Text = "설정보기";
            this.BtnRecipe.UseVisualStyleBackColor = false;
            this.BtnRecipe.Click += new System.EventHandler(this.BtnRecipe_Click);
            // 
            // BtnHome
            // 
            this.BtnHome.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnHome.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnHome.ForeColor = System.Drawing.Color.White;
            this.BtnHome.Location = new System.Drawing.Point(5, 3);
            this.BtnHome.Name = "BtnHome";
            this.BtnHome.Size = new System.Drawing.Size(100, 35);
            this.BtnHome.TabIndex = 10;
            this.BtnHome.Text = "홈";
            this.BtnHome.UseVisualStyleBackColor = false;
            this.BtnHome.Click += new System.EventHandler(this.BtnHome_Click);
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 56);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(1024, 672);
            this.PnlBody.TabIndex = 2;
            // 
            // Timer1000
            // 
            this.Timer1000.Enabled = true;
            this.Timer1000.Interval = 1000;
            this.Timer1000.Tick += new System.EventHandler(this.Timer1000_Tick);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1024, 768);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.PnlNavigator);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "대곤 코퍼레이션 - 유한킴벌리(충주) Vision Ver 3.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.PnlTop.ResumeLayout(false);
            this.PnlNavigator.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlTop;
        private Jhjo.Component.CLabel LblTitle;
        private System.Windows.Forms.Button BtnMinimize;
        private Jhjo.Component.CLabel LblTitleMachine;
        private Jhjo.Component.CLabel LblProduct;
        private Jhjo.Component.CLabel LblMachine;
        private Jhjo.Component.CLabel LblRecipe;
        private Jhjo.Component.CLabel LblInspObject;
        private Jhjo.Component.CLabel LblTitleRecipe;
        private Jhjo.Component.CLabel LblTitleInspObject;
        private Jhjo.Component.CPanel PnlNavigator;
        private System.Windows.Forms.Button BtnRecipe;
        private System.Windows.Forms.Button BtnHome;
        private System.Windows.Forms.Button BtnExit;
        private Jhjo.Component.CPanel PnlBody;
        private Jhjo.Component.CLabel LblReject;
        private System.Windows.Forms.Button BtnSetup;
        private System.Windows.Forms.Button BtnReport;
        private Jhjo.Component.CLabel LblTime;
        private System.Windows.Forms.Timer Timer1000;
        private System.Windows.Forms.Button BtnIO;
        private System.Windows.Forms.Button BtnSubStance;
    }
}


namespace YKCJ_Diaper
{
    partial class UcReport
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UcReport));
            this.PnlRight = new Jhjo.Component.CPanel();
            this.PnlSubScreen = new Jhjo.Component.CPanel();
            this.PnlBody = new Jhjo.Component.CPanel();
            this.LblElongation = new Jhjo.Component.CLabel();
            this.LblArea = new Jhjo.Component.CLabel();
            this.LblPerimeter = new Jhjo.Component.CLabel();
            this.LblYLength = new Jhjo.Component.CLabel();
            this.LblXLength = new Jhjo.Component.CLabel();
            this.LblSubStance = new Jhjo.Component.CLabel();
            this.LblRefer = new Jhjo.Component.CLabel();
            this.LblValue = new Jhjo.Component.CLabel();
            this.LblToolNo = new Jhjo.Component.CLabel();
            this.LblTool = new Jhjo.Component.CLabel();
            this.LblModel = new Jhjo.Component.CLabel();
            this.LblTime = new Jhjo.Component.CLabel();
            this.LblTitleRefer = new Jhjo.Component.CLabel();
            this.LblTitleValue = new Jhjo.Component.CLabel();
            this.LblTitleToolNo = new Jhjo.Component.CLabel();
            this.LblTitleTool = new Jhjo.Component.CLabel();
            this.LblTitleModel = new Jhjo.Component.CLabel();
            this.LblTitleElongation = new Jhjo.Component.CLabel();
            this.LblTitleArea = new Jhjo.Component.CLabel();
            this.LblTitlePerimeter = new Jhjo.Component.CLabel();
            this.LblTitleYLength = new Jhjo.Component.CLabel();
            this.LblTitleXLength = new Jhjo.Component.CLabel();
            this.LblTitleSubStance = new Jhjo.Component.CLabel();
            this.LblTitleTime = new Jhjo.Component.CLabel();
            this.PnlReport = new Jhjo.Component.CPanel();
            this.DgvReport = new System.Windows.Forms.DataGridView();
            this.ColDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColRecipe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColTool = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIndex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSubstance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColReferance = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblTitleReport = new Jhjo.Component.CLabel();
            this.PnlCondition = new Jhjo.Component.CPanel();
            this.DtpDate = new System.Windows.Forms.DateTimePicker();
            this.BtnSearch = new System.Windows.Forms.Button();
            this.LblTitleDate = new Jhjo.Component.CLabel();
            this.LblTitleCodition = new Jhjo.Component.CLabel();
            this.Splitter = new System.Windows.Forms.Splitter();
            this.CdpDisplayer = new Cognex.VisionPro.Display.CogDisplay();
            this.PnlLeft = new Jhjo.Component.CPanel();
            this.PnlRight.SuspendLayout();
            this.PnlSubScreen.SuspendLayout();
            this.PnlBody.SuspendLayout();
            this.PnlReport.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).BeginInit();
            this.PnlCondition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).BeginInit();
            this.PnlLeft.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlRight
            // 
            this.PnlRight.BDrawBorderBottom = false;
            this.PnlRight.BDrawBorderLeft = false;
            this.PnlRight.BDrawBorderRight = false;
            this.PnlRight.BDrawBorderTop = false;
            this.PnlRight.Controls.Add(this.PnlSubScreen);
            this.PnlRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlRight.Location = new System.Drawing.Point(445, 0);
            this.PnlRight.Name = "PnlRight";
            this.PnlRight.Size = new System.Drawing.Size(579, 672);
            this.PnlRight.TabIndex = 5;
            // 
            // PnlSubScreen
            // 
            this.PnlSubScreen.BDrawBorderBottom = false;
            this.PnlSubScreen.BDrawBorderLeft = true;
            this.PnlSubScreen.BDrawBorderRight = false;
            this.PnlSubScreen.BDrawBorderTop = false;
            this.PnlSubScreen.Controls.Add(this.PnlBody);
            this.PnlSubScreen.Controls.Add(this.PnlReport);
            this.PnlSubScreen.Controls.Add(this.PnlCondition);
            this.PnlSubScreen.Dock = System.Windows.Forms.DockStyle.Right;
            this.PnlSubScreen.Location = new System.Drawing.Point(-1, 0);
            this.PnlSubScreen.Name = "PnlSubScreen";
            this.PnlSubScreen.Size = new System.Drawing.Size(580, 672);
            this.PnlSubScreen.TabIndex = 0;
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Controls.Add(this.LblElongation);
            this.PnlBody.Controls.Add(this.LblArea);
            this.PnlBody.Controls.Add(this.LblPerimeter);
            this.PnlBody.Controls.Add(this.LblYLength);
            this.PnlBody.Controls.Add(this.LblXLength);
            this.PnlBody.Controls.Add(this.LblSubStance);
            this.PnlBody.Controls.Add(this.LblRefer);
            this.PnlBody.Controls.Add(this.LblValue);
            this.PnlBody.Controls.Add(this.LblToolNo);
            this.PnlBody.Controls.Add(this.LblTool);
            this.PnlBody.Controls.Add(this.LblModel);
            this.PnlBody.Controls.Add(this.LblTime);
            this.PnlBody.Controls.Add(this.LblTitleRefer);
            this.PnlBody.Controls.Add(this.LblTitleValue);
            this.PnlBody.Controls.Add(this.LblTitleToolNo);
            this.PnlBody.Controls.Add(this.LblTitleTool);
            this.PnlBody.Controls.Add(this.LblTitleModel);
            this.PnlBody.Controls.Add(this.LblTitleElongation);
            this.PnlBody.Controls.Add(this.LblTitleArea);
            this.PnlBody.Controls.Add(this.LblTitlePerimeter);
            this.PnlBody.Controls.Add(this.LblTitleYLength);
            this.PnlBody.Controls.Add(this.LblTitleXLength);
            this.PnlBody.Controls.Add(this.LblTitleSubStance);
            this.PnlBody.Controls.Add(this.LblTitleTime);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 504);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(580, 168);
            this.PnlBody.TabIndex = 7;
            // 
            // LblElongation
            // 
            this.LblElongation.BackColor = System.Drawing.Color.White;
            this.LblElongation.BDrawBorderBottom = false;
            this.LblElongation.BDrawBorderLeft = false;
            this.LblElongation.BDrawBorderRight = false;
            this.LblElongation.BDrawBorderTop = true;
            this.LblElongation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblElongation.ForeColor = System.Drawing.Color.Black;
            this.LblElongation.Location = new System.Drawing.Point(380, 140);
            this.LblElongation.Name = "LblElongation";
            this.LblElongation.OBorderColor = System.Drawing.Color.Black;
            this.LblElongation.Size = new System.Drawing.Size(200, 28);
            this.LblElongation.TabIndex = 19;
            this.LblElongation.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblArea
            // 
            this.LblArea.BackColor = System.Drawing.Color.White;
            this.LblArea.BDrawBorderBottom = false;
            this.LblArea.BDrawBorderLeft = false;
            this.LblArea.BDrawBorderRight = false;
            this.LblArea.BDrawBorderTop = true;
            this.LblArea.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblArea.ForeColor = System.Drawing.Color.Black;
            this.LblArea.Location = new System.Drawing.Point(380, 112);
            this.LblArea.Name = "LblArea";
            this.LblArea.OBorderColor = System.Drawing.Color.Black;
            this.LblArea.Size = new System.Drawing.Size(200, 28);
            this.LblArea.TabIndex = 19;
            this.LblArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblPerimeter
            // 
            this.LblPerimeter.BackColor = System.Drawing.Color.White;
            this.LblPerimeter.BDrawBorderBottom = false;
            this.LblPerimeter.BDrawBorderLeft = false;
            this.LblPerimeter.BDrawBorderRight = false;
            this.LblPerimeter.BDrawBorderTop = true;
            this.LblPerimeter.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblPerimeter.ForeColor = System.Drawing.Color.Black;
            this.LblPerimeter.Location = new System.Drawing.Point(380, 84);
            this.LblPerimeter.Name = "LblPerimeter";
            this.LblPerimeter.OBorderColor = System.Drawing.Color.Black;
            this.LblPerimeter.Size = new System.Drawing.Size(200, 28);
            this.LblPerimeter.TabIndex = 19;
            this.LblPerimeter.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblYLength
            // 
            this.LblYLength.BackColor = System.Drawing.Color.White;
            this.LblYLength.BDrawBorderBottom = false;
            this.LblYLength.BDrawBorderLeft = false;
            this.LblYLength.BDrawBorderRight = false;
            this.LblYLength.BDrawBorderTop = true;
            this.LblYLength.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblYLength.ForeColor = System.Drawing.Color.Black;
            this.LblYLength.Location = new System.Drawing.Point(380, 56);
            this.LblYLength.Name = "LblYLength";
            this.LblYLength.OBorderColor = System.Drawing.Color.Black;
            this.LblYLength.Size = new System.Drawing.Size(200, 28);
            this.LblYLength.TabIndex = 19;
            this.LblYLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblXLength
            // 
            this.LblXLength.BackColor = System.Drawing.Color.White;
            this.LblXLength.BDrawBorderBottom = false;
            this.LblXLength.BDrawBorderLeft = false;
            this.LblXLength.BDrawBorderRight = false;
            this.LblXLength.BDrawBorderTop = true;
            this.LblXLength.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblXLength.ForeColor = System.Drawing.Color.Black;
            this.LblXLength.Location = new System.Drawing.Point(380, 28);
            this.LblXLength.Name = "LblXLength";
            this.LblXLength.OBorderColor = System.Drawing.Color.Black;
            this.LblXLength.Size = new System.Drawing.Size(200, 28);
            this.LblXLength.TabIndex = 19;
            this.LblXLength.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblSubStance
            // 
            this.LblSubStance.BackColor = System.Drawing.Color.White;
            this.LblSubStance.BDrawBorderBottom = false;
            this.LblSubStance.BDrawBorderLeft = false;
            this.LblSubStance.BDrawBorderRight = false;
            this.LblSubStance.BDrawBorderTop = false;
            this.LblSubStance.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblSubStance.ForeColor = System.Drawing.Color.Black;
            this.LblSubStance.Location = new System.Drawing.Point(380, 0);
            this.LblSubStance.Name = "LblSubStance";
            this.LblSubStance.OBorderColor = System.Drawing.Color.Black;
            this.LblSubStance.Size = new System.Drawing.Size(200, 28);
            this.LblSubStance.TabIndex = 19;
            this.LblSubStance.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblRefer
            // 
            this.LblRefer.BackColor = System.Drawing.Color.White;
            this.LblRefer.BDrawBorderBottom = false;
            this.LblRefer.BDrawBorderLeft = false;
            this.LblRefer.BDrawBorderRight = false;
            this.LblRefer.BDrawBorderTop = true;
            this.LblRefer.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblRefer.ForeColor = System.Drawing.Color.Black;
            this.LblRefer.Location = new System.Drawing.Point(90, 140);
            this.LblRefer.Name = "LblRefer";
            this.LblRefer.OBorderColor = System.Drawing.Color.Black;
            this.LblRefer.Size = new System.Drawing.Size(200, 28);
            this.LblRefer.TabIndex = 19;
            this.LblRefer.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblValue
            // 
            this.LblValue.BackColor = System.Drawing.Color.White;
            this.LblValue.BDrawBorderBottom = false;
            this.LblValue.BDrawBorderLeft = false;
            this.LblValue.BDrawBorderRight = false;
            this.LblValue.BDrawBorderTop = true;
            this.LblValue.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblValue.ForeColor = System.Drawing.Color.Black;
            this.LblValue.Location = new System.Drawing.Point(90, 112);
            this.LblValue.Name = "LblValue";
            this.LblValue.OBorderColor = System.Drawing.Color.Black;
            this.LblValue.Size = new System.Drawing.Size(200, 28);
            this.LblValue.TabIndex = 19;
            this.LblValue.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblToolNo
            // 
            this.LblToolNo.BackColor = System.Drawing.Color.White;
            this.LblToolNo.BDrawBorderBottom = false;
            this.LblToolNo.BDrawBorderLeft = false;
            this.LblToolNo.BDrawBorderRight = false;
            this.LblToolNo.BDrawBorderTop = true;
            this.LblToolNo.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblToolNo.ForeColor = System.Drawing.Color.Black;
            this.LblToolNo.Location = new System.Drawing.Point(90, 84);
            this.LblToolNo.Name = "LblToolNo";
            this.LblToolNo.OBorderColor = System.Drawing.Color.Black;
            this.LblToolNo.Size = new System.Drawing.Size(200, 28);
            this.LblToolNo.TabIndex = 19;
            this.LblToolNo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTool
            // 
            this.LblTool.BackColor = System.Drawing.Color.White;
            this.LblTool.BDrawBorderBottom = false;
            this.LblTool.BDrawBorderLeft = false;
            this.LblTool.BDrawBorderRight = false;
            this.LblTool.BDrawBorderTop = true;
            this.LblTool.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblTool.ForeColor = System.Drawing.Color.Black;
            this.LblTool.Location = new System.Drawing.Point(90, 56);
            this.LblTool.Name = "LblTool";
            this.LblTool.OBorderColor = System.Drawing.Color.Black;
            this.LblTool.Size = new System.Drawing.Size(200, 28);
            this.LblTool.TabIndex = 19;
            this.LblTool.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblModel
            // 
            this.LblModel.BackColor = System.Drawing.Color.White;
            this.LblModel.BDrawBorderBottom = false;
            this.LblModel.BDrawBorderLeft = false;
            this.LblModel.BDrawBorderRight = false;
            this.LblModel.BDrawBorderTop = true;
            this.LblModel.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblModel.ForeColor = System.Drawing.Color.Black;
            this.LblModel.Location = new System.Drawing.Point(90, 28);
            this.LblModel.Name = "LblModel";
            this.LblModel.OBorderColor = System.Drawing.Color.Black;
            this.LblModel.Size = new System.Drawing.Size(200, 28);
            this.LblModel.TabIndex = 19;
            this.LblModel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTime
            // 
            this.LblTime.BackColor = System.Drawing.Color.White;
            this.LblTime.BDrawBorderBottom = false;
            this.LblTime.BDrawBorderLeft = false;
            this.LblTime.BDrawBorderRight = false;
            this.LblTime.BDrawBorderTop = false;
            this.LblTime.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblTime.ForeColor = System.Drawing.Color.Black;
            this.LblTime.Location = new System.Drawing.Point(90, 0);
            this.LblTime.Name = "LblTime";
            this.LblTime.OBorderColor = System.Drawing.Color.Black;
            this.LblTime.Size = new System.Drawing.Size(200, 28);
            this.LblTime.TabIndex = 19;
            this.LblTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // LblTitleRefer
            // 
            this.LblTitleRefer.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRefer.BDrawBorderBottom = false;
            this.LblTitleRefer.BDrawBorderLeft = false;
            this.LblTitleRefer.BDrawBorderRight = true;
            this.LblTitleRefer.BDrawBorderTop = true;
            this.LblTitleRefer.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRefer.ForeColor = System.Drawing.Color.White;
            this.LblTitleRefer.Location = new System.Drawing.Point(0, 140);
            this.LblTitleRefer.Name = "LblTitleRefer";
            this.LblTitleRefer.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRefer.Size = new System.Drawing.Size(90, 28);
            this.LblTitleRefer.TabIndex = 10;
            this.LblTitleRefer.Text = "비고";
            this.LblTitleRefer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleValue
            // 
            this.LblTitleValue.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleValue.BDrawBorderBottom = false;
            this.LblTitleValue.BDrawBorderLeft = false;
            this.LblTitleValue.BDrawBorderRight = true;
            this.LblTitleValue.BDrawBorderTop = true;
            this.LblTitleValue.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleValue.ForeColor = System.Drawing.Color.White;
            this.LblTitleValue.Location = new System.Drawing.Point(0, 112);
            this.LblTitleValue.Name = "LblTitleValue";
            this.LblTitleValue.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleValue.Size = new System.Drawing.Size(90, 28);
            this.LblTitleValue.TabIndex = 10;
            this.LblTitleValue.Text = "값";
            this.LblTitleValue.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleToolNo
            // 
            this.LblTitleToolNo.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleToolNo.BDrawBorderBottom = false;
            this.LblTitleToolNo.BDrawBorderLeft = false;
            this.LblTitleToolNo.BDrawBorderRight = true;
            this.LblTitleToolNo.BDrawBorderTop = true;
            this.LblTitleToolNo.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleToolNo.ForeColor = System.Drawing.Color.White;
            this.LblTitleToolNo.Location = new System.Drawing.Point(0, 84);
            this.LblTitleToolNo.Name = "LblTitleToolNo";
            this.LblTitleToolNo.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleToolNo.Size = new System.Drawing.Size(90, 28);
            this.LblTitleToolNo.TabIndex = 10;
            this.LblTitleToolNo.Text = "도구 번호";
            this.LblTitleToolNo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleTool
            // 
            this.LblTitleTool.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleTool.BDrawBorderBottom = false;
            this.LblTitleTool.BDrawBorderLeft = false;
            this.LblTitleTool.BDrawBorderRight = true;
            this.LblTitleTool.BDrawBorderTop = true;
            this.LblTitleTool.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleTool.ForeColor = System.Drawing.Color.White;
            this.LblTitleTool.Location = new System.Drawing.Point(0, 56);
            this.LblTitleTool.Name = "LblTitleTool";
            this.LblTitleTool.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleTool.Size = new System.Drawing.Size(90, 28);
            this.LblTitleTool.TabIndex = 10;
            this.LblTitleTool.Text = "분석 도구";
            this.LblTitleTool.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleModel
            // 
            this.LblTitleModel.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleModel.BDrawBorderBottom = false;
            this.LblTitleModel.BDrawBorderLeft = false;
            this.LblTitleModel.BDrawBorderRight = true;
            this.LblTitleModel.BDrawBorderTop = true;
            this.LblTitleModel.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleModel.ForeColor = System.Drawing.Color.White;
            this.LblTitleModel.Location = new System.Drawing.Point(0, 28);
            this.LblTitleModel.Name = "LblTitleModel";
            this.LblTitleModel.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleModel.Size = new System.Drawing.Size(90, 28);
            this.LblTitleModel.TabIndex = 10;
            this.LblTitleModel.Text = "모델";
            this.LblTitleModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleElongation
            // 
            this.LblTitleElongation.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleElongation.BDrawBorderBottom = false;
            this.LblTitleElongation.BDrawBorderLeft = true;
            this.LblTitleElongation.BDrawBorderRight = true;
            this.LblTitleElongation.BDrawBorderTop = true;
            this.LblTitleElongation.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleElongation.ForeColor = System.Drawing.Color.White;
            this.LblTitleElongation.Location = new System.Drawing.Point(290, 140);
            this.LblTitleElongation.Name = "LblTitleElongation";
            this.LblTitleElongation.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleElongation.Size = new System.Drawing.Size(90, 28);
            this.LblTitleElongation.TabIndex = 10;
            this.LblTitleElongation.Text = "원형도";
            this.LblTitleElongation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleArea
            // 
            this.LblTitleArea.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleArea.BDrawBorderBottom = false;
            this.LblTitleArea.BDrawBorderLeft = true;
            this.LblTitleArea.BDrawBorderRight = true;
            this.LblTitleArea.BDrawBorderTop = true;
            this.LblTitleArea.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleArea.ForeColor = System.Drawing.Color.White;
            this.LblTitleArea.Location = new System.Drawing.Point(290, 112);
            this.LblTitleArea.Name = "LblTitleArea";
            this.LblTitleArea.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleArea.Size = new System.Drawing.Size(90, 28);
            this.LblTitleArea.TabIndex = 10;
            this.LblTitleArea.Text = "면적";
            this.LblTitleArea.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitlePerimeter
            // 
            this.LblTitlePerimeter.BackColor = System.Drawing.Color.DimGray;
            this.LblTitlePerimeter.BDrawBorderBottom = false;
            this.LblTitlePerimeter.BDrawBorderLeft = true;
            this.LblTitlePerimeter.BDrawBorderRight = true;
            this.LblTitlePerimeter.BDrawBorderTop = true;
            this.LblTitlePerimeter.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitlePerimeter.ForeColor = System.Drawing.Color.White;
            this.LblTitlePerimeter.Location = new System.Drawing.Point(290, 84);
            this.LblTitlePerimeter.Name = "LblTitlePerimeter";
            this.LblTitlePerimeter.OBorderColor = System.Drawing.Color.Black;
            this.LblTitlePerimeter.Size = new System.Drawing.Size(90, 28);
            this.LblTitlePerimeter.TabIndex = 10;
            this.LblTitlePerimeter.Text = "둘레";
            this.LblTitlePerimeter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleYLength
            // 
            this.LblTitleYLength.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleYLength.BDrawBorderBottom = false;
            this.LblTitleYLength.BDrawBorderLeft = true;
            this.LblTitleYLength.BDrawBorderRight = true;
            this.LblTitleYLength.BDrawBorderTop = true;
            this.LblTitleYLength.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleYLength.ForeColor = System.Drawing.Color.White;
            this.LblTitleYLength.Location = new System.Drawing.Point(290, 56);
            this.LblTitleYLength.Name = "LblTitleYLength";
            this.LblTitleYLength.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleYLength.Size = new System.Drawing.Size(90, 28);
            this.LblTitleYLength.TabIndex = 10;
            this.LblTitleYLength.Text = "세로 길이";
            this.LblTitleYLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleXLength
            // 
            this.LblTitleXLength.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleXLength.BDrawBorderBottom = false;
            this.LblTitleXLength.BDrawBorderLeft = true;
            this.LblTitleXLength.BDrawBorderRight = true;
            this.LblTitleXLength.BDrawBorderTop = true;
            this.LblTitleXLength.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleXLength.ForeColor = System.Drawing.Color.White;
            this.LblTitleXLength.Location = new System.Drawing.Point(290, 28);
            this.LblTitleXLength.Name = "LblTitleXLength";
            this.LblTitleXLength.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleXLength.Size = new System.Drawing.Size(90, 28);
            this.LblTitleXLength.TabIndex = 10;
            this.LblTitleXLength.Text = "가로 길이";
            this.LblTitleXLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleSubStance
            // 
            this.LblTitleSubStance.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleSubStance.BDrawBorderBottom = false;
            this.LblTitleSubStance.BDrawBorderLeft = true;
            this.LblTitleSubStance.BDrawBorderRight = true;
            this.LblTitleSubStance.BDrawBorderTop = false;
            this.LblTitleSubStance.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleSubStance.ForeColor = System.Drawing.Color.White;
            this.LblTitleSubStance.Location = new System.Drawing.Point(290, 0);
            this.LblTitleSubStance.Name = "LblTitleSubStance";
            this.LblTitleSubStance.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleSubStance.Size = new System.Drawing.Size(90, 28);
            this.LblTitleSubStance.TabIndex = 10;
            this.LblTitleSubStance.Text = "이물 형태";
            this.LblTitleSubStance.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LblTitleTime
            // 
            this.LblTitleTime.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleTime.BDrawBorderBottom = false;
            this.LblTitleTime.BDrawBorderLeft = false;
            this.LblTitleTime.BDrawBorderRight = true;
            this.LblTitleTime.BDrawBorderTop = false;
            this.LblTitleTime.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleTime.ForeColor = System.Drawing.Color.White;
            this.LblTitleTime.Location = new System.Drawing.Point(0, 0);
            this.LblTitleTime.Name = "LblTitleTime";
            this.LblTitleTime.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleTime.Size = new System.Drawing.Size(90, 28);
            this.LblTitleTime.TabIndex = 10;
            this.LblTitleTime.Text = "일시";
            this.LblTitleTime.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlReport
            // 
            this.PnlReport.BDrawBorderBottom = false;
            this.PnlReport.BDrawBorderLeft = true;
            this.PnlReport.BDrawBorderRight = false;
            this.PnlReport.BDrawBorderTop = false;
            this.PnlReport.Controls.Add(this.DgvReport);
            this.PnlReport.Controls.Add(this.LblTitleReport);
            this.PnlReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlReport.Location = new System.Drawing.Point(0, 68);
            this.PnlReport.Name = "PnlReport";
            this.PnlReport.Size = new System.Drawing.Size(580, 436);
            this.PnlReport.TabIndex = 10;
            // 
            // DgvReport
            // 
            this.DgvReport.AllowUserToAddRows = false;
            this.DgvReport.AllowUserToDeleteRows = false;
            this.DgvReport.AllowUserToResizeRows = false;
            this.DgvReport.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvReport.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 8F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DgvReport.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvReport.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColDateTime,
            this.ColRecipe,
            this.ColTool,
            this.ColIndex,
            this.ColValue,
            this.ColSubstance,
            this.ColReferance});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvReport.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvReport.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvReport.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvReport.Location = new System.Drawing.Point(0, 28);
            this.DgvReport.MultiSelect = false;
            this.DgvReport.Name = "DgvReport";
            this.DgvReport.RowHeadersVisible = false;
            this.DgvReport.RowTemplate.Height = 23;
            this.DgvReport.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvReport.Size = new System.Drawing.Size(580, 408);
            this.DgvReport.TabIndex = 6;
            this.DgvReport.SelectionChanged += new System.EventHandler(this.DgvReport_SelectionChanged);
            // 
            // ColDateTime
            // 
            this.ColDateTime.DataPropertyName = "DATETIME";
            this.ColDateTime.FillWeight = 20F;
            this.ColDateTime.HeaderText = "일시";
            this.ColDateTime.Name = "ColDateTime";
            this.ColDateTime.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColRecipe
            // 
            this.ColRecipe.DataPropertyName = "RECIPE";
            this.ColRecipe.FillWeight = 10F;
            this.ColRecipe.HeaderText = "모델";
            this.ColRecipe.Name = "ColRecipe";
            this.ColRecipe.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColTool
            // 
            this.ColTool.DataPropertyName = "TOOL";
            this.ColTool.FillWeight = 9F;
            this.ColTool.HeaderText = "도구";
            this.ColTool.Name = "ColTool";
            this.ColTool.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIndex
            // 
            this.ColIndex.DataPropertyName = "INDEX";
            this.ColIndex.FillWeight = 6F;
            this.ColIndex.HeaderText = "번호";
            this.ColIndex.Name = "ColIndex";
            this.ColIndex.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColValue
            // 
            this.ColValue.DataPropertyName = "VALUE";
            this.ColValue.FillWeight = 15F;
            this.ColValue.HeaderText = "값";
            this.ColValue.Name = "ColValue";
            this.ColValue.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSubstance
            // 
            this.ColSubstance.DataPropertyName = "SUBSTANCE";
            this.ColSubstance.FillWeight = 15F;
            this.ColSubstance.HeaderText = "이물 형태";
            this.ColSubstance.Name = "ColSubstance";
            this.ColSubstance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColReferance
            // 
            this.ColReferance.DataPropertyName = "REFERANCE";
            this.ColReferance.FillWeight = 15F;
            this.ColReferance.HeaderText = "비고";
            this.ColReferance.Name = "ColReferance";
            this.ColReferance.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // LblTitleReport
            // 
            this.LblTitleReport.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleReport.BDrawBorderBottom = false;
            this.LblTitleReport.BDrawBorderLeft = true;
            this.LblTitleReport.BDrawBorderRight = false;
            this.LblTitleReport.BDrawBorderTop = true;
            this.LblTitleReport.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleReport.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleReport.ForeColor = System.Drawing.Color.White;
            this.LblTitleReport.Location = new System.Drawing.Point(0, 0);
            this.LblTitleReport.Name = "LblTitleReport";
            this.LblTitleReport.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleReport.Size = new System.Drawing.Size(580, 28);
            this.LblTitleReport.TabIndex = 5;
            this.LblTitleReport.Text = " * 보고서";
            this.LblTitleReport.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // PnlCondition
            // 
            this.PnlCondition.BDrawBorderBottom = false;
            this.PnlCondition.BDrawBorderLeft = true;
            this.PnlCondition.BDrawBorderRight = false;
            this.PnlCondition.BDrawBorderTop = false;
            this.PnlCondition.Controls.Add(this.DtpDate);
            this.PnlCondition.Controls.Add(this.BtnSearch);
            this.PnlCondition.Controls.Add(this.LblTitleDate);
            this.PnlCondition.Controls.Add(this.LblTitleCodition);
            this.PnlCondition.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlCondition.Location = new System.Drawing.Point(0, 0);
            this.PnlCondition.Name = "PnlCondition";
            this.PnlCondition.Size = new System.Drawing.Size(580, 68);
            this.PnlCondition.TabIndex = 9;
            // 
            // DtpDate
            // 
            this.DtpDate.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.DtpDate.Location = new System.Drawing.Point(126, 36);
            this.DtpDate.Name = "DtpDate";
            this.DtpDate.Size = new System.Drawing.Size(345, 25);
            this.DtpDate.TabIndex = 26;
            // 
            // BtnSearch
            // 
            this.BtnSearch.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSearch.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSearch.ForeColor = System.Drawing.Color.White;
            this.BtnSearch.Location = new System.Drawing.Point(477, 31);
            this.BtnSearch.Name = "BtnSearch";
            this.BtnSearch.Size = new System.Drawing.Size(100, 35);
            this.BtnSearch.TabIndex = 24;
            this.BtnSearch.Text = "검색";
            this.BtnSearch.UseVisualStyleBackColor = false;
            this.BtnSearch.Click += new System.EventHandler(this.BtnSearch_Click);
            // 
            // LblTitleDate
            // 
            this.LblTitleDate.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleDate.BDrawBorderBottom = false;
            this.LblTitleDate.BDrawBorderLeft = true;
            this.LblTitleDate.BDrawBorderRight = true;
            this.LblTitleDate.BDrawBorderTop = false;
            this.LblTitleDate.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleDate.ForeColor = System.Drawing.Color.White;
            this.LblTitleDate.Location = new System.Drawing.Point(0, 28);
            this.LblTitleDate.Name = "LblTitleDate";
            this.LblTitleDate.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleDate.Size = new System.Drawing.Size(120, 40);
            this.LblTitleDate.TabIndex = 20;
            this.LblTitleDate.Text = "일자";
            this.LblTitleDate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleCodition
            // 
            this.LblTitleCodition.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleCodition.BDrawBorderBottom = true;
            this.LblTitleCodition.BDrawBorderLeft = true;
            this.LblTitleCodition.BDrawBorderRight = false;
            this.LblTitleCodition.BDrawBorderTop = false;
            this.LblTitleCodition.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCodition.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCodition.ForeColor = System.Drawing.Color.White;
            this.LblTitleCodition.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCodition.Name = "LblTitleCodition";
            this.LblTitleCodition.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCodition.Size = new System.Drawing.Size(580, 28);
            this.LblTitleCodition.TabIndex = 5;
            this.LblTitleCodition.Text = " * 조건";
            this.LblTitleCodition.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Splitter
            // 
            this.Splitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Splitter.Location = new System.Drawing.Point(440, 0);
            this.Splitter.Name = "Splitter";
            this.Splitter.Size = new System.Drawing.Size(5, 672);
            this.Splitter.TabIndex = 4;
            this.Splitter.TabStop = false;
            this.Splitter.DoubleClick += new System.EventHandler(this.Splitter_DoubleClick);
            // 
            // CdpDisplayer
            // 
            this.CdpDisplayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CdpDisplayer.Location = new System.Drawing.Point(0, 0);
            this.CdpDisplayer.MouseWheelMode = Cognex.VisionPro.Display.CogDisplayMouseWheelModeConstants.Zoom1;
            this.CdpDisplayer.MouseWheelSensitivity = 1D;
            this.CdpDisplayer.Name = "CdpDisplayer";
            this.CdpDisplayer.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("CdpDisplayer.OcxState")));
            this.CdpDisplayer.Size = new System.Drawing.Size(440, 672);
            this.CdpDisplayer.TabIndex = 0;
            // 
            // PnlLeft
            // 
            this.PnlLeft.BDrawBorderBottom = false;
            this.PnlLeft.BDrawBorderLeft = false;
            this.PnlLeft.BDrawBorderRight = false;
            this.PnlLeft.BDrawBorderTop = false;
            this.PnlLeft.Controls.Add(this.CdpDisplayer);
            this.PnlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.PnlLeft.Location = new System.Drawing.Point(0, 0);
            this.PnlLeft.Name = "PnlLeft";
            this.PnlLeft.Size = new System.Drawing.Size(440, 672);
            this.PnlLeft.TabIndex = 3;
            // 
            // UcReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PnlRight);
            this.Controls.Add(this.Splitter);
            this.Controls.Add(this.PnlLeft);
            this.Name = "UcReport";
            this.Load += new System.EventHandler(this.UcReport_Load);
            this.PnlRight.ResumeLayout(false);
            this.PnlSubScreen.ResumeLayout(false);
            this.PnlBody.ResumeLayout(false);
            this.PnlReport.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvReport)).EndInit();
            this.PnlCondition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.CdpDisplayer)).EndInit();
            this.PnlLeft.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlRight;
        private Jhjo.Component.CPanel PnlSubScreen;
        private System.Windows.Forms.Splitter Splitter;
        private Cognex.VisionPro.Display.CogDisplay CdpDisplayer;
        private Jhjo.Component.CPanel PnlLeft;
        private Jhjo.Component.CPanel PnlReport;
        private Jhjo.Component.CLabel LblTitleReport;
        private Jhjo.Component.CPanel PnlCondition;
        private System.Windows.Forms.DateTimePicker DtpDate;
        private System.Windows.Forms.Button BtnSearch;
        private Jhjo.Component.CLabel LblTitleDate;
        private Jhjo.Component.CLabel LblTitleCodition;
        private System.Windows.Forms.DataGridView DgvReport;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColRecipe;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTool;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIndex;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSubstance;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColReferance;
        private Jhjo.Component.CPanel PnlBody;
        private Jhjo.Component.CLabel LblTitleValue;
        private Jhjo.Component.CLabel LblTitleToolNo;
        private Jhjo.Component.CLabel LblTitleTool;
        private Jhjo.Component.CLabel LblTitleModel;
        private Jhjo.Component.CLabel LblTitleElongation;
        private Jhjo.Component.CLabel LblTitleArea;
        private Jhjo.Component.CLabel LblTitlePerimeter;
        private Jhjo.Component.CLabel LblTitleYLength;
        private Jhjo.Component.CLabel LblTitleXLength;
        private Jhjo.Component.CLabel LblTitleSubStance;
        private Jhjo.Component.CLabel LblTitleTime;
        private Jhjo.Component.CLabel LblTitleRefer;
        private Jhjo.Component.CLabel LblElongation;
        private Jhjo.Component.CLabel LblArea;
        private Jhjo.Component.CLabel LblPerimeter;
        private Jhjo.Component.CLabel LblYLength;
        private Jhjo.Component.CLabel LblXLength;
        private Jhjo.Component.CLabel LblSubStance;
        private Jhjo.Component.CLabel LblRefer;
        private Jhjo.Component.CLabel LblValue;
        private Jhjo.Component.CLabel LblToolNo;
        private Jhjo.Component.CLabel LblTool;
        private Jhjo.Component.CLabel LblModel;
        private Jhjo.Component.CLabel LblTime;

    }
}

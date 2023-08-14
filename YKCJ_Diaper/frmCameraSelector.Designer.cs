namespace YKCJ_Diaper
{
    partial class frmCameraSelector
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PnlTop = new Jhjo.Component.CPanel();
            this.LblTitleCamSelector = new Jhjo.Component.CLabel();
            this.DgvCamList = new System.Windows.Forms.DataGridView();
            this.ColCompany = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColIP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColSerial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColKey = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LblIP = new Jhjo.Component.CLabel();
            this.PnlMiddleBottom = new Jhjo.Component.CPanel();
            this.LblTitleCamList = new Jhjo.Component.CLabel();
            this.LblTitleIP = new Jhjo.Component.CLabel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlMiddleTop = new Jhjo.Component.CPanel();
            this.BtnSelectFrontLeft = new System.Windows.Forms.Button();
            this.LblTitleCamSelection = new Jhjo.Component.CLabel();
            this.BtnApply = new System.Windows.Forms.Button();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.PnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DgvCamList)).BeginInit();
            this.PnlMiddleBottom.SuspendLayout();
            this.PnlMiddleTop.SuspendLayout();
            this.PnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlTop
            // 
            this.PnlTop.BDrawBorderBottom = false;
            this.PnlTop.BDrawBorderLeft = false;
            this.PnlTop.BDrawBorderRight = false;
            this.PnlTop.BDrawBorderTop = false;
            this.PnlTop.Controls.Add(this.LblTitleCamSelector);
            this.PnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlTop.Location = new System.Drawing.Point(0, 0);
            this.PnlTop.Name = "PnlTop";
            this.PnlTop.Size = new System.Drawing.Size(354, 28);
            this.PnlTop.TabIndex = 9;
            // 
            // LblTitleCamSelector
            // 
            this.LblTitleCamSelector.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitleCamSelector.BDrawBorderBottom = true;
            this.LblTitleCamSelector.BDrawBorderLeft = false;
            this.LblTitleCamSelector.BDrawBorderRight = false;
            this.LblTitleCamSelector.BDrawBorderTop = false;
            this.LblTitleCamSelector.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LblTitleCamSelector.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamSelector.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamSelector.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamSelector.Name = "LblTitleCamSelector";
            this.LblTitleCamSelector.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCamSelector.Size = new System.Drawing.Size(354, 28);
            this.LblTitleCamSelector.TabIndex = 0;
            this.LblTitleCamSelector.Text = "카메라 설정";
            this.LblTitleCamSelector.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DgvCamList
            // 
            this.DgvCamList.AllowUserToAddRows = false;
            this.DgvCamList.AllowUserToDeleteRows = false;
            this.DgvCamList.AllowUserToResizeColumns = false;
            this.DgvCamList.AllowUserToResizeRows = false;
            this.DgvCamList.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DgvCamList.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DgvCamList.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.DimGray;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            this.DgvCamList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.DgvCamList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DgvCamList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColCompany,
            this.ColModel,
            this.ColIP,
            this.ColSerial,
            this.ColKey});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 10F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.DgvCamList.DefaultCellStyle = dataGridViewCellStyle2;
            this.DgvCamList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DgvCamList.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.DgvCamList.Location = new System.Drawing.Point(0, 30);
            this.DgvCamList.MultiSelect = false;
            this.DgvCamList.Name = "DgvCamList";
            this.DgvCamList.RowHeadersVisible = false;
            this.DgvCamList.RowTemplate.Height = 23;
            this.DgvCamList.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DgvCamList.Size = new System.Drawing.Size(354, 111);
            this.DgvCamList.TabIndex = 4;
            // 
            // ColCompany
            // 
            this.ColCompany.DataPropertyName = "COMPANY";
            this.ColCompany.HeaderText = "Company";
            this.ColCompany.Name = "ColCompany";
            this.ColCompany.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.ColCompany.Visible = false;
            // 
            // ColModel
            // 
            this.ColModel.DataPropertyName = "MODEL";
            this.ColModel.HeaderText = "모델";
            this.ColModel.Name = "ColModel";
            this.ColModel.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColIP
            // 
            this.ColIP.DataPropertyName = "IP";
            this.ColIP.HeaderText = "IP";
            this.ColIP.Name = "ColIP";
            this.ColIP.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColSerial
            // 
            this.ColSerial.DataPropertyName = "SERIAL";
            this.ColSerial.HeaderText = "시리얼";
            this.ColSerial.Name = "ColSerial";
            this.ColSerial.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // ColKey
            // 
            this.ColKey.DataPropertyName = "KEY";
            this.ColKey.HeaderText = "KEY";
            this.ColKey.Name = "ColKey";
            this.ColKey.Visible = false;
            // 
            // LblIP
            // 
            this.LblIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblIP.BackColor = System.Drawing.Color.White;
            this.LblIP.BDrawBorderBottom = false;
            this.LblIP.BDrawBorderLeft = false;
            this.LblIP.BDrawBorderRight = true;
            this.LblIP.BDrawBorderTop = false;
            this.LblIP.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.LblIP.ForeColor = System.Drawing.Color.Black;
            this.LblIP.Location = new System.Drawing.Point(100, 28);
            this.LblIP.Name = "LblIP";
            this.LblIP.OBorderColor = System.Drawing.Color.Black;
            this.LblIP.Size = new System.Drawing.Size(150, 35);
            this.LblIP.TabIndex = 7;
            this.LblIP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PnlMiddleBottom
            // 
            this.PnlMiddleBottom.BDrawBorderBottom = false;
            this.PnlMiddleBottom.BDrawBorderLeft = false;
            this.PnlMiddleBottom.BDrawBorderRight = false;
            this.PnlMiddleBottom.BDrawBorderTop = false;
            this.PnlMiddleBottom.Controls.Add(this.DgvCamList);
            this.PnlMiddleBottom.Controls.Add(this.LblTitleCamList);
            this.PnlMiddleBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlMiddleBottom.Location = new System.Drawing.Point(0, 91);
            this.PnlMiddleBottom.Name = "PnlMiddleBottom";
            this.PnlMiddleBottom.Size = new System.Drawing.Size(354, 141);
            this.PnlMiddleBottom.TabIndex = 12;
            // 
            // LblTitleCamList
            // 
            this.LblTitleCamList.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCamList.BDrawBorderBottom = false;
            this.LblTitleCamList.BDrawBorderLeft = false;
            this.LblTitleCamList.BDrawBorderRight = false;
            this.LblTitleCamList.BDrawBorderTop = true;
            this.LblTitleCamList.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCamList.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamList.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamList.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamList.Name = "LblTitleCamList";
            this.LblTitleCamList.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCamList.Size = new System.Drawing.Size(354, 30);
            this.LblTitleCamList.TabIndex = 3;
            this.LblTitleCamList.Text = "카메라 목록";
            this.LblTitleCamList.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleIP
            // 
            this.LblTitleIP.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.LblTitleIP.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleIP.BDrawBorderBottom = false;
            this.LblTitleIP.BDrawBorderLeft = false;
            this.LblTitleIP.BDrawBorderRight = true;
            this.LblTitleIP.BDrawBorderTop = false;
            this.LblTitleIP.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleIP.ForeColor = System.Drawing.Color.White;
            this.LblTitleIP.Location = new System.Drawing.Point(0, 28);
            this.LblTitleIP.Name = "LblTitleIP";
            this.LblTitleIP.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleIP.Size = new System.Drawing.Size(100, 35);
            this.LblTitleIP.TabIndex = 6;
            this.LblTitleIP.Text = "IP";
            this.LblTitleIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnClose
            // 
            this.BtnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(252, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(100, 35);
            this.BtnClose.TabIndex = 4;
            this.BtnClose.Text = "종료";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // PnlMiddleTop
            // 
            this.PnlMiddleTop.BDrawBorderBottom = false;
            this.PnlMiddleTop.BDrawBorderLeft = true;
            this.PnlMiddleTop.BDrawBorderRight = false;
            this.PnlMiddleTop.BDrawBorderTop = false;
            this.PnlMiddleTop.Controls.Add(this.LblIP);
            this.PnlMiddleTop.Controls.Add(this.LblTitleIP);
            this.PnlMiddleTop.Controls.Add(this.BtnSelectFrontLeft);
            this.PnlMiddleTop.Controls.Add(this.LblTitleCamSelection);
            this.PnlMiddleTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.PnlMiddleTop.Location = new System.Drawing.Point(0, 28);
            this.PnlMiddleTop.Name = "PnlMiddleTop";
            this.PnlMiddleTop.Size = new System.Drawing.Size(354, 63);
            this.PnlMiddleTop.TabIndex = 10;
            // 
            // BtnSelectFrontLeft
            // 
            this.BtnSelectFrontLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnSelectFrontLeft.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnSelectFrontLeft.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnSelectFrontLeft.ForeColor = System.Drawing.Color.White;
            this.BtnSelectFrontLeft.Location = new System.Drawing.Point(252, 28);
            this.BtnSelectFrontLeft.Name = "BtnSelectFrontLeft";
            this.BtnSelectFrontLeft.Size = new System.Drawing.Size(100, 35);
            this.BtnSelectFrontLeft.TabIndex = 5;
            this.BtnSelectFrontLeft.Tag = "";
            this.BtnSelectFrontLeft.Text = "선택";
            this.BtnSelectFrontLeft.UseVisualStyleBackColor = false;
            this.BtnSelectFrontLeft.Click += new System.EventHandler(this.BtnSelectFrontLeft_Click);
            // 
            // LblTitleCamSelection
            // 
            this.LblTitleCamSelection.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCamSelection.BDrawBorderBottom = true;
            this.LblTitleCamSelection.BDrawBorderLeft = false;
            this.LblTitleCamSelection.BDrawBorderRight = false;
            this.LblTitleCamSelection.BDrawBorderTop = false;
            this.LblTitleCamSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitleCamSelection.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCamSelection.ForeColor = System.Drawing.Color.White;
            this.LblTitleCamSelection.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCamSelection.Name = "LblTitleCamSelection";
            this.LblTitleCamSelection.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCamSelection.Size = new System.Drawing.Size(354, 28);
            this.LblTitleCamSelection.TabIndex = 4;
            this.LblTitleCamSelection.Text = "카메라 정보";
            this.LblTitleCamSelection.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnApply
            // 
            this.BtnApply.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnApply.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnApply.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnApply.ForeColor = System.Drawing.Color.White;
            this.BtnApply.Location = new System.Drawing.Point(146, 3);
            this.BtnApply.Name = "BtnApply";
            this.BtnApply.Size = new System.Drawing.Size(100, 35);
            this.BtnApply.TabIndex = 4;
            this.BtnApply.Text = "확인";
            this.BtnApply.UseVisualStyleBackColor = false;
            this.BtnApply.Click += new System.EventHandler(this.BtnApply_Click);
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnApply);
            this.PnlButton.Controls.Add(this.BtnClose);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 232);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(354, 40);
            this.PnlButton.TabIndex = 11;
            // 
            // frmCameraSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(354, 272);
            this.Controls.Add(this.PnlMiddleBottom);
            this.Controls.Add(this.PnlMiddleTop);
            this.Controls.Add(this.PnlButton);
            this.Controls.Add(this.PnlTop);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCameraSelector";
            this.Text = "카메라 설정 화면";
            this.Load += new System.EventHandler(this.frmCameraSelector_Load);
            this.PnlTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DgvCamList)).EndInit();
            this.PnlMiddleBottom.ResumeLayout(false);
            this.PnlMiddleTop.ResumeLayout(false);
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CPanel PnlTop;
        private Jhjo.Component.CLabel LblTitleCamSelector;
        private System.Windows.Forms.DataGridView DgvCamList;
        private Jhjo.Component.CLabel LblIP;
        private Jhjo.Component.CPanel PnlMiddleBottom;
        private Jhjo.Component.CLabel LblTitleCamList;
        private Jhjo.Component.CLabel LblTitleIP;
        private System.Windows.Forms.Button BtnClose;
        private Jhjo.Component.CPanel PnlMiddleTop;
        private System.Windows.Forms.Button BtnSelectFrontLeft;
        private Jhjo.Component.CLabel LblTitleCamSelection;
        private System.Windows.Forms.Button BtnApply;
        private Jhjo.Component.CPanel PnlButton;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColCompany;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColIP;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColSerial;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColKey;
    }
}
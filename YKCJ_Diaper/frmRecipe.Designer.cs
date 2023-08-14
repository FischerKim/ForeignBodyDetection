namespace YKCJ_Diaper
{
    partial class frmRecipe
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
            this.PnlButton = new Jhjo.Component.CPanel();
            this.BtnOK = new System.Windows.Forms.Button();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.LblTitleName = new Jhjo.Component.CLabel();
            this.TxtName = new System.Windows.Forms.TextBox();
            this.PnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnOK);
            this.PnlButton.Controls.Add(this.BtnCancel);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 55);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(259, 40);
            this.PnlButton.TabIndex = 0;
            // 
            // BtnOK
            // 
            this.BtnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnOK.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnOK.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnOK.ForeColor = System.Drawing.Color.White;
            this.BtnOK.Location = new System.Drawing.Point(50, 3);
            this.BtnOK.Name = "BtnOK";
            this.BtnOK.Size = new System.Drawing.Size(100, 35);
            this.BtnOK.TabIndex = 10;
            this.BtnOK.Text = "확인";
            this.BtnOK.UseVisualStyleBackColor = false;
            this.BtnOK.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.BtnCancel.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnCancel.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnCancel.ForeColor = System.Drawing.Color.White;
            this.BtnCancel.Location = new System.Drawing.Point(156, 3);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(100, 35);
            this.BtnCancel.TabIndex = 10;
            this.BtnCancel.Text = "취소";
            this.BtnCancel.UseVisualStyleBackColor = false;
            this.BtnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // LblTitle
            // 
            this.LblTitle.BackColor = System.Drawing.Color.DarkSlateGray;
            this.LblTitle.BDrawBorderBottom = true;
            this.LblTitle.BDrawBorderLeft = false;
            this.LblTitle.BDrawBorderRight = false;
            this.LblTitle.BDrawBorderTop = false;
            this.LblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.LblTitle.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitle.ForeColor = System.Drawing.Color.White;
            this.LblTitle.Location = new System.Drawing.Point(0, 0);
            this.LblTitle.Name = "LblTitle";
            this.LblTitle.OBorderColor = System.Drawing.Color.Black;
            this.LblTitle.Size = new System.Drawing.Size(259, 28);
            this.LblTitle.TabIndex = 6;
            this.LblTitle.Text = "모델";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleName
            // 
            this.LblTitleName.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleName.BDrawBorderBottom = true;
            this.LblTitleName.BDrawBorderLeft = false;
            this.LblTitleName.BDrawBorderRight = true;
            this.LblTitleName.BDrawBorderTop = false;
            this.LblTitleName.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleName.ForeColor = System.Drawing.Color.White;
            this.LblTitleName.Location = new System.Drawing.Point(0, 28);
            this.LblTitleName.Name = "LblTitleName";
            this.LblTitleName.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleName.Size = new System.Drawing.Size(100, 28);
            this.LblTitleName.TabIndex = 7;
            this.LblTitleName.Text = "이름";
            this.LblTitleName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxtName
            // 
            this.TxtName.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.TxtName.Location = new System.Drawing.Point(106, 29);
            this.TxtName.Name = "TxtName";
            this.TxtName.Size = new System.Drawing.Size(150, 25);
            this.TxtName.TabIndex = 12;
            // 
            // frmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 95);
            this.Controls.Add(this.TxtName);
            this.Controls.Add(this.LblTitleName);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmRecipe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "모델 생성 화면";
            this.TopMost = true;
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Jhjo.Component.CPanel PnlButton;
        private Jhjo.Component.CLabel LblTitle;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnOK;
        private Jhjo.Component.CLabel LblTitleName;
        private System.Windows.Forms.TextBox TxtName;
    }
}
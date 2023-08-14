namespace YKCJ_Diaper
{
    partial class frmROIRectangle
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
            this.PnlBody = new Jhjo.Component.CPanel();
            this.NudHeight = new System.Windows.Forms.NumericUpDown();
            this.NudWidth = new System.Windows.Forms.NumericUpDown();
            this.NudY = new System.Windows.Forms.NumericUpDown();
            this.NudX = new System.Windows.Forms.NumericUpDown();
            this.LblTitleHeight = new Jhjo.Component.CLabel();
            this.LblTitleWidth = new Jhjo.Component.CLabel();
            this.LblTitleY = new Jhjo.Component.CLabel();
            this.LblTitleX = new Jhjo.Component.CLabel();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudX)).BeginInit();
            this.PnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Controls.Add(this.NudHeight);
            this.PnlBody.Controls.Add(this.NudWidth);
            this.PnlBody.Controls.Add(this.NudY);
            this.PnlBody.Controls.Add(this.NudX);
            this.PnlBody.Controls.Add(this.LblTitleHeight);
            this.PnlBody.Controls.Add(this.LblTitleWidth);
            this.PnlBody.Controls.Add(this.LblTitleY);
            this.PnlBody.Controls.Add(this.LblTitleX);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 28);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(229, 112);
            this.PnlBody.TabIndex = 19;
            // 
            // NudHeight
            // 
            this.NudHeight.DecimalPlaces = 2;
            this.NudHeight.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudHeight.Location = new System.Drawing.Point(106, 86);
            this.NudHeight.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudHeight.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudHeight.Name = "NudHeight";
            this.NudHeight.Size = new System.Drawing.Size(120, 25);
            this.NudHeight.TabIndex = 13;
            this.NudHeight.Tag = "Height";
            this.NudHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudHeight.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudHeight.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudWidth
            // 
            this.NudWidth.DecimalPlaces = 2;
            this.NudWidth.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudWidth.Location = new System.Drawing.Point(106, 58);
            this.NudWidth.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudWidth.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudWidth.Name = "NudWidth";
            this.NudWidth.Size = new System.Drawing.Size(120, 25);
            this.NudWidth.TabIndex = 13;
            this.NudWidth.Tag = "Width";
            this.NudWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudWidth.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudY
            // 
            this.NudY.DecimalPlaces = 2;
            this.NudY.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudY.Location = new System.Drawing.Point(106, 30);
            this.NudY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudY.Name = "NudY";
            this.NudY.Size = new System.Drawing.Size(120, 25);
            this.NudY.TabIndex = 13;
            this.NudY.Tag = "Y";
            this.NudY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudY.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudX
            // 
            this.NudX.DecimalPlaces = 2;
            this.NudX.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudX.Location = new System.Drawing.Point(106, 2);
            this.NudX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudX.Name = "NudX";
            this.NudX.Size = new System.Drawing.Size(120, 25);
            this.NudX.TabIndex = 13;
            this.NudX.Tag = "X";
            this.NudX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudX.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // LblTitleHeight
            // 
            this.LblTitleHeight.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleHeight.BDrawBorderBottom = false;
            this.LblTitleHeight.BDrawBorderLeft = false;
            this.LblTitleHeight.BDrawBorderRight = true;
            this.LblTitleHeight.BDrawBorderTop = false;
            this.LblTitleHeight.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleHeight.ForeColor = System.Drawing.Color.White;
            this.LblTitleHeight.Location = new System.Drawing.Point(0, 84);
            this.LblTitleHeight.Name = "LblTitleHeight";
            this.LblTitleHeight.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleHeight.Size = new System.Drawing.Size(100, 28);
            this.LblTitleHeight.TabIndex = 7;
            this.LblTitleHeight.Text = "Height";
            this.LblTitleHeight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleWidth
            // 
            this.LblTitleWidth.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleWidth.BDrawBorderBottom = true;
            this.LblTitleWidth.BDrawBorderLeft = false;
            this.LblTitleWidth.BDrawBorderRight = true;
            this.LblTitleWidth.BDrawBorderTop = false;
            this.LblTitleWidth.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleWidth.ForeColor = System.Drawing.Color.White;
            this.LblTitleWidth.Location = new System.Drawing.Point(0, 56);
            this.LblTitleWidth.Name = "LblTitleWidth";
            this.LblTitleWidth.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleWidth.Size = new System.Drawing.Size(100, 28);
            this.LblTitleWidth.TabIndex = 7;
            this.LblTitleWidth.Text = "Width";
            this.LblTitleWidth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleY
            // 
            this.LblTitleY.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleY.BDrawBorderBottom = true;
            this.LblTitleY.BDrawBorderLeft = false;
            this.LblTitleY.BDrawBorderRight = true;
            this.LblTitleY.BDrawBorderTop = false;
            this.LblTitleY.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleY.ForeColor = System.Drawing.Color.White;
            this.LblTitleY.Location = new System.Drawing.Point(0, 28);
            this.LblTitleY.Name = "LblTitleY";
            this.LblTitleY.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleY.Size = new System.Drawing.Size(100, 28);
            this.LblTitleY.TabIndex = 7;
            this.LblTitleY.Text = "Y";
            this.LblTitleY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleX
            // 
            this.LblTitleX.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleX.BDrawBorderBottom = true;
            this.LblTitleX.BDrawBorderLeft = false;
            this.LblTitleX.BDrawBorderRight = true;
            this.LblTitleX.BDrawBorderTop = false;
            this.LblTitleX.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleX.ForeColor = System.Drawing.Color.White;
            this.LblTitleX.Location = new System.Drawing.Point(0, 0);
            this.LblTitleX.Name = "LblTitleX";
            this.LblTitleX.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleX.Size = new System.Drawing.Size(100, 28);
            this.LblTitleX.TabIndex = 7;
            this.LblTitleX.Text = "X";
            this.LblTitleX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LblTitle.Size = new System.Drawing.Size(229, 28);
            this.LblTitle.TabIndex = 17;
            this.LblTitle.Text = "Rectangle";
            this.LblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PnlButton
            // 
            this.PnlButton.BDrawBorderBottom = false;
            this.PnlButton.BDrawBorderLeft = false;
            this.PnlButton.BDrawBorderRight = false;
            this.PnlButton.BDrawBorderTop = true;
            this.PnlButton.Controls.Add(this.BtnClose);
            this.PnlButton.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PnlButton.Location = new System.Drawing.Point(0, 140);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(229, 40);
            this.PnlButton.TabIndex = 18;
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(126, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(100, 35);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // frmROIRectangle
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 180);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmROIRectangle";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI (Rectangle)";
            this.PnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudX)).EndInit();
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private Jhjo.Component.CPanel PnlBody;
        private System.Windows.Forms.NumericUpDown NudHeight;
        private System.Windows.Forms.NumericUpDown NudWidth;
        private System.Windows.Forms.NumericUpDown NudY;
        private System.Windows.Forms.NumericUpDown NudX;
        private Jhjo.Component.CLabel LblTitleHeight;
        private Jhjo.Component.CLabel LblTitleWidth;
        private Jhjo.Component.CLabel LblTitleY;
        private Jhjo.Component.CLabel LblTitleX;
        private Jhjo.Component.CLabel LblTitle;
        private Jhjo.Component.CPanel PnlButton;

    }
}
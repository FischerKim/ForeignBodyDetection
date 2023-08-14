namespace YKCJ_Diaper
{
    partial class frmROIEllipse
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
            this.NudRotation = new System.Windows.Forms.NumericUpDown();
            this.NudRadiusY = new System.Windows.Forms.NumericUpDown();
            this.NudRadiusX = new System.Windows.Forms.NumericUpDown();
            this.NudCenterY = new System.Windows.Forms.NumericUpDown();
            this.NudCenterX = new System.Windows.Forms.NumericUpDown();
            this.LblTitleRotation = new Jhjo.Component.CLabel();
            this.LblTitleRadiusY = new Jhjo.Component.CLabel();
            this.LblTitleRadiusX = new Jhjo.Component.CLabel();
            this.LblTitleCenterY = new Jhjo.Component.CLabel();
            this.LblTitleCenterX = new Jhjo.Component.CLabel();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudRotation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadiusY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadiusX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterX)).BeginInit();
            this.PnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Controls.Add(this.NudRotation);
            this.PnlBody.Controls.Add(this.NudRadiusY);
            this.PnlBody.Controls.Add(this.NudRadiusX);
            this.PnlBody.Controls.Add(this.NudCenterY);
            this.PnlBody.Controls.Add(this.NudCenterX);
            this.PnlBody.Controls.Add(this.LblTitleRotation);
            this.PnlBody.Controls.Add(this.LblTitleRadiusY);
            this.PnlBody.Controls.Add(this.LblTitleRadiusX);
            this.PnlBody.Controls.Add(this.LblTitleCenterY);
            this.PnlBody.Controls.Add(this.LblTitleCenterX);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 28);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(229, 140);
            this.PnlBody.TabIndex = 13;
            // 
            // NudRotation
            // 
            this.NudRotation.DecimalPlaces = 2;
            this.NudRotation.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudRotation.Location = new System.Drawing.Point(106, 114);
            this.NudRotation.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudRotation.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudRotation.Name = "NudRotation";
            this.NudRotation.Size = new System.Drawing.Size(120, 25);
            this.NudRotation.TabIndex = 13;
            this.NudRotation.Tag = "Rotation";
            this.NudRotation.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudRotation.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRotation.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudRadiusY
            // 
            this.NudRadiusY.DecimalPlaces = 2;
            this.NudRadiusY.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudRadiusY.Location = new System.Drawing.Point(106, 86);
            this.NudRadiusY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudRadiusY.Name = "NudRadiusY";
            this.NudRadiusY.Size = new System.Drawing.Size(120, 25);
            this.NudRadiusY.TabIndex = 13;
            this.NudRadiusY.Tag = "RadiusY";
            this.NudRadiusY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudRadiusY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRadiusY.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudRadiusX
            // 
            this.NudRadiusX.DecimalPlaces = 2;
            this.NudRadiusX.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudRadiusX.Location = new System.Drawing.Point(106, 58);
            this.NudRadiusX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudRadiusX.Name = "NudRadiusX";
            this.NudRadiusX.Size = new System.Drawing.Size(120, 25);
            this.NudRadiusX.TabIndex = 13;
            this.NudRadiusX.Tag = "RadiusX";
            this.NudRadiusX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudRadiusX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRadiusX.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudCenterY
            // 
            this.NudCenterY.DecimalPlaces = 2;
            this.NudCenterY.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudCenterY.Location = new System.Drawing.Point(106, 30);
            this.NudCenterY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudCenterY.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudCenterY.Name = "NudCenterY";
            this.NudCenterY.Size = new System.Drawing.Size(120, 25);
            this.NudCenterY.TabIndex = 13;
            this.NudCenterY.Tag = "CenterY";
            this.NudCenterY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudCenterY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCenterY.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudCenterX
            // 
            this.NudCenterX.DecimalPlaces = 2;
            this.NudCenterX.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudCenterX.Location = new System.Drawing.Point(106, 2);
            this.NudCenterX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudCenterX.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudCenterX.Name = "NudCenterX";
            this.NudCenterX.Size = new System.Drawing.Size(120, 25);
            this.NudCenterX.TabIndex = 13;
            this.NudCenterX.Tag = "CenterX";
            this.NudCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudCenterX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCenterX.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // LblTitleRotation
            // 
            this.LblTitleRotation.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRotation.BDrawBorderBottom = false;
            this.LblTitleRotation.BDrawBorderLeft = false;
            this.LblTitleRotation.BDrawBorderRight = true;
            this.LblTitleRotation.BDrawBorderTop = false;
            this.LblTitleRotation.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRotation.ForeColor = System.Drawing.Color.White;
            this.LblTitleRotation.Location = new System.Drawing.Point(0, 112);
            this.LblTitleRotation.Name = "LblTitleRotation";
            this.LblTitleRotation.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRotation.Size = new System.Drawing.Size(100, 28);
            this.LblTitleRotation.TabIndex = 7;
            this.LblTitleRotation.Text = "Rotation";
            this.LblTitleRotation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRadiusY
            // 
            this.LblTitleRadiusY.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRadiusY.BDrawBorderBottom = true;
            this.LblTitleRadiusY.BDrawBorderLeft = false;
            this.LblTitleRadiusY.BDrawBorderRight = true;
            this.LblTitleRadiusY.BDrawBorderTop = false;
            this.LblTitleRadiusY.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRadiusY.ForeColor = System.Drawing.Color.White;
            this.LblTitleRadiusY.Location = new System.Drawing.Point(0, 84);
            this.LblTitleRadiusY.Name = "LblTitleRadiusY";
            this.LblTitleRadiusY.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRadiusY.Size = new System.Drawing.Size(100, 28);
            this.LblTitleRadiusY.TabIndex = 7;
            this.LblTitleRadiusY.Text = "Radius Y";
            this.LblTitleRadiusY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRadiusX
            // 
            this.LblTitleRadiusX.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRadiusX.BDrawBorderBottom = true;
            this.LblTitleRadiusX.BDrawBorderLeft = false;
            this.LblTitleRadiusX.BDrawBorderRight = true;
            this.LblTitleRadiusX.BDrawBorderTop = false;
            this.LblTitleRadiusX.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRadiusX.ForeColor = System.Drawing.Color.White;
            this.LblTitleRadiusX.Location = new System.Drawing.Point(0, 56);
            this.LblTitleRadiusX.Name = "LblTitleRadiusX";
            this.LblTitleRadiusX.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRadiusX.Size = new System.Drawing.Size(100, 28);
            this.LblTitleRadiusX.TabIndex = 7;
            this.LblTitleRadiusX.Text = "Radius X";
            this.LblTitleRadiusX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleCenterY
            // 
            this.LblTitleCenterY.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCenterY.BDrawBorderBottom = true;
            this.LblTitleCenterY.BDrawBorderLeft = false;
            this.LblTitleCenterY.BDrawBorderRight = true;
            this.LblTitleCenterY.BDrawBorderTop = false;
            this.LblTitleCenterY.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCenterY.ForeColor = System.Drawing.Color.White;
            this.LblTitleCenterY.Location = new System.Drawing.Point(0, 28);
            this.LblTitleCenterY.Name = "LblTitleCenterY";
            this.LblTitleCenterY.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCenterY.Size = new System.Drawing.Size(100, 28);
            this.LblTitleCenterY.TabIndex = 7;
            this.LblTitleCenterY.Text = "Center Y";
            this.LblTitleCenterY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleCenterX
            // 
            this.LblTitleCenterX.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleCenterX.BDrawBorderBottom = true;
            this.LblTitleCenterX.BDrawBorderLeft = false;
            this.LblTitleCenterX.BDrawBorderRight = true;
            this.LblTitleCenterX.BDrawBorderTop = false;
            this.LblTitleCenterX.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleCenterX.ForeColor = System.Drawing.Color.White;
            this.LblTitleCenterX.Location = new System.Drawing.Point(0, 0);
            this.LblTitleCenterX.Name = "LblTitleCenterX";
            this.LblTitleCenterX.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleCenterX.Size = new System.Drawing.Size(100, 28);
            this.LblTitleCenterX.TabIndex = 7;
            this.LblTitleCenterX.Text = "Center X";
            this.LblTitleCenterX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LblTitle.TabIndex = 11;
            this.LblTitle.Text = "Ellipse";
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
            this.PnlButton.Location = new System.Drawing.Point(0, 168);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(229, 40);
            this.PnlButton.TabIndex = 12;
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
            // frmROIEllipse
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 208);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmROIEllipse";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI (Ellipse)";
            this.PnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudRotation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadiusY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadiusX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterX)).EndInit();
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.NumericUpDown NudRadiusY;
        private Jhjo.Component.CLabel LblTitleRadiusY;
        private Jhjo.Component.CLabel LblTitleCenterY;
        private System.Windows.Forms.NumericUpDown NudRadiusX;
        private System.Windows.Forms.NumericUpDown NudCenterX;
        private System.Windows.Forms.NumericUpDown NudCenterY;
        private Jhjo.Component.CLabel LblTitle;
        private Jhjo.Component.CLabel LblTitleRadiusX;
        private System.Windows.Forms.Button BtnClose;
        private Jhjo.Component.CPanel PnlBody;
        private Jhjo.Component.CLabel LblTitleCenterX;
        private Jhjo.Component.CPanel PnlButton;
        private System.Windows.Forms.NumericUpDown NudRotation;
        private Jhjo.Component.CLabel LblTitleRotation;

    }
}
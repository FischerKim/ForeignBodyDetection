namespace YKCJ_Diaper
{
    partial class frmROICircularAnnulusSection
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
            this.NudAngleSpan = new System.Windows.Forms.NumericUpDown();
            this.NudAngleStart = new System.Windows.Forms.NumericUpDown();
            this.NudRadialScale = new System.Windows.Forms.NumericUpDown();
            this.NudRadius = new System.Windows.Forms.NumericUpDown();
            this.NudCenterY = new System.Windows.Forms.NumericUpDown();
            this.NudCenterX = new System.Windows.Forms.NumericUpDown();
            this.LblTitleAngleSpan = new Jhjo.Component.CLabel();
            this.LblTitleAngleStart = new Jhjo.Component.CLabel();
            this.LblTitleRadialScale = new Jhjo.Component.CLabel();
            this.LblTitleRadius = new Jhjo.Component.CLabel();
            this.LblTitleCenterY = new Jhjo.Component.CLabel();
            this.LblTitleCenterX = new Jhjo.Component.CLabel();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlButton = new Jhjo.Component.CPanel();
            this.BtnClose = new System.Windows.Forms.Button();
            this.PnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudAngleSpan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAngleStart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadialScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadius)).BeginInit();
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
            this.PnlBody.Controls.Add(this.NudAngleSpan);
            this.PnlBody.Controls.Add(this.NudAngleStart);
            this.PnlBody.Controls.Add(this.NudRadialScale);
            this.PnlBody.Controls.Add(this.NudRadius);
            this.PnlBody.Controls.Add(this.NudCenterY);
            this.PnlBody.Controls.Add(this.NudCenterX);
            this.PnlBody.Controls.Add(this.LblTitleAngleSpan);
            this.PnlBody.Controls.Add(this.LblTitleAngleStart);
            this.PnlBody.Controls.Add(this.LblTitleRadialScale);
            this.PnlBody.Controls.Add(this.LblTitleRadius);
            this.PnlBody.Controls.Add(this.LblTitleCenterY);
            this.PnlBody.Controls.Add(this.LblTitleCenterX);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 28);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(229, 168);
            this.PnlBody.TabIndex = 10;
            // 
            // NudAngleSpan
            // 
            this.NudAngleSpan.DecimalPlaces = 2;
            this.NudAngleSpan.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudAngleSpan.Location = new System.Drawing.Point(106, 142);
            this.NudAngleSpan.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudAngleSpan.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudAngleSpan.Name = "NudAngleSpan";
            this.NudAngleSpan.Size = new System.Drawing.Size(120, 25);
            this.NudAngleSpan.TabIndex = 13;
            this.NudAngleSpan.Tag = "AngleSpan";
            this.NudAngleSpan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudAngleSpan.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudAngleSpan.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudAngleStart
            // 
            this.NudAngleStart.DecimalPlaces = 2;
            this.NudAngleStart.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudAngleStart.Location = new System.Drawing.Point(106, 114);
            this.NudAngleStart.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudAngleStart.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudAngleStart.Name = "NudAngleStart";
            this.NudAngleStart.Size = new System.Drawing.Size(120, 25);
            this.NudAngleStart.TabIndex = 13;
            this.NudAngleStart.Tag = "AngleStart";
            this.NudAngleStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudAngleStart.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudAngleStart.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudRadialScale
            // 
            this.NudRadialScale.DecimalPlaces = 2;
            this.NudRadialScale.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudRadialScale.Location = new System.Drawing.Point(106, 86);
            this.NudRadialScale.Maximum = new decimal(new int[] {
            99,
            0,
            0,
            131072});
            this.NudRadialScale.Name = "NudRadialScale";
            this.NudRadialScale.Size = new System.Drawing.Size(120, 25);
            this.NudRadialScale.TabIndex = 13;
            this.NudRadialScale.Tag = "RadialScale";
            this.NudRadialScale.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudRadialScale.Value = new decimal(new int[] {
            5,
            0,
            0,
            65536});
            this.NudRadialScale.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudRadius
            // 
            this.NudRadius.DecimalPlaces = 2;
            this.NudRadius.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudRadius.Location = new System.Drawing.Point(106, 58);
            this.NudRadius.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudRadius.Name = "NudRadius";
            this.NudRadius.Size = new System.Drawing.Size(120, 25);
            this.NudRadius.TabIndex = 13;
            this.NudRadius.Tag = "Radius";
            this.NudRadius.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudRadius.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudRadius.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
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
            // LblTitleAngleSpan
            // 
            this.LblTitleAngleSpan.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleAngleSpan.BDrawBorderBottom = false;
            this.LblTitleAngleSpan.BDrawBorderLeft = false;
            this.LblTitleAngleSpan.BDrawBorderRight = true;
            this.LblTitleAngleSpan.BDrawBorderTop = false;
            this.LblTitleAngleSpan.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleAngleSpan.ForeColor = System.Drawing.Color.White;
            this.LblTitleAngleSpan.Location = new System.Drawing.Point(0, 140);
            this.LblTitleAngleSpan.Name = "LblTitleAngleSpan";
            this.LblTitleAngleSpan.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleAngleSpan.Size = new System.Drawing.Size(100, 28);
            this.LblTitleAngleSpan.TabIndex = 7;
            this.LblTitleAngleSpan.Text = "Angle Span";
            this.LblTitleAngleSpan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleAngleStart
            // 
            this.LblTitleAngleStart.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleAngleStart.BDrawBorderBottom = true;
            this.LblTitleAngleStart.BDrawBorderLeft = false;
            this.LblTitleAngleStart.BDrawBorderRight = true;
            this.LblTitleAngleStart.BDrawBorderTop = false;
            this.LblTitleAngleStart.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleAngleStart.ForeColor = System.Drawing.Color.White;
            this.LblTitleAngleStart.Location = new System.Drawing.Point(0, 112);
            this.LblTitleAngleStart.Name = "LblTitleAngleStart";
            this.LblTitleAngleStart.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleAngleStart.Size = new System.Drawing.Size(100, 28);
            this.LblTitleAngleStart.TabIndex = 7;
            this.LblTitleAngleStart.Text = "Angle Start";
            this.LblTitleAngleStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRadialScale
            // 
            this.LblTitleRadialScale.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRadialScale.BDrawBorderBottom = true;
            this.LblTitleRadialScale.BDrawBorderLeft = false;
            this.LblTitleRadialScale.BDrawBorderRight = true;
            this.LblTitleRadialScale.BDrawBorderTop = false;
            this.LblTitleRadialScale.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRadialScale.ForeColor = System.Drawing.Color.White;
            this.LblTitleRadialScale.Location = new System.Drawing.Point(0, 84);
            this.LblTitleRadialScale.Name = "LblTitleRadialScale";
            this.LblTitleRadialScale.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRadialScale.Size = new System.Drawing.Size(100, 28);
            this.LblTitleRadialScale.TabIndex = 7;
            this.LblTitleRadialScale.Text = "Radial Scale";
            this.LblTitleRadialScale.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRadius
            // 
            this.LblTitleRadius.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRadius.BDrawBorderBottom = true;
            this.LblTitleRadius.BDrawBorderLeft = false;
            this.LblTitleRadius.BDrawBorderRight = true;
            this.LblTitleRadius.BDrawBorderTop = false;
            this.LblTitleRadius.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleRadius.ForeColor = System.Drawing.Color.White;
            this.LblTitleRadius.Location = new System.Drawing.Point(0, 56);
            this.LblTitleRadius.Name = "LblTitleRadius";
            this.LblTitleRadius.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleRadius.Size = new System.Drawing.Size(100, 28);
            this.LblTitleRadius.TabIndex = 7;
            this.LblTitleRadius.Text = "Radius";
            this.LblTitleRadius.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LblTitle.TabIndex = 8;
            this.LblTitle.Text = "CircularAnnulusSection";
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
            this.PnlButton.Location = new System.Drawing.Point(0, 196);
            this.PnlButton.Name = "PnlButton";
            this.PnlButton.Size = new System.Drawing.Size(229, 40);
            this.PnlButton.TabIndex = 9;
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
            // frmROICircularAnnulusSection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(229, 236);
            this.Controls.Add(this.PnlBody);
            this.Controls.Add(this.LblTitle);
            this.Controls.Add(this.PnlButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmROICircularAnnulusSection";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI (CircularAnnulusSection)";
            this.PnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudAngleSpan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudAngleStart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadialScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterX)).EndInit();
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Jhjo.Component.CLabel LblTitle;
        private System.Windows.Forms.NumericUpDown NudRadius;
        private System.Windows.Forms.NumericUpDown NudCenterY;
        private System.Windows.Forms.NumericUpDown NudCenterX;
        private Jhjo.Component.CLabel LblTitleRadius;
        private Jhjo.Component.CPanel PnlBody;
        private Jhjo.Component.CLabel LblTitleCenterY;
        private Jhjo.Component.CLabel LblTitleCenterX;
        private Jhjo.Component.CPanel PnlButton;
        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.NumericUpDown NudAngleSpan;
        private System.Windows.Forms.NumericUpDown NudAngleStart;
        private System.Windows.Forms.NumericUpDown NudRadialScale;
        private Jhjo.Component.CLabel LblTitleAngleSpan;
        private Jhjo.Component.CLabel LblTitleAngleStart;
        private Jhjo.Component.CLabel LblTitleRadialScale;

    }
}
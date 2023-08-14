namespace YKCJ_Diaper
{
    partial class frmROIRectangleAffine
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
            this.BtnClose = new System.Windows.Forms.Button();
            this.NudSkew = new System.Windows.Forms.NumericUpDown();
            this.NudRotation = new System.Windows.Forms.NumericUpDown();
            this.PnlBody = new Jhjo.Component.CPanel();
            this.NudLengthY = new System.Windows.Forms.NumericUpDown();
            this.NudLengthX = new System.Windows.Forms.NumericUpDown();
            this.NudCenterY = new System.Windows.Forms.NumericUpDown();
            this.NudCenterX = new System.Windows.Forms.NumericUpDown();
            this.LblTitleSkew = new Jhjo.Component.CLabel();
            this.LblTitleRotation = new Jhjo.Component.CLabel();
            this.LblTitleLengthY = new Jhjo.Component.CLabel();
            this.LblTitleLengthX = new Jhjo.Component.CLabel();
            this.LblTitleCenterY = new Jhjo.Component.CLabel();
            this.LblTitleCenterX = new Jhjo.Component.CLabel();
            this.LblTitle = new Jhjo.Component.CLabel();
            this.PnlButton = new Jhjo.Component.CPanel();
            ((System.ComponentModel.ISupportInitialize)(this.NudSkew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRotation)).BeginInit();
            this.PnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NudLengthY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudLengthX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterX)).BeginInit();
            this.PnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnClose
            // 
            this.BtnClose.BackColor = System.Drawing.Color.SteelBlue;
            this.BtnClose.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.BtnClose.ForeColor = System.Drawing.Color.White;
            this.BtnClose.Location = new System.Drawing.Point(129, 3);
            this.BtnClose.Name = "BtnClose";
            this.BtnClose.Size = new System.Drawing.Size(100, 35);
            this.BtnClose.TabIndex = 10;
            this.BtnClose.Text = "Close";
            this.BtnClose.UseVisualStyleBackColor = false;
            this.BtnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // NudSkew
            // 
            this.NudSkew.DecimalPlaces = 2;
            this.NudSkew.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudSkew.Location = new System.Drawing.Point(106, 142);
            this.NudSkew.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudSkew.Minimum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            -2147483648});
            this.NudSkew.Name = "NudSkew";
            this.NudSkew.Size = new System.Drawing.Size(120, 25);
            this.NudSkew.TabIndex = 13;
            this.NudSkew.Tag = "Skew";
            this.NudSkew.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudSkew.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudSkew.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
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
            // PnlBody
            // 
            this.PnlBody.BDrawBorderBottom = false;
            this.PnlBody.BDrawBorderLeft = false;
            this.PnlBody.BDrawBorderRight = false;
            this.PnlBody.BDrawBorderTop = false;
            this.PnlBody.Controls.Add(this.NudSkew);
            this.PnlBody.Controls.Add(this.NudRotation);
            this.PnlBody.Controls.Add(this.NudLengthY);
            this.PnlBody.Controls.Add(this.NudLengthX);
            this.PnlBody.Controls.Add(this.NudCenterY);
            this.PnlBody.Controls.Add(this.NudCenterX);
            this.PnlBody.Controls.Add(this.LblTitleSkew);
            this.PnlBody.Controls.Add(this.LblTitleRotation);
            this.PnlBody.Controls.Add(this.LblTitleLengthY);
            this.PnlBody.Controls.Add(this.LblTitleLengthX);
            this.PnlBody.Controls.Add(this.LblTitleCenterY);
            this.PnlBody.Controls.Add(this.LblTitleCenterX);
            this.PnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PnlBody.Location = new System.Drawing.Point(0, 28);
            this.PnlBody.Name = "PnlBody";
            this.PnlBody.Size = new System.Drawing.Size(229, 168);
            this.PnlBody.TabIndex = 19;
            // 
            // NudLengthY
            // 
            this.NudLengthY.DecimalPlaces = 2;
            this.NudLengthY.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudLengthY.Location = new System.Drawing.Point(106, 86);
            this.NudLengthY.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudLengthY.Name = "NudLengthY";
            this.NudLengthY.Size = new System.Drawing.Size(120, 25);
            this.NudLengthY.TabIndex = 13;
            this.NudLengthY.Tag = "LengthY";
            this.NudLengthY.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudLengthY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudLengthY.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // NudLengthX
            // 
            this.NudLengthX.DecimalPlaces = 2;
            this.NudLengthX.Font = new System.Drawing.Font("맑은 고딕", 10F);
            this.NudLengthX.Location = new System.Drawing.Point(106, 58);
            this.NudLengthX.Maximum = new decimal(new int[] {
            2147483647,
            0,
            0,
            0});
            this.NudLengthX.Name = "NudLengthX";
            this.NudLengthX.Size = new System.Drawing.Size(120, 25);
            this.NudLengthX.TabIndex = 13;
            this.NudLengthX.Tag = "LengthX";
            this.NudLengthX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudLengthX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudLengthX.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
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
            this.NudCenterX.Tag = "Center X";
            this.NudCenterX.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.NudCenterX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NudCenterX.ValueChanged += new System.EventHandler(this.NudFeature_ValueChanged);
            // 
            // LblTitleSkew
            // 
            this.LblTitleSkew.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleSkew.BDrawBorderBottom = false;
            this.LblTitleSkew.BDrawBorderLeft = false;
            this.LblTitleSkew.BDrawBorderRight = true;
            this.LblTitleSkew.BDrawBorderTop = false;
            this.LblTitleSkew.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleSkew.ForeColor = System.Drawing.Color.White;
            this.LblTitleSkew.Location = new System.Drawing.Point(0, 140);
            this.LblTitleSkew.Name = "LblTitleSkew";
            this.LblTitleSkew.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleSkew.Size = new System.Drawing.Size(100, 28);
            this.LblTitleSkew.TabIndex = 7;
            this.LblTitleSkew.Text = "Skew";
            this.LblTitleSkew.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleRotation
            // 
            this.LblTitleRotation.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleRotation.BDrawBorderBottom = true;
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
            // LblTitleLengthY
            // 
            this.LblTitleLengthY.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleLengthY.BDrawBorderBottom = true;
            this.LblTitleLengthY.BDrawBorderLeft = false;
            this.LblTitleLengthY.BDrawBorderRight = true;
            this.LblTitleLengthY.BDrawBorderTop = false;
            this.LblTitleLengthY.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleLengthY.ForeColor = System.Drawing.Color.White;
            this.LblTitleLengthY.Location = new System.Drawing.Point(0, 84);
            this.LblTitleLengthY.Name = "LblTitleLengthY";
            this.LblTitleLengthY.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleLengthY.Size = new System.Drawing.Size(100, 28);
            this.LblTitleLengthY.TabIndex = 7;
            this.LblTitleLengthY.Text = "Length Y";
            this.LblTitleLengthY.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LblTitleLengthX
            // 
            this.LblTitleLengthX.BackColor = System.Drawing.Color.DimGray;
            this.LblTitleLengthX.BDrawBorderBottom = true;
            this.LblTitleLengthX.BDrawBorderLeft = false;
            this.LblTitleLengthX.BDrawBorderRight = true;
            this.LblTitleLengthX.BDrawBorderTop = false;
            this.LblTitleLengthX.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.LblTitleLengthX.ForeColor = System.Drawing.Color.White;
            this.LblTitleLengthX.Location = new System.Drawing.Point(0, 56);
            this.LblTitleLengthX.Name = "LblTitleLengthX";
            this.LblTitleLengthX.OBorderColor = System.Drawing.Color.Black;
            this.LblTitleLengthX.Size = new System.Drawing.Size(100, 28);
            this.LblTitleLengthX.TabIndex = 7;
            this.LblTitleLengthX.Text = "Length X";
            this.LblTitleLengthX.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.LblTitle.TabIndex = 17;
            this.LblTitle.Text = "RectangleAffine";
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
            this.PnlButton.TabIndex = 18;
            // 
            // frmROIRectangleAffine
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
            this.Name = "frmROIRectangleAffine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ROI (RectangleAffine)";
            ((System.ComponentModel.ISupportInitialize)(this.NudSkew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudRotation)).EndInit();
            this.PnlBody.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NudLengthY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudLengthX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NudCenterX)).EndInit();
            this.PnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnClose;
        private System.Windows.Forms.NumericUpDown NudSkew;
        private System.Windows.Forms.NumericUpDown NudRotation;
        private Jhjo.Component.CPanel PnlBody;
        private System.Windows.Forms.NumericUpDown NudLengthY;
        private System.Windows.Forms.NumericUpDown NudLengthX;
        private System.Windows.Forms.NumericUpDown NudCenterY;
        private System.Windows.Forms.NumericUpDown NudCenterX;
        private Jhjo.Component.CLabel LblTitleSkew;
        private Jhjo.Component.CLabel LblTitleRotation;
        private Jhjo.Component.CLabel LblTitleLengthY;
        private Jhjo.Component.CLabel LblTitleLengthX;
        private Jhjo.Component.CLabel LblTitleCenterY;
        private Jhjo.Component.CLabel LblTitleCenterX;
        private Jhjo.Component.CLabel LblTitle;
        private Jhjo.Component.CPanel PnlButton;

    }
}
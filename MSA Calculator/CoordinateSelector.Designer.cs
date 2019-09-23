namespace MSA_Calculator
{
    partial class CoordinateSelector
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
            this.components = new System.ComponentModel.Container();
            this.latitudeLabel = new System.Windows.Forms.Label();
            this.longitudeLabel = new System.Windows.Forms.Label();
            this.gmsLabel = new System.Windows.Forms.Label();
            this.gmcLabel = new System.Windows.Forms.Label();
            this.gmmLabel = new System.Windows.Forms.Label();
            this.gmsLatitude = new System.Windows.Forms.MaskedTextBox();
            this.gmsLongitude = new System.Windows.Forms.MaskedTextBox();
            this.gmcLatitude = new System.Windows.Forms.MaskedTextBox();
            this.gmcLongitude = new System.Windows.Forms.MaskedTextBox();
            this.gmmLatitude = new System.Windows.Forms.MaskedTextBox();
            this.gmmLongitude = new System.Windows.Forms.MaskedTextBox();
            this.degreeLabel = new System.Windows.Forms.Label();
            this.degreeLatitude = new System.Windows.Forms.TextBox();
            this.degreeLongitude = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // latitudeLabel
            // 
            this.latitudeLabel.AutoSize = true;
            this.latitudeLabel.Location = new System.Drawing.Point(62, 9);
            this.latitudeLabel.Name = "latitudeLabel";
            this.latitudeLabel.Size = new System.Drawing.Size(45, 13);
            this.latitudeLabel.TabIndex = 0;
            this.latitudeLabel.Text = "Latitude";
            // 
            // longitudeLabel
            // 
            this.longitudeLabel.AutoSize = true;
            this.longitudeLabel.Location = new System.Drawing.Point(168, 9);
            this.longitudeLabel.Name = "longitudeLabel";
            this.longitudeLabel.Size = new System.Drawing.Size(54, 13);
            this.longitudeLabel.TabIndex = 1;
            this.longitudeLabel.Text = "Longitude";
            // 
            // gmsLabel
            // 
            this.gmsLabel.AutoSize = true;
            this.gmsLabel.Location = new System.Drawing.Point(12, 28);
            this.gmsLabel.Name = "gmsLabel";
            this.gmsLabel.Size = new System.Drawing.Size(31, 13);
            this.gmsLabel.TabIndex = 2;
            this.gmsLabel.Text = "GMS";
            // 
            // gmcLabel
            // 
            this.gmcLabel.AutoSize = true;
            this.gmcLabel.Location = new System.Drawing.Point(12, 54);
            this.gmcLabel.Name = "gmcLabel";
            this.gmcLabel.Size = new System.Drawing.Size(31, 13);
            this.gmcLabel.TabIndex = 3;
            this.gmcLabel.Text = "GMC";
            // 
            // gmmLabel
            // 
            this.gmmLabel.AutoSize = true;
            this.gmmLabel.Location = new System.Drawing.Point(12, 80);
            this.gmmLabel.Name = "gmmLabel";
            this.gmmLabel.Size = new System.Drawing.Size(33, 13);
            this.gmmLabel.TabIndex = 4;
            this.gmmLabel.Text = "GMM";
            // 
            // gmsLatitude
            // 
            this.gmsLatitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmsLatitude.ForeColor = System.Drawing.Color.White;
            this.gmsLatitude.Location = new System.Drawing.Point(65, 25);
            this.gmsLatitude.Mask = ">L 00º00\'00\'\'";
            this.gmsLatitude.Name = "gmsLatitude";
            this.gmsLatitude.Size = new System.Drawing.Size(100, 20);
            this.gmsLatitude.TabIndex = 5;
            this.gmsLatitude.TextChanged += new System.EventHandler(this.gmsLatitude_TextChanged);
            // 
            // gmsLongitude
            // 
            this.gmsLongitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmsLongitude.ForeColor = System.Drawing.Color.White;
            this.gmsLongitude.Location = new System.Drawing.Point(171, 25);
            this.gmsLongitude.Mask = ">L 000º00\'00\'\'";
            this.gmsLongitude.Name = "gmsLongitude";
            this.gmsLongitude.Size = new System.Drawing.Size(100, 20);
            this.gmsLongitude.TabIndex = 6;
            this.gmsLongitude.TextChanged += new System.EventHandler(this.gmsLongitude_TextChanged);
            // 
            // gmcLatitude
            // 
            this.gmcLatitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmcLatitude.ForeColor = System.Drawing.Color.White;
            this.gmcLatitude.Location = new System.Drawing.Point(65, 51);
            this.gmcLatitude.Mask = ">L 00º00.00\'";
            this.gmcLatitude.Name = "gmcLatitude";
            this.gmcLatitude.Size = new System.Drawing.Size(100, 20);
            this.gmcLatitude.TabIndex = 7;
            this.gmcLatitude.TextChanged += new System.EventHandler(this.gmcLatitude_TextChanged);
            // 
            // gmcLongitude
            // 
            this.gmcLongitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmcLongitude.ForeColor = System.Drawing.Color.White;
            this.gmcLongitude.Location = new System.Drawing.Point(171, 51);
            this.gmcLongitude.Mask = ">L 000º00.00\'";
            this.gmcLongitude.Name = "gmcLongitude";
            this.gmcLongitude.Size = new System.Drawing.Size(100, 20);
            this.gmcLongitude.TabIndex = 8;
            this.gmcLongitude.TextChanged += new System.EventHandler(this.gmcLongitude_TextChanged);
            // 
            // gmmLatitude
            // 
            this.gmmLatitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmmLatitude.ForeColor = System.Drawing.Color.White;
            this.gmmLatitude.Location = new System.Drawing.Point(65, 77);
            this.gmmLatitude.Mask = ">L 00º00.000\'";
            this.gmmLatitude.Name = "gmmLatitude";
            this.gmmLatitude.Size = new System.Drawing.Size(100, 20);
            this.gmmLatitude.TabIndex = 9;
            this.gmmLatitude.TextChanged += new System.EventHandler(this.gmmLatitude_TextChanged);
            // 
            // gmmLongitude
            // 
            this.gmmLongitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.gmmLongitude.ForeColor = System.Drawing.Color.White;
            this.gmmLongitude.Location = new System.Drawing.Point(171, 77);
            this.gmmLongitude.Mask = ">L 000º00.000\'";
            this.gmmLongitude.Name = "gmmLongitude";
            this.gmmLongitude.Size = new System.Drawing.Size(100, 20);
            this.gmmLongitude.TabIndex = 10;
            this.gmmLongitude.TextChanged += new System.EventHandler(this.gmmLongitude_TextChanged);
            // 
            // degreeLabel
            // 
            this.degreeLabel.AutoSize = true;
            this.degreeLabel.Location = new System.Drawing.Point(12, 106);
            this.degreeLabel.Name = "degreeLabel";
            this.degreeLabel.Size = new System.Drawing.Size(47, 13);
            this.degreeLabel.TabIndex = 11;
            this.degreeLabel.Text = "Degrees";
            // 
            // degreeLatitude
            // 
            this.degreeLatitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.degreeLatitude.ForeColor = System.Drawing.Color.White;
            this.degreeLatitude.Location = new System.Drawing.Point(65, 103);
            this.degreeLatitude.Name = "degreeLatitude";
            this.degreeLatitude.Size = new System.Drawing.Size(100, 20);
            this.degreeLatitude.TabIndex = 12;
            this.degreeLatitude.TextChanged += new System.EventHandler(this.degreeLatitude_TextChanged);
            // 
            // degreeLongitude
            // 
            this.degreeLongitude.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.degreeLongitude.ForeColor = System.Drawing.Color.White;
            this.degreeLongitude.Location = new System.Drawing.Point(171, 103);
            this.degreeLongitude.Name = "degreeLongitude";
            this.degreeLongitude.Size = new System.Drawing.Size(100, 20);
            this.degreeLongitude.TabIndex = 13;
            this.degreeLongitude.TextChanged += new System.EventHandler(this.degreeLongitude_TextChanged);
            // 
            // okButton
            // 
            this.okButton.ForeColor = System.Drawing.Color.Black;
            this.okButton.Location = new System.Drawing.Point(115, 129);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 14;
            this.okButton.Text = "&OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.ForeColor = System.Drawing.Color.Black;
            this.cancelButton.Location = new System.Drawing.Point(196, 129);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 15;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // CoordinateSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(286, 166);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.degreeLongitude);
            this.Controls.Add(this.degreeLatitude);
            this.Controls.Add(this.degreeLabel);
            this.Controls.Add(this.gmmLongitude);
            this.Controls.Add(this.gmmLatitude);
            this.Controls.Add(this.gmcLongitude);
            this.Controls.Add(this.gmcLatitude);
            this.Controls.Add(this.gmsLongitude);
            this.Controls.Add(this.gmsLatitude);
            this.Controls.Add(this.gmmLabel);
            this.Controls.Add(this.gmcLabel);
            this.Controls.Add(this.gmsLabel);
            this.Controls.Add(this.longitudeLabel);
            this.Controls.Add(this.latitudeLabel);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CoordinateSelector";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Coordinate Selector";
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label latitudeLabel;
        private System.Windows.Forms.Label longitudeLabel;
        private System.Windows.Forms.Label gmsLabel;
        private System.Windows.Forms.Label gmcLabel;
        private System.Windows.Forms.Label gmmLabel;
        private System.Windows.Forms.MaskedTextBox gmsLatitude;
        private System.Windows.Forms.MaskedTextBox gmsLongitude;
        private System.Windows.Forms.MaskedTextBox gmcLatitude;
        private System.Windows.Forms.MaskedTextBox gmcLongitude;
        private System.Windows.Forms.MaskedTextBox gmmLatitude;
        private System.Windows.Forms.MaskedTextBox gmmLongitude;
        private System.Windows.Forms.Label degreeLabel;
        private System.Windows.Forms.TextBox degreeLatitude;
        private System.Windows.Forms.TextBox degreeLongitude;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}
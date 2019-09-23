namespace MSA_Calculator
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.deleteWaypointButton = new System.Windows.Forms.Button();
            this.addWaypointButton = new System.Windows.Forms.Button();
            this.waypointsListBox = new System.Windows.Forms.ListBox();
            this.editCoordinateButton = new System.Windows.Forms.Button();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label7 = new System.Windows.Forms.Label();
            this.mountainHeightBox = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.heightBox = new System.Windows.Forms.TextBox();
            this.Label27 = new System.Windows.Forms.Label();
            this.getMSAButton = new System.Windows.Forms.Button();
            this.Label18 = new System.Windows.Forms.Label();
            this.radiusBox = new System.Windows.Forms.TextBox();
            this.statusBar = new System.Windows.Forms.Panel();
            this.statusLabel = new System.Windows.Forms.Label();
            this.msaListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fromPMAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadHGTFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.legListBox = new System.Windows.Forms.ListBox();
            this.lowListBox = new System.Windows.Forms.ListBox();
            this.highListBox = new System.Windows.Forms.ListBox();
            this.peakCoordinateListBox = new System.Windows.Forms.ListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.statusBar.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // deleteWaypointButton
            // 
            this.deleteWaypointButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteWaypointButton.Image")));
            this.deleteWaypointButton.Location = new System.Drawing.Point(206, 111);
            this.deleteWaypointButton.Name = "deleteWaypointButton";
            this.deleteWaypointButton.Size = new System.Drawing.Size(23, 23);
            this.deleteWaypointButton.TabIndex = 63;
            this.deleteWaypointButton.UseVisualStyleBackColor = true;
            this.deleteWaypointButton.Click += new System.EventHandler(this.deleteWaypointButton_Click);
            // 
            // addWaypointButton
            // 
            this.addWaypointButton.Image = ((System.Drawing.Image)(resources.GetObject("addWaypointButton.Image")));
            this.addWaypointButton.Location = new System.Drawing.Point(206, 53);
            this.addWaypointButton.Name = "addWaypointButton";
            this.addWaypointButton.Size = new System.Drawing.Size(23, 23);
            this.addWaypointButton.TabIndex = 60;
            this.addWaypointButton.UseVisualStyleBackColor = true;
            this.addWaypointButton.Click += new System.EventHandler(this.addWaypointButton_Click);
            // 
            // waypointsListBox
            // 
            this.waypointsListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.waypointsListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.waypointsListBox.ForeColor = System.Drawing.Color.White;
            this.waypointsListBox.FormattingEnabled = true;
            this.waypointsListBox.Location = new System.Drawing.Point(15, 53);
            this.waypointsListBox.Name = "waypointsListBox";
            this.waypointsListBox.Size = new System.Drawing.Size(185, 197);
            this.waypointsListBox.TabIndex = 59;
            this.waypointsListBox.SelectedIndexChanged += new System.EventHandler(this.waypointsListBox_SelectedIndexChanged);
            // 
            // editCoordinateButton
            // 
            this.editCoordinateButton.Image = ((System.Drawing.Image)(resources.GetObject("editCoordinateButton.Image")));
            this.editCoordinateButton.Location = new System.Drawing.Point(206, 82);
            this.editCoordinateButton.Name = "editCoordinateButton";
            this.editCoordinateButton.Size = new System.Drawing.Size(23, 23);
            this.editCoordinateButton.TabIndex = 58;
            this.editCoordinateButton.Text = "...";
            this.editCoordinateButton.UseVisualStyleBackColor = true;
            this.editCoordinateButton.Click += new System.EventHandler(this.editCoordinateButton_Click);
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Location = new System.Drawing.Point(12, 344);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(143, 13);
            this.Label8.TabIndex = 51;
            this.Label8.Text = "Mountainous Security Height";
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Location = new System.Drawing.Point(121, 363);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(20, 13);
            this.Label7.TabIndex = 50;
            this.Label7.Text = "FT";
            // 
            // mountainHeightBox
            // 
            this.mountainHeightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.mountainHeightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.mountainHeightBox.ForeColor = System.Drawing.Color.White;
            this.mountainHeightBox.Location = new System.Drawing.Point(15, 360);
            this.mountainHeightBox.Name = "mountainHeightBox";
            this.mountainHeightBox.Size = new System.Drawing.Size(100, 20);
            this.mountainHeightBox.TabIndex = 49;
            this.mountainHeightBox.Text = "2000";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Location = new System.Drawing.Point(12, 305);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(79, 13);
            this.Label2.TabIndex = 48;
            this.Label2.Text = "Security Height";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(121, 324);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(20, 13);
            this.Label1.TabIndex = 47;
            this.Label1.Text = "FT";
            // 
            // heightBox
            // 
            this.heightBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.heightBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.heightBox.ForeColor = System.Drawing.Color.White;
            this.heightBox.Location = new System.Drawing.Point(15, 321);
            this.heightBox.Name = "heightBox";
            this.heightBox.Size = new System.Drawing.Size(100, 20);
            this.heightBox.TabIndex = 46;
            this.heightBox.Text = "1000";
            // 
            // Label27
            // 
            this.Label27.AutoSize = true;
            this.Label27.Location = new System.Drawing.Point(121, 285);
            this.Label27.Name = "Label27";
            this.Label27.Size = new System.Drawing.Size(24, 13);
            this.Label27.TabIndex = 39;
            this.Label27.Text = "NM";
            // 
            // getMSAButton
            // 
            this.getMSAButton.ForeColor = System.Drawing.Color.Black;
            this.getMSAButton.Location = new System.Drawing.Point(15, 386);
            this.getMSAButton.Name = "getMSAButton";
            this.getMSAButton.Size = new System.Drawing.Size(75, 23);
            this.getMSAButton.TabIndex = 30;
            this.getMSAButton.Text = "Calculate";
            this.getMSAButton.UseVisualStyleBackColor = true;
            this.getMSAButton.Click += new System.EventHandler(this.getMSAButton_Click);
            // 
            // Label18
            // 
            this.Label18.AutoSize = true;
            this.Label18.Location = new System.Drawing.Point(12, 266);
            this.Label18.Name = "Label18";
            this.Label18.Size = new System.Drawing.Size(40, 13);
            this.Label18.TabIndex = 29;
            this.Label18.Text = "Radius";
            // 
            // radiusBox
            // 
            this.radiusBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(55)))));
            this.radiusBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.radiusBox.ForeColor = System.Drawing.Color.White;
            this.radiusBox.Location = new System.Drawing.Point(15, 282);
            this.radiusBox.Name = "radiusBox";
            this.radiusBox.Size = new System.Drawing.Size(100, 20);
            this.radiusBox.TabIndex = 28;
            this.radiusBox.Text = "10";
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.statusBar.Controls.Add(this.statusLabel);
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(0, 419);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(745, 22);
            this.statusBar.TabIndex = 58;
            // 
            // statusLabel
            // 
            this.statusLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusLabel.ForeColor = System.Drawing.Color.White;
            this.statusLabel.Location = new System.Drawing.Point(0, 0);
            this.statusLabel.Name = "statusLabel";
            this.statusLabel.Size = new System.Drawing.Size(745, 22);
            this.statusLabel.TabIndex = 1;
            this.statusLabel.Text = "Ready";
            this.statusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // msaListBox
            // 
            this.msaListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.msaListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.msaListBox.ForeColor = System.Drawing.Color.White;
            this.msaListBox.FormattingEnabled = true;
            this.msaListBox.Location = new System.Drawing.Point(312, 53);
            this.msaListBox.Name = "msaListBox";
            this.msaListBox.Size = new System.Drawing.Size(71, 340);
            this.msaListBox.TabIndex = 0;
            this.msaListBox.SelectedIndexChanged += new System.EventHandler(this.msaListBox_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(745, 24);
            this.menuStrip1.TabIndex = 60;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fromPMAToolStripMenuItem});
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.openToolStripMenuItem.Text = "Open";
            // 
            // fromPMAToolStripMenuItem
            // 
            this.fromPMAToolStripMenuItem.Name = "fromPMAToolStripMenuItem";
            this.fromPMAToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.fromPMAToolStripMenuItem.Text = "From PMA";
            this.fromPMAToolStripMenuItem.Click += new System.EventHandler(this.fromPMAToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.saveAsToolStripMenuItem.Text = "Save as...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.downloadHGTFilesToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // downloadHGTFilesToolStripMenuItem
            // 
            this.downloadHGTFilesToolStripMenuItem.Name = "downloadHGTFilesToolStripMenuItem";
            this.downloadHGTFilesToolStripMenuItem.Size = new System.Drawing.Size(179, 22);
            this.downloadHGTFilesToolStripMenuItem.Text = "Download HGT files";
            this.downloadHGTFilesToolStripMenuItem.Click += new System.EventHandler(this.downloadHGTFilesToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(312, 37);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 13);
            this.label3.TabIndex = 61;
            this.label3.Text = "MSA";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 62;
            this.label4.Text = "Waypoints";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(386, 37);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 64;
            this.label5.Text = "High";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(463, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 13);
            this.label6.TabIndex = 65;
            this.label6.Text = "Low";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(235, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(25, 13);
            this.label9.TabIndex = 66;
            this.label9.Text = "Leg";
            // 
            // legListBox
            // 
            this.legListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.legListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.legListBox.ForeColor = System.Drawing.Color.White;
            this.legListBox.FormattingEnabled = true;
            this.legListBox.Location = new System.Drawing.Point(235, 53);
            this.legListBox.Name = "legListBox";
            this.legListBox.Size = new System.Drawing.Size(71, 340);
            this.legListBox.TabIndex = 67;
            this.legListBox.SelectedIndexChanged += new System.EventHandler(this.legListBox_SelectedIndexChanged);
            // 
            // lowListBox
            // 
            this.lowListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.lowListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lowListBox.ForeColor = System.Drawing.Color.White;
            this.lowListBox.FormattingEnabled = true;
            this.lowListBox.Location = new System.Drawing.Point(466, 53);
            this.lowListBox.Name = "lowListBox";
            this.lowListBox.Size = new System.Drawing.Size(71, 340);
            this.lowListBox.TabIndex = 69;
            this.lowListBox.SelectedIndexChanged += new System.EventHandler(this.lowListBox_SelectedIndexChanged);
            // 
            // highListBox
            // 
            this.highListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.highListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.highListBox.ForeColor = System.Drawing.Color.White;
            this.highListBox.FormattingEnabled = true;
            this.highListBox.Location = new System.Drawing.Point(389, 53);
            this.highListBox.Name = "highListBox";
            this.highListBox.Size = new System.Drawing.Size(71, 340);
            this.highListBox.TabIndex = 68;
            this.highListBox.SelectedIndexChanged += new System.EventHandler(this.highListBox_SelectedIndexChanged);
            // 
            // peakCoordinateListBox
            // 
            this.peakCoordinateListBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(25)))), ((int)(((byte)(26)))));
            this.peakCoordinateListBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.peakCoordinateListBox.ForeColor = System.Drawing.Color.White;
            this.peakCoordinateListBox.FormattingEnabled = true;
            this.peakCoordinateListBox.Location = new System.Drawing.Point(543, 53);
            this.peakCoordinateListBox.Name = "peakCoordinateListBox";
            this.peakCoordinateListBox.Size = new System.Drawing.Size(193, 340);
            this.peakCoordinateListBox.TabIndex = 70;
            this.peakCoordinateListBox.SelectedIndexChanged += new System.EventHandler(this.peakCoordinateListBox_SelectedIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(540, 37);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(82, 13);
            this.label10.TabIndex = 71;
            this.label10.Text = "High coordinate";
            // 
            // Main
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(45)))), ((int)(((byte)(48)))));
            this.ClientSize = new System.Drawing.Size(745, 441);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.peakCoordinateListBox);
            this.Controls.Add(this.lowListBox);
            this.Controls.Add(this.highListBox);
            this.Controls.Add(this.legListBox);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.deleteWaypointButton);
            this.Controls.Add(this.Label18);
            this.Controls.Add(this.editCoordinateButton);
            this.Controls.Add(this.addWaypointButton);
            this.Controls.Add(this.radiusBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Label27);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.heightBox);
            this.Controls.Add(this.waypointsListBox);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.msaListBox);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.getMSAButton);
            this.Controls.Add(this.mountainHeightBox);
            this.Controls.Add(this.menuStrip1);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "MSA Calculator";
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Main_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Main_DragEnter);
            this.statusBar.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.Label Label8;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.TextBox mountainHeightBox;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox heightBox;
        internal System.Windows.Forms.Label Label27;
        internal System.Windows.Forms.Button getMSAButton;
        internal System.Windows.Forms.Label Label18;
        internal System.Windows.Forms.TextBox radiusBox;
        private System.Windows.Forms.Button editCoordinateButton;
        private System.Windows.Forms.ListBox waypointsListBox;
        private System.Windows.Forms.Button addWaypointButton;
        private System.Windows.Forms.Button deleteWaypointButton;
        private System.Windows.Forms.Panel statusBar;
        private System.Windows.Forms.Label statusLabel;
        private System.Windows.Forms.ListBox msaListBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fromPMAToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ListBox legListBox;
        private System.Windows.Forms.ListBox lowListBox;
        private System.Windows.Forms.ListBox highListBox;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadHGTFilesToolStripMenuItem;
        private System.Windows.Forms.ListBox peakCoordinateListBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
    }
}


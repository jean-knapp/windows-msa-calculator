namespace MSA_Calculator
{
    partial class WaypointsDialog
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
            this.addButton = new DevExpress.XtraEditors.SimpleButton();
            this.editButton = new DevExpress.XtraEditors.SimpleButton();
            this.removeButton = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.waypointsListBox = new DevExpress.XtraTreeList.TreeList();
            this.treeListColumn1 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn2 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.treeListColumn3 = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.waypointsListBox)).BeginInit();
            this.SuspendLayout();
            // 
            // addButton
            // 
            this.addButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.addButton.Location = new System.Drawing.Point(12, 6);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(75, 23);
            this.addButton.TabIndex = 1;
            this.addButton.Text = "Add";
            this.addButton.Click += new System.EventHandler(this.addWaypointButton_Click);
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.Location = new System.Drawing.Point(93, 6);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 2;
            this.editButton.Text = "Edit";
            this.editButton.Click += new System.EventHandler(this.editCoordinateButton_Click);
            // 
            // removeButton
            // 
            this.removeButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.removeButton.Location = new System.Drawing.Point(174, 6);
            this.removeButton.Name = "removeButton";
            this.removeButton.Size = new System.Drawing.Size(75, 23);
            this.removeButton.TabIndex = 3;
            this.removeButton.Text = "Remove";
            this.removeButton.Click += new System.EventHandler(this.deleteWaypointButton_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.addButton);
            this.panelControl1.Controls.Add(this.removeButton);
            this.panelControl1.Controls.Add(this.editButton);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 240);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(292, 36);
            this.panelControl1.TabIndex = 4;
            // 
            // waypointsListBox
            // 
            this.waypointsListBox.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.treeListColumn1,
            this.treeListColumn2,
            this.treeListColumn3});
            this.waypointsListBox.Cursor = System.Windows.Forms.Cursors.SizeWE;
            this.waypointsListBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.waypointsListBox.Location = new System.Drawing.Point(0, 0);
            this.waypointsListBox.Name = "waypointsListBox";
            this.waypointsListBox.OptionsBehavior.Editable = false;
            this.waypointsListBox.Size = new System.Drawing.Size(292, 240);
            this.waypointsListBox.TabIndex = 5;
            // 
            // treeListColumn1
            // 
            this.treeListColumn1.Caption = "ID";
            this.treeListColumn1.FieldName = "id";
            this.treeListColumn1.Name = "treeListColumn1";
            this.treeListColumn1.Visible = true;
            this.treeListColumn1.VisibleIndex = 0;
            // 
            // treeListColumn2
            // 
            this.treeListColumn2.Caption = "Latitude";
            this.treeListColumn2.FieldName = "latitude";
            this.treeListColumn2.Name = "treeListColumn2";
            this.treeListColumn2.Visible = true;
            this.treeListColumn2.VisibleIndex = 1;
            // 
            // treeListColumn3
            // 
            this.treeListColumn3.Caption = "Longitude";
            this.treeListColumn3.FieldName = "longitude";
            this.treeListColumn3.Name = "treeListColumn3";
            this.treeListColumn3.Visible = true;
            this.treeListColumn3.VisibleIndex = 2;
            // 
            // WaypointsDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 276);
            this.Controls.Add(this.waypointsListBox);
            this.Controls.Add(this.panelControl1);
            this.Name = "WaypointsDialog";
            this.Text = "Waypoints";
            this.Load += new System.EventHandler(this.WaypointsDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.waypointsListBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.SimpleButton addButton;
        private DevExpress.XtraEditors.SimpleButton editButton;
        private DevExpress.XtraEditors.SimpleButton removeButton;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraTreeList.TreeList waypointsListBox;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn2;
        private DevExpress.XtraTreeList.Columns.TreeListColumn treeListColumn3;
    }
}
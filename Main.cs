using GlmNet;
using Hammer.Styling;
using PMA;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Xml;

namespace MSA_Calculator
{
    public partial class Main : Form
    {
        List<vec2> waypoints = new List<vec2>();
        string[] args;

        public Main(string[] args)
        {
            InitializeComponent();

            menuStrip1.Renderer = new MenuRenderer(new MenuColorTable());

            menuStrip1.BackColor = Color.FromArgb(45, 45, 48);
            foreach (ToolStripMenuItem item in menuStrip1.Items)
            {
                item.ForeColor = Color.White;
                foreach (ToolStripItem subitem in item.DropDownItems)
                    if (subitem is ToolStripMenuItem)
                    {
                        SetMenuStripSubitemColor((ToolStripMenuItem)subitem);
                    }
            }

            this.args = args;
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            if (args.Length > 0)
            {
                // loadFile();
                Application.DoEvents();
                loadFile(args[0]);
                saveFile(args[0]);
                Close();
            }
        }

        private void SetMenuStripSubitemColor(ToolStripMenuItem item)
        {
            item.ForeColor = Color.White;
            if (item is ToolStripMenuItem)
            {
                foreach (ToolStripMenuItem subitem in item.DropDownItems)
                    SetMenuStripSubitemColor(subitem);
            }
        }

        private void calculateMSA()
        {
            statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Text = "Calculating MSA.";
            Application.DoEvents();
            // Init HGT class
            HGT hgt = new HGT();

            // Start timer
            DateTime start_time = DateTime.Now;

            legListBox.Items.Clear();
            lowListBox.Items.Clear();
            highListBox.Items.Clear();
            msaListBox.Items.Clear();
            peakCoordinateListBox.Items.Clear();

            // Get values
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                vec2 p1 = waypoints[i];
                vec2 p2 = waypoints[i + 1];

                double distance = (double.Parse(radiusBox.Text) / (double)60);

                // Get search area
                vec2[] rectangle = HGT.getRouteRectangle(p1, p2, distance);

                // Load search area
                hgt.loadFiles(rectangle);

                // Get MSA
                short msa = (short)HGT.metresToFeet(hgt.getMSA(rectangle, short.Parse(heightBox.Text), short.Parse(mountainHeightBox.Text)));
                msa = (short)(Math.Ceiling(msa / 100f) * 100);
                //msaListBox.Items.Add(i + "→" + (i + 1) + ") " + msa + "FT");

                // Get peak and valley
                vec2 peak = hgt.getPeakInRectangle(rectangle);
                legListBox.Items.Add(i + "→" + (i + 1));
                lowListBox.Items.Add((short)HGT.metresToFeet(peak.x) + "FT");
                highListBox.Items.Add((short)HGT.metresToFeet(peak.y) + "FT");
                msaListBox.Items.Add(msa + "FT");
                msas[i].InnerText = msa.ToString();

                peakCoordinateListBox.Items.Add(CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(hgt.peakCoordinate)) + " " + CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(hgt.peakCoordinate)));
                Application.DoEvents();

            }

            // Stop timer

            statusLabel.Text = "MSA calculated in " + DateTime.Now.Subtract(start_time).TotalSeconds.ToString("0.000000") + "s.";
            statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
            Application.DoEvents();
        }

        private void getMSAButton_Click(object sender, EventArgs e)
        {
            calculateMSA();
        }

        private void editCoordinateButton_Click(object sender, EventArgs e)
        {
            vec2 selected = waypoints[waypointsListBox.SelectedIndex];
            using (var form = new CoordinateSelector(selected))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    vec2 coordinate = form.coordinate;
                    waypoints[waypointsListBox.SelectedIndex] = coordinate;
                    updateWaypointsList(waypointsListBox.SelectedIndex);

                }
            }
        }

        private void updateWaypointsList(int index)
        {
            updateWaypointsList();
            waypointsListBox.SelectedIndex = index;
        }

        private void updateWaypointsList()
        {
            waypointsListBox.Items.Clear();
            for (int i = 0; i < waypoints.Count; i++)
            {
                waypointsListBox.Items.Add(i + ") " + CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(waypoints[i])) + " " + CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(waypoints[i])));
            }

            bool waypointSelected = (waypointsListBox.SelectedItems.Count > 0);

            editCoordinateButton.Enabled = waypointSelected;
            deleteWaypointButton.Enabled = waypointSelected;
        }

        private void addWaypointButton_Click(object sender, EventArgs e)
        {
            using (var form = new CoordinateSelector(0, 0))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    vec2 coordinate = form.coordinate;
                    waypoints.Add(coordinate);
                    updateWaypointsList();
                }
            }
        }

        private void waypointsListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool waypointSelected = (waypointsListBox.SelectedItems.Count > 0);

            editCoordinateButton.Enabled = waypointSelected;
            deleteWaypointButton.Enabled = waypointSelected;
        }

        private void deleteWaypointButton_Click(object sender, EventArgs e)
        {
            waypoints.RemoveAt(waypointsListBox.SelectedIndex);
            updateWaypointsList();
        }

        XmlDocument doc;
        List<XmlNode> msas;

        private void fromPMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile("");
        }

        private void loadFile(string path)
        {
            statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Text = "Loading file...";
            using (var form = new LoadRouteFromPMA(path))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    List<vec2> route = form.getSelectedRoute();
                    msas = form.getSelectedRouteMSA();
                    doc = form.getFileXmlDocument();

                    waypoints.Clear();

                    for (int i = 0; i < route.Count; i++)
                    {
                        waypoints.Add(route[i]);
                    }
                    updateWaypointsList();
                }
            }
            statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
            statusLabel.Text = "File loaded.";
            Application.DoEvents();

            calculateMSA();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            waypoints.Clear();
            updateWaypointsList();
            legListBox.Items.Clear();
            lowListBox.Items.Clear();
            highListBox.Items.Clear();
            msaListBox.Items.Clear();
            doc = null;
            msas = null;
        }

        private void legListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).Focused)
            {
                lowListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                highListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                msaListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                peakCoordinateListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void msaListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).Focused)
            {
                lowListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                highListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                legListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                peakCoordinateListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void highListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).Focused)
            {
                lowListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                legListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                msaListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                peakCoordinateListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void lowListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).Focused)
            {
                legListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                highListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                msaListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                peakCoordinateListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void peakCoordinateListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ListBox)sender).Focused)
            {
                legListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                highListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                msaListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
                lowListBox.SelectedIndex = ((ListBox)sender).SelectedIndex;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var form = new About())
            {
                var result = form.ShowDialog();
            }
        }

        private void downloadHGTFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Download and extract the HGT files to \"" + Application.StartupPath + "\\hgts\\\"");
            System.Diagnostics.Process.Start("http://www.viewfinderpanoramas.org/Coverage%20map%20viewfinderpanoramas_org3.htm");
        }

        private void saveFile()
        {
            saveFile("");
        }

        private void saveFile(string path)
        {
            statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Text = "Saving file...";
            if (doc != null)
            {
                if (path.Length == 0)
                {
                    SaveFileDialog x = new SaveFileDialog();
                    x.Filter = "PMA file|*.txt;";
                    DialogResult result = x.ShowDialog();
                    if ((result == DialogResult.OK))
                    {
                        path = x.FileName;

                    }
                }

                PMAFile.writeFile(path, doc);

                statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
                statusLabel.Text = "File saved.";
            } else
            {
                statusBar.BackColor = Color.FromArgb(255, 204, 122, 0);
                statusLabel.Text = "Can't save a new file.";
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveFile();
        }

        private void Main_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
        }

        private void Main_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            if (files.Length > 0)
            {
                loadFile(files[0]);
            }
        }
    }
}

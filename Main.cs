using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraBars;
using GlmNet;
using System.Xml;
using System.Threading;
using PMAFileAPI;

namespace MSA_Calculator
{
    public partial class Main : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        List<vec2> waypoints = new List<vec2>();
        List<int> msas;

        PMANode pmaFile;
        List<PMANode> wpts;
        List<PMANode> legs;

        string[] args;

        XmlDocument doc;

        public Main(string[] args)
        {
            InitializeComponent();

            this.args = args;
        }

        private void ToolbarForm1_Load(object sender, EventArgs e)
        {
            if (args.Length > 0)
            {
                // loadFile();
                Application.DoEvents();
                loadFile(args[0]);
            }
        }

        private void calculateMSA()
        {
            //statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Caption = "Calculating MSA.";
            Application.DoEvents();
            // Init HGT class
            HGT hgt = new HGT();
            msas = new List<int>();

            // Start timer
            DateTime start_time = DateTime.Now;

            list.BeginUnboundLoad();
            list.Nodes.Clear();
            list.EndUnboundLoad();

            // Get values
            for (int i = 0; i < waypoints.Count - 1; i++)
            {
                vec2 p1 = waypoints[i];
                vec2 p2 = waypoints[i + 1];

                double distance = (double.Parse(radiusBox.EditValue.ToString()) / (double)60);

                // Get search area
                vec2[] rectangle = HGT.getRouteRectangle(p1, p2, distance);

                // Load search area
                hgt.loadFiles(rectangle);

                // Get MSA
                short msa = (short)HGT.metresToFeet(hgt.getMSA(rectangle, short.Parse(heightBox.EditValue.ToString()), short.Parse(montainousHeightBox.EditValue.ToString())));
                msa = (short)(Math.Ceiling(msa / 100f) * 100);
                //msaListBox.Items.Add(i + "→" + (i + 1) + ") " + msa + "FT");

                // Get peak and valley
                vec2 peak = hgt.getPeakInRectangle(rectangle);

                list.BeginUnboundLoad();
                list.AppendNode(new object[] {
                    i + "→" + (i + 1),
                    msa + "FT",
                    (short)HGT.metresToFeet(peak.y) + "FT",
                    (short)HGT.metresToFeet(peak.x) + "FT",
                    CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(hgt.peakCoordinate)) + " " + CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(hgt.peakCoordinate))
                }, null);
                list.EndUnboundLoad();

                msas.Add(msa);

                Application.DoEvents();


            }

            // Stop timer

            statusLabel.Caption = "MSA calculated in " + DateTime.Now.Subtract(start_time).TotalSeconds.ToString("0.000000") + "s.";
            statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
            Application.DoEvents();
        }

        private void fromPMAToolStripMenuItem_Click(object sender, EventArgs e)
        {
            loadFile("");
        }

        private void loadFile(string path)
        {
            //statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Caption = "Loading file...";
            using (var form = new LoadRouteFromPMA(path))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    pmaFile = form.getPMAFile();
                    wpts = form.getWaypoints();
                    legs = form.getLegs();

                    MessageBox.Show(wpts.Count + " waypoints");
                    MessageBox.Show(legs.Count + " legs");

                    waypoints.Clear();

                    foreach(PMANode node in wpts)
                    {
                        char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                        char thousandSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator);

                        float lat = float.Parse(node.properties["Posicao.Lat"].Replace('.', decimalSeparator));
                        float lng = float.Parse((node.properties.Keys.Contains("Posicao.Long") ? node.properties["Posicao.Long"] : node.properties["Posicao.Lon"]).Replace('.', decimalSeparator));
                        waypoints.Add(new vec2(lng, lat));
                    }
                }
            }
            //statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
            statusLabel.Caption = "File loaded.";
            Application.DoEvents();

            calculateMSA();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
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
            //statusBar.BackColor = Color.FromArgb(255, 202, 81, 0);
            statusLabel.Caption = "Saving file...";

            if (pmaFile != null)
            {
                for (int i = 0; i < legs.Count; i++)
                {
                    legs[i].properties["Castelo.NivelMinimoIFR"] = msas[i].ToString();
                }

                if (path.Length == 0)
                {
                    SaveFileDialog x = new SaveFileDialog();
                    x.Filter = "PMA file|*.txt;";
                    DialogResult result = x.ShowDialog();
                    if ((result == DialogResult.OK))
                    {
                        path = x.FileName;

                        PMAFile.write(pmaFile, path);

                    }
                }

                //PMAFile.writeFile(path, doc);

                statusBar.BackColor = Color.FromArgb(255, 0, 122, 204);
                statusLabel.Caption = "File saved.";
            }
            else
            {
                statusBar.BackColor = Color.FromArgb(255, 204, 122, 0);
                statusLabel.Caption = "Can't save a new file.";
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

        private void calculateButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            HGTsDialog dialog = new HGTsDialog(waypoints, int.Parse(radiusBox.EditValue.ToString()));
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                calculateMSA();
            }
        }

        private void backstageNewButton_ItemClick(object sender, DevExpress.XtraBars.Ribbon.BackstageViewItemEventArgs e)
        {
            switch(e.Item.Tag)
            {
                case "new":
                    pmaFile = null;
                    wpts = null;
                    legs = null;
                    break;
                case "open":
                    loadFile("");
                    break;
                case "save":
                    saveFile();
                    break;
                case "exit":
                    Close();
                    break;
            }
        }

        private void manageWaypointsButton_ItemClick(object sender, ItemClickEventArgs e)
        {
            vec2[] waypointsOld = new vec2[waypoints.Count];
            waypoints.CopyTo(waypointsOld);
            WaypointsDialog dialog = new WaypointsDialog(waypoints);
            dialog.ShowDialog();
            vec2[] waypointsNew = new vec2[waypoints.Count];
            waypoints.CopyTo(waypointsNew);

            if (!Enumerable.SequenceEqual(waypointsNew, waypointsOld))
            {
                pmaFile = null;
                wpts = null;
                legs = null;
                calculateMSA();
            }
        }
    }
}
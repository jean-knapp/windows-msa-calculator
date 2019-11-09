using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GlmNet;
using System.IO;
using System.Net;
using System.IO.Compression;

namespace MSA_Calculator
{
    public partial class HGTsDialog : DevExpress.XtraEditors.XtraForm
    {
        int distance = 0;
        List<vec2> waypoints = new List<vec2>();
        Queue<string> downloadList = new Queue<string>();
        List<string> files = new List<string>();
        WebClient client = new WebClient();

        public HGTsDialog(List<vec2> waypoints, int distance)
        {
            this.waypoints = waypoints;
            this.distance = distance;
            InitializeComponent();
        }

        private void updateList()
        {
            list.BeginUnboundLoad();
            list.Nodes.Clear();
            foreach (String filename in files)
            {
                list.AppendNode(new object[]
                {
                    Path.GetFileName(filename),
                    (File.Exists(filename) ? "Yes" : "No")
                }, null);
            }
            list.EndUnboundLoad();
        }

        private void HGTsDialog_Load(object sender, EventArgs e)
        {
            client.DownloadFileCompleted += Client_DownloadFileCompleted;

            files = new List<string>();
            // Get values
            for (int k = 0; k < waypoints.Count - 1; k++)
            {
                vec2 p1 = waypoints[k];
                vec2 p2 = waypoints[k + 1];

                double distance = ((double)this.distance / (double)60);

                // Get search area
                vec2[] rectangle = HGT.getRouteRectangle(p1, p2, distance);

                vec4 routeBoundingBox = HGT.getBoundingBox(rectangle);

                for (short i = (short)routeBoundingBox.w; i <= (short)routeBoundingBox.x; i++)
                {
                    for (short j = (short)routeBoundingBox.y; j <= (short)routeBoundingBox.z; j++)
                    {
                        string fileName = HGT.getFilePath(i, j);
                        if (!files.Contains(fileName))
                        {
                            files.Add(fileName);
                        }

                    }
                }
            }

            foreach (String filename in files)
            {
                if (!File.Exists(filename))
                {
                    downloadList.Enqueue(Path.GetFileName(filename));
                }
            }

            progressBarControl.Properties.Maximum = downloadList.Count();
            progressBarControl.EditValue = 0;
            progressLabel.Text = "Downloading files: 1 of " + progressBarControl.Properties.Maximum;

            updateList();
            downloadRequiredFiles();
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            downloadRequiredFiles();
        }

        private void downloadRequiredFiles()
        {
            if (downloadList.Count > 0)
            {
                string file = downloadList.Peek();
                if (!File.Exists(file))
                {
                    String fileName = Path.GetFileName(file);
                    Directory.CreateDirectory("hgts/");
                    client.DownloadFileAsync(new System.Uri("https://dds.cr.usgs.gov/srtm/version2_1/SRTM3/South_America/" + fileName + ".zip"), "hgts/" + fileName + ".zip");
                }
            } else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string file = downloadList.Dequeue();
            if (!File.Exists("hgts/" + file + ".zip"))
            {
                downloadList.Enqueue(file);
            } else
            {
                System.IO.Compression.ZipFile.ExtractToDirectory("hgts/" + file + ".zip", "hgts/");
                File.Delete("hgts/" + file + ".zip");
                progressBarControl.EditValue = progressBarControl.Properties.Maximum - downloadList.Count();
                progressLabel.Text = "Downloading files: " + (progressBarControl.Properties.Maximum - downloadList.Count()) + 1 + " of " + progressBarControl.Properties.Maximum;
                updateList();
            }
            downloadRequiredFiles();
        }

        private void HGTsDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            client.CancelAsync();
        }
    }
}
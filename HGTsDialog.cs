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

namespace MSA_Calculator
{
    public partial class HGTsDialog : DevExpress.XtraEditors.XtraForm
    {
        int distance = 0;
        List<vec2> waypoints = new List<vec2>();

        public HGTsDialog(List<vec2> waypoints, int distance)
        {
            this.waypoints = waypoints;
            this.distance = distance;
            InitializeComponent();
        }

        private void HGTsDialog_Load(object sender, EventArgs e)
        {
            List<string> files = new List<string>();
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

            list.BeginUnboundLoad();
            list.Nodes.Clear();
            foreach (String filename in files)
            {
                list.AppendNode(new object[]
                {
                    filename,
                    (File.Exists(filename) ? "Yes" : "No")
                }, null);
            }
            list.EndUnboundLoad();
        }
    }
}
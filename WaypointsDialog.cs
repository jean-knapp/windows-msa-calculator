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

namespace MSA_Calculator
{
    public partial class WaypointsDialog : DevExpress.XtraEditors.XtraForm
    {

        List<vec2> waypoints = new List<vec2>();

        public WaypointsDialog(List<vec2> waypoints)
        {
            this.waypoints = waypoints;
            InitializeComponent();
        }

        private void WaypointsDialog_Load(object sender, EventArgs e)
        {
            updateWaypointsList();
        }

        private void updateWaypointsList()
        {
            waypointsListBox.BeginUnboundLoad();
            waypointsListBox.Nodes.Clear();
           ;
            for (int i = 0; i < waypoints.Count; i++)
            {
                waypointsListBox.AppendNode(new object[] {
                    i,
                    CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(waypoints[i])),
                    CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(waypoints[i]))
                }, null);
            }
            waypointsListBox.EndUnboundLoad();
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
                    waypointsListBox.BeginUnboundLoad();
                    waypointsListBox.AppendNode(new object[] {
                        waypoints.Count() - 1,
                        CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(coordinate)),
                        CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(coordinate))
                    }, null);
                    waypointsListBox.EndUnboundLoad();
                }
            }
        }

        private void editCoordinateButton_Click(object sender, EventArgs e)
        {
            int id = waypointsListBox.Nodes.IndexOf(waypointsListBox.Selection[0]);

            if (id > -1)
            {
                vec2 selected = waypoints[id];
                using (var form = new CoordinateSelector(selected))
                {
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        vec2 coordinate = form.coordinate;
                        waypointsListBox.Selection[0].SetValue("id", id);
                        waypointsListBox.Selection[0].SetValue("latitude", CoordinateSelector.getGMSLatitude(CoordinateSelector.getLatitude(coordinate)));
                        waypointsListBox.Selection[0].SetValue("longitude", CoordinateSelector.getGMSLongitude(CoordinateSelector.getLongitude(coordinate)));
                        waypoints[id] = coordinate;
                    }
                }
            }
        }

        private void deleteWaypointButton_Click(object sender, EventArgs e)
        {
            int id = waypointsListBox.Nodes.IndexOf(waypointsListBox.Selection[0]);
            if (id > -1)
            {
                waypoints.RemoveAt(id);
                waypointsListBox.BeginUnboundLoad();
                waypointsListBox.Nodes.RemoveAt(id);
                waypointsListBox.EndUnboundLoad();
            }
        }

        private void dialogButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
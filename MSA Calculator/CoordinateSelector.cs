using GlmNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MSA_Calculator
{
    public partial class CoordinateSelector : Form
    {
        public vec2 coordinate;

        public CoordinateSelector(float x, float y)
        {
            InitializeComponent();

            coordinate = new vec2(x, y);
            setInputs();

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;
        }

        public CoordinateSelector(vec2 c) : this(c.x, c.y)
        {
            
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void degreeLatitude_TextChanged(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Focused)
                return;

            char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            char thousandSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator);

            int selectionStart = degreeLatitude.SelectionStart;
            degreeLatitude.Text = degreeLatitude.Text.Replace(thousandSeparator, decimalSeparator);
            degreeLatitude.SelectionStart = selectionStart;


            if (!float.TryParse(degreeLatitude.Text, out coordinate.y))
            {
                if (degreeLatitude.Text.Length != 0 && degreeLatitude.Text != "-")
                {
                    degreeLatitude.Text = coordinate.y.ToString();
                }
            }
            setInputs();
        }

        private void degreeLongitude_TextChanged(object sender, EventArgs e)
        {
            if (!((TextBox)sender).Focused)
                return;

            char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
            char thousandSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator);

            int selectionStart = degreeLongitude.SelectionStart;
            degreeLongitude.Text = degreeLongitude.Text.Replace(thousandSeparator, decimalSeparator);
            degreeLongitude.SelectionStart = selectionStart;

            if (!float.TryParse(degreeLongitude.Text, out coordinate.x))
            {
                if (degreeLongitude.Text.Length != 0 && degreeLongitude.Text != "-")
                {
                    degreeLongitude.Text = coordinate.x.ToString();
                }
            }
            setInputs();
        }

        private void gmsLatitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "N" && hemisphere != "S" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 latitude = new vec4();
            latitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "S" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 2), out latitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(5, 2), out latitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(8, 2), out latitude.z);
            coordinate.y = latitude.w * (latitude.x + latitude.y / 60 + latitude.z / 3600);

            setInputs();
            
        }

        private void gmsLongitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "W" && hemisphere != "E" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 longitude = new vec4();
            longitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "W" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 3), out longitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(6, 2), out longitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(9, 2), out longitude.z);
            coordinate.x = longitude.w * (longitude.x + longitude.y / 60 + longitude.z / 3600);

            setInputs();
        }

        private void gmcLatitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "N" && hemisphere != "S" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 latitude = new vec4();
            latitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "S" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 2), out latitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(5, 2), out latitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(8, 2), out latitude.z);

            coordinate.y = latitude.w * (latitude.x + latitude.y / 60 + latitude.z / 6000);

            setInputs();
        }

        private void gmcLongitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "W" && hemisphere != "E" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 longitude = new vec4();
            longitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "W" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 3), out longitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(6, 2), out longitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(9, 2), out longitude.z);
            coordinate.x = longitude.w * (longitude.x + longitude.y / 60 + longitude.z / 6000);

            setInputs();
        }

        private void gmmLatitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "N" && hemisphere != "S" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 latitude = new vec4();
            latitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "S" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 2), out latitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(5, 2), out latitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(8, 3), out latitude.z);

            coordinate.y = latitude.w * (latitude.x + latitude.y / 60 + latitude.z / 60000);

            setInputs();
        }

        private void gmmLongitude_TextChanged(object sender, EventArgs e)
        {
            if (!((MaskedTextBox)sender).Focused)
                return;

            string hemisphere = ((MaskedTextBox)sender).Text.Substring(0, 1);
            if (hemisphere != "W" && hemisphere != "E" && hemisphere != " ")
            {
                ((MaskedTextBox)sender).Text = ((MaskedTextBox)sender).Text.Replace(hemisphere, " ");
            }

            vec4 longitude = new vec4();
            longitude.w = (((MaskedTextBox)sender).Text.Substring(0, 1) == "W" ? -1 : 1);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(2, 3), out longitude.x);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(6, 2), out longitude.y);
            float.TryParse(((MaskedTextBox)sender).Text.Substring(9, 3), out longitude.z);
            coordinate.x = longitude.w * (longitude.x + longitude.y / 60 + longitude.z / 60000);

            setInputs();
        }

        private void setInputs()
        {
            vec4 latitude = getLatitude();

            vec4 longitude = getLongitude();

            if (!degreeLatitude.Focused)
                degreeLatitude.Text = getDegreeLatitude(latitude);
            if (!degreeLongitude.Focused)
                degreeLongitude.Text = getDegreeLongitude(longitude);

            if (!gmsLatitude.Focused)
                gmsLatitude.Text = getGMSLatitude(latitude);
            if (!gmsLongitude.Focused)
                gmsLongitude.Text = getGMSLongitude(longitude);

            if (!gmcLatitude.Focused)
                gmcLatitude.Text = getGMCLatitude(latitude);
            if (!gmcLongitude.Focused)
                gmcLongitude.Text = getGMCLongitude(longitude);

            if (!gmmLatitude.Focused)
                gmmLatitude.Text = getGMMLatitude(latitude);
            if (!gmmLongitude.Focused)
                gmmLongitude.Text = getGMMLongitude(longitude);
        }

        public vec4 getLatitude()
        {
            return getLatitude(coordinate);
        }

        public static vec4 getLatitude(vec2 coordinate)
        {
            vec4 latitude = new vec4();
            latitude.x = (float)Math.Min(90, Math.Floor(Math.Abs(coordinate.y)));
            latitude.y = (float)Math.Floor((Math.Min(90, Math.Abs(coordinate.y)) - latitude.x) * 60);
            latitude.z = ((Math.Min(90, Math.Abs(coordinate.y)) - latitude.x) * 60 - latitude.y) * 60;
            latitude.w = (coordinate.y != 0 ? coordinate.y / Math.Abs(coordinate.y) : 1);

            return latitude;
        }

        public vec4 getLongitude()
        {
            return getLongitude(coordinate);
        }

        public static vec4 getLongitude(vec2 coordinate)
        {
            vec4 longitude = new vec4();
            longitude.x = (float)Math.Min(180, Math.Floor(Math.Abs(coordinate.x)));
            longitude.y = (float)Math.Floor((Math.Min(180, Math.Abs(coordinate.x)) - longitude.x) * 60);
            longitude.z = ((Math.Min(180, Math.Abs(coordinate.x)) - longitude.x) * 60 - longitude.y) * 60;
            longitude.w = (coordinate.x != 0 ? coordinate.x / Math.Abs(coordinate.x) : 1);

            return longitude;
        }

        public static string getDegreeLatitude(vec4 latitude)
        {
            return ((latitude.w == 1 ? 1 : -1) * (latitude.x + latitude.y / 60 + latitude.z / 3600)).ToString();
        }

        public static string getDegreeLongitude(vec4 longitude)
        {
            return ((longitude.w == 1 ? 1 : -1) * (longitude.x + longitude.y / 60 + longitude.z / 3600)).ToString();
        }

        public static string getGMSLatitude(vec4 latitude)
        {
            return (latitude.w == 1 ? "N" : "S") + " " + latitude.x.ToString().PadLeft(2, '0') + "º" + latitude.y.ToString().PadLeft(2, '0') + "'" + Math.Round(latitude.z).ToString().PadLeft(2, '0');
        }

        public static string getGMSLongitude(vec4 longitude)
        {
            return (longitude.w == 1 ? "E" : "W") + " " + longitude.x.ToString().PadLeft(3, '0') + "º" + longitude.y.ToString().PadLeft(2, '0') + "'" + Math.Round(longitude.z).ToString().PadLeft(2, '0');
        }

        public static string getGMCLatitude(vec4 latitude)
        {
            return (latitude.w == 1 ? "N" : "S") + " " + latitude.x.ToString().PadLeft(2, '0') + "º" + Math.Round((latitude.y + latitude.z / 60), 2).ToString("00.00") + "'";
        }

        public static string getGMCLongitude(vec4 longitude)
        {
            return (longitude.w == 1 ? "E" : "W") + " " + longitude.x.ToString().PadLeft(3, '0') + "º" + Math.Round((longitude.y + longitude.z / 60), 2).ToString("00.00") + "'";
        }

        public static string getGMMLatitude(vec4 latitude)
        {
            return (latitude.w == 1 ? "N" : "S") + " " + latitude.x.ToString().PadLeft(2, '0') + "º" + Math.Round((latitude.y + latitude.z / 60), 3).ToString("00.000") + "'";
        }

        public static string getGMMLongitude(vec4 longitude)
        {
            return (longitude.w == 1 ? "E" : "W") + " " + longitude.x.ToString().PadLeft(3, '0') + "º" + Math.Round((longitude.y + longitude.z / 60), 3).ToString("00.000") + "'";
        }
    }
}

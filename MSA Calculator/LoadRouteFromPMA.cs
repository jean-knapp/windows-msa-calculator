using GlmNet;
using PMA;
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
using System.Xml;

namespace MSA_Calculator
{
    public partial class LoadRouteFromPMA : Form
    {
        List<List<vec2>> routes;
        List<List<XmlNode>> msas;

        XmlDocument doc;
        int selectedRoute = 0;

        public LoadRouteFromPMA(string path)
        {
            InitializeComponent();

            this.AcceptButton = okButton;
            this.CancelButton = cancelButton;

            string fileName = path;

            if (fileName.Length == 0)
            {

                OpenFileDialog x = new OpenFileDialog();
                x.Filter = "PMA file|*.txt;";
                DialogResult result = x.ShowDialog();
                if ((result == DialogResult.OK))
                {
                    fileName = x.FileName;
                }
                else
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
            }
            loadRoutes(fileName);
        }

        public List<vec2> getSelectedRoute()
        {
            return routes[selectedRoute];
        }

        public List<XmlNode> getSelectedRouteMSA()
        {
            return msas[selectedRoute];
        }

        public XmlDocument getFileXmlDocument()
        {
            return doc;
        }

        private void loadRoutes(string path)
        {
            //PMAFile.convertToXML(path);
            //doc = PMAFile.readXML(path);
            doc = PMAFile.readFile(path);

            routes = new List<List<vec2>>();
            msas = new List<List<XmlNode>>();

            foreach (XmlNode objectNode in doc.DocumentElement.ChildNodes)
            {
                if (objectNode.SelectSingleNode("DadosComuns") != null &&
                    objectNode.SelectSingleNode("DadosComuns").SelectSingleNode("Tipo") != null &&
                    objectNode.SelectSingleNode("DadosComuns").SelectSingleNode("Tipo").InnerText == "NavRota")
                {
                    pmaObjects.Items.Add(objectNode.SelectSingleNode("DadosComuns").SelectSingleNode("Nome").InnerText);

                    List<vec2> route = new List<vec2>();
                    List<XmlNode> msa = new List<XmlNode>();

                    char decimalSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberDecimalSeparator);
                    char thousandSeparator = Convert.ToChar(Thread.CurrentThread.CurrentCulture.NumberFormat.NumberGroupSeparator);

                    foreach (XmlNode child in objectNode.SelectSingleNode("Filhos"))
                    {
                        if (child.SelectSingleNode("DadosComuns").SelectSingleNode("Tipo").InnerText == "NavWaypoint")
                        {
                            float lat = float.Parse(child.SelectSingleNode("DadosEspecificos").SelectSingleNode("IObjetoNav").SelectSingleNode("GateIn").SelectSingleNode("Posicao_dot_Lat").InnerText.Replace(thousandSeparator, decimalSeparator));
                            float lon = float.Parse(child.SelectSingleNode("DadosEspecificos").SelectSingleNode("IObjetoNav").SelectSingleNode("GateIn").SelectSingleNode("Posicao_dot_Lon").InnerText.Replace(thousandSeparator, decimalSeparator));

                            route.Add(new vec2(lon, lat));
                        } else if (child.SelectSingleNode("DadosComuns").SelectSingleNode("Tipo").InnerText.StartsWith("NavSepara"))
                        {
                            // Separação
                            //route.Add(new vec2(lon2, lat2));

                            // Load pontos
                            List<vec2> pontos = new List<vec2>();
                            List<string> pontos_ref = new List<string>();
                            foreach(XmlNode ponto in child.SelectSingleNode("DadosEspecificos").SelectNodes("Ponto"))
                            {
                                if (ponto.SelectSingleNode("Waypoint").InnerText == "true")
                                {
                                    pontos.Add(new vec2(float.Parse(ponto.SelectSingleNode("Posicao_dot_Lon").InnerText.Replace(thousandSeparator, decimalSeparator)), float.Parse(ponto.SelectSingleNode("Posicao_dot_Lat").InnerText.Replace(thousandSeparator, decimalSeparator))));
                                    pontos_ref.Add(ponto.SelectSingleNode("ID").InnerText);
                                }
                            }

                            // Load trajetórias
                            List<XmlNode> trajetorias = new List<XmlNode>();
                            XmlNode trajetoria = child.SelectSingleNode("DadosEspecificos").SelectNodes("Trajet_amp__sharp_243_semicollon_ria")[0];

                            XmlNodeList pts = trajetoria.SelectNodes("PtTraj");
                            XmlNodeList segs = trajetoria.SelectNodes("Segmento");
                            for (int j = 0; j < pts.Count; j++)
                            //foreach (XmlNode pt in pts)
                            {
                                XmlNode pt = pts[j];
                                
                                string id = pt.SelectSingleNode("ID_ul_Referencia").InnerText;

                                for(int i = 0; i < pontos_ref.Count; i++)
                                {
                                    if (pontos_ref[i] == id)
                                    {
                                        route.Add(pontos[i]);

                                        if (j < pts.Count - 1)
                                        {
                                            XmlNode msaNode = segs[j].SelectSingleNode("Castelo_dot_NivelMinimoIFR");
                                            msa.Add(msaNode);
                                        }

                                        break;
                                    }
                                }


                            }
                            trajetorias.Add(trajetoria);
                            



                            
                        } else if (child.SelectSingleNode("DadosComuns").SelectSingleNode("Tipo").InnerText == "NavPerna")
                        {
                            XmlNode msaNode = child.SelectSingleNode("DadosEspecificos").SelectSingleNode("Castelo_dot_NivelMinimoIFR");
                            msa.Add(msaNode);
                        }
                    }
                    msas.Add(msa);
                    routes.Add(route);
                }
            }

            if (routes.Count == 1)
            {

            } else if (routes.Count == 0)
            {
                MessageBox.Show("Invalid file.");
                this.DialogResult = DialogResult.Cancel;
                this.Close();
            }
        }

        private void pmaObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoute = pmaObjects.SelectedIndex;
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
    }
}

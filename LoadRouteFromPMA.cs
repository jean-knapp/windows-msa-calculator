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
using System.Xml;

using PMAFileAPI;

namespace MSA_Calculator
{
    public partial class LoadRouteFromPMA : Form
    {
        PMANode pmaFile;
        List<PMANode> routes;
        int selectedRoute = 0;

        List<PMANode> waypoints;
        List<PMANode> legs;

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

        public PMANode getSelectedRoute()
        {
            return routes[selectedRoute];
        }

        public PMANode getPMAFile()
        {
            return pmaFile;
        }

        private void loadRoutes(string path)
        {
            pmaFile = PMAFile.read(path);

            routes = pmaFile.findNodesByType("IObjeto");

            for (int i = routes.Count - 1; i >= 0; i--)
            {
                PMANode dadosComunsNode = routes[i].getNodeByType("DadosComuns");
                if (dadosComunsNode == null || !dadosComunsNode.properties.Keys.Contains("Tipo") || dadosComunsNode.properties["Tipo"] != "NavRota")
                {
                    routes.RemoveAt(i);
                    continue;
                }
                {
                    pmaObjects.Items.Add(routes[i].name);
                }
            }
        }

        public List<PMANode> getWaypoints()
        {
            PMANode route = getSelectedRoute();
            List<PMANode> waypoints = new List<PMANode>();

            foreach(PMANode node in route.getNodeByType("Filhos").items)
            {
                PMANode dadosComunsNode = node.getNodeByType("DadosComuns");
                if (dadosComunsNode != null && dadosComunsNode.properties.Keys.Contains("Tipo"))
                {
                   
                    if (dadosComunsNode.properties["Tipo"] == "NavWaypoint")
                    {
                        PMANode waypoint = node.getNodeByType("DadosEspecificos").getNodeByType("IObjetoNav").getNodeByType("GateIn");
                        waypoints.Add(waypoint);
                    } else if (dadosComunsNode.properties["Tipo"] == "NavSeparação")
                    {
                        Dictionary<string, PMANode> pontos = new Dictionary<string, PMANode>();
                        foreach(PMANode ponto in node.getNodeByType("DadosEspecificos").getNodesByType("Ponto"))
                        {
                            pontos.Add(ponto.properties["ID"], ponto);
                        }

                        PMANode trajetoria = node.getNodeByType("DadosEspecificos").getNodeByType("Trajetória");

                        List<PMANode> ptsTraj = trajetoria.getNodesByType("PtTraj");
                        foreach(PMANode ptTraj in ptsTraj)
                        {
                            waypoints.Add(pontos[ptTraj.properties["ID_Referencia"]]);
                        }
                    }
                    
                }
            }

            return waypoints;
        }

        public List<PMANode> getLegs()
        {
            PMANode route = getSelectedRoute();
            List<PMANode> legs = new List<PMANode>();

            foreach (PMANode node in route.getNodeByType("Filhos").items)
            {
                PMANode dadosComunsNode = node.getNodeByType("DadosComuns");
                if (dadosComunsNode != null && dadosComunsNode.properties.Keys.Contains("Tipo"))
                {

                    if (dadosComunsNode.properties["Tipo"] == "NavPerna")
                    {
                        PMANode leg = node.getNodeByType("DadosEspecificos");
                        legs.Add(leg);
                    }
                    else if (dadosComunsNode.properties["Tipo"] == "NavSeparação")
                    {
                        PMANode trajetoria = node.getNodeByType("DadosEspecificos").getNodeByType("Trajetória");
                        legs.AddRange(trajetoria.getNodesByType("Segmento"));
                    }

                }
            }

            return legs;
        }

        /*private void loadRoutesOld(string path)
        {
            
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

        }*/

        private void pmaObjects_SelectedIndexChanged(object sender, EventArgs e)
        {
            selectedRoute = pmaObjects.SelectedIndex;
        }

        private void button_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}

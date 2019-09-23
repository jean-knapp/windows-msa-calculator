using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hammer.Styling
{
    public class MenuRenderer : ToolStripProfessionalRenderer
    {
        public MenuRenderer(ProfessionalColorTable professionalColorTable) : base(professionalColorTable)
        {
        }

        protected override void OnRenderArrow(ToolStripArrowRenderEventArgs e)
        {
            ToolStripMenuItem tsMenuItem = (ToolStripMenuItem)e.Item;
            if ((tsMenuItem != null))
                e.ArrowColor = Color.FromArgb(153, 153, 153);
            base.OnRenderArrow(e);
        }
    }

}

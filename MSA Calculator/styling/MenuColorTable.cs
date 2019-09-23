using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hammer.Styling
{
    public class MenuColorTable : ProfessionalColorTable
    {
        public override Color ToolStripDropDownBackground
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color MenuItemSelected
        {
            get
            {
                return Color.FromArgb(51, 51, 52);
            }
        }

        public override Color MenuItemBorder
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color MenuBorder
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color SeparatorDark
        {
            get
            {
                return Color.FromArgb(51, 51, 55);
            }
        }

        public override Color ImageMarginGradientBegin
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color ImageMarginGradientMiddle
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color ImageMarginGradientEnd
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color MenuItemSelectedGradientBegin
        {
            get
            {
                return Color.FromArgb(62, 62, 64);
            }
        }

        public override Color MenuItemSelectedGradientEnd
        {
            get
            {
                return Color.FromArgb(62, 62, 64);
            }
        }

        public override Color MenuItemPressedGradientBegin
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color MenuItemPressedGradientEnd
        {
            get
            {
                return Color.FromArgb(27, 27, 28);
            }
        }

        public override Color ButtonPressedHighlightBorder
        {
            get
            {
                return Color.Red;
            }
        }
    }

}

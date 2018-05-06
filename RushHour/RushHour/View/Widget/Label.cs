using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Label : Widget
    {
        public string Text
        {
            set
            {
                Master.DeleteWidgetOnScreen(Name);
                Content = value;
                Master.RefreshContentOnScreen(new string[] { Name });
            }
            get
            {
                return Content;
            }
        }

        public Label(string name, string text, int rowSpanMax, int columnSpanMax) : base(name, rowSpanMax, columnSpanMax)
        {
            Content = text;
        }
    }
}

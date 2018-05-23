using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    /// <summary>
    /// Widget used to show text
    /// </summary>
    class Label : Widget
    {
        /// <summary>
        /// Text show in Label
        /// </summary>
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

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="name">widget's name</param>
        /// <param name="text">text show in label</param>
        /// <param name="rowSpanMax">maximum nunber of row</param>
        /// <param name="columnSpanMax">maximum number of column</param>
        public Label(string name, string text, int rowSpanMax, int columnSpanMax) : base(name, rowSpanMax, columnSpanMax)
        {
            Content = text;
        }
    }
}

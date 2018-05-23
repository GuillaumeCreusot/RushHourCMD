using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class VGojira : Label
    {
        public static string text = @"
";
        public static int[] dimText = WidgetUtility.DimContent(text);


        public VGojira() : base("Gozilla", text, dimText[0], dimText[1])
        {

        }
    }
}

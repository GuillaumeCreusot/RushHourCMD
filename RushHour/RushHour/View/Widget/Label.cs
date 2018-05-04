using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Label : Widget
    {
        public Label(string name, string text) : base(name)
        {
            Content = text;
        }
    }
}

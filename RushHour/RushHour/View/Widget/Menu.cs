using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class Menu : Widget
    {

        private int selectedItem;
        private string[] items;
        private int[,] positionSelecter;
        private int margeLeft;

        public int SelectedItem
        {
            get
            {
                return selectedItem;
            }
            set
            {
                if(value >= 0 && value < NbItem)
                {
                    selectedItem = value;
                    UpdateSelecter();
                    Master.RefreshContentOnScreen(this.Name);
                }
            }
        }

        public int NbItem
        {
            get
            {
                return items.Length;
            }
        }

        protected string PermanentText
        {
            set
            {
                Content = value;

                int[] dim = WidgetUtility.DimContent(value);
                
                for(int i = 0; i < NbItem; i++)
                {
                    Content += $"\n{WidgetUtility.Repeat(' ', MargeLeft)}  {items[i]}";
                    positionSelecter[i, 0] = dim[0];
                    positionSelecter[i, 1] = MargeLeft;   
                    dim[0] += 1;
                }

                UpdateSelecter();


            }
        }

        public int MargeLeft
        {
            get
            {
                return margeLeft;
            }

            protected set
            {
                margeLeft = value;
            }
        }

        public Menu(string name, string permanentText, int rowSpanMax, int columnSpanMax, string[] items, int selectedItem = 0, int margeLeft = 0) : base(name, rowSpanMax, columnSpanMax)
        {
            this.items = items;
            positionSelecter = new int[NbItem, 2];

            MargeLeft = margeLeft;
            PermanentText = permanentText;
            this.selectedItem = selectedItem;
        }

        public void UpdateSelecter()
        {
            for(int i = 0; i < NbItem; i++)
            {
                if(selectedItem == i)
                {
                    string transition = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = transition.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), ">");
                }
                else
                {
                    string transition = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = transition.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), " ");
                }
            }
        }
    }
}

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
                    Content += $"\n {items[i]}";
                    positionSelecter[i, 0] = dim[0];
                    positionSelecter[i, 1] = 0;
                    dim[0] += 1;
                }

                UpdateSelecter();


            }
        }

        public Menu(string name, string permanentText, int rowSpanMax, int columnSpanMax, string[] items, int selectedItem = 0) : base(name, rowSpanMax, columnSpanMax)
        {
            this.items = items;
            positionSelecter = new int[NbItem, 2];

            PermanentText = permanentText;
            this.selectedItem = selectedItem;
        }

        public void UpdateSelecter()
        {
            for(int i = 0; i < NbItem; i++)
            {
                if(selectedItem == i)
                {
                    Content = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = Content.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), ">");
                }
                else
                {
                    Content = Content.Remove(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), 1);
                    Content = Content.Insert(positionSelecter[i, 1] + positionSelecter[i, 0] * (ColumnSpan + 1), " ");
                }
            }
        }
    }
}

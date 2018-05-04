using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RushHour
{
    class WidgetsManager : Widget
    {
        private List<Widget> widgets;
        private string[,] grid;

        public string[] WidgetNames
        {
            get
            {
                string[] result = new string[widgets.Count];

                for(int i = 0; i < widgets.Count; i++)
                {
                    result[i] = widgets[i].Name;
                }

                return result;
            }
        }

        public WidgetsManager(string name, int nbCol, int nbRow) : base(name)
        {
            widgets = new List<Widget>();
            grid = new string[nbRow, nbCol];

            Console.WindowWidth = nbCol;
            Console.WindowHeight = nbRow; 
        }

        public void AddWidget(Widget widget, int row, int col)
        {
            //vérification erreur
            if (row + widget.RowSpan >= grid.GetLength(0))
            {
                throw new Exception("Le Widget sort de la console (rang)");
            }
            if(col + widget.ColumnSpan >= grid.GetLength(1))
            {
                throw new Exception("Le Widget sort de la console (col)");
            }

            //position
            if (grid[row, col] == null)
            {
                grid[row, col] = widget.Name;
                widget.Position = new int[]{ row, col};
            }
            else
            {
                throw new Exception("le Widget est superposé à un autre");
            }

            //span
            for(int i = 0; i <= widget.RowSpan; i++)
            {
                for(int j = 0; j <= widget.ColumnSpan; j++)
                {
                    grid[row + i, col + j] = widget.Name;
                }
            }

            //ajout de l'objet widget à widgets
            widgets.Add(widget);
        }

        public void RefreshContent()
        {
            RefreshContent(this.WidgetNames);
        }

        public void RefreshContent(string[] contentNames)
        {
            Widget currentW;

            foreach(string name in contentNames)
            {
                currentW = FindWidgetWithName(name);
                if(currentW == null)
                {
                    throw new Exception($"le Widget {name} n'existe pas");
                }
                else
                {
                    for(int i = 0 ; i <= currentW.RowSpan; i++)
                    {
                        for(int j = 0; j < currentW.ColumnSpan; j++)
                        {
                             Console.CursorLeft = currentW.Position[1] + j;
                             Console.CursorTop = currentW.Position[0] + i;
                             Console.Write(currentW.Content[j + i * (currentW.ColumnSpan + 1)]);
                        }
                    }
                }
            }
        }

        public Widget FindWidgetWithName(string name)
        {
            int c = 0;
            while((c < widgets.Count && widgets[c].Name != name) || c == widgets.Count)
            {
                c++;
            }

            if(c < widgets.Count)
            {
                return widgets[c];
            }
            else
            {
                return null;
            }
        }
    }
}

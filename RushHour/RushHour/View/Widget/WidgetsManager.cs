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

        /// <summary>
        /// Les noms des widgets contenue dans le widgetManager
        /// </summary>
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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="name">Nom du Widget</param>
        /// <param name="nbCol">nombre de colonne</param>
        /// <param name="nbRow">nombre de rang</param>
        public WidgetsManager(string name, int nbCol, int nbRow) : base(name)
        {
            widgets = new List<Widget>();
            grid = new string[nbRow, nbCol];

            Console.WindowWidth = nbCol;
            Console.WindowHeight = nbRow; 
        }

        /// <summary>
        /// Ajouter du widget <paramref name="widget"/> au widget manager 
        /// au rang <paramref name="row"/> et la colonne <paramref name="col"/>
        /// </summary>
        /// <param name="widget">widget à ajouter</param>
        /// <param name="row">rang ou mettre le widget</param>
        /// <param name="col">colonne ou mettre le widget</param>
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

        /// <summary>
        /// Rafraichi tous les widgets
        /// </summary>
        public void RefreshContent()
        {
            RefreshContent(this.WidgetNames);
        }

        /// <summary>
        /// Rafraichit les widgets dont le nom est compris dans <paramref name="contentNames"/>
        /// </summary>
        /// <param name="contentNames">noms des widgets à rafraichir</param>
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

        public void RefreshContent(string name)
        {
            RefreshContent(new string[] { name });
        }

        /// <summary>
        /// Trouver un widget à l'aide de son nom <paramref name="name"/>
        /// </summary>
        /// <param name="name">nom du widget cherché</param>
        /// <returns>widget cherché ou null si le widget n'existe pas</returns>
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

        public void DeleteWidgetOnScreen(string name)
        {
            Widget w = FindWidgetWithName(name);
            if(w != null)
            {
                w.DeleteContent();
                RefreshContent(name);
            }
            else
            {
                throw new Exception($"Le widget avec le nom {name} n'existe pas");
            }
        }
    }
}

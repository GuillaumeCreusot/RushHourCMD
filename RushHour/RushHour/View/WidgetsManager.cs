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
        private List<List<string>> grid;

        public WidgetsManager(string name) : base(name)
        {
            widgets = new List<Widget>();
            grid = new List<List<string>>();
        }

        public void AddWidget(Widget widget, int row, int col)
        {

            //position
            int i, j;
            for (i = 0; i <= row; i++)
            {
                if (i >= grid.Count)
                {
                    grid.Add(new List<string>());
                }
            }

            for(j = 0; j <= col; j++)
            {
                if(j >= grid[i].Count)
                {
                    grid[i].Add("");
                }    
            }

            if(i < grid.Count && j < grid[i].Count && grid[i][j] != "")
            {
                throw new Exception("Widget superposé");
            }
            else
            {
                grid[i].Add(widget.Name);
            }
            

            //span
            for(int r = 0; r < widget.RowSpan; r++)
            {
                if(i + r >= grid.Count)
                {
                    grid.Add(new List<string>());
                }

                for(int c = 0; c < widget.ColumnSpan; c++)
                {
                    if(j + c >= grid[i + r].Count)
                    {
                        grid[i + r].Add(widget.Name + "-ext");
                    }
                    else
                    {
                        grid[i + r][j + c] = widget.Name + "-ext";
                    }
                }
            }

            
        }

        public void Test()
        {
            foreach(List<string> row in grid)
            {
                foreach(string val in row)
                {
                    Console.Write(val);
                }
                Console.WriteLine();
            }
        }
    }
}

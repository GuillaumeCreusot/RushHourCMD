using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RushHour
{
    class MGame
    {
        internal bool gameEnded;
        internal MGrid grid;
        private int playerScore;
        internal MMain.Difficulty difficulty;
        public MGame()
        {
            GameEnded = false;
            CreateSaveFolder();
        }

        public bool GameEnded
        {
            get
            {
                return gameEnded;
            }

            set
            {
                gameEnded = value;
            }
        }

        internal MGrid Grid
        {
            get
            {
                return grid;
            }

            set
            {
                grid = value;
            }
        }

        internal int PlayerScore
        {
            get
            {
                return playerScore;
            }

            set
            {
                playerScore = value;
            }
        }

        internal MMain.Difficulty Difficulty
        {
            get
            {
                return difficulty;
            }

            set
            {
                difficulty = value;
            }
        }

        // Functions to save and load the game
        public void Save()
        {
            CreateSaveFolder();
            string path = GetSaveFolderPath();
            string name = CreateFile(path);
            Write(GetFilePath(path, name));
        }

        public void Load()
        {
    
        }

        /// <summary>
        /// Creates a folder to save the files into
        /// </summary>
        public void CreateSaveFolder()
        {
            //create path
            string path = Environment.CurrentDirectory;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);
            string folder = Path.Combine(path, "Sauvegardes");
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }

            //crate file for names of the saves
            string fichier = folder + "\\names.txt";
            if (!File.Exists(fichier))
            {
                FileStream f = File.Create(fichier);
                f.Close();
            }
        }

        /// <summary>
        /// get path to saving folder
        /// </summary>
        public static string GetSaveFolderPath()
        {
            string path = Environment.CurrentDirectory;
            path = Path.GetDirectoryName(path);
            path = Path.GetDirectoryName(path);        
            path += "\\Sauvegardes"; 
            return path;
        }

        /// <summary>
        /// launches save menu, creates a file in folder and return its name
        /// </summary>
        public string CreateFile(string path)
        {            
            //open saves menu
            CSaveMenu saveMenu = new CSaveMenu();
            string name = saveMenu.Control();
            FileStream f = File.Create(path + "\\" + name + ".txt");
            f.Close();

            //add file name to file registery
            string pathNames = GetFilePath(path, "names");
            StreamWriter file = new StreamWriter(pathNames, true);
            file.WriteLine(name);
            file.Close();
            return name;
        }

        public static string GetFilePath(string path, string fileName)
        {
            return path + "\\" + fileName + ".txt";
        }

        /// <summary>
        /// Writes the relevent content for the current game into the saving file
        /// </summary>
        public void Write(string filePath)
        {
            //relevent info : score, difficulty, state of grid
            StreamWriter file = new StreamWriter(filePath);
            file.WriteLine(this.PlayerScore);
            file.WriteLine((int)this.Difficulty);
            //copy grid elements : length, direction pos X, psy Y, is player
            foreach (MVehicle vehicle in grid.Vehicles)
            {
                file.WriteLine(vehicle.ToString());
            }
            file.Close();
        }

        //FOR LOADING

        /// <summary>
        /// puts names of available saves in a list to display in according screen
        /// </summary>
        /// <returns></returns>
        public static string[] ListSaves()
        {
            //count Number Of Items
            StreamReader reader = new StreamReader(MGame.GetFilePath(MGame.GetSaveFolderPath(), "names"));
            string line;
            int savesNb = 0;
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    savesNb++;
                }
            }
            while (!String.IsNullOrEmpty(line));
            reader.Close();

            //add those items to list
            string[] items = new string[savesNb];
            StreamReader reader2 = new StreamReader(MGame.GetFilePath(MGame.GetSaveFolderPath(), "names"));
            string line2;
            for (int i = 0; i < savesNb; i++)
            {
                line2 = reader2.ReadLine();
                items[i] = line2;
            }
            reader2.Close();
            return items;
        }


        /// <summary>
        /// NOT DONE/ COPY PASTED FROM OTHER PROJECT : Displays the available saves and asks the user to choose one
        /// </summary>
        public string DisplaySaves(string path)
        {
            //returns name of chosen save
            //number of saves in file
            StreamReader reader = new StreamReader(GetFilePath(path, "names"));
            string test = "ok";
            int savesNb = 0;
            while (!String.IsNullOrEmpty(test)) //tant qu'on ne rencontre pas de ligne vides
            {
                savesNb++;
                test = reader.ReadLine();
            }
            reader.Close();

            //display
            StreamReader reader1 = new StreamReader(GetFilePath(path, "names"));
            Console.WriteLine("\nVoici les sauvegardes disponibles :\n");
            for (int i = 0; i < savesNb - 1; i++)
            {
                Console.WriteLine((i + 1) + " : " + reader1.ReadLine());
            }
            reader1.Close();

            //choose save
            Console.Write("\nQuelle partie souhaitez vous charger (numéro) ? ");
            int numero = int.Parse(Console.ReadLine());

            //control input
            while (numero < 1 || numero > savesNb - 1)
            {
                Console.WriteLine("\nSaisie incorrecte. Veuillez entrer un nombre entre 1 et {0}.", savesNb - 1);
                numero = int.Parse(Console.ReadLine());
            }

            StreamReader reader2 = new StreamReader(GetFilePath(path, "names"));
            //on lit numero-1 lignes pour retourner la ligne numero correspondant au choix           
            for (int i = 0; i < numero - 1; i++)
            {
                reader2.ReadLine();
            }

            string nom = reader2.ReadLine();
            reader2.Close();
            return nom;
        }

        /// <summary>
        /// Reads a saved game to load the parameters
        /// </summary>
        public void Read(string filePath)
        {

        }
    }
}

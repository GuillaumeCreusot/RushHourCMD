using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace RushHour
{
    /// <summary>
    /// Model class wich contain data about the game and save/load process
    /// </summary>
    class MGame
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public MGame()
        {
            GameEnded = false;
            CreateSaveFolder();
            grid = new MGrid(6,6);
        }

        /// <summary>
        /// game end flag
        /// </summary>
        internal bool gameEnded;
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

        /// <summary>
        /// model grid
        /// </summary>
        internal MGrid grid;
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

        /// <summary>
        /// number of move
        /// </summary>
        private int playerScore;
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

        /// <summary>
        /// actual difficulty
        /// </summary>
        internal MMain.Difficulty difficulty;
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
        public void Save(string name)
        {
            CreateSaveFolder();
            string path = GetSaveFolderPath();
            CreateFile(path, name);
            Write(GetFilePath(path, name));
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
        public void CreateFile(string path, string name)
        {            
            //open saves menu
            FileStream f = File.Create(path + "\\" + name + ".txt");
            f.Close();

            //add file name to file registery
            string pathNames = GetFilePath(path, "names");
            StreamWriter file = new StreamWriter(pathNames, true);
            file.WriteLine(name);
            file.Close();
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
        /// loads the save n°saveToLoad in names list
        /// </summary>
        public void Load(int saveToLoad)
        {
            //find name of save n°save to load
            string fileName = FindFileName(saveToLoad);
            string filePath = GetFilePath(GetSaveFolderPath(), fileName);
            Read(filePath);
        }

        /// <summary>
        /// finds the name of the save corresponding to the number
        /// </summary>
        public string FindFileName(int saveToLoad)
        {
            //open StreamReader
            StreamReader reader = new StreamReader(GetFilePath(GetSaveFolderPath(), "names"));
            string line="";
            for (int i=0; i<= saveToLoad; i++)
            {
                line = reader.ReadLine();
            }
            reader.Close();
            return line;
        }

        /// <summary>
        /// puts names of available saves in a list to display in according screen
        /// </summary>
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

            if(items.Length == 0)
            {
                items = new string[1] { "default" };
            }

            return items;
        }

        /// <summary>
        /// Reads a saved game to load the parameters
        /// </summary>
        public void Read(string filePath)
        {
            //open StreamReader
            StreamReader reader = new StreamReader(filePath);
            string line = reader.ReadLine();
            this.PlayerScore = int.Parse(line);
            line = reader.ReadLine();
            this.Difficulty = (MMain.Difficulty)int.Parse(line);
            do
            {
                line = reader.ReadLine();
                if (!String.IsNullOrEmpty(line))
                {
                    CreateVehicle(line);
                }                
            }
            while (!String.IsNullOrEmpty(line));
            reader.Close();
        }

        /// <summary>
        /// Creates a vehicle from the given info in the save file
        /// </summary>
        public void CreateVehicle(string line)
        {
            Console.WriteLine(line);
            int length = line[0]-48; //-48 to convert from ASCII
            int posX = line[1]-48;
            int posY = line[2]-48;
            MMain.Direction dir = (MMain.Direction)(line[3]-48);
            bool isPlayer;
            if (line[4]=='T')
            {
                isPlayer = true;
            }
            else
            {
                isPlayer = false;
            }
            grid.AddVehicle(posX, posY, dir, length, isPlayer);
        }
    }
}

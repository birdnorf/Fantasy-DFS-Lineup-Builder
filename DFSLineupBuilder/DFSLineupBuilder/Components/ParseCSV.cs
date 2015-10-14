using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DFSLineupBuilder.Properties;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Player = DFSLineupBuilder.Player;

namespace DFSLineupBuilder
{
    class ParseCSV
    {
        public static List<Player> parseCSV(string filename)
        {
            List<Player> listOfPlayers = new List<Player>();
            List<string[]> csvLines = new List<string[]>();
            FileInfo fileInfo = new FileInfo(filename);

            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.Delimiters = new string[] { "," };

                while (!parser.EndOfData)
                {
                    csvLines.Add(parser.ReadFields());

                }

            }


            foreach (string[] line in csvLines)
            {
                if (line[0] == "Position")
                    continue;

                //populate each players object with information from spreadsheet
                Player player = new Player();
                player.position = line[0];
                player.name = line[1];
                player.salary = Convert.ToDouble(line[2]);
                player.gameInfo = line[3];
                player.avgPoints = Convert.ToDecimal(line[4]);
                player.team = line[5];

                //compile list of player objects
                listOfPlayers.Add(player);

            }


            return listOfPlayers;

        }
    }
}

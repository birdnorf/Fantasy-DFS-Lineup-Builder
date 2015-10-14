
//System 
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

//My Classes
using BL = DFSLineupBuilder.BuildLineups;
using Parse = DFSLineupBuilder.ParseCSV;
using Player = DFSLineupBuilder.Player;
using TopPlayer = DFSLineupBuilder.Components.TopPlayer;

namespace DFSLineupBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string filename;
        List<Player> listOfPlayers = new List<Player>();
        List<Player> topPlayers = new List<Player>();
        public MainWindow()
        {
            InitializeComponent();
        }


        private void browse(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".csv";
            dlg.Filter = "CSV File (*.csv)|*.csv|Excel Files (*.xslx)|*.xslx";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                filename = dlg.FileName;
                spreadSheetTextBox.Text = filename;

                

            }
        }


        private void parseCSV(object sender, RoutedEventArgs e)
        {
            if (filename == null)
                textBlock.Text = "You suck! You JackAss!";
            else
            {
                // Parse Document and get list of players objects
                listOfPlayers = Parse.parseCSV(filename);
                textBlock.Text = "Document has been parsed! Your List of players are ready to be evaluated!";
            }
                
                
        }


        private void findTopPlayer(object sender, RoutedEventArgs e)
        {
            if (listOfPlayers == null)
                textBlock.Text = "You suck! You JackAss!";
            // Find the top players at each position
            else
            {
                topPlayers = Components.TopPlayer.findTopPlayers(listOfPlayers);

                textBlock.Text = "Here are the top players for this week: " + Environment.NewLine;
                foreach (Player player in topPlayers)
                {
                    switch(player.position)
                    {
                        case "C":
                            textBlock.Text += string.Format("Top Center: {0}, {1} {2}", player.name, player.team, Environment.NewLine);
                            break;
                        case "RW":
                            textBlock.Text += string.Format("Top Right Wing: {0}, {1} {2}", player.name, player.team, Environment.NewLine);
                            break;
                        case "LW":
                            textBlock.Text += string.Format("Top Left Wing: {0}, {1} {2}", player.name, player.team, Environment.NewLine);
                            break;
                        case "D":
                            textBlock.Text += string.Format("Top Defense: {0}, {1} {2}", player.name, player.team, Environment.NewLine);
                            break;
                        case "G":
                            textBlock.Text += string.Format("Top Goalie: {0}, {1} {2}", player.name, player.team, Environment.NewLine);
                            break;

                        default:
                            Console.WriteLine("Default case");
                            break;
                    }
                }

            }

        }


        private void buildLineups(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "This Feature is in Development! Coming Soon!";

        }




    }
}

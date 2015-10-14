
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
        Player topPlayer = new Player();
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
                // Parse Document and get list of players objects
                listOfPlayers = Parse.parseCSV(filename);
        }


        private void findTopPlayer(object sender, RoutedEventArgs e)
        {
            if (listOfPlayers == null)
                textBlock.Text = "You suck! You JackAss!";
            // Find the top player
            else
            {
                topPlayer = Components.TopPlayer.findTopPlayer(listOfPlayers);
                textBlock.Text = string.Format("The Top Player for the Week is: {0} Nigga!", topPlayer.name);

            }

        }




    }
}

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


namespace DFSLineupBuilder
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
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
                string filename = dlg.FileName;
                spreadSheetTextBox.Text = filename;
                parseCSV(filename);

            }
        }

        public void parseCSV(string filename)
        {
            using (TextFieldParser parser = new TextFieldParser(filename))
            {
                parser.Delimiters = new string[] { "," };
                while (true)
                {
                    
                    string[] parts = parser.ReadFields();
                    if (parts == null)
                    {
                        break;
                    }
                    else
                    {
                        foreach(string field in parts)
                        {
                            textBlock.Text += string.Format("{0}", field);

                        }
                    }
                }
            }
        }


    }
}

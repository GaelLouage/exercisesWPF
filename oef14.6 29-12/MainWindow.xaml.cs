using System;
using System.Collections.Generic;
using System.IO;
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

namespace oef14._6_29_12
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] enqueteArr = new int[5, 4];
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVerwerken_Click(object sender, RoutedEventArgs e)
        {
            Array.Clear(enqueteArr, 0, 5 * 4);
            lbEnquete.Items.Clear();
            string filePath = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "Enquete.txt");
            if (!File.Exists(filePath))
            {
                MessageBox.Show("File not found");
                return;
            }
            string[] file = File.ReadAllLines(filePath);
            for (int i = 0; i < file.Length; i++)
            {
                string[] splittedFile = file[i].Split(',');
                splittedFile[2] = splittedFile[2].Replace("\"", "");
                int year = int.Parse(splittedFile[1]);
                if (year < 1960)
                {
                    SetTypeVervoerInArray(splittedFile[2], 0);
                }
                else if (year < 1970)
                {
                    SetTypeVervoerInArray(splittedFile[2], 1);
                }
                else if (year < 1980)
                {
                    SetTypeVervoerInArray(splittedFile[2], 2);
                }
                else if (year < 1990)
                {
                    SetTypeVervoerInArray(splittedFile[2], 3);
                }
                else
                {
                    SetTypeVervoerInArray(splittedFile[2], 4);
                }
            }
            int startYear = 1960;
            string displayYearChar = "<";
            lbEnquete.Items.Add("E".PadLeft(30) + "F".PadLeft(10) + "OV".PadLeft(10) + "A".PadLeft(10));
            for (int i = 0; i < enqueteArr.GetLength(0); i++)
            {
                lbEnquete.Items.Add($"{displayYearChar}{startYear}{string.Empty.PadLeft(10)}" +
                     $"{enqueteArr[i, 0].ToString().PadLeft(10)}" +
                     $"{enqueteArr[i, 1].ToString().PadLeft(10)}" +
                     $"{enqueteArr[i, 2].ToString().PadLeft(10)}" +
                     $"{enqueteArr[i, 3].ToString().PadLeft(10)}");
                startYear += 10;
                if (startYear == 2000) displayYearChar = "- ";
            }
        }

        private void SetTypeVervoerInArray(string character, int arrayRow)
        {
            switch (character)
            {
                case "E":
                    enqueteArr[arrayRow, 0]++;
                    break;
                case "F":
                    enqueteArr[arrayRow, 1]++;
                    break;
                case "OV":
                    enqueteArr[arrayRow, 2]++;
                    break;
                case "A":
                    enqueteArr[arrayRow, 3]++;
                    break;
            }
        }

        private void btnSluiten_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

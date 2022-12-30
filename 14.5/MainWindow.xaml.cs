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

namespace _14._5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private int[,] myArray = new int[3, 5];
        public MainWindow()
        {
            InitializeComponent();
            Random rand = new Random();
            ArrayData(rand);
        }

        private void btnVerwisselen_Click(object sender, RoutedEventArgs e)
        {
            lblSwitch.Items.Clear();
            if (string.IsNullOrEmpty(txtIndexOne.Text) || string.IsNullOrEmpty(txtIndexTwo.Text))
            {
                MessageBox.Show("Some textboxes are empty.");
            }
            else
            {
                if(int.TryParse(txtIndexOne.Text, out int numberOne) && int.TryParse(txtIndexTwo.Text, out int numberTwo))
                {
                   
                    int[] tempArray = new int[3];
                    for (int i = 0; i < myArray.GetLength(0); i++)
                    {
                        tempArray[i] = myArray[i, numberTwo];
                        myArray[i, numberTwo] = myArray[i, numberOne];
                        myArray[i, numberOne] = tempArray[i];
                        lblSwitch.Items.Add(myArray[i, 0].ToString().PadLeft(10) +
                           myArray[i, 1].ToString().PadLeft(10) +
                           myArray[i, 2].ToString().PadLeft(10) +
                           myArray[i, 3].ToString().PadLeft(10) +
                           myArray[i, 4].ToString().PadLeft(10));
                    }
                } else
                {
                    MessageBox.Show("Some textboxes are empty.");
                }
            }
        }

        private void ArrayData(Random rand)
        {
            for (int i = 0; i < myArray.GetLength(0); i++)
            {
                string line = "";
                for (int j = 0; j < myArray.GetLength(1); j++)
                {
                    myArray[i, j] = rand.Next(1, 100);
                    line += myArray[i, j].ToString().PadLeft(10);
                }
                lblMain.Items.Add(line);
            }
        }
    }
}

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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Marble marbles = new Marble();
        public MainWindow()
        {
            InitializeComponent();
            //Marble marbles = new Marble();
            u1Label.DataContext = marbles;
            u2Label.DataContext = marbles;
            u3Label.DataContext = marbles;
            u4Label.DataContext = marbles;
            u5Label.DataContext = marbles;
            u6Label.DataContext = marbles;

            c1Label.DataContext = marbles;
            c2Label.DataContext = marbles;
            c3Label.DataContext = marbles;
            c4Label.DataContext = marbles;
            c5Label.DataContext = marbles;
            c6Label.DataContext = marbles;

            // 6 objekt i varje
            /*List<Marble> userMarbleList = new List<Marble>();
            userMarbleList.Add(marbles);

            List<Marble> compMarbleList = new List<Marble>();
            compMarbleList.Add(marbles);*/

         
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           marbles.Marbles = 10;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}

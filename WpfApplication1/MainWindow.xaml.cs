using SanSebKalaha.Classes;
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

namespace SanSebKalaha
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        RuleMaster ruleMaster = new RuleMaster();

        public MainWindow()
        {
            InitializeComponent();

            setLabelContexts();

            ruleMaster.preGame();

            board.SelectedIndex = 0;
                   
        }

        public void setLabelContexts()
        {

            start.DataContext = ruleMaster.gameButton;
            concede.DataContext = ruleMaster.gameButton;

            board.DataContext = ruleMaster.boardOptions;

            displayTurn.DataContext = ruleMaster.playersTurn;

            u1Label.DataContext = ruleMaster.marbles;
            u2Label.DataContext = ruleMaster.marbles;
            u3Label.DataContext = ruleMaster.marbles;
            u4Label.DataContext = ruleMaster.marbles;
            u5Label.DataContext = ruleMaster.marbles;
            u6Label.DataContext = ruleMaster.marbles;

            c1Label.DataContext = ruleMaster.marbles;
            c2Label.DataContext = ruleMaster.marbles;
            c3Label.DataContext = ruleMaster.marbles;
            c4Label.DataContext = ruleMaster.marbles;
            c5Label.DataContext = ruleMaster.marbles;
            c6Label.DataContext = ruleMaster.marbles;

            uPoints.DataContext = ruleMaster.marblesUser;
            cPoints.DataContext = ruleMaster.marblesComp;

            u1.DataContext = ruleMaster.availableEllipses;
            u2.DataContext = ruleMaster.availableEllipses;
            u3.DataContext = ruleMaster.availableEllipses;
            u4.DataContext = ruleMaster.availableEllipses;
            u5.DataContext = ruleMaster.availableEllipses;
            u6.DataContext = ruleMaster.availableEllipses;

            c1.DataContext = ruleMaster.availableEllipses;
            c2.DataContext = ruleMaster.availableEllipses;
            c3.DataContext = ruleMaster.availableEllipses;
            c4.DataContext = ruleMaster.availableEllipses;
            c5.DataContext = ruleMaster.availableEllipses;
            c6.DataContext = ruleMaster.availableEllipses;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.gameRules(board.SelectedIndex);
            setLabelContexts();



        }

        private void ConcedeButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.ConcedeWindow();
       
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MouseDownEllipse(object sender, MouseButtonEventArgs e)
        {

            ruleMaster.collectEllipseID(sender);

            /*Ellipse ellipse = sender as Ellipse;
            string theEllipse = "";

            // Hämta positionen på den tryckte Ellipse
            if (ellipse != null)
            {
                theEllipse = ellipse.Tag.ToString();
            }
            int ellipseInArray = Convert.ToInt32(theEllipse);

            // Hämta antalet kulor som ska flyttas
            int moveTheseMarbles = arrayTest[ellipseInArray];

            // Sätter nuvarande position till 0
            arrayTest[ellipseInArray] = 0;
            int i = 0;

            // Hämta nästkommande ställen som kulorna ska landa på
            while (i < moveTheseMarbles)
            {
                i++;
                int cupPosition = ellipseInArray + i;
                if (cupPosition >= 14)
                {
                    cupPosition = cupPosition - 14;
                }
                arrayTest[cupPosition] = arrayTest[cupPosition] + 1;
            }
            // Kör funktion för att uppdatera GUI labels
            setLabelContexts(); */
        }

        //
        // Saker vi kan göra //
        //

        // Bakgroundsbild
        /*<Grid.Background>
           <ImageBrush Stretch="None" ImageSource="Images/Wood.jpg" AlignmentY="Top" AlignmentX="Center"/>
       </Grid.Background>*/
    }
}

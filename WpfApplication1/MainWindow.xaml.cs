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
        private MarbleU1 marblesU1 = new MarbleU1();
        private MarbleU2 marblesU2 = new MarbleU2();
        private MarbleU3 marblesU3 = new MarbleU3();
        private MarbleU4 marblesU4 = new MarbleU4();
        private MarbleU5 marblesU5 = new MarbleU5();
        private MarbleU6 marblesU6 = new MarbleU6();
        private MarbleC1 marblesC1 = new MarbleC1();
        private MarbleC2 marblesC2 = new MarbleC2();
        private MarbleC3 marblesC3 = new MarbleC3();
        private MarbleC4 marblesC4 = new MarbleC4();
        private MarbleC5 marblesC5 = new MarbleC5();
        private MarbleC6 marblesC6 = new MarbleC6();
        private MarbleUser marblesUser = new MarbleUser();
        private MarbleComp marblesComp = new MarbleComp();

        private StartButton startButton = new StartButton();
        private ConcedeButton concedeButton = new ConcedeButton();

        private BoardOptions boardOptions = new BoardOptions();

        int[] arrayTest = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] arrayTest0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        int[] arrayTest3 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
        int[] arrayTest4 = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };
        int[] arrayTest5 = { 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 0 };

        RuleMaster ruleMaster = new RuleMaster();

        public MainWindow()
        {
            InitializeComponent();
            //Marble marbles = new Marble();
            updateLabelContexts();
            board.Items.Insert(0, "Standard");
            board.Items.Insert(1, "African");
            board.Items.Insert(2, "Colombian");

            start.IsEnabled = startButton.StartButtonIsEnabled;
            giveUp.IsEnabled = concedeButton.ConcedeButtonIsEnabled;
            board.IsEnabled = boardOptions.BoardOptionsIsEnabled;

            board.SelectedIndex = 0;

            /*switch (board)
            {
                case board.SelectedIndex == 0: arrayTest = arrayTest3; break;
                case board.SelectedIndex == 1: arrayTest = arrayTest4; break;
                case board.SelectedIndex == 2: arrayTest = arrayTest5; break;
            }*/

            //if(board.SelectedIndex == someIntValue){} Använd för att se vad användaren valde

            // 6 objekt i varje
            /*List<Marble> userMarbleList = new List<Marble>();
            userMarbleList.Add(marbles);

            List<Marble> compMarbleList = new List<Marble>();
            compMarbleList.Add(marbles);*/

           //arrayTest = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 }; // Ett bo, 6 skålar, ett bo, 6 skålar
         
        }

        private void updateLabelContexts()
        {
            u1Label.DataContext = marblesU1;
            u2Label.DataContext = marblesU2;
            u3Label.DataContext = marblesU3;
            u4Label.DataContext = marblesU4;
            u5Label.DataContext = marblesU5;
            u6Label.DataContext = marblesU6;

            c1Label.DataContext = marblesC1;
            c2Label.DataContext = marblesC2;
            c3Label.DataContext = marblesC3;
            c4Label.DataContext = marblesC4;
            c5Label.DataContext = marblesC5;
            Console.WriteLine(c5Label.DataContext = marblesC5);
            Console.WriteLine(c5Label.DataContext);
            Console.WriteLine(marblesC5);
            c6Label.DataContext = marblesC6;

            uPoints.DataContext = marblesUser;

            cPoints.DataContext = marblesComp;
        }

        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.GameRules(board.SelectedIndex);
            updateLabelContexts();

            start.IsEnabled = startButton.StartButtonIsEnabled;
            giveUp.IsEnabled = concedeButton.ConcedeButtonIsEnabled;
            board.IsEnabled = boardOptions.BoardOptionsIsEnabled;

        }

        private void ConcedeButton_Click(object sender, RoutedEventArgs e)
        {
            ruleMaster.ConcedeWindow();

            //start.IsEnabled = startButton;
            //giveUp.IsEnabled = concedeButton;
            /*MessageBoxResult result = MessageBox.Show("Är du säker på att du vill ge upp?", "Ge upp?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes: arrayTest = arrayTest0; setMarbleValues(); start.IsEnabled = true; giveUp.IsEnabled = false; break;
                case MessageBoxResult.No: break;
            }*/
            start.IsEnabled=startButton.StartButtonIsEnabled;
            giveUp.IsEnabled = concedeButton.ConcedeButtonIsEnabled;
            board.IsEnabled = boardOptions.BoardOptionsIsEnabled;
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void MouseDownEllipse(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;
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
            updateLabelContexts();
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

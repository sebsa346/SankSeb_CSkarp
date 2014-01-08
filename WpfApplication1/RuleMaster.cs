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

    class RuleMaster
    {
        //MainWindow mw = new MainWindow();

        public Marbles marbles = new Marbles();

        public MarbleUser marblesUser = new MarbleUser();
        public MarbleComp marblesComp = new MarbleComp();

        public GameButton gameButton = new GameButton();

        public BoardOptions boardOptions = new BoardOptions();

        private int[] arrayTest = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] arrayTest0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] arrayTest3 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
        private int[] arrayTest4 = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };
        private int[] arrayTest5 = { 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 0 };

        public void startUp()
        {
         
        }


        private void setMarbleValues()
        {
            marbles.MarblesU1 = arrayTest[0];
            marbles.MarblesU2 = arrayTest[1];
            marbles.MarblesU3 = arrayTest[2];
            marbles.MarblesU4 = arrayTest[3];
            marbles.MarblesU5 = arrayTest[4];
            marbles.MarblesU6 = arrayTest[5];
            marbles.MarblesC1 = arrayTest[12];
            marbles.MarblesC2 = arrayTest[11];
            marbles.MarblesC3 = arrayTest[10];
            marbles.MarblesC4 = arrayTest[9];
            marbles.MarblesC5 = arrayTest[8];
            marbles.MarblesC6 = arrayTest[7];

            marblesUser.UserPoints = arrayTest[6];
            marblesComp.CompPoints = arrayTest[13];

        }

        public void GameRules(int boardIndex)
        {
            gameButton.StartButtonIsEnabled = false;
            gameButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;


            if (boardIndex == 0)
            {
                arrayTest = arrayTest3;
                Console.WriteLine("Here");
            }
            else if (boardIndex == 1)
            {
                arrayTest = arrayTest4;
            }
            else if (boardIndex == 2)
            {
                arrayTest = arrayTest5;
            }
            setMarbleValues();
        }

        public void ConcedeWindow()
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att du vill ge upp?", "Ge upp?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes: arrayTest = arrayTest0; gameButton.StartButtonIsEnabled = true; gameButton.ConcedeButtonIsEnabled = false; boardOptions.BoardOptionsIsEnabled = true; 
                    setMarbleValues(); break;
                case MessageBoxResult.No: break;
            }


        }

        private void RadioButton_Check(object sender, RoutedEventArgs e)
        {

        }

        public void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gameRules();

        }

        public void MouseDownEllipsee(object sender, MouseButtonEventArgs e)
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
            setMarbleValues();
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

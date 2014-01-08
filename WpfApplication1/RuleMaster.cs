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

        private int[] arrayTest = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] arrayTest0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] arrayTest3 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
        private int[] arrayTest4 = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };
        private int[] arrayTest5 = { 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 0 };


        public void startUp()
        {
            //Marble marbles = new Marble();
  
    

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

        private void setMarbleValues()
        {
            marblesU1.MarblesU1 = arrayTest[0];
            marblesU2.MarblesU2 = arrayTest[1];
            marblesU3.MarblesU3 = arrayTest[2];
            marblesU4.MarblesU4 = arrayTest[3];
            marblesU5.MarblesU5 = arrayTest[4];
            marblesU6.MarblesU6 = arrayTest[5];
            marblesC1.MarblesC1 = arrayTest[12];
            marblesC2.MarblesC2 = arrayTest[11];
            marblesC3.MarblesC3 = arrayTest[10];
            marblesC4.MarblesC4 = arrayTest[9];
            marblesC5.MarblesC5 = arrayTest[8];
            marblesC6.MarblesC6 = arrayTest[7];
            marblesUser.UserPoints = arrayTest[6];
            marblesComp.CompPoints = arrayTest[13];
            Console.WriteLine(arrayTest[3]);
            int hej = marblesC5.MarblesC5;
            Console.WriteLine(hej);
        }

        public void GameRules(int boardIndex)
        {
            startButton.StartButtonIsEnabled = false;
            concedeButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;
            Console.WriteLine(startButton.StartButtonIsEnabled);
            Console.WriteLine(concedeButton.ConcedeButtonIsEnabled);
            Console.WriteLine(boardOptions.BoardOptionsIsEnabled);

            Console.WriteLine(boardIndex);

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
                case MessageBoxResult.Yes: arrayTest = arrayTest0; startButton.StartButtonIsEnabled = true; concedeButton.ConcedeButtonIsEnabled = false; boardOptions.BoardOptionsIsEnabled = true; 
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

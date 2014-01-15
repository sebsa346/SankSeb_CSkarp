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

    public class RuleMaster
    {

        public Marbles marbles = new Marbles();

        public MarbleUser marblesUser = new MarbleUser();
        public MarbleComp marblesComp = new MarbleComp();

        public GameButton gameButton = new GameButton();

        public BoardOptions boardOptions = new BoardOptions();
        public PlayersTurn playersTurn = new PlayersTurn();

        public AvailableEllipses availableEllipses = new AvailableEllipses();

        public string currentPlayer = "";

        public int tre = 3;

        public int[] arrayTest = new int[14];
   

        public void preGame()
        {
            gameButton.StartButtonIsEnabled = true; 
            gameButton.ConcedeButtonIsEnabled = false; 
            boardOptions.BoardOptionsIsEnabled = true; 
            availableEllipses.UserEllipsesIsEnabled = false;
            availableEllipses.CompEllipsesIsEnabled = false;
            playersTurn.WhosTurn = "Inget spel igång";

        }

        // Uppdateras alla marbles med värden som finns i spelsplans-arrayen.
        public void setMarbleValues()
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

            Console.WriteLine(marbles.MarblesU1);
            Console.WriteLine(marbles.MarblesU2);
            Console.WriteLine(marbles.MarblesU3);
            Console.WriteLine(marbles.MarblesU4);
            Console.WriteLine(marbles.MarblesU5);


        }

        public void gameRules(int boardIndex)
        {
            gameButton.StartButtonIsEnabled = false;
            gameButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;

            Console.WriteLine(boardIndex);
            // Första spelaren börjar
            playersTurn.WhosTurn = "You";

            // Sätter att User ALLTID börjar
            availableEllipses.UserEllipsesIsEnabled = true;
            availableEllipses.CompEllipsesIsEnabled = false;

            if (boardIndex == 0)
            {
                setArray(3);
                
            }
            else if (boardIndex == 1)
            {
                setArray(4);
            }
            else if (boardIndex == 2)
            {
                setArray(5);
            }
            setMarbleValues();
        }

        private void setArray(int noMarblesToStart)
        {
            for (int i = 0; i < arrayTest.Length; i++)
            {
                if (!(i == 6 || i == 13))
                {
                    arrayTest[i] = noMarblesToStart;
                }
                else
                {
                    arrayTest[i] = 0;
                }
            }
        }

        public void ConcedeWindow()
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att du vill ge upp?", "Ge upp?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes: Array.Clear(arrayTest, 0, 14); preGame(); setMarbleValues(); break;
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

        // Kollar ifall spelregeln "Capture" ska tillämpas
        private void isItCapture(int cupPosition)
        {
            int crossEllipse = 0;

            // Kolla ifall det finns en möjlighet att en "Capture" har skett
            if ((cupPosition <= 5 && currentPlayer == "You") && (arrayTest[cupPosition] == 1))
            {
                crossEllipse = 13 - (cupPosition + 1);
                arrayTest[6] += arrayTest[crossEllipse] + 1;
                arrayTest[cupPosition] = 0;
                arrayTest[crossEllipse] = 0;

            }
            else if ((Enumerable.Range(7,6).Contains(cupPosition) && currentPlayer == "George") && (arrayTest[cupPosition] == 1)) 
            {
                crossEllipse = ellipsePartner(cupPosition);
                arrayTest[13] += arrayTest[crossEllipse] + 1;
                arrayTest[cupPosition] = 0;
                arrayTest[crossEllipse] = 0;
            }

        }

        private int ellipsePartner(int cupPosition)
        {
            int ellipsePartner = 0;

            switch(cupPosition)
            {
                case 7: ellipsePartner = 5; break;
                case 8: ellipsePartner = 4; break;
                case 9: ellipsePartner = 3; break;
                case 10: ellipsePartner = 2; break;
                case 11: ellipsePartner = 1; break;
                case 12: ellipsePartner = 0; break;
            }
            return ellipsePartner;
        }

        // Kollar vem som spelade senast och ifall den spelaren har rätt att fortsätta
        private void checkWhosTurnItIs(int cupPosition)
        {

            if (cupPosition == 6 && currentPlayer == "You")
            {
                // Ha kvar samma
            }
            else if (cupPosition == 13 && currentPlayer == "George")
            {
                // Ha kvar samma
            }
            else
            {
                switchPlayer();
            }
        }

        // Byter till den andra spelaren
        private void switchPlayer()
        {
            if (currentPlayer == "You")
            {
                playersTurn.WhosTurn = "George";
                availableEllipses.CompEllipsesIsEnabled = true;
                availableEllipses.UserEllipsesIsEnabled = false;
            }
            else
            {
                playersTurn.WhosTurn = "You";
                availableEllipses.CompEllipsesIsEnabled = false;
                availableEllipses.UserEllipsesIsEnabled = true;
            }
        }

        // Tar emot "Tag" från Ellipsen som användaren valt, som sedan arbetas om till en int.
        public void collectEllipseID(object sender)
        {
            Ellipse ellipse = sender as Ellipse;

            string theEllipse = "";
            int ellipsePositionInArray = 0;

            // Hämta positionen på den valda Ellipsen
            if (ellipse != null)
            {
                theEllipse = ellipse.Tag.ToString();
            }
            ellipsePositionInArray = Convert.ToInt32(theEllipse);

            MouseDownEllipsee(ellipsePositionInArray);
        }

        // Tar emot användarens val av ellipse och agerar därefter med att
        // uppdatera de fack som ska uppdateras.
        public void MouseDownEllipsee(int ellipsePositionInArray)
        {
            int cupPosition = 0;
            currentPlayer = playersTurn.WhosTurn;

            // Hämta antalet kulor som ska flyttas
            int moveTheseMarbles = arrayTest[ellipsePositionInArray];

            // Sätter nuvarande position till 0
            arrayTest[ellipsePositionInArray] = 0;
            int i = 0;

            while (i < moveTheseMarbles)
            {
                i++;
                cupPosition = ellipsePositionInArray + i;
                if (cupPosition >= 14)
                {
                    cupPosition = cupPosition - 14;
                }
                arrayTest[cupPosition] = arrayTest[cupPosition] + 1;
            }



            isItCapture(cupPosition);

            // Kör funktion för att uppdatera GUI labels
            setMarbleValues();
            checkWhosTurnItIs(cupPosition);

        }

     
   
        //
        // Saker vi kan göra //
        //

        // Bakgroundsbild
        /*<Grid.Background>
           <ImageBrush Stretch="None" ImageSource="Images/Wood.jpg" AlignmentY="Top" AlignmentX="Center"/>
       </Grid.Background>*/

        // Gamla lösningen med 1 array
        /* while (i < moveTheseMarbles)
            {
                i++;
                cupPosition = ellipseInArray + i;
                if (cupPosition >= 14)
                {
                    cupPosition = cupPosition - 14;
                }
                arrayTest[cupPosition] = arrayTest[cupPosition] + 1;
            } */
    }
}

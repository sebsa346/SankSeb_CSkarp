﻿using SanSebKalaha.Classes;
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
        public PlayersTurn playersTurn = new PlayersTurn();

        private string currentPlayer = "";

        private int[] arrayTest = new int[14];
        /*private int[] arrayTest0 = { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        private int[] arrayTest3 = { 3, 3, 3, 3, 3, 3, 0, 3, 3, 3, 3, 3, 3, 0 };
        private int[] arrayTest4 = { 4, 4, 4, 4, 4, 4, 0, 4, 4, 4, 4, 4, 4, 0 };
        private int[] arrayTest5 = { 5, 5, 5, 5, 5, 5, 0, 5, 5, 5, 5, 5, 5, 0 };*/

        /*private int[] miniArrayTestU = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] miniArrayTestC = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] miniArrayTestU0 = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] miniArrayTestC0 = { 0, 0, 0, 0, 0, 0, 0 };
        private int[] miniArrayTestU3 = { 3, 3, 3, 3, 3, 3, 0 };
        private int[] miniArrayTestC3 = { 3, 3, 3, 3, 3, 3, 0 };
        private int[] miniArrayTestU4 = { 4, 4, 4, 4, 4, 4, 0 };
        private int[] miniArrayTestC4 = { 4, 4, 4, 4, 4, 4, 0 };*/


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
 

           /* marbles.MarblesU1 = miniArrayTestU[0];
            marbles.MarblesU2 = miniArrayTestU[1];
            marbles.MarblesU3 = miniArrayTestU[2];
            marbles.MarblesU4 = miniArrayTestU[3];
            marbles.MarblesU5 = miniArrayTestU[4];
            marbles.MarblesU6 = miniArrayTestU[5];

            marblesUser.UserPoints = miniArrayTestU[6];


            marbles.MarblesC1 = miniArrayTestC[0];
            marbles.MarblesC2 = miniArrayTestC[1];
            marbles.MarblesC3 = miniArrayTestC[2];
            marbles.MarblesC4 = miniArrayTestC[3];
            marbles.MarblesC5 = miniArrayTestC[4];
            marbles.MarblesC6 = miniArrayTestC[5];

            marblesComp.CompPoints = miniArrayTestC[6];*/

        }

        public void GameRules(int boardIndex)
        {
            gameButton.StartButtonIsEnabled = false;
            gameButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;

            // Första spelaren börjar
            playersTurn.WhosTurn = "You";

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
                case MessageBoxResult.Yes: Array.Clear(arrayTest,0,14); gameButton.StartButtonIsEnabled = true; 
                    gameButton.ConcedeButtonIsEnabled = false; boardOptions.BoardOptionsIsEnabled = true; setMarbleValues(); break;
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
            Console.WriteLine("Inne i ISCapture: " + cupPosition);

            // Kolla ifall det finns en möjlighet att en "Capture" har skett
            if ((cupPosition <= 5 && currentPlayer == "You") && (arrayTest[cupPosition] == 1))
            {
                Console.WriteLine("Inne u");
                crossEllipse = 13 - (cupPosition + 1);
                arrayTest[6] += arrayTest[crossEllipse] + 1;
                arrayTest[cupPosition] = 0;
                arrayTest[crossEllipse] = 0;

            }
            else if ((Enumerable.Range(7,6).Contains(cupPosition) && currentPlayer == "George") && (arrayTest[cupPosition] == 1)) 
            {
                Console.WriteLine("Inne C");
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
            }
            else
            {
                playersTurn.WhosTurn = "You";
            }
        }

        public void MouseDownEllipsee(object sender, MouseButtonEventArgs e)
        {
            Ellipse ellipse = sender as Ellipse;

            string theEllipse = "";
            int cupPosition = 0;
            int ellipsePositionInArray = 0;
            currentPlayer = playersTurn.WhosTurn;

            // Hämta positionen på den valda Ellipsen
            if (ellipse != null)
            {
                theEllipse = ellipse.Tag.ToString();
            }
            ellipsePositionInArray = Convert.ToInt32(theEllipse);

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

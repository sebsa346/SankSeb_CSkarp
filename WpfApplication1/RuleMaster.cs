using SanSebKalaha.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Shapes;

namespace SanSebKalaha
{

    public class RuleMaster
    {
        public AvailableEllipses availableEllipses = new AvailableEllipses();
        public BoardOptions boardOptions = new BoardOptions();
        public GameButton gameButton = new GameButton();
        public PlayersTurn playersTurn = new PlayersTurn();

        public Marbles marbles = new Marbles();
        public MarbleUser marblesUser = new MarbleUser();
        public MarbleComp marblesComp = new MarbleComp();

        private Program dbProgram = new Program();

        private string player1 = "You";
        private string player2 = "George";
        private string winner = "";
        public string currentPlayer = "";
        public int[] theGameBoard = new int[14];


        /* *******************************
         * 
         * Metoder för att programmet ska fungera som det är tänkt. 
         * Innehåller inga direkta spelregler.
         * 
         * ******************************* */


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

            // Går inte att flytta 0 kulor så användare får trycka igen.
            if (theGameBoard[ellipsePositionInArray] != 0)
                MoveMarbles(ellipsePositionInArray);
        }

        // Ifall en spelare vill ge upp så får han/hon en bekräftelseruta. Om spelaren fortfarande vill ge upp
        // så nollställs alla spelvärden.
        public void ConcedeWindow()
        {
            MessageBoxResult result = MessageBox.Show("Är du säker på att du vill ge upp?", "Ge upp?", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes: Array.Clear(theGameBoard, 0, 14); dbProgram.removePreviousGame(); preGame(); setMarbleValues(); break;
                case MessageBoxResult.No: break;
            }
        }

        // Sätter de värden som är innan ett spel har startat.
        public void preGame()
        {
            playersTurn.Color = "Black";
            playersTurn.Player1Name = player1;
            playersTurn.Player2Name = player2;

            // Kollar om det finns ett sparat spel som användaren vill fortsätta på
            if (checkForSavedGameInDB() == true)
            {
                getGameFromDB();
            }
            else
            {
                playersTurn.WhosTurn = "Inget spel igång";
                gameButton.StartButtonIsEnabled = true;
                gameButton.ConcedeButtonIsEnabled = false;
                boardOptions.BoardOptionsIsEnabled = true;
                availableEllipses.UserEllipsesIsEnabled = false;
                availableEllipses.CompEllipsesIsEnabled = false;
            }
        }

        // Spara nuvarande spel vid nedstängning.
        public void MainWindowClosing(object sender, CancelEventArgs e)
        {
            // Spara matchen ifall det verkligen är en match igång
            if (gameButton.StartButtonIsEnabled.Equals(false))
            {
                dbProgram.removePreviousGame();
                saveGameToDB();
            }
        }

        // Sätter arrayen som innehåller startkulorna
        private void setArray(int noMarblesToStart)
        {

            for (int i = 0; i < theGameBoard.Length; i++)
            {
                if (!(i == 6 || i == 13))
                {
                    theGameBoard[i] = noMarblesToStart;
                }
                else
                {
                    theGameBoard[i] = 0;
                }
            }

        }

        // Uppdateras alla marbles med värden som finns i spelsplans-arrayen.
        public void setMarbleValues()
        {
            marbles.MarblesU1 = theGameBoard[0];
            marbles.MarblesU2 = theGameBoard[1];
            marbles.MarblesU3 = theGameBoard[2];
            marbles.MarblesU4 = theGameBoard[3];
            marbles.MarblesU5 = theGameBoard[4];
            marbles.MarblesU6 = theGameBoard[5];

            marbles.MarblesC1 = theGameBoard[12];
            marbles.MarblesC2 = theGameBoard[11];
            marbles.MarblesC3 = theGameBoard[10];
            marbles.MarblesC4 = theGameBoard[9];
            marbles.MarblesC5 = theGameBoard[8];
            marbles.MarblesC6 = theGameBoard[7];

            marblesUser.UserPoints = theGameBoard[6];
            marblesComp.CompPoints = theGameBoard[13];
        }


        /* *******************************
         * 
         * Metoder för spelregler
         * 
         * ******************************* */


        // Kollar vem som spelade senast och ifall den spelaren har rätt att fortsätta.
        private void checkWhosTurnItIs(int cupPosition)
        {

            if (cupPosition == 6 && currentPlayer == player1)
            {
                // Ha kvar samma
            }
            else if (cupPosition == 13 && currentPlayer == player2)
            {
                // Ha kvar samma
            }
            else
            {
                switchPlayer();
            }
        }

        // Kollar ifall spelet har en vinnare.
        private bool gameOver()
        {
            bool gameIsOver = false;

            int marblesLeftPlayer1 = 0;
            int marblesLeftPlayer2 = 0;

            // Kollar ifall spelarna har några kulor kvar att flytta.
            for (int i = 0; i < theGameBoard.Length; i++)
            {
                if (Enumerable.Range(0,6).Contains(i)) 
                {
                    Console.WriteLine("Spelare 1 " + i);
                    marblesLeftPlayer1 += theGameBoard[i];
                }
                else if (Enumerable.Range(7,6).Contains(i)) {
                    Console.WriteLine("Spelare 2 " + i);
                    marblesLeftPlayer2 += theGameBoard[i];
                }
            }
            Console.WriteLine(" ");
            Console.WriteLine("Räknat klar");
            Console.WriteLine(" ");
            // Ifall någon ut av spelarna har slut på kulor att flytta är spelet slut.
            if (marblesLeftPlayer1 == 0 || marblesLeftPlayer2 == 0)
            {
                Console.WriteLine("Inne");
                gameIsOver = true;
                if (theGameBoard[6] > theGameBoard[13])
                {
                    winner = player1;
                    Console.WriteLine("alt1");
                }
                else if (theGameBoard[6] < theGameBoard[13])
                {
                    winner = player2;
                    Console.WriteLine("alt2");
                }
                else
                {
                    winner = "draw";
                    Console.WriteLine("alt3");
                }
                
            }

            return gameIsOver;
        }

        // En metod som används vid spelstart för att sätta de regler som spelaren valt.
        public void gameRules(int boardIndex)
        {
            gameButton.StartButtonIsEnabled = false;
            gameButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;
            boardOptions.Announcement = "";


            // Sätter att spelare 1 ALLTID börjar.
            playersTurn.WhosTurn = player1;
            playersTurn.Color = "DarkBlue";
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

        // En metod som används för att kolla vilken ellipse på den motsatta sidan som hör ihop
        // med spelare2s valda ellipse.
        private int ellipsePartner(int cupPosition)
        {
            int ellipsePartner = 0;

            switch (cupPosition)
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

        // Kollar ifall spelregeln "Capture" ska tillämpas
        private void isItCapture(int cupPosition)
        {
            int crossEllipse = 0;

            // Kolla ifall det finns en möjlighet att en "Capture" har skett
            if ((cupPosition <= 5 && currentPlayer == player1) && (theGameBoard[cupPosition] == 1))
            {
                // Hämtar sista kulan som landa samt de kulor som finns på motsatt sida.
                crossEllipse = 13 - (cupPosition + 1);
                theGameBoard[6] += theGameBoard[crossEllipse] + 1;
                theGameBoard[cupPosition] = 0;
                theGameBoard[crossEllipse] = 0;
                boardOptions.Color = "DarkBlue";
                boardOptions.Announcement = "En Capture av: " + player1 + "!";
            }

            else if ((Enumerable.Range(7,6).Contains(cupPosition) && currentPlayer == player2) && (theGameBoard[cupPosition] == 1)) 
            {
                crossEllipse = ellipsePartner(cupPosition);
                theGameBoard[13] += theGameBoard[crossEllipse] + 1;
                theGameBoard[cupPosition] = 0;
                theGameBoard[crossEllipse] = 0;
                boardOptions.Color = "DeepPink";
                boardOptions.Announcement = "En Capture av: " + player2 + "!";
            }
        }

        // Tar emot användarens val av ellipse och agerar därefter med att
        // uppdatera de fack som ska uppdateras.
        public void MoveMarbles(int ellipsePositionInArray)
        {
            int cupPosition = 0;
            currentPlayer = playersTurn.WhosTurn;
            boardOptions.Announcement = "";

            // Hämta antalet kulor som ska flyttas
            int moveTheseMarbles = theGameBoard[ellipsePositionInArray];

            // Sätter nuvarande position till 0
            theGameBoard[ellipsePositionInArray] = 0;
            int i = 0;

            while (i < moveTheseMarbles)
            {
                i++;
                cupPosition = ellipsePositionInArray + i;
                if (cupPosition >= 14)
                {
                    cupPosition = cupPosition - 14;
                }
                theGameBoard[cupPosition] = theGameBoard[cupPosition] + 1;
            }

            // Kollar ifall en capture har skett eller inte.
            isItCapture(cupPosition);

            // Kör funktion för att uppdatera GUI labels.
            setMarbleValues();
            checkWhosTurnItIs(cupPosition);

            if (gameOver() == true)
            {
                if (winner != "draw")
                {
                    boardOptions.Color = "DarkGreen";
                    boardOptions.Announcement = "Spelet är slut! Vinnaren är : " + winner + "\nStarta ett nytt spel eller kom tillbaka senare!";
                }
                else
                {
                    boardOptions.Color = "DarkYellow";
                    boardOptions.Announcement = "Spelet är slut! Matchen slutade oavgjort. \nStarta ett nytt eller kom tillbaka senare!";
                }
                // ---
                Array.Clear(theGameBoard, 0, 14); dbProgram.removePreviousGame(); preGame();
            }

        }

        // Byter till den andra spelaren
        private void switchPlayer()
        {
            if (currentPlayer == player1)
            {
                playersTurn.WhosTurn = player2;
                playersTurn.Color = "DeepPink";
                availableEllipses.CompEllipsesIsEnabled = true;
                availableEllipses.UserEllipsesIsEnabled = false;
            }
            else
            {
                playersTurn.WhosTurn = player1;
                playersTurn.Color = "DarkBlue";
                availableEllipses.CompEllipsesIsEnabled = false;
                availableEllipses.UserEllipsesIsEnabled = true;
            }
        }


        /* *******************************
         * 
         * Metoder för koppling till databas.
         * 
         * ******************************* */


        // Kollar ifall det finns en sparad match i databasen samt om användaren i så fall vill
        // fortsätta spela.
        public bool checkForSavedGameInDB()
        {
            bool proceedWithSavedGame = false;

            if (dbProgram.checkForSavedGame() != 0)
            {
                MessageBoxResult result = MessageBox.Show("Du har en undansparad match, vill du fortsätta på den? Om du inte inte fortsätter " +
                "kommer den sparade matchen att tas bort.", "En sparad match hittades!", MessageBoxButton.YesNo);
                switch (result)
                {
                    case MessageBoxResult.Yes: proceedWithSavedGame = true; break;
                    case MessageBoxResult.No: proceedWithSavedGame = false; dbProgram.removePreviousGame(); break;
                }
            }

            return proceedWithSavedGame;
        }

        // Hämta sparat spel i databasen och aktivera det i applikationen.
        public void getGameFromDB()
        {
            List<string> gameData = new List<string>();
            gameData = dbProgram.getGame();

            // Sätter igång det nya spelet
            gameButton.StartButtonIsEnabled = false;
            gameButton.ConcedeButtonIsEnabled = true;
            boardOptions.BoardOptionsIsEnabled = false;

            // Första spelaren börjar
            playersTurn.WhosTurn = gameData[1];

            // Sätter att User ALLTID börjar
            if (playersTurn.WhosTurn == player1)
            {
                playersTurn.Color = "DarkBlue";
                availableEllipses.UserEllipsesIsEnabled = true;
                availableEllipses.CompEllipsesIsEnabled = false;
            }
            else
            {
                playersTurn.Color = "DeepPink";
                availableEllipses.UserEllipsesIsEnabled = false;
                availableEllipses.CompEllipsesIsEnabled = true;
            }

            theGameBoard = dbProgram.splitQueryString(gameData[0]);
            setMarbleValues();
        }

        // Spara ett spel till databasen.
        public void saveGameToDB()
        {
            string gameBoard = "";
            List<string> gameData = new List<string>();

            for (int i = 0; i < theGameBoard.Length; i++)
            {
                Console.WriteLine(theGameBoard[i]);
                if (i + 1 != theGameBoard.Length)
                {
                    gameBoard += theGameBoard[i] + " ";
                }
                else
                {
                    gameBoard += theGameBoard[i];
                }
            }

            gameData.Add(gameBoard);
            gameData.Add(playersTurn.WhosTurn);

            dbProgram.saveGame(gameData);
        }

    }
}

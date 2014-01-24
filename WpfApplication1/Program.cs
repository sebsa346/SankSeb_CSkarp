using System;
using System.Collections.Generic;
using System.Linq;

namespace SanSebKalaha
{
    public class Program
    {

        // Kollar ifall det finns ett undansparat spel. Om det finns så returneras spelets
        // databas-id.
        public int checkForSavedGame()
        {
            int gameID = 0;

            using (var db = new PlayingKalahaContext())
            {
                // Visa alla spel som finns i databasen
                var query = from b in db.Games
                            orderby b.GameBoard
                            select b;

                Console.WriteLine("Alla spel i databasen:");
                foreach (var item in query)
                {
                    gameID = item.GameId;
                    Console.WriteLine(item.GameId);
                    Console.WriteLine(gameID);
                    Console.WriteLine(item.GameBoard);
                    Console.WriteLine(item.PlayersTurn);
                    

                }
            }
            Console.WriteLine("Innan return" + gameID);
            return gameID;
        }

        // Hämta spelbordet samt vems speltur det är. Returnera som stränglista.
        public List<string> getGame()
        {
            List<string> gameData = new List<string>();

            using (var db = new PlayingKalahaContext())
            {
                // Visa alla spel som finns i databasen
                var query = from b in db.Games
                            orderby b.GameId
                            select b;

                Console.WriteLine("Alla spel i databasen:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.GameBoard);
                    gameData.Add(item.GameBoard);
                    gameData.Add(item.PlayersTurn);


                }
            }
            Console.WriteLine("Innan return" + gameData[1]);
            return gameData;
        }

        // Ta bort det tidigare sparade spelet.
        public void removePreviousGame()
        {
            int gameID = 0;

            using (var db = new PlayingKalahaContext())
            {
                gameID = checkForSavedGame();
                if (gameID != 0)
                {
                    db.Games.Remove(db.Games.Find(gameID));
                    db.SaveChanges();
                }
            }
        }

        // Spara nuvarande spel till databasen.
        public bool saveGame(List<String> gameData)
        {
            bool succed = false;

            using (var db = new PlayingKalahaContext())
            {
                var game = new Game { GameBoard = gameData[0], PlayersTurn = gameData[1] };
                db.Games.Add(game);
                db.SaveChanges();
                succed = true;
            }

            return succed;
        }

        // Splitta strängen med kulor i och spara dessa till en int array.
        public int[] splitQueryString(string splitThis)
        {
            string[] marblesInString = new string[splitThis.Length - 2];
            List<int> tempInList = new List<int>();
            marblesInString = splitThis.Split(' ');
            int marbleAsInt = 0;

            foreach (string marbleAsString in marblesInString)
            {
                Console.WriteLine("a " + marbleAsString);
                marbleAsInt = Convert.ToInt32(marbleAsString);
                tempInList.Add(marbleAsInt);
            }
            int[] marblesInInt = tempInList.ToArray();
            return marblesInInt;
        }
    }
}

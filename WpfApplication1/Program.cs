using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SanSebKalaha
{
    public class Program
    {
        /*static void MainP(string[] args)
        {
            using (var db = new PlayingKalahaContext())
            {
                // Skapa ett game 
                /*Console.Write("Fyll i antalet kulor som finns kvar: ");
                var gameB = Console.ReadLine();

                var game = new Game { GameBoard = gameB };
                db.Games.Add(game);
                db.SaveChanges();

                // Visa alla spel som finns i databasen
                var query = from b in db.Games
                            orderby b.GameBoard
                            select b;

                Console.WriteLine("Alla spel i databasen:");
                foreach (var item in query)
                {
                    Console.WriteLine(item.GameBoard);

                }

                Console.WriteLine("Tryck på valfri tangent för att avsluta...");
                Console.ReadKey();
            }
        }*/

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

        // Ta bort det tidigare sparade spelet
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
    }
}

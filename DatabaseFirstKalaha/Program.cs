using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseFirstKalaha
{
    public class Program
    {
        static void Main(string[] args)
        {
            using (var db = new PlayingContext())
            {
                // Skapa ett game 
                /*Console.Write("Fyll i antalet kulor som finns kvar: ");
                var gameB = Console.ReadLine();

                var game = new Game { GameBoard = gameB };
                db.Games.Add(game);
                db.SaveChanges();*/

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
        }

        public bool saveGame(string gameBoard)
        {
            bool succed = false;
         
            using (var db = new PlayingContext())
            {
                var game = new Game { GameBoard = gameBoard };
                db.Games.Add(game);
                db.SaveChanges();
                succed = true;
            }

            return succed;
        }
    }
}

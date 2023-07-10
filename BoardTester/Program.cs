using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DominoGame.GameElements;

namespace BoardTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player P1 = new Player();
            Player P2 = new Player();
            Board Board = new Board(P1, P2);

            //Print tiles From BoneYard
            Console.WriteLine("---BoneYard---");
            foreach (var t  in Board.GetBoneYard()) {
                Console.WriteLine(t);
            }

            Console.WriteLine("---Player 1---");
            PrintPlayerTiles(P1);
            Console.WriteLine("---Player 2---");
            PrintPlayerTiles(P2);

            Console.ReadLine();
        }

        private static void PrintPlayerTiles(Player p)
        {
            foreach (var t in p.GetPlayableTiles())
            {
                Console.WriteLine(t);
            }
        }
    }
}

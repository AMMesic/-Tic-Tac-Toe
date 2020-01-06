using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* Mesic, Anel
 * Alouch, William
 * 2018-11-16
 * Visual Studio 2017
 */

namespace LuffarSchack
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WindowHeight = 30;
            Console.WindowWidth = 70;

            TicTacToe spela = new TicTacToe();
            spela.StartGame();
            
            Console.ReadKey();
        }
    }
}

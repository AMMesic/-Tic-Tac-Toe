using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuffarSchack
{
    class TicTacToe
    {
        Board board;
        Player playerX;
        Player playerO;
        Player currentPlayer;

       

        public void StartGame()
        {
            

            board = new Board(3);
            playerX = new Player(Player.Piece.X);
            playerO = new Player(Player.Piece.O);
            currentPlayer = playerX;
            bool spela = true;
            bool win = false;
            bool draw = true;

            while (!win && !CheckIfDraw())
            {
                SkrivUtBrädan();

                while (spela)
                {
                    Console.WriteLine("Spelare: " + currentPlayer.PlayerPiece + " Välj en siffra mellan (1 - 9): ");

                    int.TryParse(Console.ReadLine(), out int val);
                    Console.WriteLine("Ajaj, fel input eller så är platsen redan upptagen. Prova igen! ");
                    


                        if (!((val - 1) < 0) && val <= board.GetCurrentGameState().Count && board.IspositionAvailable(val - 1))
                    {
                        board.PlaceChange(currentPlayer.PlayerPiece, val - 1);
                        win = CheckIfWin();
                        draw = CheckIfDraw();
                        if (win)
                            break;
                        if (draw)
                            break;

                        
                        currentPlayer = ChangeCurrentPlayer();
                        MakeRandomAIMove();
                        win = CheckIfWin();
                        if (win || draw)
                            break;
                        currentPlayer = ChangeCurrentPlayer();

                        spela = false;
                    }
                }

                spela = true;
                Console.Clear();

            }
            SkrivUtBrädan();

            if (CheckIfWin())
            {
                Console.WriteLine("Spelare " + currentPlayer.PlayerPiece + " har vunnit! ");
            }

            if (CheckIfDraw() && !CheckIfWin())
            {
                Console.WriteLine("Det blev oavgjort! ");
            }
            Console.WriteLine("Type (0) to close the calculator or press (Enter) to calculate");
            string exit = Console.ReadLine();
            if (exit == "0")
            {
                Environment.Exit(0);
            } else
            {
                while (spela)
                SkrivUtBrädan();

            }

        }




        private Player ChangeCurrentPlayer()
        {
            return currentPlayer == playerX ? playerO : playerX;
        }



        public bool CheckIfDraw()
        {
            List<Square> bräda = board.GetCurrentGameState();

            for (int i = 0; i < bräda.Count; i++)
            {
                Square square = bräda[i];
                if (square.PieceStatus == Player.Piece.E)
                {
                    return false;
                }
            }
            return true;
        }



        public bool CheckIfWin()
        {
            if (Horisontell() == true)
            {
                return true;
            }
            if (Vertikal() == true)
            {
                return true;
            }
            if (Diagonal() == true)
            {
                return true;
            }
            return false;
        }



        public bool Horisontell()
        {
            List<Square> bräda = board.GetCurrentGameState();
            int square = (int)Math.Sqrt(bräda.Count);
            int temp = 0;

            for (int i = 0; i < bräda.Count; i += square)
            {
                temp = 0;
                for (int j = i; j < square + i; j++)
                {
                    if (bräda[j].PieceStatus == currentPlayer.PlayerPiece)
                    {
                        temp++;
                    }
                    if (temp == square)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public bool Vertikal()
        {
            List<Square> bräda = board.GetCurrentGameState();
            int square = (int)Math.Sqrt(bräda.Count);
            int temp = 0;

            for (int i = 0; i < square; i++)
            {
                temp = 0;
                for (int j = i; j < bräda.Count; j += square)
                {
                    if (bräda[j].PieceStatus == currentPlayer.PlayerPiece)
                    {
                        temp++;
                    }
                    if (temp == square)
                    {
                        return true;
                    }
                }
            }
            return false;
        }



        public bool Diagonal()
        {
            List<Square> bräda = board.GetCurrentGameState();
            int square = (int)Math.Sqrt(bräda.Count);
            int temp = 0;

            for (int i = 0; i < square; i++)
            {
                if (bräda[i + i * square].PieceStatus == currentPlayer.PlayerPiece)
                {
                    temp++;
                }
                if (temp == square)
                {
                    return true;
                }
            }

            temp = 0;
            for (int i = square - 1; i < bräda.Count - 2; i += (square - 1))
            {
                if (bräda[i].PieceStatus == currentPlayer.PlayerPiece)
                {
                    temp++;
                }
                if (temp == square)
                {
                    return true;
                }
            }
            return false;
        }



        public void SkrivUtBrädan()
        {
            List<Square> list = board.GetCurrentGameState();


            int square = (int)Math.Sqrt(list.Count);


            for (int i = 0; i < list.Count; i += square)
            {
                for (int j = 0; j < square; j++)
                {
                    Console.Write("|" + list[i + j].PieceStatus + "| ");
                }

                Console.WriteLine("\n ");
            }
        }



        public void MakeRandomAIMove()
        {
            List<int> empty = new List<int>();
            for (int i = 0; i < board.GetCurrentGameState().Count; i++)
            {
                if (board.IspositionAvailable(i))
                {
                    empty.Add(i);
                }
            }
            Random random = new Random();
            int choice = random.Next(0, empty.Count - 1);
            board.PlaceChange(currentPlayer.PlayerPiece, empty[choice]);
        }

    }

}

 
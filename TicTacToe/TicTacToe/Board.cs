using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuffarSchack
{
    class Board
    {
        List<Square> spel = new List<Square>();

        public Board(int size)
        {
            spel = new List<Square>(); 

            for (int i = 0; i < size*size; i++) 
            {
                spel.Add(new Square(Player.Piece.E));
            }
        }

        public List<Square> GetCurrentGameState()
        {
            return spel;
        }

        public bool IspositionAvailable(int pos)
        {
            if (pos < 0 || pos > spel.Count)
            {
                return false;
            }

            return spel[pos].PieceStatus == Player.Piece.E;
        }

        public void PlaceChange(Player.Piece field, int index)
        {
            spel[index].ChangeStatus(field);
        }

    }
}

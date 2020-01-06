using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuffarSchack
{
    class Square
    {
        public Player.Piece PieceStatus { get; private set; }

        public Square(Player.Piece play)
        {
           PieceStatus  = play;
        }
        
        public void ChangeStatus(Player.Piece square)
        {
            PieceStatus = square;
        }
    }
}

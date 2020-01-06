using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuffarSchack
{
    class Player
    {
        public enum Piece {E, X, O }; 
        
        public Piece PlayerPiece { get; private set; } 

        public Player(Player.Piece pla) 
        {
            PlayerPiece = pla;
        }
    }
}

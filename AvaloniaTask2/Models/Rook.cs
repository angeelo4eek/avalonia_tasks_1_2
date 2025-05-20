using System;

namespace AvaloniaTask2_3.Models
{
    public class Rook : ChessPiece
    {
        public Rook(PieceColor color, Position initialPosition)
            : base(color, initialPosition) { }

        protected override bool CanMoveTo(Position newPosition)
        {
            if (newPosition == CurrentPosition) return false;
            return newPosition.Row == CurrentPosition.Row || newPosition.Column == CurrentPosition.Column;
        }
    }
}
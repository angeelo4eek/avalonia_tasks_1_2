using System;

namespace AvaloniaTask2_3.Models
{
    public class Bishop : ChessPiece
    {
        public Bishop(PieceColor color, Position initialPosition)
            : base(color, initialPosition) { }

        protected override bool CanMoveTo(Position newPosition)
        {
            if (newPosition == CurrentPosition) return false;
            int rowDiff = Math.Abs(newPosition.Row - CurrentPosition.Row);
            int colDiff = Math.Abs(newPosition.Column - CurrentPosition.Column);
            return rowDiff == colDiff;
        }
    }
}
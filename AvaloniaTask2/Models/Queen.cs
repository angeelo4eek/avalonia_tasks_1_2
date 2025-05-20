using System;

namespace AvaloniaTask2_3.Models
{
    public class Queen : ChessPiece
    {
        public Queen(PieceColor color, Position initialPosition)
            : base(color, initialPosition) { }

        protected override bool CanMoveTo(Position newPosition)
        {
             if (newPosition == CurrentPosition) return false;
            bool isRookMove = newPosition.Row == CurrentPosition.Row || newPosition.Column == CurrentPosition.Column;
            bool isBishopMove = Math.Abs(newPosition.Row - CurrentPosition.Row) == Math.Abs(newPosition.Column - CurrentPosition.Column);
            return isRookMove || isBishopMove;
        }
    }
}
using System;

namespace AvaloniaTask2_3.Models
{
    public abstract class ChessPiece
    {
        public PieceColor Color { get; }
        public Position CurrentPosition { get; protected set; }

        protected ChessPiece(PieceColor color, Position initialPosition)
        {
            if (!initialPosition.IsValid())
            {
                throw new ArgumentOutOfRangeException(nameof(initialPosition), "Initial position is outside the standard 8x8 board.");
            }
            Color = color;
            CurrentPosition = initialPosition;
        }

        public bool MakeMove(Position newPosition)
        {
            if (newPosition.IsValid() && CanMoveTo(newPosition))
            {
                CurrentPosition = newPosition;
                return true;
            }
            return false;
        }

        protected abstract bool CanMoveTo(Position newPosition);

        public override string ToString()
        {
            return $"{Color} {GetType().Name} at {CurrentPosition}";
        }
    }
}
namespace AvaloniaTask2_3.Models
{
    public record struct Position(int Row, int Column)
    {
        public bool IsValid() => Row >= 0 && Row < 8 && Column >= 0 && Column < 8;

        public override string ToString()
        {
            if (!IsValid()) return "Invalid";
            char colChar = (char)('A' + Column);
            return $"{colChar}{Row + 1}";
        }

        public static bool TryParse(string? s, out Position position)
        {
            position = default;
            if (string.IsNullOrEmpty(s) || s.Length != 2)
                return false;

            char colChar = char.ToUpper(s[0]);
            char rowChar = s[1];

            if (colChar < 'A' || colChar > 'H' || rowChar < '1' || rowChar > '8')
                return false;

            int column = colChar - 'A';
            int row = rowChar - '1';
            position = new Position(row, column);
            return true;
        }
    }
}
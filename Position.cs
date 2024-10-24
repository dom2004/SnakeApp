namespace SnakeApp
{
    public class Position
    {
        public int _Row { get; }
        public int _Column { get; }

        public Position(int row, int column)
        {
            _Row = row;
            _Column = column;
        }

        public Position Translate(Direction direction)
        {
            return new Position(_Row + direction._rowOffset, _Column + direction._columnOffset);
        }

        protected bool Equals(Position other)
        {
            return _Row == other._Row && _Column == other._Column;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Position)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_Row, _Column);
        }

        public static bool operator ==(Position? left, Position? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Position? left, Position? right)
        {
            return !Equals(left, right);
        }
    }
}

namespace SnakeApp
{
    public class Direction
    {
        public readonly static Direction Left = new Direction(0, -1);
        public readonly static Direction Right = new Direction(0, 1);
        public readonly static Direction Up = new Direction(-1, 0);
        public readonly static Direction Down = new Direction(1, 0);

        public int _rowOffset { get; }
        public int _columnOffset { get; }

        private Direction(int rowOffset, int columnOffset)
        {
            _rowOffset = rowOffset;
            _columnOffset = columnOffset;
        }

        public Direction Opposite()
        {
            return new Direction(-_rowOffset, -_columnOffset);
        }

        protected bool Equals(Direction other)
        {
            return _rowOffset == other._rowOffset && _columnOffset == other._columnOffset;
        }

        public override bool Equals(object? obj)
        {
            if (obj is null) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != GetType()) return false;
            return Equals((Direction)obj);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_rowOffset, _columnOffset);
        }

        public static bool operator ==(Direction? left, Direction? right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Direction? left, Direction? right)
        {
            return !Equals(left, right);
        }
    }
}

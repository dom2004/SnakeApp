using System.Reflection;

namespace SnakeApp
{
    public class GameState
    {
        public int _Rows { get; }
        public int _Columns { get; }
        public Grid[,] _Grid { get; }
        public Direction Direction { get; private set; }
        public int _Score { get; private set; }
        public bool _GameOver { get; private set; }

        private readonly LinkedList<Position> _Positions = new LinkedList<Position>();
        private readonly Random _Random = new Random();

        public GameState(int rows, int columns)
        {
            _Rows = rows;
            _Columns = columns;
            _Grid = new Grid[rows, columns];
            Direction = Direction.Right;

            AddSnake();
            AddFood();
        }

        private void AddSnake()
        {
            int row = _Rows / 2;

            for (int column = 1; column <= 3; column++)
            {
                _Grid[row, column] = Grid.Snake;
                _Positions.AddFirst(new Position(row, column));
            }
        }

        private IEnumerable<Position> emptyPositions()
        {
            for (int row = 0; row < _Rows; row++)
            {
                for (int column = 0; column < _Columns; column++)
                {
                    if (_Grid[row, column] == Grid.Empty)
                    {
                        yield return new Position(row, column);
                    }
                }
            }
        }

        private void AddFood()
        {
            List<Position> empty = new List<Position>(emptyPositions());

            if (empty.Count == 0)
            {
                return; 
            }

            Position position = empty[_Random.Next(empty.Count)];
            _Grid[position._Row, position._Column] = Grid.Food;
        }

        public Position HeadPosition()
        {
            return _Positions.First.Value;
        }

        public Position BottomPosition()
        {
            return _Positions.Last.Value;
        }

        public IEnumerable<Position> SnakePositions()
        {
            return _Positions;
        }

        private void AddHead(Position position)
        {
            _Positions.AddFirst(position);
            _Grid[position._Row, position._Column] = Grid.Snake;
        }

        private void RemoveTail()
        {
            Position tail = _Positions.Last.Value;
            _Grid[tail._Row, tail._Column] = Grid.Empty;
            _Positions.RemoveLast();
        }

        public void ChangeDirection(Direction direction)
        {
            Direction = direction;
        }

        private bool GridBoundary(Position position)
        {
            return position._Row < 0 || position._Row >= _Rows || position._Column < 0 || position._Column >= _Columns;
        }

        private Grid HitDetection(Position headPosition)
        {
            if (GridBoundary(headPosition))
            {
                return Grid.Outside;
            }

            if (headPosition == BottomPosition())
            {
                return Grid.Empty;
            }

            return _Grid[headPosition._Row, headPosition._Column];
        }

        public void Move()
        {
            Position headPosition = HeadPosition().Translate(Direction);
            Grid hit = HitDetection(headPosition);

            if (hit == Grid.Outside || hit == Grid.Snake)
            {
                _GameOver = true;
            }
            else if (hit == Grid.Empty)
            {
                RemoveTail();
                AddHead(headPosition);
            }
            else if (hit == Grid.Food)
            {
                AddHead(headPosition);
                _Score++;
                AddFood();
            }
        }
    }
}

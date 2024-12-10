using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Serialization;

namespace SnakeApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Dictionary<Grid, ImageSource> GridToImage = new()
        {
            { Grid.Empty, Assets.Empty },
            { Grid.Snake, Assets.Body },
            { Grid.Food, Assets.Food }
        };

        private readonly Dictionary<Direction, int> directionToRotation = new()
        {
            { Direction.Up, 0 },
            { Direction.Right, 90 },
            { Direction.Down, 180 },
            { Direction.Left, 270 }
        };

        private readonly int _rows = 15, _columns = 15;
        private readonly Image[,] _images;
        private GameState gameState;
        private bool gameRunning;

        public MainWindow()
        {
            InitializeComponent();
            _images = GridInitialiser();
            gameState = new GameState(_rows, _columns);
        }


        private Image[,] GridInitialiser()
        {
            Image[,] images = new Image[_rows, _columns];
            GameGrid.Rows = _rows;
            GameGrid.Columns = _columns;

            for (int rows = 0; rows < _rows; rows++)
            {
                for (int columns = 0; columns < _columns; columns++)
                {
                    Image image = new Image
                    {
                        Source = Assets.Empty
                    };

                    images[rows, columns] = image;
                    GameGrid.Children.Add(image);
                }
            }

            return images;
        }

        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (gameState._GameOver)
            {
                return;
            }

            switch (e.Key)
            {
                case Key.A:
                    gameState.ChangeDirection(Direction.Left);
                    break;
                case Key.D:
                    gameState.ChangeDirection(Direction.Right);
                    break;
                case Key.W:
                    gameState.ChangeDirection(Direction.Up);
                    break;
                case Key.S:
                    gameState.ChangeDirection(Direction.Down);
                    break;
            }
        }

        private async Task RunGame()
        {
            Draw();
            await CountDown();
            Overlay.Visibility = Visibility.Hidden;
            await GameLoop();
            await GameOver();
            gameState = new GameState(_rows, _columns);
        }

        private async void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (Overlay.Visibility == Visibility.Visible)
            {
                e.Handled = true;
            }

            if (!gameRunning)
            {
                gameRunning = true;
                await RunGame();
                gameRunning = false;
            }
        }

        private void Draw()
        {
            DrawGrid();
            ScoreText.Text = $"SCORE {gameState._Score}";
        }

        private void DrawSnakeHead()
        {
            Position headPosition = gameState.HeadPosition();
            Image image = _images[headPosition._Row, headPosition._Column];
            image.Source = Assets.Head;

            int rotation = directionToRotation[gameState._direction];
            image.RenderTransform = new RotateTransform(rotation);
        }

        private void DrawGrid()
        {
            for (int row = 0; row < _rows; row++)
            {
                for (int column = 0; column < _columns; column++)
                {
                    Grid gridValue = gameState._Grid[row, column];
                    _images[row, column].Source = GridToImage[gridValue];
                }
            }
        }

        private async Task GameLoop()
        {
            while (!gameState._GameOver)
            {
                await Task.Delay(100);
                gameState.Move();
                Draw();
            }
        }

        private async Task CountDown()
        {
            for (int i = 3; i >= 1; i--)
            {
                OverlayText.Text = i.ToString();
                await Task.Delay(1000);
            }
        }

        private async Task GameOver()
        {
            await Task.Delay(1000);
            Overlay.Visibility = Visibility.Visible;
            OverlayText.Text = "PRESS ANY KEY TO START";
        }
    }
}
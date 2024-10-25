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

        private readonly int _rows = 15, _columns = 15;
        private readonly Image[,] _images;
        private GameState gameState;

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
            throw new NotImplementedException();
        }

        private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            DrawGrid();
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
    }
}
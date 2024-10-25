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
        private 

        private readonly int _rows = 15, _columns = 15;
        private readonly Image[,] _images;

        public MainWindow()
        {
            InitializeComponent();
            _images = GridInitialiser();
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
            throw new NotImplementedException();
        }
    }
}
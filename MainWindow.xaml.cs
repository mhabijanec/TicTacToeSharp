using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace TicTacToeSharp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Variables
        private CellValue[,] cellValueList;
        private bool player1Turn = true;
        private bool gameEnded;
        #endregion

        #region Constructor
        public MainWindow()
        {
            InitializeComponent();

            StartGame();
        }
        #endregion
        /// <summary>
        /// Starts game and sets values to defaults
        /// </summary>
        private void StartGame()
        {
            //create blank array of empty cells
            cellValueList = new CellValue[3,3];
            for (var i = 0; i < 3; i++)
                for (var j = 0; j < 3; j++)
                    cellValueList[i,j] = CellValue.Empty;
            //iterating over buttons inside the grid
            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.Azure;
            });

            gameEnded = false;
        }

        /// <summary>
        /// Handles cell (button) clicks
        /// </summary>
        /// <param name="sender">The selected cell</param>
        /// <param name="e">Events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (gameEnded)
            {
                StartGame();
                return;
            }

            //Find cell's position in the array
            var button = (Button)sender;
            var column = Grid.GetColumn(button);
            var row = Grid.GetRow(button);

            //skip execution if cell is empty
            if (cellValueList[column,row] != CellValue.Empty) return;
            //Set cell values depending on active player
            if(player1Turn) {
                cellValueList[column,row] =CellValue.Cross;
                button.Content ="X";
                button.Foreground = Brushes.Blue;
            }
            else
            {
                cellValueList[column,row] = CellValue.Circle;
                button.Content = "O";
                button.Foreground = Brushes.Red;
            }
            //switch player turn
            player1Turn ^= true;

            CheckForWinner();
        }
        /// <summary>
        /// Checks for three consecutive values
        /// </summary>
        private void CheckForWinner()
        {
            
        }
    }
}

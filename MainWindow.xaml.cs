using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace tic_tac_toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Private Members
        /// <summary>
        /// It represents the Cell State.
        /// Free represents Cell has not clicked.
        /// Nought represents Cell value is a O.
        /// Cross represents Cell value is an X. 
        /// </summary>
        private enum MarkType { Free, Nought, Cross }

        /// <summary>
        /// Values of cell in the active game.
        /// </summary>
        private MarkType[,] results;//private MarkType[] results;

        /// <summary>
        /// True represents Player 1's turn.
        /// False represents Player 2's turn.
        /// </summary>
        private bool playerTurn;

        /// <summary>
        /// True represents Game has ended.
        /// False represents Game has not ended yet.
        /// </summary>
        //private bool isGameEnded;
        #endregion

        #region Constructor
        /// <summary>
        /// Default Constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            NewGame();
        }

        #endregion

        /// <summary>
        /// Starts a new game and reset all value of cells
        /// </summary>
        private void NewGame()
        {
            //Creating and Initializing the results array with Free MarkType
            results = new MarkType[3,3];
            for(int i=0; i < results.GetLength(0); i++)
            {
                for (int j = 0; j < results.GetLength(1); j++)
                {
                    results[i,j] = MarkType.Free;
                }
            }

            playerTurn = true;

            Container.Children.Cast<Button>().ToList().ForEach(button =>
            {
                button.Content = string.Empty;
                button.Background = Brushes.White;
                button.Foreground = Brushes.Blue;
            }
            );

            //isGameEnded = false;
        }

        /// <summary>
        /// Handles a button's click event
        /// </summary>
        /// <param name="sender">The button that was clicked</param>
        /// <param name="e">The events of the click</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // If a button click event occurs after game ends then a new game is started
            //if (isGameEnded)
            //{
            //    NewGame();
            //    return;
            //}

            // Casting sender to button
            var button = (Button)sender;

            // Finding index of buttons on grid for results array
            var row = Grid.GetRow(button);
            var column = Grid.GetColumn(button);

            // If the value of button is set alreaddy then do nothing
            if (results[row,column] != MarkType.Free)
            { return; }

            // Setting the value of cell according to player's turn
            results[row,column] = playerTurn ? MarkType.Cross : MarkType.Nought;

            // Seting the display content of cell according to player's turn
            if (playerTurn)
            {
                button.Content = "X";
                button.Foreground = Brushes.Blue;
            }
            else
            {
                button.Content = "O";
                button.Foreground = Brushes.Red;
            }
            
            // Toggle player's turn
            playerTurn ^= true;
            
            // Checking for a winner
            CheckGameWinner();
        }

        /// <summary>
        /// Checking the winner of game if exists
        /// </summary>
        private void CheckGameWinner()
        {
            #region Horizontal Wins
            // Checking for horizontal wins

            // Row0
            if (results[0,0] != MarkType.Free && (results[0,0] & results[0,1] & results[0,2]) == results[0,0])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_0.Background = Button0_1.Background = Button0_2.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }
            
            // Row1
            if (results[1,0] != MarkType.Free && (results[1,0] & results[1,1] & results[1,2]) == results[1,0])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button1_0.Background = Button1_1.Background = Button1_2.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }


            // Row2
            if (results[2,0] != MarkType.Free && (results[2,0] & results[2,1] & results[2,2]) == results[2,0])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button2_0.Background = Button2_1.Background = Button2_2.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }

            #endregion

            #region Vertical Wins
            // Checking for vertical wins

            // Col0
            if (results[0,0] != MarkType.Free && (results[0,0] & results[1,0] & results[2,0]) == results[0,0])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_0.Background = Button1_0.Background = Button2_0.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }
            
            // Col1
            if (results[0,1] != MarkType.Free && (results[0,1] & results[1,1] & results[2,1]) == results[0,1])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_1.Background = Button1_1.Background = Button2_1.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }

            // Col2
            if (results[0,2] != MarkType.Free && (results[0,2] & results[1,2] & results[2,2]) == results[0,2])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_2.Background = Button1_2.Background = Button2_2.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }
            #endregion

            #region Diagonal Wins
            //Checking anti-diagonal wins
            if (results[0,0] != MarkType.Free && (results[0,0] & results[1,1] & results[2,2]) == results[0,0])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_0.Background = Button1_1.Background = Button2_2.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }

            //Checking diagonal wins
            if (results[0,2] != MarkType.Free && (results[0,2] & results[1,1] & results[2,0]) == results[0,2])
            {
                //isGameEnded = true;

                // Highliting winning cells
                Button0_2.Background = Button1_1.Background = Button2_0.Background = Brushes.Green;

                // Displaying the result of game
                int pnum = playerTurn ? 2 : 1;
                MessageBox.Show("Player " + pnum + " wins");
                NewGame();
                return;
            }
            #endregion

            #region No Wins
            // Check if there is no winner
            bool checkEmptyCell = false;
            foreach (var r in results)
            {
                if (r == MarkType.Free)
                {
                    checkEmptyCell = true;
                    break;
                }
            }
            if (!checkEmptyCell)
            {
                //isGameEnded = true;

                // Changing the color of cells to orange
                Container.Children.Cast<Button>().ToList().ForEach(button =>
                {
                    button.Background = Brushes.Orange;
                } );

                // Displaying the result of game
                MessageBox.Show("None of the players wins. Its a Tie !!!");
                NewGame();
                return;
            }
            #endregion
        }
    }
}

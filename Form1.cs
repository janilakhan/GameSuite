using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConsole
{        
    /// <summary>
    /// A game suite implemented as a WinForms application
    /// This games suite holds three games: Tetris, Minesweeper, Snake
    /// </summary>
    public partial class GameSuite : Form
    {
        /// <summary>
        /*
        GameSuite::GameSuite() 

        NAME

                GameSuite::GameSuite - intializes the form and its
                                       components

        SYNOPSIS

                void GameSuite::GameSuite();


        DESCRIPTION

                This function create the game suite form and sets its 
                elements

        AUTHOR

                Janila Khan

        DATE

                10:00am 2/23/2018

        */
        /// </summary>
        public GameSuite()
        {
            InitializeComponent();
        }

        /// <summary>
        /*
        GameSuite::GameSuite_Load() 

        NAME

                GameSuite::GameSuite_Load - Shows a welcome message before the WinForms
                                            application loads

        SYNOPSIS

                void GameSuite::GameSuite_Load(object sender, EventArgs e);
                    sender      --> the trading object to be opened.(change)
                    e           --> the amount of capital to apply.(change)

        DESCRIPTION

                This function will print out a welcome message before the WinForms 
                applications is loaded. 

        AUTHOR

                Janila Khan

        DATE

                9:30pm 2/23/2018

        */
        /// </summary>
        private void GameSuite_Load(object sender, EventArgs e)
        {
            // Message that will be seen as the Game Suite is loading
            MessageBox.Show("Welcome to the GameSuite! Choose a game of your choice to play.");
        }

        /// <summary>
        /*
        GameSuite::mineBox_Click() 

        NAME

                GameSuite::mineBox_Click - Holds the action of what happens after
                                           the minesweeper picture box is clicked.

        SYNOPSIS

                void GameSuite::mineBox_Click(object sender, EventArgs e);
                    sender      --> the trading object to be opened.(change)
                    e           --> the amount of capital to apply.(change)

        DESCRIPTION

                This function will perform a set of actions after the minesweeper
                picture box is clicked. It will first ask the user if they are sure
                they would like to play the minesweeper game through a dialog box.
                If the user clicks 'Yes', the game suite will open a new WinsForm 
                that holds the minsweeper game. If the user clicks 'No', the user
                recieves a message to choose a different game. 

        AUTHOR

                Janila Khan

        DATE

                6:45pm 2/23/2018

        */
        /// </summary>
        private void mineBox_Click(object sender, EventArgs e)
        {
            // Prints out a dialog box asking the user if they are sure they would
            // like to play a game of minesweeper
            DialogResult mineAns = MessageBox.Show("Do you want to start a game of Minesweeper?", 
                                                   "Start Minesweeper", MessageBoxButtons.YesNo);
            if (mineAns == DialogResult.Yes)
            {
                // If 'Yes' create a minesweeper form object and open the form
                MineForm mineGame = new MineForm();
                mineGame.ShowDialog();

            }
            else if (mineAns == DialogResult.No)
            {
                // If 'No' prints a message box asking the user to chose another game
                MessageBox.Show("You chose to play a different game.");
            }
        }

        /// <summary>
        /*
        GameSuite::tetBox_Click() 

        NAME

                GameSuite::tetBox_Click - Holds the action of what happens after the
                                          tetris picture box is clicked.

        SYNOPSIS

                void GameSuite::tetBox_Click(object sender, EventArgs e);
                    sender      --> the trading object to be opened.(change)
                    e           --> the amount of capital to apply.(change)

        DESCRIPTION

                This function will perform a set of actions after the tetris picture box
                is clicked. It will first ask the user if they are sure they would like 
                to play the tetris game through a dialog box. If the user clicks 'Yes',
                the game suite will open a new WinsForm that holds the tetris game. If
                the user clicks 'No', the user recieves a message to choose a different game. 

        AUTHOR

                Janila Khan

        DATE

                4:15pm 2/23/2018

        */
        /// </summary>
        private void tetBox_Click(object sender, EventArgs e)
        {
            // Prints out a dialog box asking the user if they are sure they would
            // like to play a game of tetris
            DialogResult tetAns = MessageBox.Show("Do you want to start a game of Tetris?", 
                                                  "Start Tetris", MessageBoxButtons.YesNo);
            if (tetAns == DialogResult.Yes)
            {
                // If 'Yes' create a tetris form object and open the form
                TetrisForm tetrisGame = new TetrisForm();
                tetrisGame.ShowDialog();
            }
            else if (tetAns == DialogResult.No)
            {
                // If 'No' prints a message box asking the user to chose another game
                MessageBox.Show("You chose to play a different game.");
            }
        }

        /// <summary>
        /*
        GameSuite::snakeBox_Click() 

        NAME

                GameSuite::snakeBox_Click - Holds the action of what happens after
                                            the snake picture box is clicked.

        SYNOPSIS

                void GameSuite::snakeBox_Click(object sender, EventArgs e);
                    sender      --> the trading object to be opened.(change)
                    e           --> the amount of capital to apply.(change)

        DESCRIPTION

                This function will perform a set of actions after the Snake picture box
                is clicked. It will first ask the user if they are sure they would like
                to play the Snake game through a dialog box. If the user clicks 'Yes', 
                the game suite will open a new WinsForm that holds the Snake game. If the
                user clicks 'No', the user recieves a message to choose a different game. 

        AUTHOR

                Janila Khan

        DATE

                12:00pm 4/9/2018

        */
        /// </summary>
        private void snakeBox_Click(object sender, EventArgs e)
        {
            // Prints out a dialog box asking the user if they are sure they would
            // like to play a game of snake
            DialogResult snakeAns = MessageBox.Show("Do you want to start a game of Snake?",
                                                   "Start Snake", MessageBoxButtons.YesNo);
            if (snakeAns == DialogResult.Yes)
            {
                // If 'Yes' create a snake form object and open the form
                SnakeForm snakeGame = new SnakeForm();
                snakeGame.ShowDialog();
            }
            else if (snakeAns == DialogResult.No)
            {
                // If 'No' prints a message box asking the user to chose another game
                MessageBox.Show("You chose to play a different game.");
            }
        }
    }
}

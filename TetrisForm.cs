using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using WMPLib;
using System.Media;
using System.IO;

namespace GameConsole
{
    /// <summary>
    /// This class controls the elements of the tetris form
    /// </summary>
    public partial class TetrisForm : Form
    {

        /// <summary>
        /*
        TetrisForm::TetrisForm() 

        NAME

                TetrisForm::TetrisForm - intializes the form and its
                                           components

        SYNOPSIS

                void TetrisForm::TetrisForm();


        DESCRIPTION

                This function create the tetris form and the elements 
                within the form. This function also starts the timer.

        AUTHOR

                Janila Khan

        DATE

                12:00pm 3/23/2018

        */
        /// </summary>
        public TetrisForm()
        {
            InitializeComponent();

            // Intialize the board
            t_board = new TetrisBoard();

            // Background music
            try
            {
                player = new SoundPlayer(GameConsole.Properties.Resources.tetrisTheme);
                player.PlayLooping();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Set the score, rows to zero
            t_playerScoreLabel.Text = t_board.m_score.ToString();
            t_playerRowsLabel.Text = t_board.m_rowsCleared.ToString();

            // Set the level to one
            t_playerLevelLabel.Text = t_board.m_level.ToString();
            
            // Create a timer and set a interval.
            m_time = new System.Timers.Timer();
            m_time.Interval = 400;

            // Hook up the Elapsed event for the timer. 
            m_time.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            m_time.AutoReset = true;

            // Start the timer
            m_time.Enabled = true;

            // Paint lines for the bucket
            tetrisBoard.Paint += new PaintEventHandler(tetrisBoard_Bucket);

            // The controls for the board and the game
            buttonsTextBox.Text += "\r\n";
            buttonsTextBox.Text += "<Down>: Move Block Striaght Down \r\n";
            buttonsTextBox.Text += "<Left>: Move Block To The Left \r\n";
            buttonsTextBox.Text += "<Right>: Move Block To The Right \r\n";
            buttonsTextBox.Text += "<A>: Rotate To the Left \r\n";
            buttonsTextBox.Text += "<D>: Rotate to the Right \r\n";
            buttonsTextBox.Text += "\r\n";
        }

        /// <summary>
        /*
        TetrisForm::TetrisForm_Load() 

        NAME

                TetrisForm::TetrisForm_Load - Prints a message to the user

        SYNOPSIS

                void TetrisForm::TetrisForm_Load(object sender, EventArgs e);

        DESCRIPTION

                This function will print out a message telling the user the to get
                ready to play tetris.

        AUTHOR

                Janila Khan

        DATE

                4:00pm 3/1/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void TetrisForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Get Ready to Play a Game of Tetris!");
        }

        /// <summary>
        /*
        TetrisForm::TetrisForm_KeyDown() 

        NAME

                TetrisForm::TetrisForm_KeyDown - Moves the block in a certain direction

        SYNOPSIS

                void TetrisForm::TetrisForm_KeyDown(object sender, KeyEventArgs k);

        DESCRIPTION

                This function will move the block piece a certain direction
                according to what button is pressed.

        AUTHOR

                Janila Khan

        DATE

                7:00pm 3/18/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void TetrisForm_KeyDown(object sender, KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                // Move the Block down faster
                case (Keys.Down):
                    t_board.downward();
                    tetrisBoard.Invalidate();
                    break;
                
                // Move the block one space to the right
                case (Keys.Right):
                    t_board.m_currentBlock.moveToRight();
                    tetrisBoard.Invalidate();
                    break;

                // Move the block one space to the left
                case (Keys.Left):
                    t_board.m_currentBlock.moveToLeft();
                    tetrisBoard.Invalidate();
                    break;

                // Rotate the block counter clockwise
                case (Keys.A):
                    t_board.m_currentBlock.rotateLeft();
                    tetrisBoard.Invalidate();
                    break;

                // Rotate the block clockwise
                case (Keys.D):
                    t_board.m_currentBlock.rotateRight();
                    tetrisBoard.Invalidate();
                    break;
            }
        }

        /// <summary>
        /*
        TetrisForm::tetrisBoard_Bucket() 

        NAME

                TetrisForm::tetrisBoard_Bucket - Draws a bucket around the tetris board 
                                                 panel

        SYNOPSIS

                void TetrisForm::tetrisBoard_Bucket(object sender, PaintEventArgs p);

        DESCRIPTION

                This function will draw a bucket around the tetrisBoard panel. This is
                done by creating a pen object and setting it to a certain color. Then,
                I two point objects and set values to those objects. Then I draw the
                line that corresponds with those points. This draws one line to the
                screen. I do the same thing another two times to create the bucket.

        AUTHOR

                Janila Khan

        DATE

                11:00am 3/19/2018

        */
        /// </summary>
        /// <param name="sender">A Reference to the tetrisBoard panel</param>
        /// <param name="p">Specifies the graphics to use to paint the 
        /// tetrisBoard panel</param>
        private void tetrisBoard_Bucket(object sender, PaintEventArgs p)
        {            
            // Draw the board to the screen
            t_board.drawBoard(p);
            
            // Create pen.
            Pen pen = new Pen(Color.Blue, 5);

            // Points for the first line
            Point point1 = new Point(0, 0);
            Point point2 = new Point(0, 421);

            //Draw first line to the screen.
            p.Graphics.DrawLine(pen, point1, point2);

            // Points for the second line
            Point point3 = new Point(213, 0);
            Point point4 = new Point(213, 421);

            //Draw second line to the screen.
            p.Graphics.DrawLine(pen, point3, point4);

            // Points for the third line
            Point point5 = new Point(0, 421);
            Point point6 = new Point(213, 421);

            //Draw third line to the screen.
            p.Graphics.DrawLine(pen, point5, point6);
        }

        /// <summary>
        /*
        TetrisForm::nextBlock_Bucket() 

        NAME

                TetrisForm::nextBlock_Bucket - Draws a bucket around the next block 
                                               panel

        SYNOPSIS

                void TetrisForm::nextBlock_Bucket(object sender, PaintEventArgs p);

        DESCRIPTION

                This function will draw a bucket around the nextblock panel. This is
                done by creating a pen object and setting it to a certain color. Then,
                I create a rectangle with the width and height being the size of the
                panel. 

        AUTHOR

                Janila Khan

        DATE

                12:00pm 3/19/2018

        */
        /// </summary>
        /// <param name="sender">A Reference to the next block panel</param>
        /// <param name="p">Specifies the graphics to use to paint the next block 
        /// panel</param>
        private void nextBlock_Bucket(object sender, PaintEventArgs p)
        {
            // Draw the next block
            t_board.drawNextBlock(p);
            
            // Create pen.
            Pen pen = new Pen(Color.RoyalBlue, 5);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;
            int width = 154;
            int height = 121;

            // Draw rectangle to screen.
            p.Graphics.DrawRectangle(pen, x, y, width, height);
        }

        /// <summary>
        /*
        TetrisForm::updateOthers() 

        NAME

                TetrisForm::updateOthers - Updates the score, rows cleared, and the
                                           level that the user is on.

        SYNOPSIS

                void TetrisForm::updateOthers();

        DESCRIPTION

                This function will update the score, rows, and level and print out
                to screen in the textbox that corresponds with those values.

        AUTHOR

                Janila Khan

        DATE

                12:30pm 3/19/2018

        */
        /// </summary>
        private void updateLabels()
        {
            //Fixed window handle issue.
            if (!this.IsHandleCreated)
            {
                this.CreateControl();
            }

            // update the rows that are clear, the score and the 
            // level the player is on
            this.t_playerScoreLabel.Invoke((MethodInvoker)delegate ()
            {
                this.t_playerScoreLabel.Text = t_board.m_score.ToString();
            });

            this.t_playerRowsLabel.Invoke((MethodInvoker)delegate ()
            {
                this.t_playerRowsLabel.Text = t_board.m_rowsCleared.ToString();
            });

            this.t_playerLevelLabel.Invoke((MethodInvoker)delegate ()
            {
                this.t_playerLevelLabel.Text = t_board.m_level.ToString();
            });
        }

        /// <summary>
        /*
        TetrisForm::OnTimedEvent() 

        NAME

                TetrisForm::OnTimedEvent - Keeps the game going, moves the block down
                                           creates a new block

        SYNOPSIS

                void TetrisForm::OnTimedEvent(object sender, ElaspedEventArgs e);

        DESCRIPTION

                This function will move the block downwards, add a new block until
                the game is over.

        AUTHOR

                Janila Khan

        DATE

                2:00pm 3/23/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">The time the event was triggered</param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        { 
            // Move the block downward
            t_board.downward();

            // When the game is over stop the time
            if (t_board.gameOver())
            {
                // stop the timer
                m_time.Stop();

                // stop the music
                player.Stop();

                // ask the user if they would like to save their score
                endGame();
            }

            // update the rows cleared, the level, and score
            updateLabels();
            
            // Invalidate the board and the next block so changes are able to
            // be seen. The board is able to account for movements and the
            // next block is able to change the block.
            tetrisBoard.Invalidate();
            nextBlock.Invalidate();
        }
       
        /// <summary>
        /*
        TetrisForm::endGame() 

        NAME

                TetrisForm::endGame - Prints the user's stats and ask the user if they
                                      would like to save their score to the scoreboard.

        SYNOPSIS

                void TetrisForm::endGame();

        DESCRIPTION

                This function will tell the user their stats during the game and
                ask the user if they would like to save their score. First, the user
                is told their stats through a message box. Then the user is asked if
                they would like to save their score to the scoreboard. If 'Yes' the
                TetrisScoreBoard form is shown. Else the user is told that their score
                will not be saved and the form closes.

        AUTHOR

                Janila Khan

        DATE

                6:00pm 3/23/2018

        */
        /// </summary>
        public void endGame()
        {
            // Print the message "Game Over" to the screen
            MessageBox.Show("Game Over!");

            // Holds the user's start during their game
            string gameScores = string.Format("You were on level {0}, and cleared {1} rows, and earned {2} points",
                                                t_board.m_level.ToString(),
                                                t_board.m_rowsCleared.ToString(),
                                                t_board.m_score.ToString());

            // Print the user's stats to the screen
            MessageBox.Show(gameScores);

            // Ask the user if they would like to save their score to the scoreboard
            DialogResult scoreAns = MessageBox.Show("Do you want to add your score to the Tetris Scoreboard?",
                                                    "Add Score", MessageBoxButtons.YesNo);
            if (scoreAns == DialogResult.Yes)
            {
                // If 'Yes', save the score to a public static int so the TetrisScoreBoard
                // is able to recieve the score.
                m_PlayerScore = t_board.m_score;

                // Create a new scoreboard object and open the scoreboard window
                TetrisScoreBoard t_score = new TetrisScoreBoard();
                t_score.ShowDialog();

                // Close the form
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Close();
                });
            }
            else if (scoreAns == DialogResult.No)
            {
                // If 'No', tell the user that their score will not be save into the scoreboard
                // and close the form
                MessageBox.Show("Ok. Your score will not be added to the scoreboard. Goodbye!");

                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Hide();
                });

            }
        }

        #region variables

        SoundPlayer player;
        //private WindowsMediaPlayer player;

        private System.Timers.Timer m_time;

        private TetrisBoard t_board;

        public static int m_PlayerScore;

        #endregion
    }
}
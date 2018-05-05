using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using WMPLib;

namespace GameConsole
{
    /// <summary>
    /// This class controls the elements of the MineForm and the game
    /// logic for the minesweeper game. 
    /// </summary>
    public partial class MineForm : Form
    {

        /// <summary>
        /*
        MineForm::MineForm() 

        NAME

                MineForm::MineForm - Constructor.

        SYNOPSIS

                void MineForm::MineForm();

        DESCRIPTION

                Constructor

        AUTHOR

                Janila Khan

        DATE

                10:00am 4/2/2018

        */
        /// </summary>
        public MineForm()
        {
            InitializeComponent();

            // Background music
            try
            {
                player = new SoundPlayer(GameConsole.Properties.Resources.minesweeperBG);
                player.PlayLooping();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Set the timer and mines
            m_playerTimeLabel.Text = m_seconds.ToString();
            m_flagLabel.Text = flags.ToString();

            // Create a timer and set a interval.
            m_timer = new System.Timers.Timer();
            m_timer.Interval = 1000;

            // Hook up the Elapsed event for the timer. 
            m_timer.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events 
            m_timer.AutoReset = true;

            // Start the timer
            m_timer.Enabled = true;

            // Create the buttons for the game
            createMineButtons();

            // Distribute the mines within the board and 
            distributeMines();

            // set numbers adjacent to the mines
            setNumbers();
        }

        /// <summary>
        /*
        MineForm::MineForm_Load() 

        NAME

                MineForm::MineForm_Load - Prints a message to the user

        SYNOPSIS

                void MineForm::MineForm_Load(object sender, EventArgs e);

        DESCRIPTION

                This function will print out a message telling the user the to get
                ready to play minesweeper.

        AUTHOR

                Janila Khan

        DATE

                11:00pm 3/27/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void MineForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Get Ready to Play a Game of Minesweeper!");

            // Display Instructions
            mineInstructions();
        }

        /// <summary>
        /*
        MineForm::mineBoardPanel_Bucket() 

        NAME

                MineForm::mineBoardPanel_Bucket - Draws a bucket around the next block 
                                                  panel

        SYNOPSIS

                void MineForm::mineBoardPanel_Bucket(object sender, PaintEventArgs p);

        DESCRIPTION

                This function will draw a bucket around the mineBoard panel. This is
                done by creating a pen object and setting it to a certain color. Then,
                I set the x and y values of the rectangle. After that we set the width 
                and the height of the rectangle. Finally we draw the rectangle to the
                screen.

        AUTHOR

                Janila Khan

        DATE

                2:40pm 4/2/2018

        */
        /// </summary>
        /// <param name="sender">A Reference to the mineBoard panel</param>
        /// <param name="p">Specifies the graphics to use to paint the 
        /// mineBoard panel</param>
        private void mineBoardPanel_Bucket(object sender, PaintEventArgs p)
        {
            // Create pen.
            Pen pen = new Pen(Color.DarkGreen, 5);

            // Create location and size of rectangle.
            int x = 0;
            int y = 0;

            // This is the size of the panel
            int width = 223;
            int height = 213;

            // Draw rectangle to screen.
            p.Graphics.DrawRectangle(pen, x, y, width, height);
        }

        /// <summary>
        /*
        MineForm::MineForm_Close() 

        NAME

                MineForm::mineInstructions - Display the instructions in a message box. 

        SYNOPSIS

                void MineForm::mineInstructions();

        DESCRIPTION

                This function will display a message box that holds the instructions of the
                minesweeper game.

        AUTHOR

                Janila Khan

        DATE

                9:20pm 4/3/2018

        */
        /// </summary>
        private void mineInstructions()
        {
            string content = "";

            // The content will hold the instuctions of the minesweeper game
            content += "Objective: \r\n" +
                       "Locate all the mines as quickly as possible. \r\n" +
                       "Specifically, the game of minesweeper is won at the point when \r\n" +
                       "all squares that are not mines are clicked open. \r\n \r\n";

            content += "How to Play: \r\n" +
                       "To open a square by clicking on it. When a square is successfully \r\n" +
                       "opened without containing a mine, it shows a number.The number \r\n" +
                       "indicates the number of mines that exist in the eight squares \r\n" +
                       "touching the square the number was in. \r\n\r\n";

            content += "When a square is right-clicked, a flag appears over the square. \r\n" +
                       "Right-clicking is intended for marking a square as a mine. \r\n" +
                       "Right-click again to remove the flag.";

            // Display the instructions in a message box
            MessageBox.Show(content);
        }

        /// <summary>
        /*
        MineForm::createMineButtons() 

        NAME

                MineForm::createMineButtons - Create the mine buttons needed for the
                                              game.

        SYNOPSIS

                void MineForm::createMineButtons();

        DESCRIPTION

                This function will create the mine buttons for the game. The 
                board is a 9x9, so there will be 81 buttons.

        AUTHOR

                Janila Khan

        DATE

                5:00pm 4/2/2018

        */
        /// </summary>
        private void createMineButtons()
        {
            int x = 0;
            int y = 0;

            for (int i = 1; i <= m_boardWidth; i++)
            {
                for (int j = 1; j <= m_boardHeight; j++)
                {
                    // Intialize a button
                    m_mineButton[i, j] = new Button();

                    // Location
                    x = i * m_buttonWidth;
                    y = j * m_buttonHeight;

                    // Intialize the bounds of the button with the location and the size
                    m_mineButton[i, j].SetBounds(x, y, m_buttonWidth, m_buttonHeight);

                    // Set the actions for the button
                    m_mineButton[i, j].Click += new EventHandler(ButtonOnClick);
                    m_mineButton[i, j].MouseUp += new MouseEventHandler(ButtonRightClick);

                    // Set the values to zero
                    m_mineButtonValue[i, j] = 0;
                    m_saveValue[i, j] = 0;

                    m_mineButton[i, j].TabStop = false;

                    // Add the button to the panel
                    mineBoardPanel.Controls.Add(m_mineButton[i, j]);
                }
            }
        }

        /// <summary>
        /*
        MineForm::distributeMines() 

        NAME

                MineForm::distributionMines - Distribute 10 mines in random location
                                              throughout the board

        SYNOPSIS

                void MineForm::distributeMines();

        DESCRIPTION

                This function will distribute 10 mines in random location throughout
                the board. 
                

        AUTHOR

                Janila Khan

        DATE

                8:00pm 4/5/2018

        */
        /// </summary>
        private void distributeMines()
        {
            int randNum = 0;

            Random rand = new Random();

            //List to hold the x and y locations that are possible
            List<int> coord_x = new List<int>();
            List<int> coord_y = new List<int>();

            while (mines > 0)
            {
                coord_x.Clear();
                coord_y.Clear();

                // Go through the board
                for (int i = 1; i <= m_boardWidth; i++)
                {
                    for (int j = 1; j <= m_boardHeight; j++)
                    {
                        // check if the point has a mine
                        if (m_mineButtonValue[i, j] != -1)
                        {
                            // add point to the possible location lists
                            coord_x.Add(i);
                            coord_y.Add(j);
                        }
                    }
                }

                // Get the a random value
                randNum = rand.Next(0, coord_x.Count);

                // Set the mine in the random place
                m_mineButtonValue[coord_x[randNum], coord_y[randNum]] = -1;
                m_saveValue[coord_x[randNum], coord_y[randNum]] = -1;

                // Decrease the number of mines
                mines--;
            }
        }

        /// <summary>
        /*
        MineForm::setNumbers() 

        NAME

                MineForm::setNumbers - Set the value of each point

        SYNOPSIS

                void MineForm::setNumbers();

        DESCRIPTION

                This function will set the numbers of each point on
                the board.

        AUTHOR

                Janila Khan

        DATE

                10:15pm 4/4/2018

        */
        /// </summary>
        private void setNumbers()
        {
            // Go through the board
            for (int i = 1; i <= m_boardWidth; i++)
            {
                for (int j = 1; j <= m_boardHeight; j++)
                {
                    // Check if the point has a mine
                    if (m_mineButtonValue[i, j] != -1)
                    {
                        // Set the value by the adjacent points
                        m_mineButtonValue[i, j] = adjacentMines(i, j);
                        m_saveValue[i, j] = adjacentMines(i, j);
                    }
                }
            }
        }

        /// <summary>
        /*
        MineForm::ButtonRightClick() 

        NAME

                MineForm::ButtonRightClick - Perform the actions when the right mouse
                                             button is clicked.

        SYNOPSIS

                void MineForm::ButtonRightClick(object sender, MouseEventArgs m);

        DESCRIPTION

                This function will perform the action when the right mouse button is
                clicked. First, it will check to see if the right mouse button is
                clicked. If it is we can continue, otherwise we don't. Then, it checks
                to see if there is already a flag. If not, we add a flag at that button's
                location. If there is a flag we take off the flag at that button's location.

        AUTHOR

                Janila Khan

        DATE

                12:30pm 4/4/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised 
        /// the event</param>
        /// <param name="m">The data of the mose event</param>
        private void ButtonRightClick(object sender, MouseEventArgs m)
        {
            // Check to see the right button was clicked
            if (m.Button == MouseButtons.Right)
            {
                // Get the coordinates of the button
                coordinates = ((Button)sender).Location;

                // Get the x and y location of the button
                int x = coordinates.X / m_buttonWidth;
                int y = coordinates.Y / m_buttonHeight;

                // Check to see if the button already has a flag or if there
                // are no more flags the user can add
                if (m_mineButtonValue[x, y] != flagValue && flags > 0)
                {
                    // Set background image of the button as the flag
                    m_mineButton[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.flag;

                    // Set the value to the flag value  
                    m_mineButtonValue[x, y] = flagValue;

                    // Decrease the amounts of flags by 1
                    flags--;

                    // Check to see if the user has won
                    checkFlagWin();
                }
                else
                {
                    // Check to see there is already a flag
                    if (m_mineButtonValue[x, y] == flagValue)
                    {
                        // set the value to its previous value
                        m_mineButtonValue[x, y] = m_saveValue[x, y];

                        // Take off the flag from the background image
                        m_mineButton[x, y].BackgroundImageLayout = ImageLayout.Stretch;
                        m_mineButton[x, y].BackgroundImage = null;

                        // Increase the amounts of flags by 1
                        flags++;
                    }
                }
            }

            // Print out the number of remaining flags in the textbox
            m_flagLabel.Text = flags.ToString();
        }

        /// <summary>
        /*
        MineForm::ButtonOnClick() 

        NAME

                MineForm::ButtonOnClick - Perform the action of the button being clicked.

        SYNOPSIS

                void MineForm::ButtonOnClick(object sender, EventArgs e);

        DESCRIPTION

                This function will perform actions when a button is clicked on the board.
                First, I need to get the coordinates of the button. Then, I check to see 
                if that button has a flag. If it does, the action can not be perform. If
                the button does not a flag, then it performs the actions of a button being 
                clicked.

        AUTHOR

                Janila Khan

        DATE

                3:15pm 4/4/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised 
        /// the event</param>
        /// <param name="e">Contains the event data</param>
        private void ButtonOnClick(object sender, EventArgs e)
        {
            // The coordinates of the button that was just clicked
            coordinates = ((Button)sender).Location;

            // The x and y location of the button
            int x = coordinates.X / m_buttonWidth;
            int y = coordinates.Y / m_buttonHeight;

            // Check to see if that button has a flag
            // If not, continue
            if (m_mineButtonValue[x, y] != flagValue)
            {
                // Click the button
                ((Button)sender).Enabled = false;
                ((Button)sender).Text = "";

                // Set the layout of the background image
                ((Button)sender).BackgroundImageLayout = ImageLayout.Stretch;

                if (m_mineButtonValue[x, y] != -1 && !m_gameOver)
                {
                    // Check to see if the user has won the game
                    checkWin();
                }

                // Print the background image to the screen
                setButtonImages(x, y);
            }
        }

        /// <summary>
        /*
        MineForm::adjacentMines() 

        NAME

                MineForm::adjacentMines - Return the number of mines that are 
                                          adjacent to a point.

        SYNOPSIS

                int MineForm::adjacentMines(int x, int y);

        DESCRIPTION

                This function will determine the number of mines that are
                adjacent to a point. Return the number of mines that are 
                adjacent.

        AUTHOR

                Janila Khan

        DATE

                5:00pm 4/6/2018

        */
        /// </summary>
        /// <param name="x">The location of the x value</param>
        /// <param name="y">The location of the y value</param>
        /// <returns>Return the number of mines that are adjacent</returns>
        private int adjacentMines(int x, int y)
        {
            int number = 0;

            // Go throught the adjacent sides of a point
            for (int i = 0; i < 8; i++)
            {
                // the x and y location of the adjacent point
                int a_x = x + m_adjacentX[i];
                int a_y = y + m_adjacentY[i];

                // If the point is on the board and the adjacent point has a mine 
                // increase the number of mines
                if (isPointOnBoard(a_x, a_y) && m_mineButtonValue[a_x, a_y] == -1)
                {
                    number++;
                }
            }

            // Return the number of adjacent mines of a point
            return number;
        }

        /// <summary>
        /*
        MineForm::isPointOnBoard() 

        NAME

                MineForm::isPointOnBoard - Check to see if the point is valid.

        SYNOPSIS

                bool MineForm::isPointOnBoard(int x, int y);

        DESCRIPTION

                This function will check to see if the point given is a valid
                point on the board. Return true if it is, else return false if 
                it isn't.

        AUTHOR

                Janila Khan

        DATE

                6:45pm 4/6/2018

        */
        /// </summary>
        /// <param name="x">The location of the x value</param>
        /// <param name="y">The location of the y value</param>
        /// <returns>Return true if it is, else return false if it isn't.</returns>
        private bool isPointOnBoard(int x, int y)
        {
            if (x < 1 || x > m_boardWidth || y < 1 || y > m_boardHeight)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /*
        MineForm::setButtonImages() 

        NAME

                MineForm::setButtonImages - Print the block of the button the user 
                                            clicked.

        SYNOPSIS

                void MineForm::setButtonImages(int x, int y);

        DESCRIPTION

                This function will print the block of the button the user clicked.

        AUTHOR

                Janila Khan

        DATE

                3:15pm 4/7/2018

        */
        /// </summary>
        /// <param name="x">The location of the x value</param>
        /// <param name="y">The location of the y value</param>
        private void setButtonImages(int x, int y)
        {
            // Disabled the pressed button
            m_mineButton[x, y].Enabled = false;
            m_mineButton[x, y].BackgroundImageLayout = ImageLayout.Stretch;

            // Set the saved values as the mine button value
            if (m_gameOver && m_mineButtonValue[x, y] == flagValue)
            {
                m_mineButtonValue[x, y] = m_saveValue[x, y];
            }

            // Stop the timer if the game is over
            if (m_gameOver)
            {
                m_timer.Stop();
            }

            // 
            switch (m_mineButtonValue[x, y])
            {
                // If zero, print a blank block
                case 0:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.zero;
                    emptySpace(x, y);
                    break;
                // If one, print the one number block
                case 1:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.one;
                    break;
                // If two, print the two number block
                case 2:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.two;
                    break;
                // If three, print the three number block
                case 3:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.three;
                    break;
                // If four, print the four number block
                case 4:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.four;
                    break;
                // If five, print the five number block
                case 5:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.five;
                    break;
                // If six, print the six number block
                case 6:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.six;
                    break;
                // If seven, print the seven number block
                case 7:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.seven;
                    break;
                // If eight, print the eight number block
                case 8:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.eight;
                    break;
                // If negative one, print the mine block
                case -1:
                    m_mineButton[x, y].BackgroundImage = GameConsole.Properties.Resources.mine;
                    if (!m_gameOver)
                    {
                        endGame();
                    }
                    break;
            }
        }

        /// <summary>
        /*
        MineForm::emptySpace() 

        NAME

                MineForm::emptySpace - Fills all the empty neighbors of
                                       a point

        SYNOPSIS

                void MineForm::emptySpace(int x, int y);

        DESCRIPTION

                This function will fill all the empty neighbors of a point.

        AUTHOR

                Janila Khan

        DATE

                5:45pm 4/7/2018

        */
        /// </summary>
        /// <param name="x">The location of the x value</param>
        /// <param name="y">The location of the y value</param>
        private void emptySpace(int x, int y)
        {
            // If a button click has a value of zero continue
            if (m_mineButtonValue[x, y] == 0)
            {
                // Check the adjacent spaces for a value
                for (int i = 0; i < 8; i++)
                {
                    // The Location of the adjacent space
                    int a_x = x + m_adjacentX[i];
                    int a_y = y + m_adjacentY[i];

                    if (isPointOnBoard(a_x, a_y))
                    {
                        if (m_mineButton[a_x, a_y].Enabled == true
                            && m_mineButtonValue[a_x, a_y] != -1 && !m_gameOver)
                        {
                            // Print the value of the image
                            setButtonImages(a_x, a_y);
                        }
                    }
                }
            }
        }

        /// <summary>
        /*
        MineForm::printBoard() 

        NAME

                MineForm::printBoard - Print the rest of the board onto the screen

        SYNOPSIS

                void MineForm::printBoard();

        DESCRIPTION

                This function will print the rest of the board when the game is over.

        AUTHOR

                Janila Khan

        DATE

                6:00pm 4/7/2018

        */
        /// </summary>
        private void printBoard()
        {
            // Go through the rest of the board 
            for (int i = 1; i <= m_boardWidth; i++)
            {
                for (int j = 1; j <= m_boardHeight; j++)
                {
                    if (m_mineButton[i, j].Enabled == true)
                    {
                        // Print the images of the button
                        setButtonImages(i, j);
                    }
                }
            }
        }

        /// <summary>
        /*
        MineForm::endGame() 

        NAME

                MineForm::endGame - Perform actions to end the game is the user 
                                    loses.

        SYNOPSIS

                void MineForm::endGame();

        DESCRIPTION

                This function will end the game and print the rest of the board
                values. After a message is printed to the screen the form will
                close since the user lost.

        AUTHOR

                Janila Khan

        DATE

                3:00pm 4/8/2018

        */
        /// </summary>
        private void endGame()
        {
            // Set gameOver to true and print the values of the board
            m_gameOver = true;
            printBoard();

            // Stop the background music
            player.Stop();

            // Print a message to the screen stating the game is over
            MessageBox.Show("Game Over! You Lose!");

            // Close the form
            this.Close();
        }

        /// <summary>
        /*
        MineForm::checkFlagWin() 

        NAME

                MineForm::checkFlagWin - Check to see if the user has won.

        SYNOPSIS

                void MineForm::checkFlagWin();

        DESCRIPTION

                This function will check to see if the user has won by placing
                all the flags in the right positions. First, it go through the 
                board and check to see if there are mines. If there are mines
                then the user has not won since they haven't place a flag in
                that location. If there aren't any mines, the gameOver variable
                is set to zero. The user recieves a message and are asked if
                they would like to save their score. 

        AUTHOR

                Janila Khan

        DATE

                4:00pm 4/8/2018

        */
        /// </summary>
        private void checkFlagWin()
        {
            bool win = true;

            // Go through the board
            for (int i = 1; i <= m_boardWidth; i++)
            {
                for (int j = 1; j <= m_boardHeight; j++)
                {
                    // if there is a mine, the user has not place a flag 
                    // in that location, so the user has not won
                    if (m_mineButtonValue[i, j] == -1)
                    {
                        win = false;
                    }
                }
            }

            if (win)
            {
                // The game is over and the rest of the button are shown
                m_gameOver = true;
                printBoard();

                // Stop the background music
                player.Stop();

                // Display a message to the screen
                MessageBox.Show("You Win!");

                // Ask the user if they would like to add their time to 
                // the scoreboard
                addToScoreBoard();
            }
        }

        /// <summary>
        /*
        MineForm::checkWin() 

        NAME

                MineForm::checkWin - Check to see if the user has won.

        SYNOPSIS

                void MineForm::checkWin();

        DESCRIPTION

                This function will check to see if the board has empty spaces
                if yes the game continues otherwise, the game is over

        AUTHOR

                Janila Khan

        DATE

                4:45pm 4/8/2018

        */
        /// </summary>
        private void checkWin()
        {
            bool win = true;

            // Go through the board
            for (int i = 1; i <= m_boardWidth; i++)
            {
                for (int j = 1; j <= m_boardHeight; j++)
                {
                    // Checks to see if a button is not clicked, and if there is a
                    // mine then the user has not won.
                    if (m_mineButton[i, j].Enabled == true && m_saveValue[i, j] != -1)
                    {
                        win = false;
                    }
                }
            }

            if (win)
            {
                // the game is over and the buttons that were not clicked
                // are shown
                m_gameOver = true;
                printBoard();

                // Stop the music that is playing in the background
                player.Stop();

                // Print a message to the user
                MessageBox.Show("You Win!");

                // Ask the user if they would like to add their time to the scoreboard
                addToScoreBoard();
            }
        }

        /// <summary>
        /*
        MineForm::OnTimedEvent() 

        NAME

                MineForm::OnTimedEvent - Print the time onto the screen.

        SYNOPSIS

                void MineForm::OnTimedEvent(object sender, ElaspedEventArgs e);

        DESCRIPTION

                This function will make the time keep going and print it out to the 
                screen.

        AUTHOR

                Janila Khan

        DATE

                5:15pm 4/8/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised
        ///  the event</param>
        /// <param name="e">The time the event was triggered</param>
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            m_seconds++;

            //Fixed window handle issue.
            if (!this.IsHandleCreated)
            {
                this.CreateControl();
            }

            // update the time 
            this.m_playerTimeLabel.Invoke((MethodInvoker)delegate ()
            {
                m_playerTimeLabel.Text = m_seconds.ToString();
            });
        }

        /// <summary>
        /*
        MineForm::addToscoreBoard() 

        NAME

                MineForm::addToScoreBoard - Ask the user if they would like to add their 
                                              time to the minesweeper scoreboard.

        SYNOPSIS

                void MineForm::addToScoreBoard();

        DESCRIPTION

                This function will ask the user if they would like to save their time in
                the Minesweeper ScoreBoard. If 'yes', the scoreboard dialog will be open 
                and the user can input their time. If 'no', a message will be shown to
                the screen.

        AUTHOR

                Janila Khan

        DATE

                5:30pm 4/8/2018

        */
        /// </summary>
        public void addToScoreBoard()
        {
            // Ask the user if they would like to save their score to the scoreboard
            DialogResult timeAns = MessageBox.Show("Do you want to add your time to the Minesweeper Scoreboard?",
                                                    "Add Time", MessageBoxButtons.YesNo);
            if (timeAns == DialogResult.Yes)
            {
                // If 'Yes', save the time to a public static int so the MineScoreBoard
                // is able to recieve the score.
                m_PlayerTime = m_seconds;

                // Create a new scoreboard object and open the scoreboard window
                MineScoreBoard m_time = new MineScoreBoard();
                m_time.ShowDialog();

                // Close the form
                this.Close();

            }
            else if (timeAns == DialogResult.No)
            {
                // If 'No', tell the user that their score will not be save into the scoreboard
                // and close the form
                MessageBox.Show("Ok. Your time will not be added to the scoreboard. Goodbye!");
                this.Close();
            }
        }


        #region variables

        SoundPlayer player;

        private System.Timers.Timer m_timer;

        public static int m_PlayerTime;

        // Board width and height
        int m_boardWidth = 9;
        int m_boardHeight = 9;

        // How many mines are in the game
        int mines = 10;

        // Flags
        int flagValue = 9;
        int flags = 10;

        // Button variables
        Button[,] m_mineButton = new Button[10, 10];
        int[,] m_mineButtonValue = new int[10, 10];
        int[,] m_saveValue = new int[10, 10];

        int m_buttonWidth = 20;
        int m_buttonHeight = 20;

        Point coordinates;

        // Points that are around a button
        int[] m_adjacentX = { 1, 0, -1, 0, 1, -1, -1, 1 };
        int[] m_adjacentY = { 0, 1, 0, -1, 1, -1, 1, -1 };

        // Time
        int m_seconds = 0;

        bool m_gameOver;
       
        #endregion
    }
}
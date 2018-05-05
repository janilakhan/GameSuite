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
    /// This class controls the elements of the SnakeForm and the game
    /// logic for the snake game. 
    /// </summary>
    public partial class SnakeForm : Form
    {
        /// <summary>
        /*
        SnakeForm::SnakeForm() 

        NAME

                SnakeForm::SnakeForm - Constructor.

        SYNOPSIS

                void SnakeForm::SnakeForm();

        DESCRIPTION

                Constructor

        AUTHOR

                Janila Khan

        DATE

                4:00pm 4/18/2018

        */
        /// </summary>
        public SnakeForm()
        {
            InitializeComponent();

            // Set the width ans height of the playing board
            m_Width = snakeBoard.Width - 5;
            m_Height = snakeBoard.Height - 5;

            // Set the score zero
            playerScoreLabel.Text = m_score.ToString();

            try
            {
                player = new SoundPlayer(GameConsole.Properties.Resources.snakeBG);
                player.PlayLooping();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }

            // Create the snake and place the food on the board
            createSnake();
            createFood();

            // Create a timer and set a interval.
            m_time = new System.Timers.Timer();
            m_time.Interval = 100;

            // Hook up the Elapsed event for the timer. 
            m_time.Elapsed += OnTimedEvent;

            // Have the timer fire repeated events (true is the default)
            m_time.AutoReset = true;

            // Start the timer
            m_time.Enabled = true;
        }

        /// <summary>
        /*
        SnakeForm::SnakeForm_Load() 

        NAME

                SnakeForm::SnakeForm_Load - Prints a message to the user

        SYNOPSIS

                void SnakeForm::SnakeForm_Load(object sender, EventArgs e);

        DESCRIPTION

                This function will print out a message telling the user the to get
                ready to play snake.

        AUTHOR

                Janila Khan

        DATE

                7:00pm 4/9/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void SnakeForm_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Get Ready to Play a Game of Snake!");

            // Display the instructions
            snakeInstructions();
        }

        /// <summary>
        /*
        SnakeForm::snakeInstructions() 

        NAME

                SnakeForm::snakeInstructions - Display the instructions in a message box. 

        SYNOPSIS

                void SnakeForm::snakeInstructions();

        DESCRIPTION

                This function will display a message box that holds the instructions of the
                snake game.

        AUTHOR

                Janila Khan

        DATE

                7:35pm 4/23/2018

        */
        /// </summary>
        private void snakeInstructions()
        {
            string content = "";

            // The content will hold the instuctions of the minesweeper game
            content += "Objective: \r\n" +
                       "To eat the blue blocks which are the snakes food. \r\n \r\n";

            content += "How to Play: \r\n" +
                       "Press the LEFT, RIGHT, DOWN, UP keys to move the snake around \r\n" +
                       "the board. \r\n\r\n";

            // Display the instructions in a message box
            MessageBox.Show(content);
        }

        /// <summary>
        /*
        SnakeForm::createSnake() 

        NAME

                SnakeForm::createSnake - Creates the snake needed for the snake game

        SYNOPSIS

                void SnakeForm::createSnake();

        DESCRIPTION

                This function will create the snake which is needed for the game. The
                snake is created by using a Rectangle array. 

        AUTHOR

                Janila Khan

        DATE

                10:00am 4/12/2018

        */
        /// </summary>
        private void createSnake()
        {
            m_snakeBody = new Rectangle[2];

            int x = 20;
            int y = 0;

            m_snakeBody[0] = new Rectangle(x, y, blockSize, blockSize);
            m_snakeBody[0] = new Rectangle(x-10, y, blockSize, blockSize);
        }

        /// <summary>00
        /*
        SnakeForm::createFood() 

        NAME

                SnakeForm::createFood - Create the snake food that is needed for the game.

        SYNOPSIS

                void SnakeForm::createFood();

        DESCRIPTION

                This function will create the snake's food. This is done by getting two 
                random values that are within the board and then creating a rectangle 
                object. 

        AUTHOR

                Janila Khan

        DATE

                10:45am 4/12/2018

        */
        /// </summary>
        private void createFood()
        {
            // Two random values that will hold the x and y value
            int x = rand.Next(0, m_Width);
            int y = rand.Next(0, m_Height);

            // Intialize the rectangle 
            m_snakeFood = new Rectangle(x, y, blockSize, blockSize);
        }

        /// <summary>
        /*
        SnakeForm::drawSnake() 

        NAME

                SnakeForm::drawSnake - Fill the snakeBody with color and print to the 
                                       screen

        SYNOPSIS

                void SnakeForm::drawSnake(Graphics g);

        DESCRIPTION

                This function will fill each rectangle in the snakeBody. To do this, 
                I first go throught each element of the array. If it is the first element,
                I set the color to the m_snakeHead color, which is red. If it is not the first
                element the color is set to the m_snakeBody color which is black.

        AUTHOR

                Janila Khan

        DATE

                12:00pm 4/12/2018

        */
        /// </summary>
        /// <param name="g">The object that will be drawed</param>
        private void drawSnake(Graphics g)
        {
            // Go through each element of the m_snakeBody
            int i = 0;
            foreach (Rectangle rec in m_snakeBody)
            {
                // Fill the head of the snake
                if (i == 0)
                {
                    g.FillRectangle(m_snakeHeadColor, rec);
                    i++;
                }
                // Fill the rest of the body
                else
                {
                    g.FillRectangle(m_snakeBodyColor, rec);
                }
            }
        }

        /// <summary>
        /*
        SnakeForm::snakeBoard_Paint() 

        NAME

                snakeForm::SnakeBoard_Paint - Prints the snake and the snake's food onto the
                                              board.

        SYNOPSIS

                void SnakeForm::snakeBoard_Paint(object sender, PaintEventArgs p);

        DESCRIPTION

                This function will draw the snake and the snake's food onto the board.

        AUTHOR

                Janila Khan

        DATE

                12:45pm 4/12/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the snakeboard panel</param>
        /// <param name="p">Specifies the Graphics to use to paint the
        /// snakeBoard panel</param>
        private void snakeBoard_Paint(object sender, PaintEventArgs p)
        {
            // Draw the snake onto the board
            drawSnake(p.Graphics);

            // Print the snake's food onto the board
            p.Graphics.FillRectangle(m_snakeFoodColor, m_snakeFood);
        }

        /// <summary>
        /*
        SnakeForm::moveSnake() 

        NAME

                SnakeForm::moveSnake - Creates the action of moving the snake in the 
                                       direction that was specified.

        SYNOPSIS

                void SnakeForm::moveSnake();

        DESCRIPTION

                This function creates the action of moving the snake around the board.
                First, we save the rest of the snake values except the head. Then, we 
                changed the direction of the head by the direction that was set. 

        AUTHOR

                Janila Khan

        DATE

                10:15am 4/16/2018

        */
        /// </summary>
        private void moveSnake()
        {
            // Save the snake values
            for (int i = m_snakeBody.Length - 1; i > 0; i--)
            {
                m_snakeBody[i] = m_snakeBody[i - 1];
            }   

            // If the direction is left, subtract the x value by 10
            if (Direction.Left == m_dir)
            {
                m_snakeBody[0].X = m_snakeBody[0].X - 10;
            }

            // If the direction is right, add the x value by 10
            if (Direction.Right == m_dir)
            {
                m_snakeBody[0].X = m_snakeBody[0].X + 10;
            }

            // If the direction is down, add the y value by 10
            if (Direction.Down == m_dir)
            {
                m_snakeBody[0].Y = m_snakeBody[0].Y + 10;
            }

            // If the direction is up, subtract the y value by 10
            if (Direction.Up == m_dir)
            {
                m_snakeBody[0].Y = m_snakeBody[0].Y - 10;
            }

        }

        /// <summary>
        /*
        SnakeForm::SnakeForm_KeyDown() 

        NAME

                SnakeForm::SnakeForm_KeyDown - Moves the snake in a certain direction

        SYNOPSIS

                void SnakeForm::SnakeForm_KeyDown(object sender, KeyEventArgs e);

        DESCRIPTION

                This function will move the snake a certain direction
                according to what button is pressed. 

        AUTHOR

                Janila Khan

        DATE

                1:15pm 4/16/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="k">Represents the key that was pressed</param>
        private void SnakeForm_KeyDown(object sender, KeyEventArgs k)
        {
            switch (k.KeyCode)
            {
                // If the 'Left' key was pressed, set the m_dir variable 
                // to the Left and move the snake
                case Keys.Left:
                    if (m_dir != Direction.Right)
                    {
                        m_dir = Direction.Left;
                        moveSnake();
                    }
                    break;

                // If the 'Right' key was pressed, set the m_dir variable 
                // to the Right and move the snake
                case Keys.Right:
                    if (m_dir != Direction.Left)
                    {
                        m_dir = Direction.Right;
                        moveSnake();
                    }

                    break;

                // If the 'Up' key was pressed, set the m_dir variable 
                // to the Up and move the snake
                case Keys.Up:
                    if(m_dir != Direction.Down)
                    { 
                        m_dir = Direction.Up;
                        moveSnake();
                    }
                    break;

                // If the 'Down' key was pressed, set the m_dir variable 
                // to the Down and move the snake
                case Keys.Down:
                    if(m_dir != Direction.Up)
                    {
                        m_dir = Direction.Down;
                        moveSnake();
                    }
                    break;
            }
        }

        /// <summary>
        /*
        SnakeForm::addToSnake() 

        NAME

                SnakeForm::addToSnake - Increases the snake after the snake eats

        SYNOPSIS

                void SnakeForm::addToSnake();

        DESCRIPTION

                This function will add one more rectangle object to the snakeBody array
                creating the effect that the snake has eating. This is done by creating 
                a temporary rectangle array and setting the values. After this is done,
                I make set the snakeBody with the same values.

        AUTHOR

                Janila Khan

        DATE

                6:00pm 4/16/2018

        */
        /// </summary>
        private void addToSnake()
        {
            // Create a temporary rectangle array that has one more value than the 
            // snakeBody array
            Rectangle[] temp = new Rectangle[m_snakeBody.Count() + 1];

            // Set the head of the array 
            temp[0] = new Rectangle(m_snakeBody[0].X, m_snakeBody[0].Y, blockSize, blockSize);

            int j = 0;

            // Save the values into the temp array
            for (int i = 1; i < temp.Count(); i++)
            {
                temp[i] = m_snakeBody[j];
                j++;
            }

            m_snakeBody = temp;
        }

        /// <summary>
        /*
        SnakeForm::snakeEatFood() 

        NAME

                SnakeForm::snakeEatFood - Checks to see if the snake has eaten the 
                                          snake's food.
                                        

        SYNOPSIS

                void SnakeForm::snakeEatFood();

        DESCRIPTION

                This function checks to see if the snake has eaten the snake's food.
                If the food was eaten by the snake then I increase the length to the 
                snake. Then create a new food object and increase the score by 10 points.

        AUTHOR

                Janila Khan

        DATE

                7:00pm 4/16/2018

        */
        /// </summary>
        private void snakeEatFood()
        {
            // Check to see if the head of the snake has touch the snake food
            // object
            if (m_snakeBody[0].IntersectsWith(m_snakeFood))
            {
                // Increase the length of the snake
                addToSnake();

                createFood();
                
                // add ten points to the score
                m_score += 10;
            }
        }

        /// <summary>
        /*
        SnakeForm::ifCollided() 

        NAME

                SnakeForm::ifCollided - Checks to see if the snake has hit its own body
                                        

        SYNOPSIS

                bool SnakeForm::ifCollided();

        DESCRIPTION

                This function checks to see if the snake collided with its own
                body. If it does it returns true otherwise, it returns false.

        AUTHOR

                Janila Khan

        DATE

                1:00pm 4/18/2018

        */
        /// </summary>
        /// <returns> Returns true if the snake has collided with itself,
        /// false otherwise  </returns>
        private bool ifCollided()
        {
            for (int i = 2; i < m_snakeBody.Length - 1; i++)
            {
                if (m_snakeBody[i].IntersectsWith(m_snakeBody[0]))
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /*
        SnakeForm::outOfBound() 

        NAME

                SnakeForm::outOfBound - Checks to see if the snake goes out of bounds
                                        

        SYNOPSIS

                bool SnakeForm::outOfBound();

        DESCRIPTION

                This function checks to see if the snake goes out of the board bounds.
                If it does it returns true otherwise, it returns false.

        AUTHOR

                Janila Khan

        DATE

                2:00pm 4/18/2018

        */
        /// </summary>
        /// <returns> Returns true if the snake goes out of bounds,
        /// false otherwise  </returns>
        private bool outOfBound()
        {
            // Check to see if the snake goes out of the board bound
            if (m_snakeBody[0].X < 0 || m_snakeBody[0].X > m_Width || m_snakeBody[0].X > m_Height ||
                m_snakeBody[0].Y < 0 || m_snakeBody[0].Y > m_Width || m_snakeBody[0].Y > m_Height)
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /*
        SnakeForm::OnTimedEvent() 

        NAME

                SnakeForm::OnTimedEvent - Keeps the game going, moves the snake in the 
                                           direction that is specified

        SYNOPSIS

                void SnakeForm::OnTimedEvent(object sender, ElaspedEventArgs e);

        DESCRIPTION

                This function keep the snake going until the game is over. It will keep
                the snake moving until the user presses a button to move the snake in a
                different direction.

        AUTHOR

                Janila Khan

        DATE

                4:30pm 4/18/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e"> The time the event was triggered</param>
        private void OnTimedEvent(object sender, EventArgs e)
        {

            // Keep the snake in the direction that is specified
            moveSnake();

            // Check to see if the snake has hit itself or if it out of bounds
            if (ifCollided() || outOfBound())
            {
                // stop the timer
                m_time.Stop();

                // stop the background music
                player.Stop();

                // ask the user if they would like to add their score
                endGame();
            }


            // Check to see if the snake has eaten the food
            snakeEatFood();

            //Fixed window handle issue.
            if (!this.IsHandleCreated)
            {
                this.CreateControl();
            }

            // Display the player's score
            this.playerScoreLabel.Invoke((MethodInvoker)delegate ()
            {
                playerScoreLabel.Text = m_score.ToString();
            });

            snakeBoard.Invalidate();

        }

        /// <summary>
        /*
        SnakeForm::endGame() 

        NAME

                SnakeForm::endGame - Prints the user's stats and ask the user if they
                                     would like to save their score to the scoreboard.

        SYNOPSIS

                void SnakeForm::endGame();

        DESCRIPTION

                This function will ask the user if they would like to save their score. 
                First, user is asked if they would like to save their score to the 
                scoreboard. If 'Yes' the SnakeScoreBoard form is shown. Else the user is
                told that their score will not be saved and the form closes.

        AUTHOR

                Janila Khan

        DATE

                9:00pm 4/14/2018

        */
        /// </summary>
        private void endGame()
        {
            // Print the message "Game Over" to the screen
            MessageBox.Show("Game Over!");

            // Ask the user if they would like to save their score to the scoreboard
            DialogResult scoreAns = MessageBox.Show("Do you want to add your score to the Snake Scoreboard?",
                                                    "Add Score", MessageBoxButtons.YesNo);
            if (scoreAns == DialogResult.Yes)
            {
                // If 'Yes', save the score to a public static int so the SnakeScoreBoard
                // is able to recieve the score.
                m_PlayerScore = m_score;

                // Create a new scoreboard object and open the scoreboard window
                SnakeScoreBoard s_score = new SnakeScoreBoard();
                s_score.ShowDialog();

                // Close the form
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Hide();
                });

            }
            else if (scoreAns == DialogResult.No)
            {
                // If 'No', tell the user that their score will not be save into the scoreboard
                // and close the form
                MessageBox.Show("Ok. Your score will not be added to the scoreboard. Goodbye!");
                
                // Close the form
                this.Invoke((MethodInvoker)delegate
                {
                    // close the form on the forms thread
                    this.Hide();
                });
            }
        }

        #region variables

        SoundPlayer player;

        private System.Timers.Timer m_time;

        // Score
        public static int m_PlayerScore;
        private int m_score = 0;

        // Width and Height of the board
        private int m_Width = 0;
        private int m_Height = 0;

        // Snake and the snake's Food
        Rectangle[] m_snakeBody;
        Rectangle m_snakeFood;

        // The colors for each object on the board
        SolidBrush m_snakeHeadColor = new SolidBrush(Color.DarkRed);
        SolidBrush m_snakeBodyColor = new SolidBrush(Color.Black);
        SolidBrush m_snakeFoodColor = new SolidBrush(Color.Blue);

        Random rand = new Random();

        // The size of each block unit
        private int blockSize = 10;

        // The direction that the game will start with
        Direction m_dir = Direction.Down;

        // The different set of directions
        public enum Direction { Up, Down, Left, Right};

        #endregion
    }
}
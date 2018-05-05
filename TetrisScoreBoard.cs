using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameConsole
{
    /// <summary>
    /// This class controls the scoreboard for the Tetris Game
    /// </summary>
    public partial class TetrisScoreBoard : Form
    {
        /// <summary>
        /*
        TetrisScoreBoard::TetrisScoreBoard() 

        NAME

                TetrisScoreBoard::TetrisScoreBoard - intializes the form and its
                                                     components

        SYNOPSIS

                TetrisScoreBoard::TetrisScoreBoard();


        DESCRIPTION

                This function create the tetris scoreboard form and
                the elements within the form. 

        AUTHOR

                Janila Khan

        DATE

                2:30pm 3/24/2018

        */
        /// </summary>
        public TetrisScoreBoard()
        {
            InitializeComponent();

            // Sets the score textbox with the user's score
            playerScore = TetrisForm.m_PlayerScore;
            t_scoreTextBox.Text = playerScore.ToString();

            // receive the fullpath towards the textfile
            m_fileName = "t_scoreboard.txt";
            m_fullPath = Path.GetFullPath(m_fileName);

            // Read all the lines in the files if able to otherwise, send an error message 
            try
            {
                m_content = File.ReadAllLines(m_fileName);

                // Parse the lines and put them into a list
                parseLines();

                // Print the scores on to the screen
                printScoreToScreen();

            }
            catch(Exception e)
            {
                // print an message if there is a exception
                MessageBox.Show("Exception: " + e.Message);
            }

            
        }

        /// <summary>
        /*
        TetrisScoreBoard::TetrisScoreBoard_Load() 

        NAME

                TetrisScoreBoard::TetrisScoreBoard_Load - Prints a message of how to use
                                                          the form.

        SYNOPSIS

                void TetrisScoreBoard::TetrisScoreBoard_Load(object sender, EventArgs e);

        DESCRIPTION

                This function will print out a message on how to add your score to the 
                scoreboard.

        AUTHOR

                Janila Khan

        DATE

                6:15pm 3/23/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="e">Contains the event data</param>
        private void TetrisScoreBoard_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Enter the player's name and then press Enter.");
        }

        /// <summary>
        /*
        TetrisScoreBoard::parseLines() 

        NAME

                TetrisScoreBoard::parseLines - Parse the content of the text file by 
                                                splitting each line.

        SYNOPSIS

                void TetrisScoreBoard::parseLines();

        DESCRIPTION

                This function will parse the content of the text file. First, it go
                through each line and split on a certain character. This is done by 
                using a Regular Expression and its Split method. Afterwards, I set 
                the first element of the splitted string as the key and the second
                element as the value. Then, the elements are added to the scoreboard.

        AUTHOR

                Janila Khan

        DATE

                10:00am 3/24/2018

        */
        /// </summary>
        private void parseLines()
        {
            int key;
            string value;

            string[] words;

            // For each line in text file  
            foreach(string line in m_content)
            {
                // Split the line between the ":" character
                words = Regex.Split(line, @":");

                // Set the first value as the key and the second as the value
                key = int.Parse(words[0].ToString());
                value = words[1].ToString();

                // Intialize the key and value to the Key Value Pair object
                KeyValuePair<int, string> item = new KeyValuePair<int, string>(key, value);

                // Add the score to the scoreboard
                m_scoreBoard.Add(item);
            }
        }

        /// <summary>
        /*
        TetrisScoreBoard::printScoreToScreen() 

        NAME

                TetrisScoreBoard::printScoreToScreen - Prints the scoreboard to the list textbox

        SYNOPSIS

                void TetrisScoreBoard::printScoreToScreen();

        DESCRIPTION

                This function will print out the names and scores of each user who played the 
                tetris game and saved their score. First, I cleared any text from the list 
                textbox. Then I go through every element of the and print out the key which
                is the user's score and the value which is the user's name. However, to get
                the points in descending order, I go through the scoreboard object in reverse.

        AUTHOR

                Janila Khan

        DATE

                10:50am 3/24/2018

        */
        /// </summary>
        private void printScoreToScreen()
        {
            // Clear the any text from the list textbox
            t_listTextBox.Text = "";

            // Go through the scoreboard in descending order due to the fact that we want to 
            // show the higher scores first.
            foreach(KeyValuePair<int, string> i in m_scoreBoard.OrderByDescending(order => order.Key))
            {
                // Print the score to the textbox
                t_listTextBox.Text += string.Format("{0} \t {1} \r\n", i.Key, i.Value);
            }
        }

        /// <summary>
        /*
        TetrisScoreBoard::addScore() 

        NAME

                TetrisScoreBoard::addScore - Add the user's name and score to the scoreboard

        SYNOPSIS

                void TetrisScoreBoard::addScore();

        DESCRIPTION

                This function will add the score to the scoreboard object.

        AUTHOR

                Janila Khan

        DATE

                11:30am 3/24/2018

        */
        /// </summary>
        private void addScore()
        {
            // Get the players name from the textbox
            playerName = t_nameTextBox.Text;

            // Intialize the the playerScore and name to a Key Value Pair object
            KeyValuePair<int, string> item = new KeyValuePair<int, string>(playerScore, playerName);

            // Add the item to the list
            m_scoreBoard.Add(item);
        }

        /// <summary>
        /*
        TetrisScoreBoard::writeToTextFile() 

        NAME

                TetrisScoreBoard::writeToTextFile - Writes the new scoreboard to the text file

        SYNOPSIS

                void TetrisScoreBoard::writeToTextFile();

        DESCRIPTION

                This function will write the new scoreboard to the text file. First, I created
                a StreamWriter object and send the path as an argument. Then we set the line
                variable to each element of the scoreboard object and write to the text file.
                After each element is added to text file, we close the the file. 

        AUTHOR

                Janila Khan

        DATE

                1:00pm 3/24/2018

        */
        /// </summary>
        private void writeToTextFile()
        {
            // write to a text file if able to, otherwise send an error message
            try
            {
                string line;

                // Create a StreamWriter object and open the file with the path
                StreamWriter file = new StreamWriter(m_fullPath, false);

                // Write each line to the text file
                foreach (KeyValuePair<int, string> i in m_scoreBoard)
                {
                    line = string.Format("{0}:{1}", i.Key, i.Value);
                    file.WriteLine(line);
                }

                // Close the File
                file.Close();
            }
            catch(Exception e)
            {
                // Print a message if there is an exception
                MessageBox.Show("Exception: " + e.Message);
            }
        }

        /// <summary>
        /*
        TetrisScoreBoard::nameTextBox_KeyDown() 

        NAME

                TetrisScoreBoard::nameTextBox_KeyDown - This will perform a set actions after 
                                                        a certain button is clicked

        SYNOPSIS

                void TetrisScoreBoard::nameTextBox_KeyDown(object sender, KeyEventArgs e);

        DESCRIPTION

                This function will perform a set of actions after the "Enter" key is clicked.
                First, it checks if the user is pressing the "Enter" key, if they are not the
                other actions are not performed. Next, the user score is added to the scoreboard
                and the new scoreboard is printed to the screen. After that the new scoreboard is
                written to the text file. Then a message comes to the screen telling the user 
                their score was added to the scoreboard. 

        AUTHOR

                Janila Khan

        DATE

                1:50pm 3/24/2018

        */
        /// </summary>
        /// <param name="sender">A reference to the object that raised the event</param>
        /// <param name="k">Represents the key that was pressed</param>
        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // If the enter key was not pressed, there is nothing to do.
            if (e.KeyCode != Keys.Enter) return;

            // Add player's score to scoreboard
            addScore();

            // Print new scores to screen
            printScoreToScreen();

            // Send new sorted dictionary to textfile
            writeToTextFile();

            // Message to the user that their score has been inputed
            MessageBox.Show("Your Score has been inputed");
        }


        # region variables

        // Holds the user's name and score
        public string playerName { get; set; }
        public int playerScore { get; set; }

        // A List object that holds all the names and scores within the scoreboard
        List<KeyValuePair<int, string>> m_scoreBoard = new List<KeyValuePair<int, string>>();

        string[] m_content;
        string m_fileName;
        string m_fullPath;

        #endregion
    }
}

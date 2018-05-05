using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace GameConsole
{
    /// <summary>
    /// This class holds the elements of the tetris board
    /// </summary>
    class TetrisBoard
    {
        
        /// <summary>
        /*
        TetrisBoard::TetrisBoard() 

        NAME

                TetrisBoard::TetrisBoard - Constructor

        SYNOPSIS

                TetrisBoard::TetrisBoard();


        DESCRIPTION

                Constructor

        AUTHOR

                Janila Khan

        DATE

                11:00pm 3/11/2018

        */
        /// </summary>
        public TetrisBoard()
        {
            // Intialize the board
            m_board = new Rectangle[cols, rows];
            m_color = new SolidBrush[cols, rows];

            m_level = 1;
            m_score = 0;
            m_rowsCleared = 0;

            // Create and call for block piece
            m_currentBlock = new TetrisBlocks(this);
            m_currentBlock.centerPosition();
            m_nextBlock = new TetrisBlocks(this);
        }

        /// <summary>
        /*
        TetrisBoard::drawBoard() 

        NAME

                TetrisBoard::drawBoard - Draws the board.

        SYNOPSIS

                void TetrisBoard::drawBoard(PaintEventArgs p);

        DESCRIPTION

                This function draws the board on to the screen.

        AUTHOR

                Janila Khan

        DATE

                8:00pm 3/11/2018

        */
        /// </summary>
        /// <param name="p">Specifies the graphics to use to paint board</param>
        public void drawBoard(PaintEventArgs p)
        {
            m_currentBlock.drawBlock(p);

            for(int i = 0; i < cols; ++i)
            {
                for(int j = 0; j < rows; ++j)
                {
                    if (!m_board[i, j].IsEmpty)
                    {
                        if (m_color[i, j] == null)
                        {
                            p.Graphics.FillRectangle(new SolidBrush(Color.Black), m_board[i, j]);
                        }
                        else
                        {
                            p.Graphics.FillRectangle(m_color[i, j], m_board[i, j]);
                        }
                    }
                }
            }
        }

        /// <summary>
        /*
        TetrisBoard::drawNextBlock() 

        NAME

                TetrisBoard::drawNextBlock - Draws the next block

        SYNOPSIS

                void TetrisBoard::drawNextBlock(PaintEventArgs p);

        DESCRIPTION

                This function draws the next block.

        AUTHOR

                Janila Khan

        DATE

                10:00am 3/20/2018

        */
        /// </summary>
        /// <param name="p">Specifies the graphics to use to paint the
        /// next block</param>
        public void drawNextBlock(PaintEventArgs p)
        {
            m_nextBlock.drawBlock(p);
        }

        /// <summary>
        /*
        TetrisBoard::newBlock() 

        NAME

                TetrisBoard::newBlock - Sets newblock to current block
                                           and then makes a new next block.

        SYNOPSIS

                void TetrisBoard::newBlock();


        DESCRIPTION

                This function changes the next block to the current
                block. Then, the functions creates a new next block. 

        AUTHOR

                Janila Khan

        DATE

                9:00pm 3/11/2018

        */
        /// </summary>
        public void newBlock()
        {
            if (!gameOver())
            {
                m_currentBlock = m_nextBlock.centerPosition();
                m_nextBlock = new TetrisBlocks(this);
            }
        }

        /// <summary>
        /*
        TetrisBoard::isSpaceEmpty() 

        NAME

                TetrisBoard::isSpaceEmpty - Checks to see if a board 
                                            space is empty

        SYNOPSIS

                void TetrisBoard::isSpaceEmpty(int x, int y);


        DESCRIPTION

                This function checks to see if a space on the board 
                is empty. Returns true if the space is empty on the
                board, otherwise returns false.

        AUTHOR

                Janila Khan

        DATE

                11:00am 3/20/2018

        */
        /// </summary>
        /// <param name="x">The x coordinate of the board grid</param>
        /// <param name="y">The y coordinate of the board grid</param>
        /// <returns>Return true if the space is empty on the board, 
        /// otherwise returns false</returns>
        public bool isSpaceEmpty(int x, int y)
        {
            if (m_board[x, y].IsEmpty)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /*
        TetrisBoard::setBlockToBoard() 

        NAME

                TetrisBoard::setBlockToBoard - Sets block onto the board.

        SYNOPSIS

                void TetrisBoard::setBlockToBoard();


        DESCRIPTION

                This function set the block onto the board. The function
                sets each segment of the board individually.

        AUTHOR

                Janila Khan

        DATE

                3:00pm 3/20/2018

        */
        /// </summary>
        public void setBlockToBoard()
        {
            int x;
            int y;

            Rectangle[] setBlock = m_currentBlock.m_blockShape;

            // set each segment of a block individually
            for (int i = 0; i < setBlock.Length; ++i)
            {
                // the x and y value for each segment
                x = setBlock[i].X / 21;
                y = setBlock[i].Y / 21;

                // if a block is in the first two rows 
                if (y < 2)
                {
                    gameOver();
                }

                // set the segment ot the board and color the segment
                m_board[x, y] = setBlock[i];
                m_color[x, y] = new SolidBrush(m_currentBlock.m_blockColor);
            }

            // check for clear rows
            clearRows();
        }

        /// <summary>
        /*
        TetrisBoard::downward() 

        NAME

                TetrisBoard::downward - Moves the current block downward.

        SYNOPSIS

                void TetrisBoard::downward();


        DESCRIPTION

                This function keeps the current block to moving downward 
                until it can't move down. When it can't the block adds the
                block to the board and changes the block.

        AUTHOR

                Janila Khan

        DATE

                4:00pm 3/20/2018

        */
        /// </summary>
        public void downward()
        {
            if (!m_currentBlock.moveDown())
            {
                // set the block to the board
                setBlockToBoard();

                // call for a new block
                newBlock();
            }
        }
        
        /// <summary>
        /*
        TetrisBoard::clearRows() 

        NAME

                TetrisBoard::clearRows - Clear the full rows on the board.

        SYNOPSIS

                void TetrisBoard::TetrisForm();


        DESCRIPTION

                This function determines of rows that filled. These 
                rows later on will be cleared and will add up for the
                score. First, the functions check to see if a row is
                full. If a row is full we take out the row from the 
                board and take it out from the color grid.    

        AUTHOR

                Janila Khan

        DATE

                7:00pm 3/21/2018

        */
        /// </summary>
        public void clearRows()
        {
            int clear = 0;

            for (int r = rows - 1; r >= 0; --r)
            {
                bool full = true;

                for (int c = 0; c < cols; ++c)
                {
                    if (isSpaceEmpty(c, r))
                    {
                        full = false;
                        break;
                    }
                }

                // if there is full row move the board one row down
                if (full)
                {
                    clear += 1;

                    for (int j = r; j > 0; --j)
                    {
                        for (int i = 0; i < cols; ++i)
                        {
                            // check to see if the space is empty one row down
                            if (!isSpaceEmpty(i, j - 1))
                            {
                                m_board[i, j - 1].Y += 21; 
                            }

                            // Move the board and the color one row down
                            m_board[i, j] = m_board[i, j - 1];  
                            m_color[i, j] = m_color[i, j - 1];
                        }
                    }
                    r++; 
                }
            }

            scorePoints(clear);
        }

        /// <summary>
        /*
        TetrisBoard::gameOver() 

        NAME

                TetrisBoard::gameOver - Determines if the game is over.

        SYNOPSIS

                bool TetrisBoard::gameOver();


        DESCRIPTION

                This function will determine if the game is over.
                It checks if the spaces in the first two rows (the 
                top part of the board) is filled. Returns true if 
                the board is filled, otherwise returns false.
            
        AUTHOR

                Janila Khan

        DATE

                4:00pm 3/23/2018

        */
        /// </summary>
        /// <returns>Returns true if the first two rows of the board have a 
        /// block within them.Returns false otherwise.</returns>
        public bool gameOver()
        {
            for (int i = 0; i < cols; ++i)
            {
                for (int j = 0; j < 2; ++j)
                {
                    // checks to see if a space is empty
                    if (!isSpaceEmpty(i, j))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        /// <summary>
        /*
        TetrisBoard::scorePoints() 

        NAME

                TetrisBoard::scorePoints - Calculate a user's score and 
                                          increase the level.

        SYNOPSIS

                void TetrisBoard::scorePoints(int clear);


        DESCRIPTION

                This function will determine the score and the level
                the user is on. To calculate the score, I chose to 
                multiply 20 by the number that is clear and the level
                the user is on. The level increases every 10 rows that
                are clear.

        AUTHOR

                Janila Khan

        DATE

                4:30pm 3/23/2018

        */
        /// </summary>
        /// <param name="clear">Holds the value of rows that were recently 
        /// cleared</param>
        private void scorePoints(int clear)
        {
            // Calculating the score
            m_score += 20 * clear * m_level;
            m_rowsCleared += clear;

            // Increasing the level
            m_level = (m_rowsCleared / 10) + 1;
        }

        #region variables

        Rectangle[,] m_board;
        SolidBrush[,] m_color;

        public TetrisBlocks m_currentBlock;
        public TetrisBlocks m_nextBlock;

        public int m_score { get; set; }
        public int m_rowsCleared { get; set; }
        public int m_level { get; set; }

        // The height and width of the board
        public int cols = 10;
        public int rows = 20;
        
        #endregion
    }
}
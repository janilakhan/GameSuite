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
    /// This class holds the elements of the tetris the 
    /// seven tetris blocks
    /// </summary>
    class TetrisBlocks
    {

        /// <summary>
        /*
        TetrisBlocks::TetrisBlocks() 

        NAME

                TetrisBlocks::TetrisBlocks- constructor

        SYNOPSIS

                TetrisBlocks::TetrisBlocks(TetrisBoard t_board);

        DESCRIPTION

                Constructor

        AUTHOR

                Janila Khan

        DATE

                5:50pm 3/10/2018

        */
        /// </summary>
        /// <param name="t_board">A TetrisBoard object</param>
        public TetrisBlocks(TetrisBoard t_board)
        {
            //Intialize the board
            m_board = t_board;

            blockRow = 0;
            blockColumn = 0;
            
            // Get a random number
            Random rand = new Random();
            num = rand.Next(0, 7);

            // Use the random to chose a block and the color that 
            // corresponds with it
            block = m_pieces[num];
            m_blockColor = m_piecesColor[num];

            // Create the block piece
            m_blockShape = new Rectangle[4];
            m_blockShape = createBlocks(block);
        }

        /// <summary>
        /*
        TetrisBlocks::moveDown() 

        NAME

                TetrisBlocks::moveDown - Move the block one unit down.

        SYNOPSIS

                Rectangle[] TetrisBlocks::createBlocks(bool[,] t_block);

        DESCRIPTION

                This function creates the tetris block using the Rectangle
                class.          
            
        AUTHOR

                Janila Khan

        DATE

                5:00pm 3/9/2018

        */
        /// </summary>
        private Rectangle[] createBlocks(bool[,] t_block)
        {
            Rectangle[] shape = new Rectangle[4];

            int count = 0;

            int x;
            int y;

            for (int i = 0; i < 4; ++i) 
            {
                for (int j = 0; j < 4; ++j) 
                {
                    if (t_block[i, j])
                    {
                        // The x and y variable holds the upper-left corner of the rectangle.
                        x = (blockColumn * (m_blockWidth + 1)) + ((m_blockHeight + 1) * j) + 1;
                        y = (blockRow * (m_blockWidth + 1)) + ((m_blockHeight + 1) * i) + 1;

                        // Create a segment of the block
                        shape[count] = new Rectangle(x, y, m_blockWidth, m_blockHeight);

                        ++count;
                    }
                }
            }

            return shape;
        }

        /// <summary>
        /*
        TetrisBlocks::drawBlock() 

        NAME

                TetrisBlocks::drawBlock - Fill the block with color

        SYNOPSIS

                void TetrisBlocks::drawBlock(PaintEventArgs p);

        DESCRIPTION

                This function will draw the block to the screen.
                For each segment of the block will be filled with
                the block color. 

        AUTHOR

                Janila Khan

        DATE

               6:30pm 3/9/2018

        */
        /// </summary>
        /// <param name="p">Specifies the graphics to use to paint the
        /// current block</param>
        public void drawBlock(PaintEventArgs p)
        {
            // Create a solid brush object that will fill the block
            SolidBrush brush = new SolidBrush(m_blockColor);

            // Fill the block with its specific color
            for (int i = 0; i < m_blockShape.Length; ++i)
            {
                p.Graphics.FillRectangle(brush, m_blockShape[i]);
            }
        }

        /// <summary>
        /*
        TetrisBlocks::centerPosition() 

        NAME

                TetrisBlocks::dropBlock - Location of where the block
                                          will begin.

        SYNOPSIS

                TetrisBlocks TetrisBlocks::dropBlock();

        DESCRIPTION

                This function will print the block in the center 
                of the board.                     
            
        AUTHOR

                Janila Khan

        DATE

                7:00pm 3/9/2018

        */
        /// </summary>
        /// <returns>A TetrisBlocks object</returns>
        public TetrisBlocks centerPosition()
        {
            blockColumn = 3;
            m_blockShape = createBlocks(block);

            return this;
        }

        /// <summary>
        /*
        TetrisBlocks::moveToRight() 

        NAME

                TetrisBlocks::moveToRight - Move the block one unit to the 
                                            right.

        SYNOPSIS

                bool TetrisBlocks::moveToRight();

        DESCRIPTION

                This function will move the block one unit to the right. 
                First, create a temporary rectangle which will hold the 
                same values as the block. Then, make changes to the x value 
                of each block segment, by adding 1. If the move is valid
                we set blockshape to the temp block, otherwise the block
                stays the same. 
            
        AUTHOR

                Janila Khan

        DATE

                2:00pm 3/14/2018

        */
        /// </summary>
        /// <returns>Returns true if the block is able to move one unit to 
        /// the right, otherwise it will return false.</returns>
        public bool moveToRight()
        {
            // Create a temporary rectangle object and copy its values
            Rectangle[] temp = new Rectangle[4];
            Array.Copy(m_blockShape, temp, 4);

            // Move the each segment of the temp block one unit to the right
            for (int i = 0; i < temp.Length; ++i)
            {
                temp[i].X += m_blockWidth + 1;
            }

            // check if to see the move is valid
            if (isValidMove(temp))
            {
                m_blockShape = temp;
                blockColumn += 1;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /*
        TetrisBlocks::moveToLeft() 

        NAME

                TetrisBlocks::moveToLeft - Move the block one unit to the left.

        SYNOPSIS

                bool TetrisBlocks::moveToLeft();

        DESCRIPTION

                This function will move the block one unit to left. First,
                create a temporary rectangle which will hold the same
                values as the block. Then, make changes to the x value 
                of each block segment, by adding 1 and multiplying it by -1.
                If the move is valid we set blockshape to the temp block,
                otherwise the block stays the same. 
            
        AUTHOR

                Janila Khan

        DATE

                4:30pm 3/14/2018

        */
        /// </summary>
        /// <returns>Returns true if the block is able to move one unit to 
        /// the left, otherwise it will return false.</returns>
        public bool moveToLeft()
        {
            // Create a temporary rectangle object and copy its values
            Rectangle[] tempRects = new Rectangle[m_blockShape.Length];
            Array.Copy(m_blockShape, tempRects, m_blockShape.Length);

            // Move the each segment of the temp block one unit to the left
            for (int i = 0; i < tempRects.Length; ++i)
            {
                tempRects[i].X += ((m_blockWidth + 1) * -1);
            }
            
            // check if to see the move is valid
            if (isValidMove(tempRects))
            {
                m_blockShape = tempRects;
                blockColumn += -1;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /*
        TetrisBlocks::moveDown() 

        NAME

                TetrisBlocks::moveDown - Move the block one unit down.

        SYNOPSIS

                bool TetrisBlocks::moveToLeft();

        DESCRIPTION

                This function will move the block down one unit. First,
                create a temporary rectangle which will hold the same
                values as the block. Then, make changes to the y value 
                of each block segment, by adding 1. If the move is valid
                we set blockshape to the temp block, otherwise the block
                stays the same. 
            
        AUTHOR

                Janila Khan

        DATE

                6:00pm 3/14/2018

        */
        /// </summary>
        /// <returns>Returns true if the block is able to move down one unit,
        /// otherwise it will return false.</returns>
        public bool moveDown()
        {
            Rectangle[] tempRects = new Rectangle[m_blockShape.Length];
            Array.Copy(m_blockShape, tempRects, m_blockShape.Length);

            // Move the each segment of the temp block one unit down
            for (int i = 0; i < tempRects.Length; ++i)
            {
                tempRects[i].Y += m_blockHeight + 1;
            }

            // check if the move is valid
            if (isValidMove(tempRects))
            {
                m_blockShape = tempRects;
                blockRow += 1;
                return true;
            }
            else
            {
                return false;
            }
        }       

        /// <summary>
        /*
        TetrisBlocks::rotateLeft() 

        NAME

                TetrisBlocks::rotateLeft - Rotates counter clockwise

        SYNOPSIS

                void TetrisBlocks::rotateLeft();


        DESCRIPTION

                This function rotates the block counter clockwise

        AUTHOR

                Janila Khan

        DATE

                10:00am 3/18/2018

        */
        /// </summary>
        public void rotateLeft()
        {
            int length = block.GetLength(0);
            bool[,] tempShape = new bool[length, length];

            // rotate the block
            for (int i = length - 1; i >= 0; --i)
            {
                for (int j = 0; j <= length - 1; ++j)
                {
                    tempShape[j, (length - 1 - i)] = block[i, j];
                }
            }

            // Create the temp rectangle
            Rectangle[] temp = createBlocks(tempShape);

            // check if the move is valid
            if (isValidMove(temp))
            {
                block = tempShape;
                m_blockShape = temp;
            }
        }

        /// <summary>
        /*
        TetrisBlocks::rotateRigth() 

        NAME

                TetrisBlocks::rotateRight - Rotates clockwise

        SYNOPSIS

                void TetrisBlocks::rotateRight();


        DESCRIPTION

                This function rotates the block clockwise

        AUTHOR

                Janila Khan

        DATE

                2:00pm 3/18/2018

        */
        /// </summary>
        public void rotateRight()
        {
            // rotate the block clockwise
            rotateLeft();
            rotateLeft();
            rotateLeft();
        }

        /// <summary>
        /*
        TetrisBlocks::isValidMove() 

        NAME

                TetrisBlocks::isValidMove - Checks to see if the block
                                            can move to a specific location.

        SYNOPSIS

                bool TetrisBlocks::isValidMove(Rectangle[] block);
  
        DESCRIPTION

                This function will check to see if a block can move to a specific
                location on the board. The function will first check to see if the
                block segment passes the right, left and bottom boundaries of the
                board. Then the function checks if the a block segments hits another
                segment that is alreadt is set. If any of these conditions are true,
                returns false, otherwise true. 

        AUTHOR

                Janila Khan

        DATE

                10:00am 3/15/2018

        */
        /// </summary>
        /// <param name="block">A reference to the tetris block</param>
        /// <returns>Returns true if the block is able to move to a specific location,
        /// false otherwise. </returns>
        private bool isValidMove(Rectangle[] block)
        {
            // set the right and bottom boundaries
            // left boundaries is 0
            int right = ((m_blockWidth + 1) * 10) - m_blockHeight;
            int bottom = ((m_blockHeight + 1) * 20) - m_blockWidth;

            int length = block.Length;

            for (int i = 0; i < length; ++i)
            {
                // check the left, right, bottom boundaries 
                if (block[i].X < 0 || block[i].X > right || block[i].Y > bottom)
                {
                    return false;
                }
            }

            int x;
            int y;

            //check to see if other blocks are set
            for (int i = 0; i < length; ++i)
            {
                // Grid Coordinates  
                x = (block[i].X / (m_blockWidth + 1));
                y = (block[i].Y / (m_blockWidth + 1)); 

                // if the space is not empty the movement is not valid
                if (!m_board.isSpaceEmpty(x, y))
                {
                    return false;
                }
            }

            return true;
        }

        #region varibles
        
        // The different types of blocks
        private static bool[,] I_Block =
        {
            {false,false,false,false},
            {true,true,true,true},
            {false,false,false,false},
            {false,false,false,false}
        };

        private static bool[,] J_Block =
        {
            {false,false,true,false},
            {false,false,true,false},
            {false,true,true,false},
            {false,false,false,false }
        };

        private static bool[,] L_Block =
        {
            {false,true,false,false},
            {false,true,false,false},
            {false,true,true,false},
            {false,false,false,false}
        };

        private static bool[,] O_Block =
        {
            {false,false,false,false},
            {false,true,true,false},
            {false,true,true,false},
            {false,false,false,false}
        };

        private static bool[,] S_Block =
        {
            {false,false,false,false},
            {false,true,true,false},
            {true,true,false,false},
            {false,false,false,false}
        };

        private static bool[,] T_Block =
        {
            {false,false,false,false},
            {false,true,true,true},
            {false,false,true,false},
            {false,false,false,false}
        };

        private static bool[,] Z_Block =
        {
            {false,false,false,false},
            {false,true,true,false},
            {false,false,true,true},
            {false,false,false,false}
        };

        // An array that will hold the tetris blocks
        private static bool[][,] m_pieces = { I_Block, J_Block, L_Block, O_Block, S_Block, T_Block, Z_Block };

        // An array to hold the different colors of each block
        private Color[] m_piecesColor = { Color.SkyBlue, Color.Blue, Color.Orange, Color.Yellow, Color.Green, Color.Purple, Color.Red };

        private int m_blockWidth = 20;
        private int m_blockHeight = 20;

        private bool[,] block;
        private int num;
        private int blockRow;
        private int blockColumn;

        private TetrisBoard m_board;

        public Rectangle[] m_blockShape { get; set; }
        public Color m_blockColor { get; }
        
        #endregion
    }
}
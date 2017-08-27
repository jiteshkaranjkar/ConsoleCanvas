using System;

namespace CanvasDrawing
{
    /// <summary>
    /// draws the console canvas using given input values
    /// </summary>
    public class DrawingCanvas
    {
        #region private member variables
        private string[,] arrCanvas;
        private int width;
        private int height;
        private int startXPosition;
        private int startYPosition;
        #endregion private member variables

        #region public methods
        /// <summary>
        /// Draws canvas on console
        /// </summary>
        /// <param name="x1">input starting point on X-axis</param>
        /// <param name="x2">input end point on X-axis</param>
        /// <param name="y1">input starting point on y-axis</param>
        /// <param name="y2">input end point on y-axis</param>
        public bool DrawCanvas(int x1, int x2, int y1, int y2)
        {
            try
            {
                if (x1 == 0 && x2 > 0 && y1 == 0 && y2 > 0)
                {
                    //set basic height and width of canvas and starting position 
                    this.startXPosition = 1;
                    this.startYPosition = Console.CursorTop;

                    this.width = x2 + 2;
                    this.height = y2 + 2;

                    arrCanvas = new string[this.height + 2, this.width + 2];// initialized 2d array to identify the spots where the box has chars

                    DrawLine(0, 0, this.width - 1, 0, "-"); //First drew line on X-axis from x1(0) to x2(21) with y = 0
                    DrawLine(0, 1, 0, this.height - 2, "|");//Secondly drew line on Y-axis from y1(1) to y2(4) with x = 0
                    DrawLine(0, this.height - 1, this.width - 1, this.height - 1, "-"); //then drew line on X-axis from x1(0) to x2(21) with y = 6
                    DrawLine(this.width - 1, 1, this.width - 1, this.height - 2, "|");  //lastly drew line on Y-axis from y1(1) to y2(2)  with x = 18

                    return true;
                }
                else
                {
                    Console.WriteLine("Invalid input provided, try again with valid width and height.");
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Draws lines on console canvas
        /// </summary>
        /// <param name="x1">input starting point on X-axis</param>
        /// <param name="x2">input end point on X-axis</param>
        /// <param name="y1">input starting point on y-axis</param>
        /// <param name="y2">input end point on y-axis</param>
        /// <param name="lChar">character to be displayed</param>
        public void DrawLine(int x1, int y1, int x2, int y2, string lChar)
        {
            int i = 0;
            Console.SetCursorPosition(x1, y1 + 1);
            for (int j = y1 + 1; j < y2 + 2; j++)
            {
                for (i = x1; i < x2 + 1; i++)
                {
                    Console.SetCursorPosition(i, j);
                    Console.Write(lChar);
                    arrCanvas[j, i] = lChar.ToString();
                }
            }
        }

        /// <summary>
        /// Draws Rectangle on console canvas
        /// </summary>
        /// <param name="x1">input starting point on X-axis</param>
        /// <param name="x2">input end point on X-axis</param>
        /// <param name="y1">input starting point on y-axis</param>
        /// <param name="y2">input end point on y-axis</param>
        /// <param name="rchar">character to be displayed</param>
        public void DrawRectangle(int x1, int y1, int x2, int y2, string rchar)
        {
            DrawLine(x1, y1, x2, y1, rchar); //First drew line on X-axis from x1(14) to x2(18) with y = 1
            DrawLine(x1, y1, x1, y2, rchar); //Secondly drew line on Y-axis from y1(1) to y2(2) with x = 14
            DrawLine(x1, y2, x2, y2, rchar); //then drew line on X-axis from x1(14) to x2(18) with y = 3
            DrawLine(x2, y1, x2, y2, rchar); //lastly drew line on Y-axis from y1(1) to y2(2)  with x = 18
        }

        /// <summary>
        /// Draws/fills in the console canvas with a given char indicating color
        /// </summary>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="strColor"></param>
        public void BucketFill(int x1, int y1, string strColor)
        {
            if (x1 > 0 && y1 > 0 && x1 < this.width && y1 < this.height)
            {
                for (int j = this.startYPosition + 1; j < this.height; j++)
                {
                    for (int i = this.startXPosition; i < this.width; i++)
                    {
                        Console.SetCursorPosition(i, j);
                        if (string.IsNullOrEmpty(arrCanvas[j, i]))
                            Console.Write(strColor);
                    }
                }
            }
        }
        #endregion public methods
    }
}

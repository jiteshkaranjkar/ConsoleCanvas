using CanvasDrawing;
using System;

namespace CanvasConsole
{
    /// <summary>
    /// Check for Console input and processes input commands
    /// </summary>
    public class DrawCanvas
    {
        private bool isCanvasDone = false;

        /// <summary>
        /// Takes Input command and calls respective method to further processing
        /// </summary>
        /// <param name="draw"></param>
        /// <param name="inputArray"></param>
        /// <param name="xCursorPosition"></param>
        /// <param name="yCursorPosition"></param>
        public void CanvasCommands(DrawingCanvas drawing, string[] inputArray, int xCursorPosition, int yCursorPosition)
        {
            //call the drawing function as per input command
            switch (inputArray[0].Trim().ToUpper())
            {
                case CommandConst.C:
                    isCanvasDone = drawing.DrawCanvas(0, int.Parse(inputArray[1].Trim()), 0, int.Parse(inputArray[2].Trim()));
                    Console.SetCursorPosition(xCursorPosition, SetCusrsorPosition(yCursorPosition));
                    break;
                case CommandConst.L:
                    if (isCanvasDone)
                        drawing.DrawLine(int.Parse(inputArray[1].Trim()), int.Parse(inputArray[2].Trim()), int.Parse(inputArray[3].Trim()), int.Parse(inputArray[4].Trim()), "x");
                    else
                        Console.WriteLine("First create Canvas to draw a line");
                    Console.SetCursorPosition(xCursorPosition, SetCusrsorPosition(yCursorPosition));
                    break;
                case CommandConst.R:
                   if (isCanvasDone)
                        drawing.DrawRectangle(int.Parse(inputArray[1].Trim()), int.Parse(inputArray[2].Trim()), int.Parse(inputArray[3].Trim()), int.Parse(inputArray[4].Trim()), "x");
                    else
                        Console.WriteLine("First create Canvas to draw a Rectangle");
                    Console.SetCursorPosition(xCursorPosition, SetCusrsorPosition(yCursorPosition));
                    break;
                case CommandConst.B:
                    if (isCanvasDone)
                        drawing.BucketFill(int.Parse(inputArray[1].Trim()), int.Parse(inputArray[2].Trim()), inputArray[3].Trim());
                    else
                        Console.WriteLine("First create Canvas to fill it with color text");
                    Console.SetCursorPosition(xCursorPosition, SetCusrsorPosition(yCursorPosition));
                    break;
                case CommandConst.Q:
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Sets the cursor position on the console Canvas after reading input and drawing picture
        /// </summary>
        /// <param name="yCursorPosition">y axis position when cursor needs to be set</param>
        /// <returns>cursor position</returns>
        private int SetCusrsorPosition(int yCursorPosition)
        {
            if (Console.CursorTop > yCursorPosition)
                yCursorPosition = Console.CursorTop + 2;

            return yCursorPosition;
        }
    }
}

using CanvasDrawing;
using System;

namespace CanvasConsole
{
    /// <summary>
    /// Startup class, opens and listens to Console input
    /// </summary>
    class Canvas
    {
        static bool isFirstCommand = false;
        /// <summary>
        /// Main method, takes the Console input commands and values and processes
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            DrawCanvas drawCanvas = new DrawCanvas();
            DrawingCanvas drawing = new DrawingCanvas();

            try
            {
                while (true)
                {
                    //reading input command with values
                    string inputCommand = Console.ReadLine();

                    //split the input command
                    string[] inputArray = inputCommand.Split(' ');

                    //Validate the first input command
                    if (!CanvasCheck.CheckFirstCommand(inputArray[0].Trim().ToUpper()) && !isFirstCommand)
                    {
                        Console.WriteLine("Invalid input Command - First command should be 'C w h' to draw a Canvas");
                    }
                    else
                    {
                        isFirstCommand = true;

                        //get current cursor position to set it later after operation is done
                        int xCursorPosition = Console.CursorLeft;
                        int yCursorPosition = Console.CursorTop + 2;

                        //call Canvas drawing methods using input commands
                        drawCanvas.CanvasCommands(drawing, inputArray, xCursorPosition, yCursorPosition);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error occured : " + ex.Message);
                Console.ReadLine();
            }
            finally { }
        }

    }
}

namespace CanvasDrawing
{
    public class CanvasCheck
    {
        public static bool CheckFirstCommand(string firstCommand)
        {
            if (firstCommand == CommandConst.C)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}

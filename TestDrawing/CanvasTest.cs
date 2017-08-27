using CanvasDrawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestDrawing
{
    [TestClass]
    public class TestDrawing
    {
        private DrawingCanvas drawing;

        [TestInitialize]
        public void Initialize()
        {
            drawing = new DrawingCanvas();   
        }


        [TestMethod]
        public void CanvasFirstCommandCheck()
        {
            Assert.AreEqual(true, CanvasCheck.CheckFirstCommand("C"));
        }

        [TestMethod]
        public void CheckWidthHeight()
        {
            Assert.AreEqual(true, drawing.DrawCanvas(0, 20, 0, 4));
        }
        
        [TestCleanup]
        public void CleanUp()
        {

        }
    }
}

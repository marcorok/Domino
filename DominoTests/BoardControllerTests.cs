using DominoClient.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DominoTests
{

    [TestClass]
    internal class BoardControllerTests
    {
        [TestMethod]
        public void SetUpBoard_FromConstructor_Success() {
            //Arrange
            PaintElementsController pec = new PaintElementsController(new Rectangle());
            BoardController bc = new BoardController(pec);
            //Act
            bc.SetupBoard();
            //Assert

            //TilesList must contain 7 tiles
            Assert.AreEqual(7, bc.TilesList.Count);
            //P1 is not null
            Assert.IsNotNull(bc.Player1);
            //P2 is not null
            Assert.IsNotNull(bc.Player2);
            //CommandsHistory is not null
            Assert.IsNotNull(bc.CommandsHistory);
            //CommandsHistory is empty
            Assert.IsTrue(bc.CommandsHistory.Count == 0);
            //Board is not null
            Assert.IsNotNull(bc.Board);

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Commands;
using Robot.Enums;

namespace Robot.Tests
{
    [TestClass]
    public class PlaceCommandTests
    {
        [TestMethod]
        public void PlaceCommand_Default_Behaviour()
        {
            var robot = new Robot();

            var command = new PlaceCommand(robot);
            command.Execute("PLACE 2,3,SOUTH");

            Assert.AreEqual(2, robot.X);
            Assert.AreEqual(3, robot.Y);
            Assert.AreEqual(Direction.SOUTH, robot.F);
        }

        [TestMethod]
        public void PlaceCommand_CanBePlaceSomewhereElse()
        {
            var robot = new Robot();

            var command = new PlaceCommand(robot);
            command.Execute("PLACE 2,3,SOUTH");

            Assert.AreEqual(2, robot.X);
            Assert.AreEqual(3, robot.Y);
            Assert.AreEqual(Direction.SOUTH, robot.F);

            command.Execute("PLACE 4,4,WEST");

            Assert.AreEqual(4, robot.X);
            Assert.AreEqual(4, robot.Y);
            Assert.AreEqual(Direction.WEST, robot.F);
        }

        [TestMethod]
        public void PlaceCommand_CannotPlaceOutsideOfBoard()
        {
            var robot = new Robot();

            var command = new PlaceCommand(robot);
            command.Execute("PLACE 2,7,SOUTH");

            Assert.IsFalse(robot.X.HasValue); 
            Assert.IsFalse(robot.Y.HasValue);
        }

        [TestMethod]
        public void PlaceCommand_CannotPlaceOutsideOfBoard2()
        {
            var robot = new Robot();

            var command = new PlaceCommand(robot);
            command.Execute("PLACE -1,2,SOUTH");

            Assert.IsFalse(robot.X.HasValue);
            Assert.IsFalse(robot.Y.HasValue);
        }
    }
}

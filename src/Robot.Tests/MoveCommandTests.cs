using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Commands;
using Robot.Enums;

namespace Robot.Tests
{
    [TestClass]
    public class MoveCommandTests
    {
        [TestMethod]
        public void MoveCommand_MoveFromNorth_ChangesYCoordinate()
        {
            var robot = new Robot();
            robot.MoveTo(0, 0, Direction.NORTH);
                
            var command = new MoveCommand(robot);
            command.Execute("MOVE");

            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(1, robot.Y);
            Assert.AreEqual(Direction.NORTH, robot.F);
        }

        [TestMethod]
        public void MoveCommand_MoveFromEast_ChangesXCoordinate()
        {
            var robot = new Robot();
            robot.MoveTo(0, 0, Direction.EAST);

            var command = new MoveCommand(robot);
            command.Execute("MOVE");

            Assert.AreEqual(1, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.AreEqual(Direction.EAST, robot.F);
        }

        [TestMethod]
        public void MoveCommand_TryToMoveOffBoard_CommandIsIgnored()
        {
            var robot = new Robot();
            robot.MoveTo(4, 4, Direction.NORTH);

            var command = new MoveCommand(robot);
            command.Execute("MOVE");

            Assert.AreEqual(4, robot.X);
            Assert.AreEqual(4, robot.Y);
            Assert.AreEqual(Direction.NORTH, robot.F);
        }

        [TestMethod]
        public void MoveCommand_RobotThatHasNotBeenPlaced_WillIgnoreCommands()
        {
            var robot = new Robot();

            var command = new MoveCommand(robot);
            command.Execute("MOVE");

            Assert.IsFalse(robot.X.HasValue);
            Assert.IsFalse(robot.Y.HasValue);
        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Commands;
using Robot.Enums;

namespace Robot.Tests
{
    [TestClass]
    public class RotateCommandTests
    {
        [TestMethod]
        public void RotateCommand_RotatesLeftOnce_MovesFromNorthToWest()
        {
            var robot = new Robot();
            robot.MoveTo(0, 0, Direction.NORTH);
                
            var command = new RotateCommand(robot);
            command.Execute("LEFT");

            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.AreEqual(Direction.WEST, robot.F);
        }

        [TestMethod]
        public void RotateCommand_RotatesRightOnce_MovesFromNorthToWest()
        {
            var robot = new Robot();
            robot.MoveTo(0, 0, Direction.NORTH);

            var command = new RotateCommand(robot);
            command.Execute("RIGHT");

            Assert.AreEqual(0, robot.X);
            Assert.AreEqual(0, robot.Y);
            Assert.AreEqual(Direction.EAST, robot.F);
        }

        [TestMethod]
        public void RotateCommand_RotatingFourTimes_ShouldGoBackToWhereWeStarted()
        {
            var robot = new Robot();
            robot.MoveTo(2, 2, Direction.NORTH);

            var command = new RotateCommand(robot);
            command.Execute("LEFT");
            command.Execute("LEFT");
            command.Execute("LEFT");
            command.Execute("LEFT");

            Assert.AreEqual(2, robot.X);
            Assert.AreEqual(2, robot.Y);
            Assert.AreEqual(Direction.NORTH, robot.F);
        }

        [TestMethod]
        public void RotateCommand_RotatinLeftThenRight_ShouldGoBackToWhereWeStarted()
        {
            var robot = new Robot();
            robot.MoveTo(2, 2, Direction.NORTH);

            var command = new RotateCommand(robot);
            command.Execute("LEFT");
            command.Execute("RIGHT");
           
            Assert.AreEqual(2, robot.X);
            Assert.AreEqual(2, robot.Y);
            Assert.AreEqual(Direction.NORTH, robot.F);
        }

        [TestMethod]
        public void MoveCommand_RobotThatHasNotBeenPlaced_WillIgnoreCommands()
        {
            var robot = new Robot();

            var command = new RotateCommand(robot);
            command.Execute("LEFT");

            Assert.AreEqual(Direction.NORTH, robot.F);
        }
    }
}

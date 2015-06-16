using Microsoft.VisualStudio.TestTools.UnitTesting;
using Robot.Commands;
using Robot.Enums;

namespace Robot.Tests
{
    [TestClass]
    public class MultiCommandTests
    {
        [TestMethod]
        public void Test()
        {
            var robot = new Robot();
            robot.MoveTo(1,2,Direction.EAST);

            new MoveCommand(robot).Execute("MOVE");
            new MoveCommand(robot).Execute("MOVE");
            new RotateCommand(robot).Execute("LEFT");
            new MoveCommand(robot).Execute("MOVE");

            Assert.AreEqual(3, robot.X);
            Assert.AreEqual(3, robot.Y);
            Assert.AreEqual(Direction.NORTH, robot.F);
        }
    }
}

using Robot.Enums;

namespace Robot.Commands
{
    public class MoveCommand : BaseCommand
    {
        public MoveCommand(Robot robot) : base(robot)
        {
        }

        public override string Usage()
        {
            return "MOVE";
        }

        protected override bool PerformExecution(string command)
        {
            if (Robot.X.HasValue && Robot.Y.HasValue)
            {
                var x = Robot.X.Value;
                var y = Robot.Y.Value;

                switch (Robot.F)
                {
                    case Direction.NORTH:
                        y += 1;
                        break;
                    case Direction.SOUTH:
                        y -= 1;
                        break;
                    case Direction.EAST:
                        x += 1;
                        break;
                    case Direction.WEST:
                        x -= 1;
                        break;
                }

                return Robot.MoveTo(x, y, Robot.F);
            }

            return false;
        }

        protected override bool Parse(string command)
        {
            return command == "MOVE";
        }
    }
}
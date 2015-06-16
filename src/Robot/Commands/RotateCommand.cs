using System;
using System.Text.RegularExpressions;
using Robot.Enums;

namespace Robot.Commands
{
    public class RotateCommand : BaseCommand
    {
        public RotationDirection Direction { get; set; }

        public RotateCommand(Robot robot) : base(robot)
        {
        }

        public override string Usage()
        {
            return "<DIRECTION> where DIRECTION is in (LEFT, RIGHT)";
        }

        protected override bool PerformExecution(string command)
        {
            if (!Robot.X.HasValue || !Robot.Y.HasValue)
            {
                return false;
            }

            var newDirection = Mod((int)(Direction == RotationDirection.RIGHT ? Robot.F + 1 : Robot.F - 1), 4);
            return Robot.MoveTo(Robot.X.Value, Robot.Y.Value, (Direction)newDirection);
        }

        private int Mod(int x, int m)
        {
            return (x % m + m) % m;
        }

        protected override bool Parse(string command)
        {
            var regex = new Regex(@"(\bLEFT\b|\bRIGHT\b)");

            var match = regex.Match(command);

            if (match.Success)
            {
                Direction = (RotationDirection)Enum.Parse(typeof(RotationDirection), match.Groups[1].ToString());
                return true;
            }

            return false;
        }
    }
}
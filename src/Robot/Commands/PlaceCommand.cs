using System;
using System.Text.RegularExpressions;
using Robot.Enums;

namespace Robot.Commands
{
    public class PlaceCommand : BaseCommand
    {
        int X { get; set; }
        int Y { get; set; }
        Direction F { get; set; }

        public PlaceCommand(Robot robot)
            : base(robot)
        {
        }

        public override string Usage()
        {
            return "PLACE <X>,<Y>,<DIRECTION> where DIRECTION is in (NORTH, SOUTH EAST WEST)";
        }

        protected override bool PerformExecution(string command)
        {
            return Robot.MoveTo(X, Y, F);
        }

        protected override bool Parse(string command)
        {
            if (!string.IsNullOrWhiteSpace(command))
            {
                var regex = new Regex(@"PLACE (\d),(\d),(\bNORTH\b|\bSOUTH\b|\bEAST\b|\bWEST\b)");

                var match = regex.Match(command);

                if (match.Success)
                {
                    X = int.Parse(match.Groups[1].ToString());
                    Y = int.Parse(match.Groups[2].ToString());
                    F = (Direction) Enum.Parse(typeof (Direction), match.Groups[3].ToString());
                    return true;
                }
            }

            return false;
        }
    }
}
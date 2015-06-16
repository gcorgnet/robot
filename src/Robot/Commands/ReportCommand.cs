using System;

namespace Robot.Commands
{
    public class ReportCommand : BaseCommand
    {
        public ReportCommand(Robot robot) : base(robot)
        {
        }

        public override string Usage()
        {
            return "REPORT";
        }

        protected override bool PerformExecution(string command)
        {
            Console.WriteLine("{0},{1},{2}", Robot.X, Robot.Y, Robot.F);
            return true;
        }

        protected override bool Parse(string command)
        {
            return command == "REPORT";
        }
    }
}
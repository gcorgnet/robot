using System.Collections.Generic;
using System.Linq;

namespace Robot.Commands
{
    public class CommandFactory
    {
        private readonly List<BaseCommand> _commands;

        public CommandFactory(Robot robot)
        {
            _commands = new List<BaseCommand>
            {
                new PlaceCommand(robot),
                new MoveCommand(robot),
                new ReportCommand(robot),
                new RotateCommand(robot)
            };
        }

        public IEnumerable<BaseCommand> Commands { get { return _commands; } }  

        public BaseCommand GetCommand(string command)
        {
            return _commands.FirstOrDefault(x => x.CanExecute(command));
        }
    }
}

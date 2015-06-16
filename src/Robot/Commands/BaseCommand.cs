namespace Robot.Commands
{
    public abstract class BaseCommand
    {
        protected Robot Robot;

        protected BaseCommand(Robot robot)
        {
            Robot = robot;
        }

        public bool Execute(string command)
        {
            if (!Parse(command))
            {
                return false;
            }

            return PerformExecution(command);
        }

        public abstract string Usage();

        public bool CanExecute(string command)
        {
            return Parse(command);
        }

        protected abstract bool PerformExecution(string command);

        protected abstract bool Parse(string command);
    }
}
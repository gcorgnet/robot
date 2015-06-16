using System;
using Robot.Commands;

namespace Robot
{
    class Program
    {
        static void Main(string[] args)
        {
            var robot = new Robot();
            var cmdFactory = new CommandFactory(robot);

            while (true)
            {
                var input = Console.ReadLine();

                var cmd = cmdFactory.GetCommand(input);

                if (cmd != null)
                {
                    cmd.Execute(input);
                }
                else
                {
                    Console.WriteLine("Invalid Command");
                    Usage(cmdFactory);
                }
            }
        }

        private static void Usage(CommandFactory factory)
        {
            Console.WriteLine("Accepted Commands:");

            foreach (var baseCommand in factory.Commands)
            {
                Console.WriteLine(baseCommand.Usage());
            }
        }
    }
}

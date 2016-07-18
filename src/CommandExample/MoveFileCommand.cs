using System;
using System.IO;

namespace CommandExample
{
    class MoveFileCommand : ICommand
    {
        private readonly string source;
        private readonly string destination;

        public MoveFileCommand(string source, string destination)
        {
            this.source = source;
            this.destination = destination;
        }

        public void Execute()
        {
            new FileInfo(source).MoveTo(destination);

            if (new FileInfo(destination).Exists)
            {
                Console.WriteLine("Moved {0} to {1}", source, destination);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Could not move {0} to {1}", source, destination));
            }
        }

        public void Undo()
        {
            new FileInfo(destination).MoveTo(source);

            if (new FileInfo(source).Exists)
            {
                Console.WriteLine("Moved {0} to {1}", destination, source);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Could not move {0} to {1}", destination, source));
            }
        }
    }
}

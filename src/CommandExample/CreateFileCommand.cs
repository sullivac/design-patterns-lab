using System;
using System.IO;

namespace CommandExample
{
    class CreateFileCommand : ICommand
    {
        private readonly string fileName;

        public CreateFileCommand(string fileName)
        {
            this.fileName = fileName;
        }

        public void Execute()
        {
            using (new FileInfo(fileName).Create()) { }

            if (new FileInfo(fileName).Exists)
            {
                Console.WriteLine("Created file: {0}", fileName);
            }
            else
            {
                throw new InvalidOperationException(string.Format("Could not create file {0}", fileName));
            }
        }

        public void Undo()
        {
            new FileInfo(fileName).Delete();

            if (new FileInfo(fileName).Exists)
            {
                throw new InvalidOperationException(string.Format("Could not delete file {0}", fileName));
            }
            else
            {
                Console.WriteLine("Deleted file {0}", fileName);
            }
        }
    }
}

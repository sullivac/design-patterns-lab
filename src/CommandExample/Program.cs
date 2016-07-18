using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var createFile = new CreateFileCommand("output.txt");
            var moveFile = new MoveFileCommand("output.txt", "other.txt");

            createFile.Execute();
            moveFile.Execute();
            moveFile.Undo();
            createFile.Undo();
        }
    }
}

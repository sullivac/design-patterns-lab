using System;
using System.Linq;

namespace FactoryPattern
{
    public class AbstractFactoryClient
    {
        private const string SquareSnake = "SquareSnake";
        private const string Simple = "Simple";

        private readonly MazeClient mazeClient;
        private readonly string[] validMazeTypes = { SquareSnake, Simple };

        public AbstractFactoryClient(MazeClient mazeClient)
        {
            this.mazeClient = mazeClient;
        }

        public void Execute()
        {
            Console.Write("Enter maze type ({0}): ", string.Join(", ", validMazeTypes));
            string mazeType = Console.ReadLine();
            if (string.IsNullOrEmpty(mazeType))
            {
                mazeType = SquareSnake;
            }
            if (!validMazeTypes.Any(validMazeType => StringComparer.OrdinalIgnoreCase.Compare(validMazeType, mazeType) == 0))
            {
                throw new ArgumentException(string.Format("Unknown maze type {0}.", mazeType));
            }

            int length = 0;
            bool invalid = true;
            while (invalid)
            {
                Console.Write("Enter a length: ");
                string input = Console.ReadLine();
                if (string.IsNullOrEmpty(input))
                {
                    length = 4;

                    break;
                }
                if (input.StartsWith("q", StringComparison.OrdinalIgnoreCase)) { return; }

                invalid = !int.TryParse(input, out length);
            }

            ICreateMazes mazeFactory = null;
            if (StringComparer.OrdinalIgnoreCase.Compare(mazeType, SquareSnake) == 0)
            {
                mazeFactory = new SnakeSquareMazeFactory(length);
            }
            else if (StringComparer.OrdinalIgnoreCase.Compare(mazeType, Simple) == 0)
            {
                mazeFactory = new SimpleMazeFactory(length);
            }

            IMovePlayer maze = mazeFactory.Create();

            mazeClient.StartMaze(maze);
        }
    }
}

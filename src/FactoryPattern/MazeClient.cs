using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryPattern
{
    public class MazeClient
    {
        private readonly ICreateMazes mazeFactory;
        private readonly string[] northTokens = { "n", "north" };
        private readonly string[] eastTokens = { "e", "east" };
        private readonly string[] southTokens = { "s", "south" };
        private readonly string[] westTokens = { "w", "west" };
        private readonly string[] exitTokens = { "x", "exit" };
        private readonly string[] currentTokens = { "c", "current" };
        private readonly string[] validTokens;

        public MazeClient()
        {
            validTokens = northTokens.Concat(eastTokens)
                .Concat(southTokens)
                .Concat(westTokens)
                .Concat(exitTokens)
                .Concat(currentTokens)
                .ToArray();
        }

        public void StartMaze(IMovePlayer maze)
        {
            bool continuePlay = true;
            var player = new Player(maze);

            Action displayCurrentPosition = () => Console.WriteLine("Player is now in room {0}.", player.CurrentPosition);

            player.OnCurrentChanged = displayCurrentPosition;
            player.OnWait = () => Console.WriteLine("Player is still in room {0}.", player.CurrentPosition);
            player.OnDone = () =>
            {
                continuePlay = false;

                Console.WriteLine("Player has exited the maze.");
            };

            while (continuePlay)
            {
                Console.Write("Enter command (North, East, South, West, Current, Exit): ");
                string line = Console.ReadLine();

                IEnumerable<string> tokens = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                    .Where(IsValid);

                foreach (string token in tokens)
                {
                    if (northTokens.Any(Matches(token)))
                    {
                        player.MoveNorth();
                    }
                    else if (eastTokens.Any(Matches(token)))
                    {
                        player.MoveEast();
                    }
                    else if (southTokens.Any(Matches(token)))
                    {
                        player.MoveSouth();
                    }
                    else if (westTokens.Any(Matches(token)))
                    {
                        player.MoveWest();
                    }
                    else if (exitTokens.Any(Matches(token)))
                    {
                        continuePlay = false;
                    }
                    else if (currentTokens.Any(Matches(token)))
                    {
                        displayCurrentPosition();
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Unknown token {0}.", token), "token");
                    }
                }
            }
        }

        private bool IsValid(string token)
        {
            return validTokens.Any(Matches(token));
        }

        private Func<string, bool> Matches(string token)
        {
            return validToken => StringComparer.OrdinalIgnoreCase.Compare(validToken, token) == 0;
        }
    }
}

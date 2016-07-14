using System;
using System.Collections.Generic;
using System.Linq;

namespace FactoryPattern
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var client = new AbstractFactoryClient(new MazeClient());

            client.Execute();
        }
    }
}

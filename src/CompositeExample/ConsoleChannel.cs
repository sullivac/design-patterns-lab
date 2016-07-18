using System;

namespace CompositeExample
{
    public class ConsoleChannel : IChannel
    {
        public void Send(string message)
        {
            Console.WriteLine(message);
        }
    }
}

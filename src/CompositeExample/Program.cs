using System;
using System.IO;

namespace CompositeExample
{
    class Program
    {
        private readonly IChannel channel;

        public Program(IChannel channel)
        {
            if (channel == null) { throw new ArgumentNullException("channel", "channel is null."); }

            this.channel = channel;
        }

        static void Main(string[] args)
        {
            var compositeChannel = new CompositeChannel();
            compositeChannel.Add(new LoggingChannel(new ConsoleChannel()));
            compositeChannel.Add(new LoggingChannel(new FileChannel(new FileInfo("output.txt"))));
            compositeChannel.Add(new LoggingChannel(new FileChannel(new FileInfo("other.txt"))));

            new Program(compositeChannel).Execute();
        }

        public void Execute()
        {
            var run = true;
            while (run)
            {
                Console.Write("Enter a message or Quit: ");
                string line = Console.ReadLine();
                if (StringComparer.OrdinalIgnoreCase.Compare("quit", line) == 0)
                {
                    run = false;
                }
                else
                {
                    channel.Send(line);
                }
            }
        }
    }
}

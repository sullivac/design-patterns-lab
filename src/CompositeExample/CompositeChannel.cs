using System;
using System.Collections.Generic;

namespace CompositeExample
{
    class LoggingChannel : IChannel
    {
        private readonly IChannel channel;
        public LoggingChannel(IChannel channel)
        {
            this.channel = channel;
        }

        public void Send(string message)
        {
            channel.Send(message);

            Console.WriteLine("Message Sent!");
        }
    }
    class CompositeChannel : IChannel
    {
        private readonly List<IChannel> channels;

        public CompositeChannel()
        {
            channels = new List<IChannel>();
        }

        public void Add(IChannel channel)
        {
            if (channel == null) { throw new ArgumentNullException("channel", "channel is null."); }

            channels.Add(channel);
        }

        public void Send(string message)
        {
            foreach (var channel in channels)
            {
                channel.Send(message);
            }
        }
    }
}

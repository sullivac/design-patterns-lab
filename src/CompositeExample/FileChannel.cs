using System.IO;

namespace CompositeExample
{
    class FileChannel : IChannel
    {
        private readonly FileInfo file;

        public FileChannel(FileInfo file)
        {
            this.file = file;
        }

        public void Send(string message)
        {
            using (var stream = file.Open(FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            using (var streamWriter = new StreamWriter(stream))
            {
                streamWriter.WriteLine(message);

                stream.Flush();
            }
        }
    }
}

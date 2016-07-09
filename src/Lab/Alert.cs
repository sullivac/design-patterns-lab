using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab
{
    public class Alert
    {
        public Alert(string message, string type)
        {
            Message = message;
            Type = type;
        }

        public string Message { get; private set; }
        public string Type { get; private set; }

        
    }
}

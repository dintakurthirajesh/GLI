using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI.GlobalEntity
{
    public class ErrorException
    {
        public int ID { get; set; }
        public string ExceptionMsg { get; set; }
        public string ExceptionType { get; set; }
        public string ExceptionSource { get; set; }
        public string ExceptionURL { get; set; }
        public string Ip { get; set; }

    }
}

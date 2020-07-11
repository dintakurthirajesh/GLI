using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GLI.GlobalEntity
{
    public class Notifications
    {
        public int ID { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        //public HttpPostedFileBase Upload { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public byte[] FileContent { get; set; }
        public string HiddenValue { get; set; }
        public string Action { get; set; }

        public string HitCount { get; set; }
    }
}

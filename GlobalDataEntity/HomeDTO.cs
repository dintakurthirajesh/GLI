using System;

namespace GLI.GlobalEntity
{
    public class HomeDTO
    {
        public int ID { get; set; }
        public string NotificationTitle { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }

        //public HomeDTO()
        //{
        //    ID = 0;
        //    NotificationTitle = string.Empty;
        //    FromDate = null;
        //    ToDate = DateTime.MinValue;
        //}
    }
}

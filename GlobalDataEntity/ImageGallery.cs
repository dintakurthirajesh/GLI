using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace GLI.GlobalEntity
{
    public class ImageGallery
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string FileExt { get; set; }
        public byte[] FileContent { get; set; }
        public string UploadUrl { get; set; }
        public string HiddenValue { get; set; }
        public string Status { get; set; }
        public int CreatedBy { get; set; }
        public int ModifiedBy { get; set; }
        //public IFormFile UploadFile { set; get; }

        public List<Gallery> GalleryList { get; set; }


    }
    public class Gallery
    {
        public int ID { get; set; }
        public string FileName { get; set; }
        public string Action { get; set; }
    }
}

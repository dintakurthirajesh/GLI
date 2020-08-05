using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
<<<<<<< HEAD
using System.IO;
=======
>>>>>>> e1813bd233c9b4cf9444534e3dc776742aadd975

namespace GLI.GlobalEntity
{
    public class MemberShip
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string FatherName { get; set; }
        public DateTime DOB { get; set; }
        public string Nationality { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        //[RegularExpression(@"^[0-9]{6}$", ErrorMessage = "Invalid PinCode")]
        public int? Pin { get; set; }

        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]

        public Int64 PhoneNo { get; set; }

        //[RegularExpression(@"^([\w-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([\w-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$", ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        //[RegularExpression(@"^(\d{10})$", ErrorMessage = "Invalid Mobile")]
        public Int64 MobileNo { get; set; }
        public string Profession { get; set; }
        public string OtherDetails { get; set; }
        public string PhotoName { get; set; }
        public string PhotoType { get; set; }

        //[RegularExpression(@"^([a-zA-Z0-9\s_\\.\-:])+(.jpeg|.png|.jpg|.gif)$", ErrorMessage = "Invalid Photo Type")]
        public HttpPostedFileBase PhotoContent { get; set; }
        public string Ip { get; set; }
        public string Password { get; set; }

        public string Date { get; set; }

        public string Country { get; set; }

    }
}

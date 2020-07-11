using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GLI.GlobalEntity
{
    public class LoginDTO
    {
        public int Id { get; set; }
        [RegularExpression(@"^[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,6}$", ErrorMessage = "Invalid email.")]
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public bool Status { get; set; }
        public int RoleId { get; set; }
        public string DisplayName { get; set; }

        public int? MemberShipId { get; set; }
}
    }

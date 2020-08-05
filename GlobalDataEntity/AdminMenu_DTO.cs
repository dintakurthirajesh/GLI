using System;
using System.Collections.Generic;
using System.Text;

namespace GLI.GlobalEntity
{
    public class AdminMenu_DTO
    {
        public int? MenuId { get; set; }
        public string MenuName { get; set; }       

        public int? MainMenuId { get; set; }
        public string SubMenu { get; set; }
        public int? SubMenuId { get; set; }
        public int? ParentId { get; set; }
        public string PageUrl { get; set; }
    }

}

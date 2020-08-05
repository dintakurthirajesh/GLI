using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLI.GlobalEntity
{
    public class GliLaws
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int? MainMenuId { get; set; }
        public string SubMenu { get; set; }
        public int? ParentId { get; set; }
        public int? SubMenuId { get; set; }
        public int? PageUrl { get; set; }
        public string Ip { get; set; }
        public string UserName { get; set; }
    }
}

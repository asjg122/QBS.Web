using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.System
{
    [Table("TB_UserReceive")]
    public class UserReceive
    {
        public int id { get; set; }

        public int ReceiveId { get; set; }

        public int SysUserId { get; set; }


        public Identity.SysUser? SysUser { get; set; }
    }
}

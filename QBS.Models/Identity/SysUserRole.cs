using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Identity
{
    [Table("TB_SysUserRole")]
    public class SysUserRole : Microsoft.AspNetCore.Identity.IdentityUserRole<int>
    {
        public int Id { get; set; }
        public SysRole? Role { get; set; }

        public SysUser? User { get; set; }
    }
}

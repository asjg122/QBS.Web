using QBS.Models.System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Identity
{
    /// <summary>
    /// 系统角色
    /// </summary>
    [Table("TB_SysRole")]
    public class SysRole : Microsoft.AspNetCore.Identity.IdentityRole<int>
    {
        public ICollection<SysRoleMenu> SysRoleMenus { get; set; } = new HashSet<SysRoleMenu>();

        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();

    }
}

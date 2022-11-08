using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using QBS.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.DbManager.DbContexts
{
    public class QBSContext: IdentityDbContext<SysUser, SysRole, int,
                                                          SysUserClaim, SysUserRole, SysUserLogin,
                                                          SysRoleClaim, SysUserToken>
    {

    }
}

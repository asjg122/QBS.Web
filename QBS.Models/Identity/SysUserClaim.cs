using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Identity
{
    [Table("TB_SysUserClaim")]
    public class SysUserClaim : Microsoft.AspNetCore.Identity.IdentityUserClaim<int>
    {
    }
}

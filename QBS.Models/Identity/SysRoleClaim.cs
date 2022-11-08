using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Identity
{
    [Table("TB_SysRoleClaim")]
    public class SysRoleClaim : Microsoft.AspNetCore.Identity.IdentityRoleClaim<int>
    {
    }
}

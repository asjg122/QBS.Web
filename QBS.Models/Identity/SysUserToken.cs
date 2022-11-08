using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Identity
{

    [Table("TB_SysUserToken")]
    public class SysUserToken : Microsoft.AspNetCore.Identity.IdentityUserToken<int>
    {
        public int Id { get; set; }

    }
}

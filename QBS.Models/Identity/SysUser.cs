using QBS.Models.Normal;
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
    /// 系统用户
    /// </summary>
    [Table("TB_SysUser")]
    public class SysUser : Microsoft.AspNetCore.Identity.IdentityUser<int>
    {
        /// <summary>
        /// 支持登录时输入密码
        /// </summary>
        public string? LoginPassword { get; set; }
        public ICollection<SysUserRole> SysUserRoles { get; set; } = new HashSet<SysUserRole>();
        public ICollection<UserReceive> UserReceives { get; set; } = new HashSet<UserReceive>();
        public ICollection<NorUserCourse> UserCourses { get; set; } = new HashSet<NorUserCourse>();
        public ICollection<ExaminationPlan> ExaminationPlans { get; set; } = new HashSet<ExaminationPlan>();
        public ICollection<Test> Tests = new HashSet<Test>();
    }
}

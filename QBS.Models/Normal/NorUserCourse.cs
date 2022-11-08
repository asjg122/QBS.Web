using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 用户课程中间表
    /// </summary>
    [Table("TB_NorUserCourse")]
    public class NorUserCourse
    {
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int? CourseId { get; set; }

        public Identity.SysUser? User { get; set; }
        public Course? Course { get; set; }
    }
}

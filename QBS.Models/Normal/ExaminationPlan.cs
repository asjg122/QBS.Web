using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 考试计划
    /// </summary>
    [Table("Tb_ExaminationPlan")]
    public class ExaminationPlan
    {
        public int Id { get; set; }
        /// <summary>
        /// 考试名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 考试开始时间
        /// </summary>
        public DateTime? StartTime { get; set; }
        /// <summary>
        /// 考试结束时间
        /// </summary>
        public DateTime? EndTime { get; set; }
        /// <summary>
        /// 考试描述
        /// </summary>
        public string? Describe { get; set; }

        /// <summary>
        /// 用户编号
        /// </summary>
        public int? UserId { get; set; }
        public Identity.SysUser? User { get; set; }

        public List<Test> Tests { get; set; } = new List<Test>();
    }
}

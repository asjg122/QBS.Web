using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 试卷
    /// </summary>
    [Table("TB_Test")]
    public class Test
    {
        public int Id { get; set; }
        /// <summary>
        /// 试卷名
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 试卷版本
        /// </summary>
        public string? Edition { get; set; }
        /// <summary>
        /// 试卷类型
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// 试卷状态
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// 考试安排ID
        /// </summary>
        public int? PlanId { get; set; }
        public ExaminationPlan? ExaminationPlan { get; set; }

        /// <summary>
        /// 用户ID
        /// </summary>
        public int? UserId{ get; set; }
        public Identity.SysUser? User { get; set; }

        public List<TestQuestion> TestQuestions { get; set; } = new List<TestQuestion>();
    }
}

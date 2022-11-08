using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 试卷题目
    /// </summary>
    [Table("TB_TestQuestion")]
    public class TestQuestion
    {
        public int Id { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Describe { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        public string? Analysis { get; set; }
        /// <summary>
        /// 试题类型
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// 分数
        /// </summary>
        public int? Score { get; set; }

        /// <summary>
        /// 试卷ID
        /// </summary>
        public int? TestId { get; set; }
        public Test? Test { get; set; }

        public List<TestAnswer> TestAnswers { get; set; } = new List<TestAnswer>();
    }
}

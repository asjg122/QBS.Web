using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 试卷答案
    /// </summary>
    [Table("TB_TestAnswer")]
    public class TestAnswer
    {
        public int Id { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public string? Sort { get; set; }
        /// <summary>
        /// 顺序编号
        /// </summary>
        public int SortId { get; set; }
        /// <summary>
        /// 是否正确
        /// </summary>
        public string? IsRight { get; set; }

        /// <summary>
        /// 试卷题目ID
        /// </summary>
        public int TestQuestionId { get; set; }
        public TestQuestion? TestQuestion { get; set; }
    }
}

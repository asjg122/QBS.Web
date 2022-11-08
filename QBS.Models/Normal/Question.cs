using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 题目
    /// </summary>
    [Table("TB_Question")]
    public class Question
    {
        public int Id { get; set; }
        /// <summary>
        /// 描述
        /// </summary>
        public string? Describe { get; set; }
        /// <summary>
        /// 难易程度
        /// </summary>
        public string? Difficulty { get; set; }
        /// <summary>
        /// 解析
        /// </summary>
        public string? Analysis { get; set; }
        /// <summary>
        /// 试题类型
        /// </summary>
        public string? Type { get; set; }

        /// <summary>
        /// 题库编号
        /// </summary>
        public int? QuestionBankId { get; set; }
        public QuestionBank? QuestionBank { get; set; }

        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
        public Course? Course { get; set; }

        public List<Answer> Answers { get; set; } = new List<Answer>();
    }
}

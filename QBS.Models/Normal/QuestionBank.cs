using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 题库
    /// </summary>
    [Table("TB_QuestionBank")]
    public class QuestionBank
    {
        public int Id { get; set; }
        /// <summary>
        /// 题库名称
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// 题库介绍
        /// </summary>
        public string? Content { get; set; }
        /// <summary>
        /// 年级
        /// </summary>
        public string? Grade { get; set; }
   
        public Course? Course { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int? CourseId { get; set; }

        public List<Question> Questions { get; set; } = new List<Question>();
    }
}

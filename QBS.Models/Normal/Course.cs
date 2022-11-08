using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 课程
    /// </summary>
    [Table("TB_Course")]
    public class Course
    {
        public int Id { get; set; }
        /// <summary>
        /// 课程名称
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// 课程类别ID
        /// </summary>
        public int CourseTypeId { get; set; }
        public CourseType? CourseType { get; set; }

        public List<KnowledgePoints> KnowledgePoints { get; set; } = new List<KnowledgePoints>();

        public List<QuestionBank> QuestionBanks { get; set; } = new List<QuestionBank>();

        public List<Question> Questions { get; set; } = new List<Question>();

        public List<NorUserCourse> UserCourses { get; set; } = new List<NorUserCourse>();
    }  
}

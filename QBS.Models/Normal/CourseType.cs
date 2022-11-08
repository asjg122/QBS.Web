using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 课程类别
    /// </summary>
    [Table("TB_CourseType")]
    public class CourseType
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
    }
}

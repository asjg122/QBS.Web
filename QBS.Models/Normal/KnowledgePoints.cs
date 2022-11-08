using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 知识点
    /// </summary>
    [Table("TB_KnowledgePoints")]
    public class KnowledgePoints
    {
        public int Id { get; set; }
        /// <summary>
        /// 考点
        /// </summary>
        public string? ExaminationSite {get;set;}
        /// <summary>
        /// 内容
        /// </summary>
        public string? Content { get; set; }

        public KnowledgePointsRank? knowledgePointsRank { get; set; }
        /// <summary>
        /// 考试级别ID
        /// </summary>
        public int RankId { get; set; }

        public KnowledgePointsType? knowledgePointsType { get; set; }
        /// <summary>
        /// 种类ID
        /// </summary>
        public int TypeId { get; set; }

        public Course? Course { get; set; }
        /// <summary>
        /// 课程ID
        /// </summary>
        public int CourseId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 知识点级别
    /// </summary>
    [Table("TB_KnowledgePointsRank")]
    public class KnowledgePointsRank
    {
        public int Id { get; set; }
        /// <summary>
        /// 知识点级别名称
        /// </summary>
        public string? Name { get; set; }

        public List<KnowledgePoints> KnowledgePoints { get; set; } = new List<KnowledgePoints>();
    }
}

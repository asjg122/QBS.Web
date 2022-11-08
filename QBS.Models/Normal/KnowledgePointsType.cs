using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 知识点类别
    /// </summary>
    [Table("TB_KnowledgePointsType")]
    public class KnowledgePointsType
    {
        public int Id { get; set; }
        /// <summary>
        /// 知识点种类名称
        /// </summary>
        public string? Name { get; set; }
        public List<KnowledgePoints> KnowledgePoints { get; set; } = new List<KnowledgePoints>();
    }
}

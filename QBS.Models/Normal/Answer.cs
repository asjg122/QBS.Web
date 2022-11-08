using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBS.Models.Normal
{
    /// <summary>
    /// 答案
    /// </summary>
    [Table("TB_Answer")]
    public class Answer
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

        public int? QuestionId { get; set; }
        public Question? Question { get; set; }
    }
}

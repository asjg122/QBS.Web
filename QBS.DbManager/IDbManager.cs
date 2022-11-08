using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QBS.DbManager
{
    public interface IDbManager
    {
        /// <summary>
        /// DbContext上下文
        /// </summary>
        public QBS.DbManager.DbContexts.QBSDbContext Ctx { get; }

        public bool Save<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : class;

    }
}

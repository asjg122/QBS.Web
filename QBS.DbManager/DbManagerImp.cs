using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace QBS.DbManager
{
    /// <summary>
    /// 数据交互管理类
    /// </summary>
    public class DbManagerImp : IDbManager
    {
        private readonly QBS.DbManager.DbContexts.QBSDbContext m_Context;

        public DbManagerImp(QBS.DbManager.DbContexts.QBSDbContext context)
        {
            m_Context = context;
        }

        /// <summary>
        /// DbContext上下文
        /// </summary>
        public QBS.DbManager.DbContexts.QBSDbContext Ctx
        {
            get
            {
                return m_Context;
            }
        }

        /// <summary>
        /// 保存对象数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public bool Save<T>(T entity, Expression<Func<T, bool>> predicate = null) where T : class
        {
            if (predicate == null)
            {
                this.Ctx.Set<T>().Add(entity);
                return this.Ctx.SaveChanges() > 0;
            }
            else
            {
                var item = this.Ctx.Set<T>().SingleOrDefault(predicate);
                if (item == null)
                {
                    this.Ctx.Set<T>().Add(entity);
                    return this.Ctx.SaveChanges() > 0;
                }
                else
                {
                    var propts = entity.GetType().GetProperties();
                    foreach (var p in propts)
                    {
                        p.SetValue(item, p.GetValue(entity, null), null);
                    }
                    this.Ctx.SaveChanges();
                }

                return true;
            }
        }


    }
}

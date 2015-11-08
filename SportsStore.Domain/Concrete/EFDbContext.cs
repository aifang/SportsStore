using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SportsStore.Domain.Concrete
{
    /// <summary>
    /// 类似数据库里面的sql窗口，可以执行sql，作为事务中的内容，确定后可以提交,
    /// </summary>
    public class EFDbContext : DbContext
    {
        /// <summary>
        /// 属性名 Products（库中的表名），用Product实体类来表示
        /// </summary>
        public DbSet<Product> Products { get; set; }
    }
}

using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace SportsStore.Domain.Concrete
{
    /// <summary>
    /// 存储库类，实现IProductRepository接口，使用了一个EFDbContext实例
    /// </summary>
    public class EFProductRepository:IProductRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Product> Products
        {
            get { return context.Products; }
        }
    }
}

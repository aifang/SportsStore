using SportsStore.Domain.Entities;
using System.Linq;



namespace SportsStore.Domain.Abstract
{
    /// <summary>
    /// 创建一个抽象的存储库
    /// </summary>
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}

using NUI.Data.Infrastructure;
using NUI.Model.Models;
using System.Collections.Generic;
using System.Linq;

namespace NUI.Data.Repositoties
{
    //Khai bao interface de dung cac phuong thuc dac biet khong co trong RepositoryBase
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {
        //Cac nghiep vu dac biet ngoai cac phuong thuc co trong RepositoryBase
        IEnumerable<ProductCategory> GetByAlias(string alias);
    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        //Implement phuong thuc cua IProductCategoryRepository
        public IEnumerable<ProductCategory> GetByAlias(string alias)
        {
            return this.DbContext.ProductCategories.Where(x => x.Alias == alias);
        }
    }
}
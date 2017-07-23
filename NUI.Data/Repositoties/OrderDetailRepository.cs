using NUI.Data.Infrastructure;
using NUI.Model.Models;

namespace NUI.Data.Repositoties
{
    public interface IOrderDetailRepository
    {
    }

    public class OrderDetailRepository : RepositoryBase<OrderDetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
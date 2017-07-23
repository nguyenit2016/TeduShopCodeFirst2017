using NUI.Data.Infrastructure;
using NUI.Model.Models;

namespace NUI.Data.Repositoties
{
    public interface IOrderRepository
    {
    }

    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
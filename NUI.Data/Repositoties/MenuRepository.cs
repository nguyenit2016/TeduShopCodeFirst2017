using NUI.Data.Infrastructure;
using NUI.Model.Models;

namespace NUI.Data.Repositoties
{
    public interface IMenuRepository
    {
    }

    public class MenuRepository : RepositoryBase<Menu>, IMenuRepository
    {
        public MenuRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
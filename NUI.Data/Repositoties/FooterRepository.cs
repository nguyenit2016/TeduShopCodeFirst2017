using NUI.Data.Infrastructure;
using NUI.Model.Models;

namespace NUI.Data.Repositoties
{
    public interface IFooterRepository
    {
    }

    public class FooterRepository : RepositoryBase<Footer>, IFooterRepository
    {
        public FooterRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
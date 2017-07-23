using NUI.Data.Infrastructure;
using NUI.Model.Models;

namespace NUI.Data.Repositoties
{
    public interface ITagRepository
    {
    }

    public class TagRepository : RepositoryBase<Tag>, ITagRepository
    {
        public TagRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
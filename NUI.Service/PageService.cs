using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;

namespace NUI.Service
{
    public interface IPageService
    {
        Page GetByAlias(string alias);

        void SaveChanges();
    }

    public class PageService : IPageService
    {
        private IPageRepository _pageRepository;
        private IUnitOfWork _unitOfWork;

        public PageService(IPageRepository pageRepository, IUnitOfWork unitOfWork)
        {
            this._pageRepository = pageRepository;
            this._unitOfWork = unitOfWork;
        }

        public Page GetByAlias(string alias)
        {
            return this._pageRepository.GetSingleByCondition(x => x.Alias == alias);
        }

        public void SaveChanges()
        {
            this._unitOfWork.Commit();
        }
    }
}
using NUI.Common;
using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;

namespace NUI.Service
{
    public interface ICommonService
    {
        Footer GetFooter();
    }

    public class CommonService : ICommonService
    {
        private IFooterRepository _footerRepository;
        private IUnitOfWork _unitOfWork;

        public CommonService(IFooterRepository footerRepository, IUnitOfWork unitOfWork)
        {
            this._footerRepository = footerRepository;
            this._unitOfWork = unitOfWork;
        }

        public Footer GetFooter()
        {
            return _footerRepository.GetSingleByCondition(x => x.ID == CommonConstants.DefaultFooterId);
        }
    }
}
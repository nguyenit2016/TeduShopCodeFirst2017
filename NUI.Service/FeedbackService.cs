using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;

namespace NUI.Service
{
    public interface IFeedbackService
    {
        Feedback Create(Feedback feeback);

        void SaveChanges();
    }

    public class FeedbackService : IFeedbackService
    {
        private IFeedbackRepository _feedbackRepository;
        private IUnitOfWork _unitOfWork;

        public FeedbackService(IFeedbackRepository feedbackRepository, IUnitOfWork unitOfWork)
        {
            this._feedbackRepository = feedbackRepository;
            this._unitOfWork = unitOfWork;
        }

        public Feedback Create(Feedback feeback)
        {
            return _feedbackRepository.Add(feeback);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }
    }
}
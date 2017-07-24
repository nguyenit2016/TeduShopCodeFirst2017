using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;
using System.Collections.Generic;

namespace NUI.Service
{
    public interface IPostCategoryService
    {
        void Add(PostCategory postCategory);

        void Update(PostCategory postCategory);

        void Delete(int id);

        IEnumerable<PostCategory> GetAll();

        IEnumerable<PostCategory> GetAllByParentId(int parentId);

        PostCategory GetById(int id);

        void SaveChanges();
    }

    public class PostCategoryService : IPostCategoryService
    {
        private IPostCategoryRepository _postCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public void Add(PostCategory postCategory)
        {
            this._postCategoryRepository.Add(postCategory);
        }

        public void Delete(int id)
        {
            this._postCategoryRepository.Delete(id);
        }

        public IEnumerable<PostCategory> GetAll()
        {
            return this._postCategoryRepository.GetAll();
        }

        public IEnumerable<PostCategory> GetAllByParentId(int parentId)
        {
            return this._postCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public PostCategory GetById(int id)
        {
            return this._postCategoryRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            this._unitOfWork.Commit();
        }

        public void Update(PostCategory postCategory)
        {
            this._postCategoryRepository.Update(postCategory);
        }
    }
}
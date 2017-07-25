using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUI.Data.Infrastructure;
using NUI.Data.Repositoties;
using NUI.Model.Models;
using NUI.Service;
using System.Collections.Generic;

namespace NUI.UnitTest.ServiceTest
{
    [TestClass]
    public class PostCategoryServiceTest
    {
        private Mock<IPostCategoryRepository> _mockRepository;
        private Mock<IUnitOfWork> _mockUnitOfWork;
        private IPostCategoryService _categoryService;
        private List<PostCategory> _listCategory;

        [TestInitialize]
        public void Initialize()
        {
            _mockRepository = new Mock<IPostCategoryRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _categoryService = new PostCategoryService(_mockRepository.Object, _mockUnitOfWork.Object);
            _listCategory = new List<PostCategory>()
            {
                new PostCategory(){ID = 1,Name = "DM1",Alias = "DM1",Status=true,},
                new PostCategory(){ID = 2,Name = "DM2",Alias = "DM2",Status=true,},
                new PostCategory(){ID = 3,Name = "DM3",Alias = "DM3",Status=true,},
            };
        }

        [TestMethod]
        public void PostCategory_Service_Created()
        {
            PostCategory postCategory = new PostCategory();
            postCategory.Name = "Test";
            postCategory.Alias = "Test";
            postCategory.Status = true;

            _mockRepository.Setup(m => m.Add(postCategory)).Returns((PostCategory p) =>
              {
                  p.ID = 1;
                  return p;
              });

            var result = _categoryService.Add(postCategory);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.ID);
        }

        [TestMethod]
        public void PostCategory_Service_GetAll()
        {
            //Setup method
            _mockRepository.Setup(m => m.GetAll(null)).Returns(_listCategory);

            //Call action
            var result = _categoryService.GetAll() as List<PostCategory>;

            //Compare
            Assert.IsNotNull(result);
            Assert.AreEqual(3, result.Count);
        }
    }
}
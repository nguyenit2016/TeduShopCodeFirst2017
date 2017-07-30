using AutoMapper;
using NUI.Model.Models;
using NUI.Service;
using NUI.Web.Infrastructure.Core;
using NUI.Web.Models;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using NUI.Web.Infrastructure.Extentions;

namespace NUI.Web.Api
{
    [RoutePrefix("api/postcategory")]
    public class PostCategoryController : ApiControllerBase
    {
        private IPostCategoryService _postCategoryService;

        public PostCategoryController(IErrorService errorService, IPostCategoryService postCategoryService) : base(errorService)
        {
            this._postCategoryService = postCategoryService;
        }

        [Route("getall")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var listCategory = _postCategoryService.GetAll();
                var listPostCategoryVm = Mapper.Map<List<PostCategoryViewModel>>(listCategory);
                HttpResponseMessage response = request.CreateResponse(HttpStatusCode.OK, listPostCategoryVm);
                return response;
            });
        }

        [Route("add")]
        public HttpResponseMessage Post(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    PostCategory newPostCategory = new PostCategory();
                    newPostCategory.CoppyDataPostCategory(postCategoryVm);

                    var category = _postCategoryService.Add(newPostCategory);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK, category);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("update")]
        public HttpResponseMessage Put(HttpRequestMessage request, PostCategoryViewModel postCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    var postCategoryDb = _postCategoryService.GetById(postCategoryVm.ID);
                    postCategoryDb.CoppyDataPostCategory(postCategoryVm);

                    _postCategoryService.Update(postCategoryDb);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }

        [Route("delete")]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    _postCategoryService.Delete(id);
                    _postCategoryService.SaveChanges();

                    response = request.CreateResponse(HttpStatusCode.OK);
                }
                else
                {
                    request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return response;
            });
        }
    }
}
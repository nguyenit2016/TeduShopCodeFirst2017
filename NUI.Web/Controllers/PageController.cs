using AutoMapper;
using NUI.Model.Models;
using NUI.Service;
using NUI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NUI.Web.Controllers
{
    public class PageController : Controller
    {
        IPageService _pageService;

        public PageController(IPageService pageService)
        {
            this._pageService = pageService;
        }
        // GET: Page
        public ActionResult Index(string alias)
        {
            var pageModel = _pageService.GetByAlias(alias);
            var pageViewModel = Mapper.Map<Page, PageViewModel>(pageModel);
            if (pageViewModel != null)
                return View(pageViewModel);
            else
                return RedirectToAction("Index", "Home");
        }
    }
}
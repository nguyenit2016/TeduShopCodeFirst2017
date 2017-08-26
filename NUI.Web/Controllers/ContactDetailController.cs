using AutoMapper;
using BotDetect.Web.Mvc;
using NUI.Common;
using NUI.Model.Models;
using NUI.Service;
using NUI.Web.Infrastructure.Extentions;
using NUI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace NUI.Web.Controllers
{
    public class ContactDetailController : Controller
    {
        IContactDetailService _contactDetailService;
        IFeedbackService _feedbackService;

        public ContactDetailController(IContactDetailService contactDetailService, IFeedbackService feedbackService)
        {
            this._contactDetailService = contactDetailService;
            this._feedbackService = feedbackService;
        }

        // GET: ContactDetail
        public ActionResult Index()
        {
            FeedbackViewModel viewModel = new FeedbackViewModel();
            viewModel.ContactDetail = GetDetail();
            return View(viewModel);
        }

        [HttpPost]
        [CaptchaValidation("CaptchaCode", "ContactCaptcha", "Mã xác nhận không đúng!")]
        public ActionResult SendFeedback(FeedbackViewModel feedbackViewModel)
        {
            if(ModelState.IsValid)
            {
                Feedback newFeedback = new Feedback();
                newFeedback.CoppyDataFeedback(feedbackViewModel);
                _feedbackService.Create(newFeedback);
                _feedbackService.SaveChanges();

                ViewData["SuccessMsg"] = "Phản hồi đã được gởi đi";

                string content = System.IO.File.ReadAllText(Server.MapPath("~/Assets/Client/template/contact_template.html"));
                content = content.Replace("{{Name}}", feedbackViewModel.Name);
                content = content.Replace("{{Email}}", feedbackViewModel.Email);
                content = content.Replace("{{Message}}", feedbackViewModel.Message);
                var emailAdmin = ConfigHelper.GetByKey("EmailAdmin");
                MailHelper.SendMail(emailAdmin, "Thông tin liên hệ từ website", content);
                MailHelper.SendMail(feedbackViewModel.Email, "Thông tin phản hồi từ website", content);

                feedbackViewModel.Name = string.Empty;
                feedbackViewModel.Email = string.Empty;
                feedbackViewModel.Message = string.Empty;
            }
            feedbackViewModel.ContactDetail = GetDetail();
            return View("Index", feedbackViewModel);
        }
        private ContactDetailViewModel GetDetail()
        {
            var contactDetailmodel = _contactDetailService.GetDefaultContact();
            var contactDetailViewModel = Mapper.Map<ContactDetail, ContactDetailViewModel>(contactDetailmodel);
            return contactDetailViewModel;
        }
    }
}
using AutoMapper;
using Microsoft.AspNet.Identity;
using NUI.Common;
using NUI.Model.Models;
using NUI.Service;
using NUI.Web.App_Start;
using NUI.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using NUI.Web.Infrastructure.Extentions;

namespace NUI.Web.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;
        IOrderService _orderService;
        ApplicationUserManager _applicationUserManager;

        public CartController(IProductService productService, IOrderService orderService, ApplicationUserManager applicationUserManager)
        {
            this._productService = productService;
            this._orderService = orderService;
            this._applicationUserManager = applicationUserManager;
        }
        // GET: Cart
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Checkout()
        {
            if(Session[CommonConstants.SessionCart] == null)
            {
                return Redirect("/gio-hang.html");
            }
            return View();
        }

        public JsonResult CreateOrder(string orderViewModel)
        {
            var orderVM = new JavaScriptSerializer().Deserialize<OrderViewModel>(orderViewModel);
            var orderNew = new Order();
            orderNew.CoppyDataOrder(orderVM);

            if (Request.IsAuthenticated)
            {
                orderNew.CustomerId = User.Identity.GetUserId();
                orderNew.CrearedBy = User.Identity.GetUserName();
            }

            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            List<OrderDetail> orderDetails = new List<OrderDetail>();
            foreach (var item in cart)
            {
                var detail = new OrderDetail();
                detail.ProductID = item.ProductId;
                detail.Quantity = item.Quantity;
                orderDetails.Add(detail);
            }

            var result = _orderService.Add(orderNew, orderDetails);
            return Json(new
            {
                status = result
            });
        }

        public JsonResult GetUser()
        {
            if (Request.IsAuthenticated)
            {
                var userId = User.Identity.GetUserId();
                var user = _applicationUserManager.FindById(userId);
                return Json(new
                {
                    data = user,
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        public JsonResult GetAll()
        {
            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            return Json(new
            {
                data = cart,
                status = true
            }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Add(int productId)
        {
            var cart = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            if (cart == null)
                cart = new List<CartViewModel>();
            if(cart.Any(x=>x.ProductId == productId))
            {
                foreach (var item in cart)
                {
                    if (item.ProductId == productId)
                        item.Quantity += 1;
                }
            }
            else
            {
                CartViewModel newItem = new CartViewModel();
                newItem.ProductId = productId;
                var product = _productService.GetById(productId);
                newItem.Product = Mapper.Map<Product, ProductViewModel>(product);
                newItem.Quantity = 1;
                cart.Add(newItem);
            }
            Session[CommonConstants.SessionCart] = cart;
            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Update(string cartData)
        {
            var cartViewModel = new JavaScriptSerializer().Deserialize<List<CartViewModel>>(cartData);
            var cartSession = (List<CartViewModel>)Session[CommonConstants.SessionCart];

            foreach (var item in cartSession)
            {
                foreach (var jItem in cartViewModel)
                {
                    if(item.ProductId == jItem.ProductId)
                    {
                        item.Quantity = jItem.Quantity;
                    }
                }
            }

            Session[CommonConstants.SessionCart] = cartSession;

            return Json(new
            {
                status = true
            });
        }

        [HttpPost]
        public JsonResult Delete(int productId)
        {
            var cartSession = (List<CartViewModel>)Session[CommonConstants.SessionCart];
            if(cartSession != null)
            {
                cartSession.RemoveAll(x => x.ProductId == productId);
                Session[CommonConstants.SessionCart] = cartSession;
                return Json(new
                {
                    status = true
                });
            }
            return Json(new
            {
                status = false
            });
        }

        [HttpPost]
        public JsonResult DeleteAll()
        {
            Session[CommonConstants.SessionCart] = new List<CartViewModel>();
            return Json(new
            {
                status = true
            });
        }
    }
}
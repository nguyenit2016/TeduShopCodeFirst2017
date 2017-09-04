using AutoMapper;
using NUI.Model.Models;
using NUI.Web.Models;
using System;
using System.Collections.Generic;

namespace NUI.Web.Infrastructure.Extentions
{
    public static class EntityExtensions
    {
        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="postCategory"></param>
        /// <param name="postCategoryVm"></param>
        public static void CoppyDataPostCategory(this PostCategory postCategory, PostCategoryViewModel postCategoryVm)
        {
            postCategory.ID = postCategoryVm.ID;
            postCategory.Name = postCategoryVm.Name;
            postCategory.Alias = postCategoryVm.Alias;
            postCategory.Description = postCategoryVm.Description;
            postCategory.ParentID = postCategoryVm.ParentID;
            postCategory.DisplayOrder = postCategoryVm.DisplayOrder;
            postCategory.Images = postCategoryVm.Images;
            postCategory.HomeFlag = postCategoryVm.HomeFlag;
            postCategory.CreatedDate = postCategoryVm.CreatedDate;
            postCategory.CreatedBy = postCategoryVm.CreatedBy;
            postCategory.UpdatedDate = postCategoryVm.UpdatedDate;
            postCategory.UpdatedBy = postCategoryVm.UpdatedBy;
            postCategory.MetaKeyword = postCategoryVm.MetaKeyword;
            postCategory.MetaDescription = postCategoryVm.MetaDescription;
            postCategory.Status = postCategoryVm.Status;
        }

        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="post"></param>
        /// <param name="postVm"></param>
        public static void CoppyDataPost(this Post post, PostViewModel postVm)
        {
            post.ID = postVm.ID;
            post.Name = postVm.Name;
            post.Alias = postVm.Alias;
            post.CategoryID = postVm.CategoryID;
            post.Images = postVm.Images;
            post.Description = postVm.Description;
            post.Content = postVm.Content;
            post.HomeFlag = postVm.HomeFlag;
            post.HotFlag = postVm.HotFlag;
            post.ViewCount = postVm.ViewCount;
            post.CreatedBy = postVm.CreatedBy;
            post.UpdatedDate = postVm.UpdatedDate;
            post.UpdatedBy = postVm.UpdatedBy;
            post.MetaKeyword = postVm.MetaKeyword;
            post.MetaDescription = postVm.MetaDescription;
            post.Status = postVm.Status;
        }

        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="productCategory"></param>
        /// <param name="productCategoryVm"></param>
        public static void CoppyDataProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
            productCategory.Alias = productCategoryVm.Alias;
            productCategory.Description = productCategoryVm.Description;
            productCategory.ParentID = productCategoryVm.ParentID;
            productCategory.DisplayOrder = productCategoryVm.DisplayOrder;
            productCategory.Images = productCategoryVm.Images;
            productCategory.HomeFlag = productCategoryVm.HomeFlag;
            productCategory.CreatedDate = productCategoryVm.CreatedDate;
            productCategory.CreatedBy = productCategoryVm.CreatedBy;
            productCategory.UpdatedDate = productCategoryVm.UpdatedDate;
            productCategory.UpdatedBy = productCategoryVm.UpdatedBy;
            productCategory.MetaKeyword = productCategoryVm.MetaKeyword;
            productCategory.MetaDescription = productCategoryVm.MetaDescription;
            productCategory.Status = productCategoryVm.Status;
        }

        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="product"></param>
        /// <param name="productVm"></param>
        public static void CoppyDataProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.Alias = productVm.Alias;
            product.CategoryID = productVm.CategoryID;
            product.Images = productVm.Images;
            product.MoreImages = productVm.MoreImages;
            product.Price = productVm.Price;
            product.PromotionPrice = productVm.PromotionPrice;
            product.Warranty = productVm.Warranty;
            product.Description = productVm.Description;
            product.Content = productVm.Content;
            product.HomeFlag = productVm.HomeFlag;
            product.HotFlag = productVm.HotFlag;
            product.ViewCount = productVm.ViewCount;
            product.CreatedDate = productVm.CreatedDate;
            product.CreatedBy = productVm.CreatedBy;
            product.UpdatedDate = productVm.UpdatedDate;
            product.UpdatedBy = productVm.UpdatedBy;
            product.MetaKeyword = productVm.MetaKeyword;
            product.MetaDescription = productVm.MetaDescription;
            product.Status = productVm.Status;
            product.Tags = productVm.Tags;
            product.Quantity = productVm.Quantity;
        }

        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="feedback"></param>
        /// <param name="feedbackVm"></param>
        public static void CoppyDataFeedback(this Feedback feedback, FeedbackViewModel feedbackVm)
        {
            feedback.ID = feedbackVm.ID;
            feedback.Name = feedbackVm.Name;
            feedback.Email = feedbackVm.Email;
            feedback.Message = feedbackVm.Message;
            feedback.CreatedDate = DateTime.Now;
            feedback.Status = feedbackVm.Status;
        }

        /// <summary>
        /// Coppy data từ một đối tượng ViewModel sang một đối tượng Model
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderVm"></param>
        public static void CoppyDataOrder(this Order order, OrderViewModel orderVm)
        {
            order.ID = orderVm.ID;
            order.CustomerName = orderVm.CustomerName;
            order.CustomerAddress = orderVm.CustomerAddress;
            order.CustomerEmail = orderVm.CustomerEmail;
            order.CustomerMobile = orderVm.CustomerMobile;
            order.CustomerMessage = orderVm.CustomerMessage;
            order.PaymentMethod = orderVm.PaymentMethod;
            order.CrearedDate = DateTime.Now;
            order.CrearedBy = orderVm.CrearedBy;
            order.Status = orderVm.Status;
            order.CustomerId = orderVm.CustomerId;
        }
    }
}
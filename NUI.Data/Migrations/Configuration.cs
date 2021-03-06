﻿namespace NUI.Data.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Model.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<NUI.Data.NuiShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(NUI.Data.NuiShopDbContext context)
        {
            //CreateUserSample(context);
            CreateSlideSample(context);
            CreatePageSample(context);
            CreateContactDetailSample(context);
        }

        private void CreateUserSample(NuiShopDbContext context)
        {
            var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new NuiShopDbContext()));
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new NuiShopDbContext()));

            var user = new ApplicationUser()
            {
                UserName = "nguyen",
                Email = "nguyenpv1302@gmail.com",
                EmailConfirmed = true,
                BirthDay = DateTime.Now,
                FullName = "nguyen"
            };

            manager.Create(user, "123456");
            if (!roleManager.Roles.Any())
            {
                roleManager.Create(new IdentityRole { Name = "Admin" });
                roleManager.Create(new IdentityRole { Name = "User" });
            }

            var adminUser = manager.FindByEmail("nguyenpv1302@gmail.com");
            manager.AddToRoles(adminUser.Id, new string[] { "Admin", "User" });
        }

        private void CreateProductCategorySample(NuiShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory(){Name ="Product Category 1",Alias="Product-Category-1",Status=true},
                    new ProductCategory(){Name ="Product Category 2",Alias="Product-Category-2",Status=true},
                    new ProductCategory(){Name ="Product Category 3",Alias="Product-Category-3",Status=true}
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateSlideSample(NuiShopDbContext context)
        {
            if (context.Slides.Count() == 0)
            {
                List<Slide> listSlide = new List<Slide>()
                {
                    new Slide() {
                        Name ="Slide 1",
                        Status =true, URL="#",
                        Images ="/Assets/client/images/bag.jpg",
                        DisplayOrder =1,
                        Content = @"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"
                    },
                    new Slide() {
                        Name ="Slide 2",
                        Status =true, URL="#",
                        Images ="/Assets/client/images/bag1.jpg",
                        DisplayOrder =2,
                        Content = @"<h2>FLAT 50% 0FF</h2>
                                <label>FOR ALL PURCHASE <b>VALUE</b></label>
                                <p>Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et </p>
                                <span class=""on-get"">GET NOW</span>"
                    }
                };
                context.Slides.AddRange(listSlide);
                context.SaveChanges();
            }
        }

        private void CreatePageSample(NuiShopDbContext context)
        {
            if (context.Pages.Count() == 0)
            {
                var page = new Page()
                {
                    Name = "Giới thiệu",
                    Alias = "gioi-thieu",
                    Content = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book. It has survived not only five centuries, but also the leap into electronic typesetting, remaining essentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing Lorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.",
                    Status = true
                };
                context.Pages.Add(page);
                context.SaveChanges();
            }
        }

        private void CreateContactDetailSample(NuiShopDbContext context)
        {
            if (context.ContactDetails.Count() == 0)
            {
                var contactDetail = new NUI.Model.Models.ContactDetail()
                {
                    Name = "Giới thiệu",
                    Address = "123, Cộng Hòa, P. 12, Q. Tân Bình, Tp. Hồ Chí Minh",
                    Email = "nguyenpv1302@gmail.com",
                    Lat = 10.80152,
                    Lng = 106.650988,
                    Phone = "0946999878",
                    Website = "abc.com",
                    Other = "",
                    Status = true
                };
                context.ContactDetails.Add(contactDetail);
                context.SaveChanges();
            }
        }
    }
}
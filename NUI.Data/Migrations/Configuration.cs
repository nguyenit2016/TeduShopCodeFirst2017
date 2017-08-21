namespace NUI.Data.Migrations
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
    }
}
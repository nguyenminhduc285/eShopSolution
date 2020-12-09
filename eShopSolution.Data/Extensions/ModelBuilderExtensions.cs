﻿using eShopSolution.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace eShopSolution.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppConfig>().HasData(
                new AppConfig() { Key = "HomeTitle", Value = "This is home page of eShopSolution" },
                new AppConfig() { Key = "HomeKeyword", Value = "This is keyword eShopSolution" },
                new AppConfig() { Key = "HomeDescription", Value = "This is description of eShopSolution" }
                );

            modelBuilder.Entity<Language>().HasData(
                new Language() { Id = "vi", Name = "Tieng Viet", IsDefault = true },
                new Language() { Id = "en", Name = "English", IsDefault = false }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category()
                {
                    Id = 1,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 1,
                    Status = Enums.Status.Active,
                },
                new Category()
                {
                    Id = 2,
                    IsShowOnHome = true,
                    ParentId = null,
                    SortOrder = 2,
                    Status = Enums.Status.Active,
                }
                );
            modelBuilder.Entity<CategoryTranslation>().HasData(
                new CategoryTranslation()
                {
                    Id = 1,
                    CategoryId = 2,
                    Name = "Ao Khoac Nu",
                    LanguageId = "vi",
                    SeoAlias = "Ao Cho Nu",
                    SeoDescription = "San pham ao thoi trang nu",
                    SeoTitle = "Ao Khoac"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Woman Jacket",
                    LanguageId = "en",
                    SeoAlias = "Jaket for Female",
                    SeoDescription = "The Fashion Product for Female",
                    SeoTitle = "Jacket"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Ao Khoac Nam",
                    LanguageId = "vi",
                    SeoAlias = "Ao Cho Nam",
                    SeoDescription = "San pham ao thoi trang nam",
                    SeoTitle = "Ao Khoac"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Men Jacket",
                    LanguageId = "en",
                    SeoAlias = "Jaket for Male",
                    SeoDescription = "The Fashion Product for Male",
                    SeoTitle = "Jacket"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product()
                {
                    Id = 1,
                    DateCreated = DateTime.Now,
                    OriginalPrice = 100000,
                    Price = 200000,
                    Stock = 0,
                    ViewCount = 0,
                });

            modelBuilder.Entity<ProductTranslation>().HasData(
                new ProductTranslation()
                {
                    Id = 1,
                    ProductId = 1,
                    Name = "Ao Khoac Nam",
                    LanguageId = "vi",
                    SeoAlias = "Ao Cho Nam",
                    SeoDescription = "San pham ao thoi trang nam",
                    SeoTitle = "Ao Khoac",
                    Details = "Mo ta san pham",
                    Description = ""
                },
                new ProductTranslation()
                {
                    Id = 2,
                    ProductId = 1,
                    Name = "Men Jacket",
                    LanguageId = "en",
                    SeoAlias = "Jaket for Male",
                    SeoDescription = "The Fashion Product for Male",
                    SeoTitle = "Jacket",
                    Details = "Description of product",
                    Description = ""
                });

            modelBuilder.Entity<ProductInCategory>().HasData(
               new ProductInCategory() { ProductId = 1, CategoryId = 1 }
               );
            // any guid
            var roleId = new Guid("8D04DCE2-969A-435D-BBA4-DF3F325983DC");
            var adminId = new Guid("69BD714F-9576-45BA-B5B7-F00649BE00DE");
            modelBuilder.Entity<AppRole>().HasData(new AppRole
            {
                Id = roleId,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Administrator role"
            });

            var hasher = new PasswordHasher<AppUser>();
            modelBuilder.Entity<AppUser>().HasData(new AppUser
            {
                Id = adminId,
                UserName = "admin",
                NormalizedUserName = "admin",
                Email = "nguyenminhducit285@gmail.com",
                NormalizedEmail = "nguyenminhducit285@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "Abcd1234$"),
                SecurityStamp = string.Empty,
                FirstName = "Duc",
                LastName = "Nguyen Minh",
                Dob = new DateTime(2020, 01, 31)
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = roleId,
                UserId = adminId
            });
        }
    }
}
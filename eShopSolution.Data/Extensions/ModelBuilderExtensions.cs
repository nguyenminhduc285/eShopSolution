using eShopSolution.Data.Entities;
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
                new Language() { Id = "vi-VN", Name = "Tieng Viet", IsDefault = true },
                new Language() { Id = "en-US", Name = "English", IsDefault = false }
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
                    LanguageId = "vi-VN",
                    SeoAlias = "Ao Cho Nu",
                    SeoDescription = "San pham ao thoi trang nu",
                    SeoTitle = "Ao Khoac"
                },
                new CategoryTranslation()
                {
                    Id = 2,
                    CategoryId = 2,
                    Name = "Woman Jacket",
                    LanguageId = "en-US",
                    SeoAlias = "Jaket for Female",
                    SeoDescription = "The Fashion Product for Female",
                    SeoTitle = "Jacket"
                },
                new CategoryTranslation()
                {
                    Id = 3,
                    CategoryId = 1,
                    Name = "Ao Khoac Nam",
                    LanguageId = "vi-VN",
                    SeoAlias = "Ao Cho Nam",
                    SeoDescription = "San pham ao thoi trang nam",
                    SeoTitle = "Ao Khoac"
                },
                new CategoryTranslation()
                {
                    Id = 4,
                    CategoryId = 1,
                    Name = "Men Jacket",
                    LanguageId = "en-US",
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
                    LanguageId = "vi-VN",
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
                    LanguageId = "en-US",
                    SeoAlias = "Jaket for Male",
                    SeoDescription = "The Fashion Product for Male",
                    SeoTitle = "Jacket",
                    Details = "Description of product",
                    Description = ""
                });

            modelBuilder.Entity<ProductInCategory>().HasData(
               new ProductInCategory() { ProductId = 1, CategoryId = 1 }
               );

        }
    }
}

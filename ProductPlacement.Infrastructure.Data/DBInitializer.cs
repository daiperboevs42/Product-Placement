using Microsoft.EntityFrameworkCore.Query.Internal;
using ProdductPlacement.Core.Entity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace ProductPlacement.Infrastructure.Data
{
    public class DBInitializer
    {
        public static void SeedDB(ProductPlacementAppContext ctx)
        {
            ctx.Database.EnsureDeleted();
            ctx.Database.EnsureCreated();

            var user1 = ctx.Users.Add(new User()
            {
                IsAdmin = true,
                Username = "user",
            }).Entity;

            var firstProdType = ctx.ProductTypes.Add(new ProductType()
            {
                Name = "Arts n Craft"
            }).Entity;
            var secondProdType = ctx.ProductTypes.Add(new ProductType()
            {
                Name = "Recreational Firearm"
            }).Entity;
            var firstColor = ctx.Colors.Add(new Color()
            {
                Name = "White"
            }).Entity;
            var secondColor = ctx.Colors.Add(new Color()
            {
                Name = "Light Pine"
            }).Entity;
            var thirdColor = ctx.Colors.Add(new Color()
            {
                Name = "Gunmetal"
            }).Entity;
            var firstProd = ctx.Products.Add(new Product() 
            { 
                Name = "Glue",
                Color = firstColor,
                Price = 20,
                ProductType = firstProdType,
                CreatedDate = DateTime.Now
            }).Entity;
            var secondProd = ctx.Products.Add(new Product()
            {
                Name = "Wooden Sticks",
                Color = secondColor,
                Price = 25,
                ProductType = firstProdType,
                CreatedDate = DateTime.Now
            }).Entity;
            var thirdProd = ctx.Products.Add(new Product()
            {
                Name = "Colt M4A1",
                Color = thirdColor,
                Price = 15000,
                ProductType = secondProdType,
                CreatedDate = DateTime.Now
            }).Entity;
            ctx.SaveChanges();
        }
    }
}

namespace BSTicketSystem.Migrations
{
    using BSTicketSystem.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<BSTicketSystem.Models.BSTicketDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BSTicketSystem.Models.BSTicketDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Authority.AddOrUpdate(x => x.Id,
                    new Authority 
                    { 
                        //Id = 1, 
                        Authority_Name = "管理者" 
                    }
                );
            context.Member.AddOrUpdate(x => x.Id,
                    new Member
                    {
                        //Id = 1,
                        Email = "kevin790404@gmail.com",
                        Name = "kevin",
                        Password = "123456",
                        Tel = "0916-926-141",
                        Authority_Id = 1
                    }
                );
            context.Seat.AddOrUpdate(x => x.Id,
                    new Seat
                    {
                        //Id = 1,
                        Name = "A1",
                        C_left = "17",
                        C_top = "21",
                        Price = 280
                    }
                );
            context.Map.AddOrUpdate(x => x.Id,
                    new Map
                    {
                        //Id = 1,
                        Seat_Quantity = 28,
                        Seat_Id = 1,
                        IsAgree = true
                    }
                );
            context.Activity.AddOrUpdate(x => x.Id,
                    new Activity
                    {
                        //Id = 1,
                        Member_Id = 1,
                        Name = "David",
                        Address = "新竹市",
                        SetupTime = DateTime.Now,
                        ActivityTime = DateTime.Parse("2020-08-31"),
                        StartTime = DateTime.Parse("2020-07-22"),
                        EndTime = DateTime.Parse("2020-08-22"),
                        Quantity = 25,
                        Map_Id = 1
                    }
                );
            context.Img.AddOrUpdate(x => x.Id,
                    new Img 
                    { 
                        //Id = 1, 
                        ImgPath = "https://cf.shopee.tw/file/285a01f86e37702c571b3918818f403a_tn" 
                    }
                );
            context.ImgActivity.AddOrUpdate(x => x.Img_Id,
                    new ImgActivity
                    { 
                        Activity_Id = 1,
                        Img_Id = 1
                    }
                );
            context.Product.AddOrUpdate(x => x.Id,
                    new Product 
                    {
                        Id = 1,
                        Activity_Id = 1,
                        Name = "T-Shirt",
                        Price = 120,
                        Stock = 10,
                        Description = ""
                    }
                );
            context.ImgProduct.AddOrUpdate(x => x.Img_Id,
                    new ImgProduct { Img_Id = 1, Product_Id = 1}
                );
            context.Order.AddOrUpdate(x => x.Id,
                    new Order
                    {
                        Id = 1,
                        Member_Id = 1,
                        Activity_Id = 1,
                        Price = 240,
                        Payment_Method = "現金",
                        IsPay = true,
                        BuyTime = DateTime.Now,
                        Description = ""
                    }
                );
            context.OrderDetail.AddOrUpdate(x => x.Id,
                    new OrderDetail
                    {
                        Id = 1,
                        Order_Id = 1,
                        Product_Id = 1,
                        Quantity = 2
                    }
                );
        }
    }
}

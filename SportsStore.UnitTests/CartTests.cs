using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using System.Web.Mvc;
using System.Linq;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class CartTests
    {
        [TestMethod]
        public void Can_Add_To_Cart()
        {
            //准备-创建模仿库
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductID=1,Name="p1",Category="Apples"}}.AsQueryable());
            
            Cart cart = new Cart();

            CartController target = new CartController(mock.Object);

            target.AddToCart(cart, 1, null);

            Assert.AreEqual(cart.Lines.Count(), 1); Assert.AreEqual(cart.Lines.ToArray()[0].Product, 1);
        }


    }
}

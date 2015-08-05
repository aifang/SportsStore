using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Can_Pageinate()
        {
            //准备
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                {new Product{ProductID=1,Name="p1"},
                new Product{ProductID=2,Name="p2"},
                new Product{ProductID=3,Name="p3"},
                new Product{ProductID=4,Name="p4"},
                new Product{ProductID=5,Name="p5"}}.AsQueryable());
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //动作
            IEnumerable<Product> result = (IEnumerable<Product>)controller.List(2).Model;  //获取

            //断言
            Product[] prodArray = result.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "p4");
            Assert.AreEqual(prodArray[1].Name, "p5");
            //https://10.0.0.187/svn/建设_福建省_01建设厅/TLW-P2015-008_省外入闽工程监理企业和人员信息登记系统/01 项目开发/1.6 代码/1.6.1 trunk/zjkcbak
        }
    }
}

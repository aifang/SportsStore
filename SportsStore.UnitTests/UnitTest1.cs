using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using System.Linq;
using SportsStore.WebUI.Controllers;
using System.Collections;
using System.Collections.Generic;

using System.Web.Mvc;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;


namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        /// <summary>
        /// 单元测试：分页
        /// </summary>
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
            //创建分页控制器，并使页面显示产品数为3项
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //动作
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;  //获取

            //断言
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "p4");
            Assert.AreEqual(prodArray[1].Name, "p5");
            //https://10.0.0.187/svn/建设_福建省_01建设厅/TLW-P2015-008_省外入闽工程监理企业和人员信息登记系统/01 项目开发/1.6 代码/1.6.1 trunk/zjkcbak
        }

        /// <summary>
        /// 单元测试：创建页面链接
        /// </summary>
        [TestMethod]        
        public void Can_Generate_Page_Links()
        {
            //准备  定义一个HTML辅助器，为了运用扩展方法，需要这样
            HtmlHelper myHelper=null;
            //准备  创建PageInfo数据
            PagingInfo pagingInfo=new PagingInfo{
                CurrentPage=2,
                TotalItems=28,
                ItemsPerPage=10         
            };
            //准备 用lambda表达式建立委托
            Func<int, string> pageUrlDelegate = i => "Page" + i;
            //动作
            MvcHtmlString result = myHelper.PageLinks(pagingInfo, pageUrlDelegate);
            //断言
            Assert.AreEqual(result.ToString(), @"<a href=""Page1"">1</a>" + @"<a class=""selected"" href=""Page2"">2</a>" + @"<a href=""Page3"">3</a>");

        }

        /// <summary>
        /// 单元测试：页面模型视图数据
        /// </summary>
        [TestMethod]
        public void Can_Send_Pagination_View_Model()
        {
            //准备
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]{
                new Product{ProductID=1,Name="p1"},
                new Product{ProductID=2,Name="p2"},
                new Product{ProductID=3,Name="p3"},
                new Product{ProductID=4,Name="p4"},
                new Product{ProductID=5,Name="p5"}}.AsQueryable());
            
            //准备
            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //动作
            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            //断言
            PagingInfo pageInfo = result.PagingInfo;
            Assert.AreEqual(pageInfo.CurrentPage, 2);
            Assert.AreEqual(pageInfo.ItemsPerPage, 3);
            Assert.AreEqual(pageInfo.TotalItems, 5);
            Assert.AreEqual(pageInfo.TotalPage, 2);
        }

    }
}

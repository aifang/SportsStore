using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using SportsStore.WebUI.HtmlHelpers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //初始化接口
        private IProductRepository repositroy;
        public ProductController(IProductRepository productRepository)
        {
            this.repositroy = productRepository;
        }

        public ViewResult List()
        {
            return View(repositroy.Products);
        }
    }
}

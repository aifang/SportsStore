using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        //初始化接口
        private IProductRepository repositroy;
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repositroy = productRepository;
        }

        public ViewResult List(int page=1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repositroy.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = repositroy.Products.Count()
                }
            };
            return View(model);
            //return View(repositroy.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));

        }
    }
}

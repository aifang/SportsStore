using System;
using System.Web.Mvc;
using SportsStore.Domain.Entities;

namespace SportsStore.WebUI.Binders
{
    public class CartModelBinder:IModelBinder
    {
        private const string sessionKey="Cart";
        public object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            //通过会话获取Cart
            Cart cart = (Cart)controllerContext.HttpContext.Session[sessionKey];
            //若会话没有Cart，则创建一个
            if(cart==null)
            {
                cart = new Cart();
                controllerContext.HttpContext.Session[sessionKey] = cart;
            }
            //Cart
            return cart;
        }
    }
}
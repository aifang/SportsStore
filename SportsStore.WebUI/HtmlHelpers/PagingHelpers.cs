using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Web.Mvc;
using SportsStore.WebUI.Models;

namespace SportsStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html,PagingInfo pagingInfo, Func<int,string>pageUrl)
        {
            StringBuilder result = new StringBuilder();
            for(int i=1;i<=pagingInfo.TotalPage;i++)
            {
                TagBuilder tag = new TagBuilder("a");//构造一个a标签
                tag.MergeAttribute("herf", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if(i==pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.Append(tag.ToString());
            }
            return MvcHtmlString.Create(result.ToString());
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Web.Helpers
{
    public static class HtmlExtensions
    {
        public static Paging GetPages(this HtmlHelper html, int itemCount, int itemsPerPage)
        {
            int page;
            int itemsPerPageQuery;
            int.TryParse(HttpContext.Current.Request.QueryString["page"], out page);
            int.TryParse(HttpContext.Current.Request.QueryString["res"], out itemsPerPageQuery);
            if (page == 0) page = 1;
            if (itemsPerPageQuery != 0) itemsPerPage = itemsPerPageQuery;
            var pages = new Paging { ItemsPerPage = itemsPerPage, CurrentPage = page, PreviousPage = page - 1,
                NextPage = page + 1, TotalPages = Math.Ceiling(itemCount / (Double)itemsPerPage), Skip = (page * itemsPerPage) - itemsPerPage,
                Take = itemsPerPage,TotalResults=itemCount };
            return pages;
        }
    }
}
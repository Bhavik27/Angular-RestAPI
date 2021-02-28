using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebAPI.Infrastructure.Models.VModels
{
    public class PageModel
    {
        public int PageSize { get; set; }
        public int PageIndex { get; set; }
        public string OrderBy { get; set; }
        public string SortOrder { get; set; }
    }



    public static class PagingUtils
    {
        public static IQueryable<T> OrderAsc<T>(this IQueryable<T> ob, PageModel pageModel)
        {
            return ob.OrderBy(x => x.GetType().GetProperty(pageModel.OrderBy).GetValue(x))
                .Skip(pageModel.PageIndex * pageModel.PageSize)
                .Take(pageModel.PageSize);
        }
        public static IQueryable<T> OrderDesc<T>(this IQueryable<T> ob, PageModel pageModel)
        {
            return ob.OrderByDescending(x => x.GetType().GetProperty(pageModel.OrderBy).GetValue(x))
                .Skip(pageModel.PageIndex * pageModel.PageSize)
                .Take(pageModel.PageSize);
        }
    }
}

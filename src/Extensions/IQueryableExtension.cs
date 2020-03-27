﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using PersonelTakip.Core;

namespace PersonelTakip.Extensions
{
    public static  class IQueryableExtension
    {


        

       public static IQueryable<T> ApplyPaging<T>(this IQueryable<T> query,IQueryObject queryObject)
        {
            if (queryObject.Page <= 0)
                queryObject.Page = 1;
            if (queryObject.PageSize <= 0)
                queryObject.PageSize = 10;
           return query = query.Skip((queryObject.Page - 1) * queryObject.PageSize).Take(queryObject.PageSize);
       }
        public static IQueryable<T> ApplyOrdering<T>(this IQueryable<T> query, IQueryObject queryObj, Dictionary<string, Expression<Func<T, object>>> columnsMap)
        {
            if (string.IsNullOrWhiteSpace(queryObj.SortBy) || !columnsMap.ContainsKey(queryObj.SortBy))
                return query;

            if (queryObj.IsSortAscending)
                return query.OrderBy(columnsMap[queryObj.SortBy]);
            else
                return query.OrderByDescending(columnsMap[queryObj.SortBy]);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using CacheDependencyHelper;
using DotNetSoft.Model;

namespace DotNetSoft.WebHelper
{
    public class CategoryDataProxy
    {
        private static readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);
        private static readonly int categoryTimeout = int.Parse(ConfigurationManager.AppSettings["CategoryCacheDuration"]);

        public static List<Model.Category> GetList()
        {
            BLL.Category bll = new BLL.Category();

            if (!enableCaching)
                return bll.GetList();

            string key = "category_all";
            List<Model.Category> data = (List<Model.Category>)HttpRuntime.Cache[key];

            if (data == null)
            {
                data = bll.GetList();

                AggregateCacheDependency cd = DependencyFactory.GetProvinceCityDependency();

                HttpRuntime.Cache.Add(key, data, cd, DateTime.Now.AddHours(categoryTimeout), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            return data;
        }
    }
}

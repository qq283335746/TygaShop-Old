using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Web;
using System.Web.Caching;
using CacheDependencyHelper;

namespace DotNetSoft.WebHelper
{
    public class SiteContentDataProxy
    {
        private static readonly bool enableCaching = bool.Parse(ConfigurationManager.AppSettings["EnableCaching"]);
        private static readonly int siteContentTimeout = int.Parse(ConfigurationManager.AppSettings["SiteContentCacheDuration"]);

        /// <summary>
        /// 获取当前根节点下的所有内容类型和内容
        /// </summary>
        /// <param name="typeName"></param>
        /// <returns></returns>
        public static List<Model.ContentDetail> GetSiteContent()
        {
            BLL.ContentDetail bll = new BLL.ContentDetail();

            if (!enableCaching)
                return bll.GetSiteContent("站点所有帮助");

            string key = "sitecontent_all";
            List<Model.ContentDetail> data = (List<Model.ContentDetail>)HttpRuntime.Cache[key];

            if (data == null)
            {
                data = bll.GetSiteContent("站点所有帮助");

                AggregateCacheDependency cd = DependencyFactory.GetProvinceCityDependency();

                HttpRuntime.Cache.Add(key, data, cd, DateTime.Now.AddHours(siteContentTimeout), Cache.NoSlidingExpiration, CacheItemPriority.High, null);
            }

            return data;
        }
    }
}

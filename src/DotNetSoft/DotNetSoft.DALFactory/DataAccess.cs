using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Reflection;

namespace DotNetSoft.DALFactory
{
    public sealed class DataAccess
    {
        private static readonly string[] paths = ConfigurationManager.AppSettings["WebDALMsSqlProvider"].Split(',');

        public static IDAL.ICategory CreateCategory()
        {
            string className = paths[0] + ".Category";
            return (IDAL.ICategory)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.IProduct CreateProduct()
        {
            string className = paths[0] + ".Product";
            return (IDAL.IProduct)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.ISystemProfile CreateSystemProfile()
        {
            string className = paths[0] + ".SystemProfile";
            return (IDAL.ISystemProfile)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.IProvinceCity CreateProvinceCity()
        {
            string className = paths[0] + ".ProvinceCity";
            return (IDAL.IProvinceCity)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.IOrderInfo CreateOrderInfo()
        {
            string className = paths[0] + ".OrderInfo";
            return (IDAL.IOrderInfo)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.ISearchKeyword CreateSearchKeyword()
        {
            string className = paths[0] + ".SearchKeyword";
            return (IDAL.ISearchKeyword)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.IContentType CreateContentType()
        {
            string className = paths[0] + ".ContentType";
            return (IDAL.IContentType)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.IContentDetail CreateContentDetail()
        {
            string className = paths[0] + ".ContentDetail";
            return (IDAL.IContentDetail)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.Bbs.IContentType CreateBbsContentType()
        {
            string className = paths[0] + ".Bbs.ContentType";
            return (IDAL.Bbs.IContentType)Assembly.Load(paths[1]).CreateInstance(className);
        }

        public static IDAL.Bbs.IContentDetail CreateBbsContentDetail()
        {
            string className = paths[0] + ".Bbs.ContentDetail";
            return (IDAL.Bbs.IContentDetail)Assembly.Load(paths[1]).CreateInstance(className);
        }
      
    }
}

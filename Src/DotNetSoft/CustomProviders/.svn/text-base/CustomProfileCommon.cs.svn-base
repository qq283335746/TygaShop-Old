using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.Profile;

namespace CustomProviders
{
    public class CustomProfileCommon : ProfileBase
    {
        public new void Save()
        {
            HttpContext.Current.Profile.Save();
        }

        [SettingsAllowAnonymous(true)]
        [ProfileProvider("MsSqlProfileProvider")]
        public DotNetSoft.BLL.Cart ShoppingCart
        {
            get { return (DotNetSoft.BLL.Cart)HttpContext.Current.Profile.GetPropertyValue("ShoppingCart"); }
            set { HttpContext.Current.Profile.SetPropertyValue("ShoppingCart", value); }
        }

        [SettingsAllowAnonymous(true)]
        [ProfileProvider("MsSqlProfileProvider")]
        public DotNetSoft.BLL.UserAddress UserAddress
        {
            get { return (DotNetSoft.BLL.UserAddress)HttpContext.Current.Profile.GetPropertyValue("UserAddress"); }
            set { HttpContext.Current.Profile.SetPropertyValue("UserAddress", value); }
        }

        [SettingsAllowAnonymous(false)]
        [ProfileProvider("MsSqlProfileProvider")]
        public DotNetSoft.BLL.UserCustomAttr UserCustomAttr
        {
            get { return (DotNetSoft.BLL.UserCustomAttr)HttpContext.Current.Profile.GetPropertyValue("UserCustomAttr"); }
            set { HttpContext.Current.Profile.SetPropertyValue("UserCustomAttr", value); }
        }

        public CustomProfileCommon GetProfile(string userName,bool isAuthenticated)
        {
            return (CustomProfileCommon)ProfileBase.Create(userName, isAuthenticated);
        }

        public string GetUserName()
        {
            if (HttpContext.Current.Profile.IsAnonymous) return HttpContext.Current.Request.AnonymousID;
            else return HttpContext.Current.Profile.UserName;
        }
    }
}

using System;

namespace DotNetSoft.Model.Bbs
{
    public class ContentType
    {
        #region 成员方法

        public object NumberID { get; set; }
        public string TypeName { get; set; }
        public object ParentID { get; set; }
        public int Sort { get; set; }
        public string SameName { get; set; }
        public DateTime LastUpdatedDate { get; set; }

        #endregion
    }
}
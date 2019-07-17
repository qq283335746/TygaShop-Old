using System;

namespace DotNetSoft.Model
{
    public class SearchKeyword
    {
        #region 成员方法

        public object NumberID { get; set; }
        public string SearchName { get; set; }
        public int TotalCount { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public int DataCount { get; set; }

        #endregion
    }
}
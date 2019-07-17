using System;

namespace CacheDependencyHelper
{
    public class SearchKeyword : MsSqlCacheDependency
    {
        public SearchKeyword() : base("KeywordTableDependency") { }
    }
}

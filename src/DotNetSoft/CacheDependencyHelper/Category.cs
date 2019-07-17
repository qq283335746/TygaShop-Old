using System;

namespace CacheDependencyHelper
{
    public class Category : MsSqlCacheDependency
    {
        public Category() : base("CategoryTableDependency") { }
    }
}

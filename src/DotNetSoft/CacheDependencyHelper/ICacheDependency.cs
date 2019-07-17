using System.Web.Caching;

namespace CacheDependencyHelper
{
    public interface ICacheDependency
    {
        /// <summary>
        /// Method to create the appropriate implementation of Cache Dependency
        /// </summary>
        /// <returns>CacheDependency object(s) embedded in AggregateCacheDependency</returns>
        AggregateCacheDependency GetDependency();
    }
}

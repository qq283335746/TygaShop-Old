﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CacheDependencyHelper
{
    public class SiteContent : MsSqlCacheDependency
    {
        public SiteContent() : base("ContentTableDependency") { }
    }
}

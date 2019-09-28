﻿using System.Collections.Generic;

namespace Blog.Common
{
    public class PagedViewModel<T>
    {
        public int TotalCount { get; set; }
        public int TotalPage { get; set; }
        public int CurrentPage { get; set; }
        public IEnumerable<T> Data { get; set; }
    }
}
﻿using System.Net.Http;
using Blog.Data;

namespace Blog.Api
{
    public partial class Api
    {
        private readonly BlogContext _context;

        public Api(BlogContext context)
        {
            _context = context;
        }
    }
}
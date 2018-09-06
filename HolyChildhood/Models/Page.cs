﻿using System.Collections.Generic;

namespace HolyChildhood.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<PageContent> PageContents { get; set; }
        public Page Parent { get; set; }
        public List<Page> Children { get; set; }
    }
}
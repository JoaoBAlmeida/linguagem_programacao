using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace WebCrawler_Mangakakalot.Models
{
    [DebuggerDisplay("{Title}, {Link}")]
    public class Popular
    {
        public string Title { get; set; }
        public string Link { get; set; }
    }
}

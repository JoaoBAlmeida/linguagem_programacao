﻿using System;
using System.Collections.Generic;
using System.Text;

namespace WebCrawler_Mangakakalot.Template
{
    public class SpiderInsert : SpiderDAO
    {
        public SpiderInsert()
        {
            openDB();
        }
        protected override string GetConnectionURL()
        {
            return "SERVER=localhost;DATABASE=lp3;UID=root;PASSWORD=;";
        }

        //With this, it's possible to change with what table youre working
        //Change into args to "unlock" the possibility of inline code changing
        protected override string GetQuery()
        {
            return "INSERT INTO mangakakalot (Title, Link, Date) VALUES(@Title,@Link,@Date)";
        }
    }
}

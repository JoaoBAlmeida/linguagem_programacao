using System;
using System.Collections.Generic;
using System.Net;
using WebCrawler_Mangakakalot.Crawler;
using WebCrawler_Mangakakalot.Models;
using WebCrawler_Mangakakalot.Template;

namespace WebCrawler_Mangakakalot
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to WebCrawler Mangakakalot");
            Console.WriteLine("Do you want to collect data from web page?\nY|N");
            string ansr = Console.ReadLine().ToLower();
            if (ansr != "y") return;
            Console.WriteLine("With great waiting times, comes great loss of patience...");

            //Get data from web page into a list based off a model
            WebCrawler spider = new WebCrawler();
            List<Popular> pops = spider.startCrawler().GetAwaiter().GetResult();

            bool smartUser = false;
            while (!smartUser)
            {
                Console.WriteLine("======================");
                Console.WriteLine("What to to with all the collected info?");
                Console.WriteLine("1 - Upload into DataBase");
                Console.WriteLine("2 - Download From DataBase");
                int opt = Convert.ToInt32(Console.ReadLine());
                switch (opt)
                {
                    case 1:
                        //Putting each Popular into the database
                        SpiderInsert spider1 = new SpiderInsert();
                        foreach (Popular pop in pops)
                        {
                            spider1.SetIntoDB(pop);
                        }
                        Console.WriteLine("Upload Action Completed");
                        spider1.CloseBD();
                        smartUser = true;
                        break;
                    case 2:
                        Console.WriteLine("Not yet Implemented");
                        smartUser = true;
                        break;
                    default:
                        Console.WriteLine("Option not calibrated by the system");
                        continue;
                }
            }
            Console.WriteLine("Press Enter to exit program...");
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            if (keyInfo.Key == ConsoleKey.Enter) System.Environment.Exit(0);
        }
    }
}

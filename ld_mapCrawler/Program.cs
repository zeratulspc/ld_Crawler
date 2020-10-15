using System;
using System.Threading;

//셀레니움
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace ld_mapCrawler
{
    class Program
    {

        static void Main(string[] args)
        {
            using (IWebDriver driver = new ChromeDriver())
            {

                driver.Url = "https://m.naver.com/";

                while (true)
                {
                    //키 받기
                    ConsoleKey key = Console.ReadKey().Key;
                    if (key != ConsoleKey.Enter || key != ConsoleKey.C) // 키가 엔터면 진행
                    {
                        break;
                    } 

                    if (key == ConsoleKey.C) // 키가 C면 화면 싹쓸이
                    {
                        Console.Clear();
                    }

                    var rank = driver.FindElement(By.ClassName("_region_recommendplace_rank")); //장소추천 컴포넌트 찾기

                    for (int j = 1; j <= 5; j++) // idx 별로 탐색, 없으면 출력하지않음
                    {
                        try
                        {
                            var tgt = rank.FindElement(By.XPath("div[3]/div[2]/div/div[" + 1 + "]/ul/li[" + j + "]/a/div[2]/div[1]/strong"));
                            string title = tgt.Text;
                            if (title != "") 
                            {
                                Console.WriteLine(title);
                            }
                        }
                        catch (Exception e) { }
                    }

                    for (int j = 1; j <= 5; j++)
                    {
                        try
                        {
                            var tgt = rank.FindElement(By.XPath("div[3]/div[2]/div/div[" + 2 + "]/ul/li[" + j + "]/a/div[2]/div[1]/strong"));
                            string title = tgt.Text;
                            if (title != "")
                            {
                                Console.WriteLine(title);
                            }
                        }
                        catch (Exception e) { }
                    }

                    for (int j = 1; j <= 5; j++)
                    {
                        try
                        {
                            var tgt = rank.FindElement(By.XPath("div[3]/div[2]/div/div[" + 3 + "]/ul/li[" + j + "]/a/div[2]/div[1]/strong"));
                            string title = tgt.Text;
                            if (title != "")
                            {
                                Console.WriteLine(title);
                            }
                        }
                        catch (Exception e) { }
                    }
                }

                driver.Close(); // 엔터가 아닌
            }
        }
    }
}

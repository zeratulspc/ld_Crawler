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
                driver.Manage().Window.Maximize();

                driver.FindElement(By.Id("MM_SEARCH_FAKE")).Click();

                IWebElement q = driver.FindElement(By.Id("query"));
                q.SendKeys("서울 혼자서 가볼만한곳");
                driver.FindElement(By.ClassName("sch_submit")).Click();
                Thread.Sleep(5000);

                var rank = driver.FindElement(By.ClassName("_region_recommendplace_rank"));

                while (true)
                {
                    string key = Console.ReadLine();
                    if (key != "T" && key != "t")
                    {
                        break;
                    }

                    for (int j = 1; j <= 5; j++)
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


                /*
                 // 1위 제목 출력
                for (int i=1;i<=10;i++)
                {
                    var rank = driver.FindElement(By.ClassName("_cm_content_area_list_boxoffice"));
                    var rankOne = rank.FindElement(By.XPath(".//li["+i+"]/a/div/div[2]/strong"));
                    string title = rankOne.Text;
                    Console.WriteLine(title);
                } 
                 
                 */

                driver.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using System.Net;
namespace WebScraperRankBoost
{
      public class Scrapper
      {
         public static List<string> nameList = new List<string>();
         public static List<string> statsList = new List<string>(); 
         public static string listTester;
        
        public static void RefreshLists()
        {
            WebClient client = new WebClient();
            string stringPage = client.DownloadString("https://rankedboost.com/league-of-legends-wild-rift/items/");
            HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(stringPage);
            HtmlNodeCollection nodeList = doc.GetElementbyId("tierListTableWROneItems").ChildNodes;

            if (nodeList != null)
            {
                foreach (HtmlNode node in nodeList)
                {
                    var names = node.SelectNodes("//span[contains(@class, 'rune-name-lol-wr')]");
                    HtmlNodeCollection stats = doc.DocumentNode.SelectNodes("//div[@class='lolwr-champion-rank-table rune-td-lolwr-desc item-lol-wrlist']");

                    foreach (HtmlNode name in names)
                    {
                        nameList.Add(name.InnerText);
                    }
                    foreach (HtmlNode st in stats)
                    {
                        statsList.Add(st.InnerText);
                    }
                }
            }           
        }
      }
}

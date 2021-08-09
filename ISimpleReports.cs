using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    interface ISimpleReports
    {
        public string KeyWord(string context, string region, string domain);
        public string Concurents(string region, string domain);
    }

    interface IDashboard   //Дэшборд
    {
        public string Dashboard(string region, string domain);
        public string DashboardKey(string region, string keyword);
    }
    interface IContext   //Реклама
    {
        public string KeyWordObyavlenia(string region, string domain, int ads_id);
        public string Advertisement(string region, string domain, bool full);
        public string ULink(string region, string domain);
        public string UFact(string region, string domain);
    }
    interface IOrganic   //Органическая выдача
    {
        public string SitePage(string region, string domain);
        public string KeyWordPage(string region, string domain, string page_url);
        public string PageConcurents(string region, string domain, string page_url);
    }
    interface ISimilarkeys  //Дополняющие фразы
    {
        public string Similarkeys(string region, string keyword);
    }
    interface IOwner    //Сайт владельца
    {
        public string Owner(string id, string mode);
    }


    public class SimpleReports : ISimpleReports, IDashboard, IContext, IOrganic, ISimilarkeys, IOwner
    {
        public string Dashboard(string region, string domain)
        {
            string get = "report/simple/domain_dashboard";
            string request;
            //Dictionary<string, string> dict = new Dictionary<string, string>
            //{
            //    { "base", bse },
            //    {"domain",domain }
            //};

            //foreach (var item in dict)
            //{
            //    text = get + item.Key + item.Value;
            //}    

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }
        public string DashboardKey(string region, string keyword)
        {
            string get = "report/simple/domain_dashboard";
            string request;

            request = get + "?base=" + region + "&domain=" + keyword;
            return request;
        }
        
        public string KeyWordObyavlenia(string region, string domain, int ads_id)   //?????????????????????
        {
            string get = "report/simple/context/keywords/byads";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }
        public string Advertisement(string region, string domain, bool full)
        {
            string get = "report/simple/context/ads";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }
        public string UFact(string region, string domain)
        {
            string get = "report/simple/context/ads/facts";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }
        public string ULink(string region, string domain)
        {
            string get = "report/simple/context/ads/links";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }


        public string SitePage(string region, string domain)
        {
            string get = "report/simple/organic/sitepages";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }
        public string KeyWordPage(string region, string domain, string page_url)
        {
            string get = "report/simple/organic/keywords/bypage?";
            string request;

            request = get + "?base=" + region + "&domain=" + domain + "&page_url=" + page_url;
            return request;
        }
        public string PageConcurents(string region, string domain, string page_url)
        {
            string get = "report/simple/organic/concurent_pages";
            string request;

            request = get + "?base=" + region + "&domain=" + "&page_url=" + page_url;
            return request;
        }

        public string KeyWord(string context, string region, string domain)
        {
            if (context == "context" || context == "organic")
            {
                string get = "report/simple/" + context + "/keywords";

                string request = get + "?base=" + region + "&domain=" + domain;
                return request;
            }
            else
            {
                return "Неверный контекст";
            }
        }
        public string Concurents(string region, string domain)
        {
            string get = "report/simple/organic/concurents";
            string request;

            request = get + "?base=" + region + "&domain=" + domain;
            return request;
        }

        public string Owner(string id, string mode)
        {
            string get = "report/owner/";
            string request;

            //Dictionary<int, string> Mode = new Dictionary<int, string>
            //{
            //    {1, "analystics" },
            //    {2, "adsense" },
            //    {3, "leadia" },
            //    {4, "relapio" },
            //    {5, "subdomains" }
            //};
            request = get + mode + "?id=" + id;
            return request;

        }
        public string Similarkeys(string region, string keyword)
        {
            string get = "report/simple/similarkeys";
            string request;

            request = get + "?base=" + region + "&domain=" + keyword;
            return request;
        }



    }

}

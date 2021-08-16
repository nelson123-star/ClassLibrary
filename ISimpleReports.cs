using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClassLibrary
{
    interface ISimpleReports
    {
        public Task<string> KeyWord(string context, string @base, string domain);
        public Task<string> Concurents(string @base, string domain);
    }
    interface IDashboard   //Дэшборд
    {
        public Task<string> Dashboard(string @base, string domain);
        public Task<string> DashboardKey(string @base, string keyword);
    }
    interface IContext   //Реклама
    {
        public Task<string> KeyWordObyavlenia(string @base, string domain, int ads_id);
        public Task<string> Advertisement(string @base, string domain, bool full);
        public Task<string> ULink(string @base, string domain);
        public Task<string> UFact(string @base, string domain);
    }
    interface IOrganic   //Органическая выдача
    {
        public Task<string> SitePage(string @base, string domain);
        public Task<string> KeyWordPage(string @base, string domain, string page_url);
        public Task<string> PageConcurents(string @base, string domain, string page_url);
    }
    interface ISimilarkeys  //Дополняющие фразы
    {
        public Task<string> Similarkeys(string @base, string keyword);
    }
    interface IOwner    //Сайт владельца
    {
        public Task<string> Owner(string id, string mode);
    }


    public class SimpleReports : ISimpleReports, IDashboard, IContext, IOrganic, ISimilarkeys, IOwner
    {
        string token = string.Empty;
        private const string streamGet = "report/simple/";

        public SimpleReports()
        {
            vHttpClient client = new vHttpClient(token);
        }

        public async Task<string> Dashboard(string @base, string domain)
        {
            string get = "domain_dashboard";
           
            return streamGet + get + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> DashboardKey(string @base, string keyword)
        {
            string get = "report/simple/domain_dashboard";
            string request;

            request = get + "?base=" + @base + "&domain=" + keyword;
            return request;
        }
        
        public async Task<string> KeyWordObyavlenia(string @base, string domain, int ads_id)   //?????????????????????
        {
            string get = "report/simple/context/keywords/byads";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }
        public async Task<string> Advertisement(string @base, string domain, bool full)
        {
            string get = "report/simple/context/ads";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }
        public async Task<string> UFact(string @base, string domain)
        {
            string get = "report/simple/context/ads/facts";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }
        public async Task<string> ULink(string @base, string domain)
        {
            string get = "report/simple/context/ads/links";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }

        public async Task<string> SitePage(string @base, string domain)
        {
            string get = "report/simple/organic/sitepages";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }
        public async Task<string> KeyWordPage(string @base, string domain, string page_url)
        {
            string get = "report/simple/organic/keywords/bypage?";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain + "&page_url=" + page_url;
            return request;
        }
        public async Task<string> PageConcurents(string @base, string domain, string page_url)
        {
            string get = "report/simple/organic/concurent_pages";
            string request;

            request = get + "?base=" + @base + "&domain=" + "&page_url=" + page_url;
            return request;
        }

        public async Task<string> KeyWord(string context, string @base, string domain)
        {
            if (context == "context" || context == "organic")
            {
                string get = "report/simple/" + context + "/keywords";

                string request = get + "?base=" + @base + "&domain=" + domain;
                return request;
            }
            else
            {
                return "Неверный контекст";
            }
        }
        public async Task<string> Concurents(string @base, string domain)
        {
            string get = "report/simple/organic/concurents";
            string request;

            request = get + "?base=" + @base + "&domain=" + domain;
            return request;
        }

        public async Task<string> Owner(string id, string mode)
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
        public async Task<string> Similarkeys(string @base, string keyword)
        {
            string get = "report/simple/similarkeys";
            string request;

            request = get + "?base=" + @base + "&domain=" + keyword;
            return request;
        }



    }

}

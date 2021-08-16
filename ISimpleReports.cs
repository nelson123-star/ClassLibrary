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
        private const string baseUrl = "report/simple/";
        private readonly vHttpClient client;

        public SimpleReports(string token)
        {
            this.client = new vHttpClient(token);
        }

        public async Task<string> Dashboard(string @base, string domain)
        {
           string url = baseUrl + "domain_dashboard" + "?base=" + @base + "&domain=" + domain;
            return await client.GETAsync(url);
        }
        public async Task<string> DashboardKey(string @base, string keyword)
        {
            return baseUrl + "domain_dashboard" + "?base=" + @base + "&domain=" + keyword;
        }
        public async Task<string> KeyWordObyavlenia(string @base, string domain, int ads_id)   //?????????????????????
        {
            return baseUrl + "context/keywords/byads" + " ? base=" + @base + "&domain=" + domain;
        }
        public async Task<string> Advertisement(string @base, string domain, bool full)
        {
            return baseUrl + "context/ads" + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> UFact(string @base, string domain)
        {
            return baseUrl + "context/ads/facts" + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> ULink(string @base, string domain)
        {
            return baseUrl + "context/ads/links" + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> SitePage(string @base, string domain)
        {
            return baseUrl + "organic/sitepages" + "?base=" + @base + "&domain=" + domain;
        }
        public async Task<string> KeyWordPage(string @base, string domain, string page_url)
        {
            return baseUrl + "organic/keywords/bypage?" + "?base=" + @base + "&domain=" + domain + "&page_url=" + page_url;
        }
        public async Task<string> PageConcurents(string @base, string domain, string page_url)
        {
            return baseUrl + "organic/concurent_pages" + "?base=" + @base + "&domain=" + "&page_url=" + page_url;
        }
        public async Task<string> KeyWord(string context, string @base, string domain)
        {
            if (context == "context" || context == "organic")
            {
                return baseUrl + context + "/keywords" + "?base=" + @base + "&domain=" + domain; 
            }
            else
            {
                return "Неверный контекст";
            }
        }
        public async Task<string> Concurents(string @base, string domain)
        {
            return baseUrl + "organic/concurents" + "?base=" + @base + "&domain=" + domain;;
        }
        public async Task<string> Owner(string id, string mode)
        {
            return "report/owner/" + mode + "?id=" + id;
        }
        public async Task<string> Similarkeys(string @base, string keyword)
        {
            return  baseUrl + "similarkeys" + "?base=" + @base + "&domain=" + keyword;;
        }



    }

}

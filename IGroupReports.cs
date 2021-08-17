using System.Threading.Tasks;

namespace ClassLibrary
{
    interface IOrganicGroup
    {
        public Task<string> KeyWord(string rid);
        public Task<string> ConcurentsGroup(string rid);
        public Task<string> SitePage(string rid);
    }
    interface IContextGroup
    {
        public Task<string> KeyWordContext(string rid);
        public Task<string> ConcurentsGroupContext(string rid);
        public Task<string> Advertisement(string rid);
        public Task<string> AdsLinks(string rid);
        public Task<string> AdsFacts(string rid);
    }
    interface IReports
    {
        public Task<string> CreateReport(string @base, string domains, string name); 
    }

    class IGroupReports : IOrganicGroup, IContextGroup, IReports
    {
        private const string baseUrl = "report/group/";
        private const string baseUrlOrg = "organic/";
        private const string baseUrlCon = "context/";


        public async Task<string> KeyWord(string rid)
        {
            return baseUrl + baseUrlOrg + "keywords/" + rid;
        }
        public async Task<string> SitePage(string rid)
        {
            return baseUrl + baseUrlOrg + "sitepages/" + rid;
        }
        public async Task<string> ConcurentsGroup(string rid)
        {
            return baseUrl + baseUrlOrg + "concurents/" + rid;
        }


        public async Task<string> AdsFacts(string rid)
        {
            return baseUrl + baseUrlCon + "ads/facts/" + rid;
        }
        public async Task<string> AdsLinks(string rid)
        {
            return baseUrl + baseUrlCon + "ads/links/" + rid;
        }
        public async Task<string> Advertisement(string rid)
        {
            return baseUrl + baseUrlCon + "ads/" + rid;
        }
        public async Task<string> KeyWordContext(string rid)
        {
            return baseUrl + baseUrlCon + "keywords/" + rid;
        }
        public async Task<string> ConcurentsGroupContext(string rid)
        {
            return baseUrl + baseUrlCon + "concurents/" + rid;
        }


        public async Task<string> CreateReport(string @base, string domains, string name)
        {
            return baseUrl;
        }


    }
}

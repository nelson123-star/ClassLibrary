using System.Collections.Generic;
using Newtonsoft.Json;


namespace ClassLibrary.KeysSoModel
{
    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse); 
    public class Top
    {
        [JsonProperty("pos")]
        public int Pos { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("it1")]
        public int It1 { get; set; }

        [JsonProperty("it3")]
        public int It3 { get; set; }

        [JsonProperty("it5")]
        public int It5 { get; set; }

        [JsonProperty("it10")]
        public int It10 { get; set; }

        [JsonProperty("it50")]
        public int It50 { get; set; }

        [JsonProperty("pit1")]
        public int Pit1 { get; set; }

        [JsonProperty("pit5")]
        public int Pit5 { get; set; }

        [JsonProperty("pit10")]
        public int Pit10 { get; set; }

        [JsonProperty("pit50")]
        public int Pit50 { get; set; }

        [JsonProperty("adsenseid")]
        public string Adsenseid { get; set; }

        [JsonProperty("analytics")]
        public int Analytics { get; set; }

        [JsonProperty("pagesinindex")]
        public int Pagesinindex { get; set; }

        [JsonProperty("vis")]
        public int Vis { get; set; }
    }

    public class Gr
    {
        [JsonProperty("pos")]
        public int Pos { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("txt")]
        public string Txt { get; set; }

        [JsonProperty("adscnt")]
        public int Adscnt { get; set; }

        [JsonProperty("adkeyscnt")]
        public int Adkeyscnt { get; set; }

        [JsonProperty("facts")]
        public List<object> Facts { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }
    }

    public class Pr
    {
        [JsonProperty("pos")]
        public int Pos { get; set; }

        [JsonProperty("domain")]
        public string Domain { get; set; }

        [JsonProperty("header")]
        public string Header { get; set; }

        [JsonProperty("txt")]
        public string Txt { get; set; }

        [JsonProperty("adscnt")]
        public int Adscnt { get; set; }

        [JsonProperty("adkeyscnt")]
        public int Adkeyscnt { get; set; }

        [JsonProperty("facts")]
        public List<string> Facts { get; set; }

        [JsonProperty("links")]
        public List<string> Links { get; set; }
    }

    public class Ads
    {
        [JsonProperty("gr")]
        public List<Gr> Gr { get; set; }

        [JsonProperty("pr")]
        public List<Pr> Pr { get; set; }
    }

    public class Similar
    {
        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("wsk")]
        public int Wsk { get; set; }

        [JsonProperty("cnt")]
        public string Cnt { get; set; }

        [JsonProperty("ws")]
        public int Ws { get; set; }

        [JsonProperty("docs")]
        public int Docs { get; set; }

        [JsonProperty("pr0amn")]
        public int Pr0amn { get; set; }

        [JsonProperty("pr0ctr")]
        public double Pr0ctr { get; set; }
    }

    public class Root
    {
        [JsonProperty("id")]
        public int Id { get; set; }

        [JsonProperty("word")]
        public string Word { get; set; }

        [JsonProperty("ws")]
        public int Ws { get; set; }

        [JsonProperty("wsk")]
        public int Wsk { get; set; }

        [JsonProperty("docs")]
        public int Docs { get; set; }

        [JsonProperty("top")]
        public List<Top> Top { get; set; }

        [JsonProperty("ads")]
        public Ads Ads { get; set; }

        [JsonProperty("similar")]
        public List<Similar> Similar { get; set; }
    }


}

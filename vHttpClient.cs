using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class vHttpClient
    {
        private HttpClient _client;
        private IEnumerable<string> contents;
        private readonly string _token;
        private const string BaseUrl = "https://api.keys.so/";
        private readonly string _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:83.0) Gecko/20100101 Firefox/83.0 ";
        private static readonly object SyncObj = new object();


        vHttpClient(string token)
        {
            _client = new HttpClient();
            _token = token;
        }

        public async Task<string> GETAsync(string Uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_client.BaseAddress.ToString() + Uri}");
            string error = string.Empty;

            try
            {
                var response = await _client.SendAsync(requestMessage);

                HttpContent content = response.Content;
                var inf = content.ReadAsStreamAsync().ToString();
                return inf;
            }
            catch (Exception ex)
            {
                lock(SyncObj)
                {
                    error = $"Сообщение: Пользовательское сообщение: ошибка GETasync; Ошибка: {ex.Message}";
                    File.AppendAllLines(error, contents, Encoding.UTF8);
                }
            }

            return null;
        }

        public async Task<string> POSTAsync(string Uri, string content)
        {
            HttpContent Content = new StringContent(content);
            string error = string.Empty;

            try
            {
                var requestMessage = new HttpRequestMessage();
                requestMessage.RequestUri = new Uri(Uri);
                requestMessage.Method = HttpMethod.Post;
                byte[] byteArray = Encoding.UTF8.GetBytes(content);
                //var Content = byteArray.ToString();
                requestMessage.Content = Content;
                
                return await _client.SendAsync(requestMessage).Result.Content.ReadAsStringAsync();
            }
            catch (Exception ex)
            {
                lock (SyncObj)
                {
                    error = $"Сообщение: Пользовательское сообщение: ошибка GETasync; Ошибка: {ex.Message}";
                    File.AppendAllLines(error, contents, Encoding.UTF8);
                }
            }
            return null;
        }

        public HttpStatusCode StatusHandler(HttpResponseMessage response)
        {
            switch(response.StatusCode)
            {
                case HttpStatusCode.OK:
                    break;
                case HttpStatusCode.Accepted:
                    break;
                case HttpStatusCode.Unauthorized:
                    break;
                case HttpStatusCode.TooManyRequests:
                    break;
                case HttpStatusCode.InternalServerError:
                    break;
            }

            return response.StatusCode;
        }

        ~vHttpClient()
        {
            _client.Dispose();
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;


namespace ClassLibrary
{
    public class vHttpClient
    {
        private HttpClient _client;
        private IEnumerable<string> contents;
        private readonly string _token;
        private const string BaseUrl = "https://api.keys.so/X-Keyso-TOKEN:";
        private readonly string _userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64; rv:83.0) Gecko/20100101 Firefox/83.0 ";
        private static readonly object SyncGET = new object();
        private static readonly object SyncPOST = new object();


        public vHttpClient(string token)
        {
            _client = new HttpClient();
            _token = token;
        }

        public async Task<string> GETAsync(string Uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{BaseUrl + _token}/{Uri}");
            string error = string.Empty;
            _client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await _client.SendAsync(requestMessage);
                response.StatusCode.ToString();


                var content = response.Content.Headers;
                Console.WriteLine(response.ToString());


                using (FileStream fs = new FileStream("Post.json", FileMode.OpenOrCreate))
                {
                    using (StreamWriter writer = new StreamWriter(@"C:\Users\user\source\repos\ConsoleAppHTTP\bin\Debug\net5.0\Post.json"))
                    {
                        JsonConvert.SerializeObject(content);
                        Console.WriteLine("Сериализация выполенена");

                    }
                }
                return content.ToString();
            }
            catch (Exception ex)
            {
                lock(SyncGET)
                {
                    error = $"Сообщение: Пользовательское сообщение: ошибка GETasync; Ошибка: {ex.Message}";
                    File.AppendAllLines(error, contents, Encoding.UTF8);
                }
            }
            finally
            {
                requestMessage.Dispose();
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
                lock (SyncPOST)
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
                    Console.WriteLine(StatusHandler(response));
                    break;
                case HttpStatusCode.Accepted:
                    Console.WriteLine(StatusHandler(response));
                    break;
                case HttpStatusCode.Unauthorized:
                    Console.WriteLine(StatusHandler(response));
                    break;
                case HttpStatusCode.TooManyRequests:
                    Console.WriteLine(StatusHandler(response));
                    break;
                case HttpStatusCode.InternalServerError:
                    Console.WriteLine(StatusHandler(response));
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

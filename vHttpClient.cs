using System;
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
        private readonly string _token;
        private readonly string _userAgent;

        vHttpClient(Uri BaseUrl, string token, string userAgent)
        {
            _client = new HttpClient();
            _client.BaseAddress = BaseUrl;  //https://api.keys.so/
            _token = token;
            _userAgent = userAgent;
            //_requestMessage = new HttpRequestMessage();
        }




        public async Task<string> GETAsync(string Uri)
        {
            var requestMessage = new HttpRequestMessage(HttpMethod.Get, $"{_client.BaseAddress.ToString() + Uri}");

            try
            {
                var response = await _client.SendAsync(requestMessage);

                HttpContent content = response.Content;
                var inf = content.ReadAsStreamAsync().ToString();
                return inf;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                _client.Dispose();
            }

            return null;
        }

        public async Task<string> POSTAsync(string Uri, string content)
        {
            HttpContent Content = new StringContent(content); 
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
                Console.WriteLine("Ошибка: " + ex.Message);
            }
            finally
            {
                _client.Dispose();
            }
            return null;
        }

        public HttpStatusCode StatusHandler(HttpResponseMessage response)
        {
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Console.WriteLine("Успешный запрос " + "\n");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Accepted)
            {
                Console.WriteLine("Запрос был принят на обработку, но он не завершен. Повторите запрос позже " + "\n");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            {
                Console.WriteLine("Ошибка авторизации" + "\n");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
            {
                Console.WriteLine("Исчерпан лимит запросов по текущему тарифному плану. Подробное описание ошибки доступно в поле message.В заголовке Retry - After ответа сервера указанно время(в секундах), через которое клиенту рекомендуется повторить запрос. " + "\n");
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                Console.WriteLine("Внутренняя ошибка сервера. Подробное описание ошибки доступно в поле message" + "\n");
            }
            return response.StatusCode;
        }
    }
}

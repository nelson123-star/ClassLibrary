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
        private static readonly HttpClient _client;
        //private static readonly HttpRequestMessage _requestMessage;

        static vHttpClient()
        {
            _client = new HttpClient();
            //_requestMessage = new HttpRequestMessage();
        }

        public async static Task<string> GET(string Uri)
        {
            var requestMessage = new HttpRequestMessage();


            try
            {
                requestMessage.RequestUri = new Uri(Uri);
                requestMessage.Method = HttpMethod.Get;

                var response = await _client.SendAsync(requestMessage);

                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    //Console.WriteLine("Успешный запрос ");
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.Accepted)
                {
                    //Console.WriteLine("Запрос был принят на обработку, но он не завершен. Повторите запрос позже ");

                }
                else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    //Console.WriteLine("Ошибка авторизации");

                }
                else if(response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    //Console.WriteLine(" 	Исчерпан лимит запросов по текущему тарифному плану. Подробное описание ошибки доступно в поле message.
                    //В заголовке Retry - After ответа сервера указанно время(в секундах), через которое клиенту рекомендуется повторить запрос. ");
                }
                else if(response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
                {
                    //Console.WriteLine("Внутренняя ошибка сервера. Подробное описание ошибки доступно в поле message");
                }
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

        public static async Task<string> POST(string Uri, string content)
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
    }
}

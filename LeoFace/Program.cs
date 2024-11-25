using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

class Program
{
    static async Task Main(string[] args)
    {
        await MakeRequest();
    }

    static async Task MakeRequest()
    {
        using (var client = new HttpClient())
        {
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "{subscription key}");
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.2-preview.1/persongroups/{personGroupId}?" + queryString;

            HttpResponseMessage response;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{body}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PutAsync(uri, content);

                var result = await response.Content.ReadAsStringAsync();

                Console.WriteLine("HttpResponse: " + response.StatusCode);
                Console.WriteLine("Response Msg: " + result);
            }
        }
    }
}

using System;
using System.Net.Http.Headers;
using System.Text;
using System.Net.Http;
using System.Web;

namespace CSHttpClientSample
{
    static class Program
    {
        static void Main()
        {
            MakeRequest();
            
            Console.ReadLine();
        }

        static async void MakeRequest()
        {
            var client = new HttpClient();
            var queryString = HttpUtility.ParseQueryString(string.Empty);

            // Request headers
            client.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", "********");

            // Request parameters
            //queryString["returnFaceId"] = "true";
            //queryString["returnFaceLandmarks"] = "false";
            //queryString["returnFaceAttributes"] = "accessories";
            //queryString["recognitionModel"] = "recognition_04";
            //queryString["returnRecognitionModel"] = "false";
            //queryString["detectionModel"] = "detection_01";
            //queryString["faceIdTimeToLive"] = "86400";
            var uri = "https://westcentralus.api.cognitive.microsoft.com/face/v1.2-preview.1/detect?returnFaceAttributes=glasses%2Cocclusion%2Cqualityforrecognition&returnFaceId=true&returnRecognitionModel=true&recognitionModel=recognition_03" ;

            HttpResponseMessage response;

            string result;

            // Request body
            byte[] byteData = Encoding.UTF8.GetBytes("{\r\n    \"url\": \"https://bucket-img.tnlmedia.com/cabinet/2023/02/88a0e332-f890-4aec-9edc-56852f068357.jpg\"\r\n}");

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                result = await response.Content.ReadAsStringAsync();
            }
            Console.WriteLine("HttpResponse: " + response.StatusCode);
            Console.WriteLine("Detect Msg: " + result);
            Console.WriteLine("Hit ENTER to exit...");
        }
    }
}
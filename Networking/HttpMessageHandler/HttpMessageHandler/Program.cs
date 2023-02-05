using System.Net;
using System.Net.Http;

namespace HttpMessageHandler
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://postman-echo.com/post";
            CookieContainer cookies = new CookieContainer();
            // Tạo HttpClient - thiết lập handler cho nó

            using var handler = new SocketsHttpHandler();
            using var httpClient = new HttpClient(handler);
            handler.AllowAutoRedirect= true;
            //AllowAutoRedirect: Thuộc tính, mặc định là true, để thiết lập tự động chuyển hướng.
            //Ví dụ truy vấn đến URI có chuyển hướng đến đích mới (301) thì
            //- HttpClient sẽ tự động chuyển hướng truy vấn đến đó.


            handler.AutomaticDecompression = DecompressionMethods.GZip;
            //AutomaticDecompression:Thuộc tính thuộc tính để handler tự động giải nén

            handler.UseCookies = true;
            handler.CookieContainer = cookies;     // Thay thế CookieContainer mặc định
            // Tạo HttpRequestMessage
            using var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri(url);
            httpRequestMessage.Headers.Add("User-Agent", "Mozilla/5.0");
            var parameters = new List<KeyValuePair<string, string>>()
    {
        new KeyValuePair<string, string>("key1", "value1"),
        new KeyValuePair<string, string>("key2", "value2")

    };
            httpRequestMessage.Content = new FormUrlEncodedContent(parameters);

            // Thực hiện truy vấn
            var response = await httpClient.SendAsync(httpRequestMessage);


            // Hiện thị các cookie (các cookie trả về có thể sử dụng cho truy vấn tiếp theo)
            cookies.GetCookies(new Uri(url)).ToList().ForEach(cookie => {
                Console.WriteLine($"{cookie.Name} = {cookie.Value}");
            });

            // Đọc chuỗi nội dung trả về (HTML)
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine(result);
        }
    }
}
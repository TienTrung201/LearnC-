using System.Net;
using System.Net.NetworkInformation;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using System.Text;
using static System.Net.WebRequestMethods;

namespace NetWorking_Uri_Dns_Ping_HttpClient
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            /*URI
            string url = "https://xuanthulab.net/lap-trinh/csharp/?page=3#acff";
            var uri = new Uri(url); để tạo đối tượng uri cần địa chỉ url
            // đọc tất cả thuộc tính trong lớp uri
            var uritype = typeof(Uri);
            uritype.GetProperties().ToList().ForEach(property => {
                Console.WriteLine($"{property.Name,15} {property.GetValue(uri)}");
            });
            Console.WriteLine($"Segments: {string.Join(",", uri.Segments)}");
            */
            /*DNS cho phép truy  cập đến các máy chủ dns
            string url = "https://www.bootstrapcdn.com/";
            var uri = new Uri(url);
            var hostEntry = Dns.GetHostEntry(uri.Host);
            Console.WriteLine($"Host {uri.Host} có các IP");
            hostEntry.AddressList.ToList().ForEach(ip => Console.WriteLine(ip));
            */
            /*Lớp Ping
Lớp Ping (System.Net.NetworkInformation.Ping), lớp này cho phép ứng dụng xác định một máy từ xa (như server, máy trong mạng ...) có phản hồi không.
            var ping = new Ping();
            var pingReply = ping.Send("google.com.vn");
            Console.WriteLine(pingReply.Status);
            if (pingReply.Status == IPStatus.Success)
            {
                Console.WriteLine(pingReply.RoundtripTime);
                Console.WriteLine(pingReply.Address);
            }
            */

            //Get==============================================================
            /*

            var url = "https://www.google.com/search?q=xuanthulab";
            var html = await GetWebContent(url);// await tự động trả kết quả cho html
            Console.WriteLine(html);


            // tải 1 link ảnh về từ đường dẫn
            var url2 = "https://raw.githubusercontent.com/xuanthulabnet/jekyll-example/master/images/jekyll-01.png";
            byte[] bytes = await DownloadDataBytes(url2);
            try
            {
                string filepath = "anh1.png";       // tên file  tạo file       cho phép ghi    không share
                using (var stream = new FileStream(filepath, FileMode.Create, FileAccess.Write, FileShare.None))
                {                    Console.WriteLine(bytes.Length + "     hello");

                    stream.Write(bytes, 0, bytes.Length);
                    Console.WriteLine("save " + filepath);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("lôi");
            }
            */
            //Get==============================================================

            //post===============================================================
            var httpClient = new HttpClient();

            var httpRequestMessage = new HttpRequestMessage();
            httpRequestMessage.Method = HttpMethod.Post;
            httpRequestMessage.RequestUri = new Uri("https://postman-echo.com/post");

            var parameters = new List<KeyValuePair<string, string>>();
            parameters.Add(new KeyValuePair<string, string>("key1", "value1"));

            parameters.Add(new KeyValuePair<string, string>("key2", "value2-1"));
            parameters.Add(new KeyValuePair<string, string>("key2", "value2-2"));

            // Thiết lập Content
            var content = new FormUrlEncodedContent(parameters);
            string jsoncontent = "{\"value1\": \"giatri1\", \"value2\": \"giatri2\"}";
            var httpContent = new StringContent(jsoncontent, Encoding.UTF8, "application/json");
            //httpRequestMessage.Content = content;
            httpRequestMessage.Content = httpContent;

            // Thực hiện Post
            var response = await httpClient.SendAsync(httpRequestMessage);

            var responseContent = await response.Content.ReadAsStringAsync();///responseContent đưuọc trả về
            Console.WriteLine(responseContent);
            // Khi chạy kết quả trả về cho biết Server đã nhận được dữ liệu Post đến
            //post===============================================================


        }
        // Tải về trang web và trả về chuỗi nội dung
        public static async Task<string> GetWebContent(string url)
        {
            // Khởi tạo http client
            using var httpClient = new HttpClient();// tự động hủy khi thoat puong htuc

            try
            {
                // Thiết lập các Header nếu cần vho biết người dùng đang dùng gì
                httpClient.DefaultRequestHeaders.Add("user-Agent", "Mozilla/5.0");

                // Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Hiện thị thông tin header trả về
                ShowHeaders(response.Headers);

                // Phát sinh Exception nếu mã trạng thái trả về là lỗi
                response.EnsureSuccessStatusCode();

                Console.WriteLine($"tai thanh cong - statusCode {(int)response.StatusCode} {response.ReasonPhrase}");

                Console.WriteLine("Starting read data");

                // Đọc nội dung content trả về - ĐỌC CHUỖI NỘI DUNG
                string htmltext = await response.Content.ReadAsStringAsync();
                Console.WriteLine($"Nhận được {htmltext.Length} ký tự");
                Console.WriteLine();
                return htmltext;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }


        public static async Task<byte[]> DownloadDataBytes(string url)
        {
            // Khởi tạo http client
            using var httpClient = new HttpClient();// tự động hủy khi thoat puong htuc
            try
            {
                // Thiết lập các Header nếu cần vho biết người dùng đang dùng gì
                httpClient.DefaultRequestHeaders.Add("user-Agent", "Mozilla/5.0");

                // Thực hiện truy vấn GET
                HttpResponseMessage response = await httpClient.GetAsync(url);

                // Hiện thị thông tin header trả về 
                ShowHeaders(response.Headers);
                var bytes = await response.Content.ReadAsByteArrayAsync();
                return bytes;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        static void ShowHeaders(HttpResponseHeaders headers)
        {
            Console.WriteLine("CAC HEADER");
            foreach (var header in headers)
            {

                Console.WriteLine($"{header.Key} : {header.Value}");
            }
        }

    }
}
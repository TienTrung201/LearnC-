

using System.Text;
using Microsoft.Extensions.Options;

namespace CauHinhDiASPnet
{
    public class TestOptionsMiddleware : IMiddleware
    { 
        public  TestOption _testOption {set; get; }
        public ProducNames _productNames {set; get; }

        public TestOptionsMiddleware(IOptions<TestOption> option,ProducNames productNames){
            _testOption=option.Value;
            _productNames=productNames;
        }
        public async Task InvokeAsync(HttpContext context, RequestDelegate next)
        {
            var testOption = new StringBuilder();
            testOption.Append("TestOption\n");
            testOption.Append("option1: " + _testOption.opt1);
            testOption.Append($"\noption2 K1: {_testOption.opt2.k2}");
            testOption.Append($"\nproduct name: {_productNames.GetNameeeee()}");
            await context.Response.WriteAsync(testOption.ToString());
            await next(context);
        }
    }
}
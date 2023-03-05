using System.Text;
namespace CauHinhDiASPnet
{
    public class ProducNames
    {
        private List<string> names { get; set; }
        public ProducNames()
        {
            names = new List<string>(){
                "Iphone 7","samsung"
            };
        }
        public string GetNameeeee()
        {
            var stringBuilder = new StringBuilder();
            names.ForEach(name => stringBuilder.Append(name));
            return stringBuilder.ToString();
        }
    }

}
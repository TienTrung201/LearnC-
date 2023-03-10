using InitProject.Models;

namespace InitProject.Service
{
    public class PlanetService:List<PlanetModel>
    {
        public PlanetService() {
            Add(new PlanetModel()
            {
                Id=1,
                Name= "Jupiter",
                VnName= "Sao Mộc ",
                Content= "Sao Mộc (khoảng cách đến Mặt Trời 5,2 AU), với khối lượng bằng 318 lần khối lượng Trái Đất và bằng 2,5 lần tổng khối lượng của 7 hành tinh còn lại trong Thái Dương Hệ. Mộc Tinh có thành phần chủ yếu hiđrô và heli. Nhiệt lượng khổng lồ từ bên trong Sao Mộc tạo ra một số đặc trưng bán vĩnh cửu trong bầu khí quyển của nó, như các dải mây và Vết đỏ lớn.\r\nSao Mộc có 63 vệ tinh đã biết. 4 vệ tinh lớn nhất, Ganymede, Callisto, Io, và Europa (các vệ tinh Galileo) có các đặc trưng tương tự như các hành tinh đá, như núi lửa và nhiệt lượng từ bên trong.[63] Ganymede, vệ tinh tự nhiên lớn nhất trong hệ Mặt Trời, có kích thước lớn hơn Sao Thủy."
            });
            Add(new PlanetModel()
            {
                Id = 2,
                Name = "Saturn",
                VnName = "Sao Thổ",
                Content = "Sao Thổ (khoảng cách đến Mặt Trời 9,5 AU), có đặc trưng khác biệt rõ rệt đó là hệ vành đai kích thước rất lớn, và những đặc điểm giống với Sao Mộc, như về thành phần bầu khí quyển và từ quyển. Mặc dù thể tích của Sao Thổ bằng 60% thể tích của Sao Mộc, nhưng khối lượng của nó chỉ bằng 1/3 so với Sao Mộc, hay 95 lần khối lượng Trái Đất, khiến nó trở thành hành tinh có mật độ nhỏ nhất trong hệ Mặt Trời (nhỏ hơn cả mật độ của nước lỏng). Vành đai Sao Thổ chứa bụi cũng như các hạt băng và đá nhỏ."
            });
            Add(new PlanetModel()
            {
                Id = 3,
                Name = "Uranus",
                VnName = "Sao thiên vương",
                Content = "Sao Thiên Vương (khoảng cách đến Mặt Trời 19,6 AU), khối lượng bằng 14 lần khối lượng Trái Đất, là hành tinh vòng ngoài nhẹ nhất. Trục tự quay của nó có đặc trưng lạ thường duy nhất so với các hành tinh khác, độ nghiêng trục quay >900 so với mặt phẳng hoàng đạo. Thiên Vương Tinh có lõi lạnh hơn nhiều so với các hành tinh khí khổng lồ khác và nhiệt lượng bức xạ vào không gian cũng nhỏ.[65]\r\n"
            });
        }
    }
}

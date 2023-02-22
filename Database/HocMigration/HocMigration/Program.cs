namespace HocMigration
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // migration code=> database
            /*
                    dotnet ef migrations add databaseName
                    dotnet ef migrations list  danh sách các phiên bản
                    không chỉnh sửa gì thì V1-V0 không khác nhau
                    dotnet ef migrations add V1

                    dotnet ef migrations remove xóa cái cuối

                    dotnet ef database update ---name--  nếu k có name thì lấy cái cuối
                    Đổi tên cột thì dữ liệ vẫn giữ nguyên
                    dotnet ef database update ---name-- 

                    dotnet ef database drop -xóa toàn bộ database

                    dotnet ef migrations script lấy tất cả câu lệnh sql
                    dotnet ef migrations script name1 name2

                     dotnet ef migrations script -o tenfile.sql
            */
        }
    }
}
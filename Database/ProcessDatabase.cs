using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace KiemTra
{
    internal class ProcessDatabase
    {
        private string strConnect = "";
        private SqlConnection connection = null;

        public ProcessDatabase(string strcon)
        {
            StrConnect = strcon;
        }
        public string StrConnect { get => strConnect; set => strConnect = value; }

        // Kết nối đến CSDL
        public void ConnectToDatabase()
        {
            connection = new SqlConnection(StrConnect);
            if (connection.State != ConnectionState.Open)
            {
                connection.Open();
            }
        }
        // Đóng kết nối CSDL
        public void DisconnectToDataBase()
        {
            if (connection.State != ConnectionState.Closed)
            {
                connection.Close();
            }
        }

        // Đọc dữ liệu từ database và trả về data table
        public DataTable ReadTable(string sql)
        {
            ConnectToDatabase();
            SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            DataTable table = new DataTable();
            table.Clear();
            adapter.Fill(table);

            DisconnectToDataBase();

            return table;
        }

        // Truy vấn dữ liệu từ database
        // Thêm, Sửa, Xóa, Update..
        public void UpdateData(string sql)
        {
            ConnectToDatabase();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = sql;
            command.ExecuteNonQuery();
            DisconnectToDataBase();
        }
    }
}

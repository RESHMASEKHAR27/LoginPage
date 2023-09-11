using Microsoft.Data.SqlClient;

namespace LoginPage.Data
{
    public class LoginData
    {

        public const string connectionstring = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Credentials;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        public int Check(string Username, string Password)
        {
            int flag = 0;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string insertQuery = "SELECT * FROM [dbo].[Table] WHERE UserName=@UserName AND Password=@Password";
                using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                {
                    cmd.Parameters.AddWithValue("username", Username);
                    cmd.Parameters.AddWithValue("password", Password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            flag = reader.GetInt32(0);
                        }
                    }
                }

            }
            return flag;

        }

        public string? select(int Id)
        {
            string? Name = null;
            using (SqlConnection conn = new SqlConnection(connectionstring))
            {
                conn.Open();

                string selectQuery = "SELECT * FROM [dbo].[Table] WHERE Id=@Id"; 
                using (SqlCommand cmd = new SqlCommand(selectQuery, conn))
                {
                    cmd.Parameters.AddWithValue("Id", Id);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Name = reader.GetString(1);
                        }
                    }
                }
                conn.Close();
            }
            return Name;
        }



    }
}

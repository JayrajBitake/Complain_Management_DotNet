using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalProject.Models
{
    public class db
    {
        SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;");
        public int LoginCheck(ULogin ul)
        {
            SqlCommand com = new SqlCommand("Login", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@LoginName", ul.LoginName);
            com.Parameters.AddWithValue("@Password", ul.Password);
            SqlParameter oblogin = new SqlParameter();
            oblogin.ParameterName = "@Isvalid";
            oblogin.SqlDbType = SqlDbType.Bit;
            oblogin.Direction = ParameterDirection.Output;
            com.Parameters.Add(oblogin);
            con.Open();
            com.ExecuteNonQuery();
            int res = Convert.ToInt32(oblogin.Value);
            con.Close();
            return res;
        }
    }
}

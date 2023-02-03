using FinalProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalProject.Controllers
{
    public class ComplainLogic
    {
        public IEnumerable<Complain> complain
        {
            get
            {

                List<Complain> c1 = new List<Complain>();
                using (SqlConnection con = new SqlConnection(("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;")))
                {
                    SqlCommand cmd = new SqlCommand("GetComplainDetails", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Complain c = new Complain();
                        c.Id = Convert.ToInt32(rdr["Id"]);
                        c.Category = rdr["Category"].ToString();
                        c.Description = rdr["Description"].ToString();
                        c.Status = rdr["Status"].ToString();
                        c1.Add(c);
                    }
                }
                return c1;
            }
        



        }
        public void UpdateStatus(Complain complain)
        {
            using (SqlConnection con = new SqlConnection(("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;")))
            {
                SqlCommand cmd = new SqlCommand("Update", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter Id = new SqlParameter();
                Id.ParameterName = "@Id";
                Id.Value = complain.Id;
                cmd.Parameters.Add(Id);
                SqlParameter Status = new SqlParameter();
                Status.ParameterName = "@Status";
                Status.Value = complain.Id;
                cmd.Parameters.Add(Status);
                con.Open();
                cmd.ExecuteNonQuery();



            }

            }
        public void DeleteComplain(int id)
        {
            using (SqlConnection con = new SqlConnection(("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;")))

         
            {
                SqlCommand cmd = new SqlCommand("Delete", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@Id";
                paramId.Value = id;
                cmd.Parameters.Add(paramId);
                con.Open();
                cmd.ExecuteNonQuery();
            }
        }




    }
}

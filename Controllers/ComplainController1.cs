using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Drawing;

namespace FinalProject.Controllers
{
    public class ComplainController1 : Controller
    {
        // GET: ComplainController1
       
        public ActionResult Index(Complain c1)
        {
            Complain c = new Complain();
            DataSet ds = new DataSet();

            using (SqlConnection con = new SqlConnection(("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;")))
            {
                using (SqlCommand cmd = new SqlCommand("GetComplainDetails", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                   // cmd.Parameters.AddWithValue("@Id", c1.Id);

                    con.Open();
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    sda.Fill(ds);
                    List<Complain> complainlist = new List<Complain>();
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        Complain uobj = new Complain();
                        uobj.Id = Convert.ToInt32(ds.Tables[0].Rows[i]["ID"].ToString());
                        uobj.Category = ds.Tables[0].Rows[i]["Category"].ToString();
                        uobj.Description = ds.Tables[0].Rows[i]["Description"].ToString();
                        uobj.Status = ds.Tables[0].Rows[i]["Status"].ToString();

                        complainlist.Add(uobj);

                    }
                    c.Complaininfo = complainlist;
                    
                }
                con.Close();
            }

        
            return View();
        }

        // GET: ComplainController1/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ComplainController1/Create
        public ActionResult Create()
        {

           

                return View();
        }

        // POST: ComplainController1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Complain c)
        {
            try
            {
                Enroll er = new Enroll();
                using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;"))
                {
                    using (SqlCommand cmd = new SqlCommand("EnrollComplain", con))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Id", c.Id);
                        cmd.Parameters.AddWithValue("@Category", c.Category);
                        cmd.Parameters.AddWithValue("@Description", c.Description);
                        cmd.Parameters.AddWithValue("@Status", c.Status);
                        

                        // cmd.Parameters.AddWithValue("@status", "INSERT");
                        con.Open();
                        ViewData["result"] = cmd.ExecuteNonQuery();
                        con.Close();

                    }
                }


                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComplainController1/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ComplainController1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ComplainController1/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ComplainController1/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

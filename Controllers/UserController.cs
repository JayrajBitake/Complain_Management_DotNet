using FinalProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace FinalProject.Controllers
{
    public class UserController : Controller
    {
        db dbop = new db();
        // GET: UserController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Enroll e)
        {
            Enroll er = new Enroll();
            using (SqlConnection con = new SqlConnection("Data Source=(localdb)\\ProjectModels;Initial Catalog=FinalProject;Integrated Security=True;"))
            {
                using (SqlCommand cmd = new SqlCommand("EnrollDetail", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@LoginName", e.LoginName);
                    cmd.Parameters.AddWithValue("@FullName", e.FullName);
                    cmd.Parameters.AddWithValue("@Password", e.Password);
                    cmd.Parameters.AddWithValue("@ConfirmPassword", e.ConfirmPassword);
                    cmd.Parameters.AddWithValue("@Gender", e.Gender);
                    cmd.Parameters.AddWithValue("@EmailId", e.EmailId);
                    cmd.Parameters.AddWithValue("@PhoneNumber", e.PhoneNumber);

                    // cmd.Parameters.AddWithValue("@status", "INSERT");
                    con.Open();
                    ViewData["result"] = cmd.ExecuteNonQuery();
                    con.Close();

                }
            }


            return View();
        }


        // GET: UserController/Details/5
        public ActionResult Details([Bind] ULogin ul)
        {
            try
            {
                db dbop = new db();
                int res = dbop.LoginCheck(ul);
                if (res == 1)
                {
                    TempData["msg"] = "Welcome User..!!";
                    return View("Create");
                }
                else
                {
                    TempData["msg"] = "Login Name or Password is wrong.!";
                }




                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserController/Create
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

        // GET: UserController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserController/Edit/5
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

        // GET: UserController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserController/Delete/5
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

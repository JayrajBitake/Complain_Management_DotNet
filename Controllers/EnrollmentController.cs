using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FinalProject.Models;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Data;
using System.Web;

namespace FinalProject.Controllers
{
    public class EnrollmentController : Controller

    {
        public string value = "";
        // GET: EnrollmentController
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Enroll e)
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




        // GET: EnrollmentController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EnrollmentController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EnrollmentController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: EnrollmentController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EnrollmentController/Edit/5
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

        // GET: EnrollmentController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EnrollmentController/Delete/5
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

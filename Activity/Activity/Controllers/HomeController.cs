using Activity.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Data;

namespace Activity.Controllers
{
    public class HomeController : Controller
    {
        private ActivityEntities db = new ActivityEntities();
        public ActionResult Index()
        {
            
            TempData["EndTime"] = Session["EndTime"];
          
            return View();
        }

        [HttpPost]
        public void PostCountdownTimer()
        {
            if (Session["EndTime"] == null)
            {
                Session["EndTime"] = DateTime.Now.AddHours(0).AddMinutes(00).AddSeconds(30).ToString("dd-MM-yyyy h:mm:ss tt");
            }
            TempData["EndTime"] = Session["EndTime"];
           
            Response.Redirect("/Home/Index");
        }

        // Destroys EndTime Session object
        public void StopTimer()
        {
            Session.Abandon();
        }
        public ActionResult StartGame()

        {
            var idList = db.Words.Select(x => x.WordsID).OrderBy(y => Guid.NewGuid()).ToList();
          

            if (idList.Count == 0)
            {
                return RedirectToAction("Finish");
            }
            Word word = db.Words.Find(idList[0]);



            db.Words.Remove(word);
            db.SaveChanges();



            return View(word);
        }

        public ActionResult Finish()
        {
            return View();
        }

    }
}
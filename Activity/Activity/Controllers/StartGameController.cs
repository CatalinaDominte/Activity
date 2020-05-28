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
    public class StartGameController : Controller
    {
        private ActivityEntities db = new ActivityEntities();

       
       
        
        // GET: StartGame/StartGame/5
        public ActionResult StartGame()

        {
            var idList = db.Words.Select(x => x.WordsID).OrderBy(y => Guid.NewGuid()).ToList();

            if (idList.Count==0)
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


        // GET: StartGame/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Word word = db.Words.Find(id);
            if (word == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", word.PlayerID);
            return View(word);
        }

        // POST: StartGame/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "WordsID,Word1,PlayerID")] Word word)
        {
            if (ModelState.IsValid)
            {
                db.Entry(word).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlayerID = new SelectList(db.Players, "PlayerID", "PlayerName", word.PlayerID);
            return View(word);
        }

        // GET: StartGame/Delete/5
       
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

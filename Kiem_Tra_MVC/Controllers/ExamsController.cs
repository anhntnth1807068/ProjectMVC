using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kiem_Tra_MVC.Models;

namespace Kiem_Tra_MVC.Controllers
{
    public class ExamsController : Controller
    {
        private Kiem_Tra_MVCContext db = new Kiem_Tra_MVCContext();

        // GET: Exams
        public ActionResult Index()
        {
            var exams = db.Exams.Include(e => e.ClassRoom).Include(e => e.ExamSubject).Include(e => e.Faculty);
            return View(exams.ToList());
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.ClassRoomid = new SelectList(db.ClassRooms, "id", "ClassNAme");
            ViewBag.ExamSubjectid = new SelectList(db.ExamSubjects, "id", "Name");
            ViewBag.Facultyid = new SelectList(db.Faculties, "id", "FacultiName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,ExamSubjectid,StartTime,ExamDate,Duration,ClassRoomid,Facultyid,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClassRoomid = new SelectList(db.ClassRooms, "id", "ClassNAme", exam.ClassRoomid);
            ViewBag.ExamSubjectid = new SelectList(db.ExamSubjects, "id", "Name", exam.ExamSubjectid);
            ViewBag.Facultyid = new SelectList(db.Faculties, "id", "FacultiName", exam.Facultyid);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClassRoomid = new SelectList(db.ClassRooms, "id", "ClassNAme", exam.ClassRoomid);
            ViewBag.ExamSubjectid = new SelectList(db.ExamSubjects, "id", "Name", exam.ExamSubjectid);
            ViewBag.Facultyid = new SelectList(db.Faculties, "id", "FacultiName", exam.Facultyid);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,ExamSubjectid,StartTime,ExamDate,Duration,ClassRoomid,Facultyid,Status")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClassRoomid = new SelectList(db.ClassRooms, "id", "ClassNAme", exam.ClassRoomid);
            ViewBag.ExamSubjectid = new SelectList(db.ExamSubjects, "id", "Name", exam.ExamSubjectid);
            ViewBag.Facultyid = new SelectList(db.Faculties, "id", "FacultiName", exam.Facultyid);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

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

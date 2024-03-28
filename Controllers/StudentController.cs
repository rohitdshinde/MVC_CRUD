using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVC_CRUD.Models;
using System.Data.Entity;

namespace MVC_CRUD.Controllers
{
    public class StudentController : Controller
    {
        RohitDBEntities db;
        public StudentController()
        {
            db = new RohitDBEntities();
        }

        public ActionResult Index()
        {
            List<student> lst = db.students.ToList();
            return View(lst);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(student st)
        {
            db.students.Add(st);
            db.SaveChanges();
            return RedirectToAction("INDEX");
        }
        public ActionResult Edit(int id)
        {
            student st= db.students.Find(id);   
            return View(st);
        }
        [HttpPost]
        public ActionResult Edit(student st)
        {
            db.Entry<student>(st).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            student st = db.students.Find(id);
            db.students.Remove(st);
            db.SaveChanges();
            return RedirectToAction("Index");   
        }


    }
}
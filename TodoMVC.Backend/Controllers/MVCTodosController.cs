using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TodoMVC.Backend.Models;

namespace TodoMVC.Backend.Controllers
{
    public class MVCTodosController : Controller
    {
        private TodoDbContext db = new TodoDbContext();

        // GET: mvc/todos
        public ActionResult Index()
        {
            var todos = db.Todos.ToList();
            return Content(JsonConvert.SerializeObject(todos), "application/json");
        }

        // GET: mvc/todos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return HttpNotFound();
            }
            return Content(JsonConvert.SerializeObject(todo), "application/json");
        }

        // POST: mvc/todos/Create
        [HttpPost]
        public ActionResult Create(string txt)
        {
            var todo = new Todo() { Txt = txt };
            db.Todos.Add(todo);
            db.SaveChanges();

            return Content(JsonConvert.SerializeObject(todo), "application/json");
        }

        // POST:  mvc/todos/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, string txt, bool done)
        {
            var todo = db.Todos.Find(id);
            todo.Txt = txt;
            todo.Done = done;
            db.SaveChanges();

            return Content(JsonConvert.SerializeObject(todo), "application/json");
        }

        // POST:  mvc/todos/Delete/5
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            Todo todo = db.Todos.Find(id);
            db.Todos.Remove(todo);
            db.SaveChanges();
            return Content(JsonConvert.SerializeObject(new { success = true }), "application/json");
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

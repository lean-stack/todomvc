using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TodoMVC.Backend.Models;

namespace TodoMVC.Backend.Controllers
{
    public class WebAPITodosController : ApiController
    {
        private TodoDbContext db = new TodoDbContext();

        // GET: api/WebAPITodos
        public IQueryable<Todo> GetTodos()
        {
            return db.Todos;
        }

        // GET: api/WebAPITodos/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult GetTodo(int id)
        {
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT: api/WebAPITodos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTodo(int id, Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != todo.Id)
            {
                return BadRequest();
            }

            db.Entry(todo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TodoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/WebAPITodos
        [ResponseType(typeof(Todo))]
        public IHttpActionResult PostTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Todos.Add(todo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = todo.Id }, todo);
        }

        // DELETE: api/WebAPITodos/5
        [ResponseType(typeof(Todo))]
        public IHttpActionResult DeleteTodo(int id)
        {
            Todo todo = db.Todos.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            db.Todos.Remove(todo);
            db.SaveChanges();

            return Ok(todo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TodoExists(int id)
        {
            return db.Todos.Count(e => e.Id == id) > 0;
        }
    }
}
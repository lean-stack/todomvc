using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using TodoMVC.Backend.Controllers;
using TodoMVC.Backend.Models;

namespace TodoMVC.Backend.Realtime
{
    public class TodoHub : Hub
    {
        TodoDbContext ctx = new TodoDbContext();

        public void GetAll()
        {
            Clients.Caller.sentAll(ctx.Todos.ToList());
        }

        public void CreateTodo(string txt)
        {
            var todo = new Todo() { Txt = txt };
            ctx.Todos.Add(todo);
            ctx.SaveChanges();

            Clients.All.createdTodo(todo);
        }

        public void UpdateTodo(int id, string txt, bool done)
        {
            var todo = ctx.Todos.Find(id);
            todo.Txt = txt;
            todo.Done = done;
            ctx.SaveChanges();

            Clients.All.updatedTodo(todo);
        }

        public void DeleteTodo(int id)
        {
            Todo todo = ctx.Todos.Find(id);
            ctx.Todos.Remove(todo);
            ctx.SaveChanges();
            Clients.All.deletedTodo(id);

        }
    }
}
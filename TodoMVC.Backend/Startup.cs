﻿using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Newtonsoft.Json;

[assembly: OwinStartup(typeof(TodoMVC.Backend.Startup))]

namespace TodoMVC.Backend
{
    public class Startup
    {

        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR();
        }
    }
}

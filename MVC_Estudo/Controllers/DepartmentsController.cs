﻿using Microsoft.AspNetCore.Mvc;
using MVC_Estudo.Models;
using System.Collections.Generic;

namespace MVC_Estudo.Controllers
{
    public class DepartmentsController : Controller
    {
        public IActionResult Index()
        {
            List<Department> list = new List<Department>();
            list.Add(new Department { Id= 1, Name ="Eletronics" });
            list.Add(new Department { Id = 2, Name = "Fashion" });


            return View(list);
        }
    }
}

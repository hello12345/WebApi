﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace WebapiCore.Controllers
{
    public class testController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}
        [HttpGet]
        public string Get() {
            return "test";
        }
    }
}
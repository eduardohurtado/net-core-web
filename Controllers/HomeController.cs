using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace net_core_web
{
    public class HomeController : Controller
    {
        public JsonResult Index()
        {
            return Json(new { id = 2, name = "Pedro", });
        }

    }
}
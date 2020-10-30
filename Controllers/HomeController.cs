using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace net_core_web
{
    public class HomeController : Controller
    {
        private IFriendStore friendStore;

        // Constructor
        public HomeController(IFriendStore FriendStore)
        {
            friendStore = FriendStore;
        }

        // Default controller method.
        // public string Index()
        // {
        //     return friendStore.friendGetData(1).Email;
        // }

        public ViewResult Index()
        {
            Friend model = friendStore.friendGetData(1);
            return View(model);
        }

        // public JsonResult Details()
        // {
        //     Friend model = friendStore.friendGetData(1);
        //     return Json(model);
        // }

        public ViewResult Details()
        {
            Friend dataFriend = friendStore.friendGetData(2);

            ViewData["HeadTitle"] = "Friends List ViewData";
            ViewData["Friend"] = dataFriend;

            ViewBag.Title = "Friends List ViewBag";
            ViewBag.Friend = dataFriend;

            return View(dataFriend);
        }
    }
}
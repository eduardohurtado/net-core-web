using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using net_core_web.Model;
using net_core_web.ViewModels;

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

        // Attribute routing
        [Route("")]
        [Route("Home")]
        [Route("Home/Index")]
        public ViewResult Index()
        {
            var allFriends = friendStore.getAllFriends();
            return View(allFriends);
        }

        // public JsonResult Details()
        // {
        //     Friend model = friendStore.friendGetData(1);
        //     return Json(model);
        // }

        // Attribute routing
        [Route("Home/Details/{id?}")]
        public ViewResult Details(int id)
        {
            Friend dataFriend = friendStore.friendGetData(2);

            ViewData["HeadTitle"] = "Friends List ViewData";
            ViewData["Friend"] = dataFriend;

            ViewBag.Title = "Friends List ViewBag";
            ViewBag.Friend = dataFriend;

            return View(dataFriend);
        }

        // Attribute routing
        [Route("Home/DataFriend/{id?}")]
        public ViewResult DataFriend(int? id)
        {

            ViewDetails details = new ViewDetails();
            details.Friend = friendStore.friendGetData(id ?? 1);
            details.Title = "Data from DataFriend<ViewDetails>";

            return View(details);
        }
    }
}
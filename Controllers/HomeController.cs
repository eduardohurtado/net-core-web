using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
using net_core_web.Model;
using net_core_web.ViewModels;

namespace net_core_web
{
    public class HomeController : Controller
    {
        private IFriendStore friendStore;
        private IWebHostEnvironment _webHostEnvironment;

        // Constructor
        public HomeController(
            IFriendStore FriendStore,
            IWebHostEnvironment webHostEnvironment
            )
        {
            friendStore = FriendStore;
            _webHostEnvironment = webHostEnvironment;
        }

        // Default controller method.
        // public string Index()
        // {
        //     return friendStore.friendGetData(1).Email;
        // }

        // Attribute routing
        [HttpGet]
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

        [Route("Home/Create")]
        public ViewResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Home/Create")]
        public IActionResult Create(CreateFriendModel e)
        {
            if (ModelState.IsValid)
            {
                // Friend friend = friendStore.newFriend(e);
                // return RedirectToAction("DataFriend", new { id = friend.Id });

                string guidImage = null;
                if (e.Photo != null)
                {
                    string imagesPath = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                    guidImage = Guid.NewGuid().ToString() + e.Photo.FileName;
                    string finalRoute = Path.Combine(imagesPath, guidImage);
                    e.Photo.CopyTo(new FileStream(finalRoute, FileMode.Create));
                }

                Friend newFriend = new Friend();
                newFriend.Name = e.Name;
                newFriend.Email = e.Email;
                newFriend.City = e.City;
                newFriend.photoRoute = guidImage;

                friendStore.newFriend(newFriend);
                return RedirectToAction("Datafriend", new { id = newFriend.Id });
            }

            return View();
        }

        [Route("Home/Modify/{id?}")]
        public ViewResult Modify(int? id)
        {
            Friend details = new Friend();
            details = friendStore.friendGetData(id ?? 1);
            return View(details);
        }

        [HttpPost]
        [Route("Home/Modify/{id}")]
        public IActionResult Modify(Friend e)
        {
            if (ModelState.IsValid)
            {
                Friend friend = friendStore.modifyFriend(e);
                return RedirectToAction("DataFriend", new { id = friend.Id });
            }

            return View();
        }

        public ActionResult Delete(int? id)
        {
            Friend friend = friendStore.deleteFriend(31);

            return RedirectToAction("Index");
        }
    }
}
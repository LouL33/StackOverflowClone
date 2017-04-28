using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using StackOverflowClone.Models;

namespace StackOverflowClone.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
            {
                ViewBag.IsModerator = HttpContext.User.IsInRole( "Moderator");
                ViewBag.IsAuthenticatedUser = HttpContext.User.IsInRole("AuthenticatedUser");
            }
            var listOfPosts = new ApplicationDbContext().PostModels.ToList();
            return View(listOfPosts);
        }

        //[Authorize(Roles = "AuthenticatedUser")]
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }

}
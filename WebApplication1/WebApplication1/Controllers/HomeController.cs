using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
using WebApplication1.Service;
using WebApplication1.ViewModel;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public UserService userService { get; set; }
        public HomeController()
        {
            userService = new UserService();
        }
        public ActionResult Index()
        {
            List<User> userlist = userService.getusers();
            return View(userlist);
        }

        public ActionResult Create(string id)
        {
            UserViewModel model = new UserViewModel();
            long userid = 0;
            long.TryParse(id, out userid);
            if (userid > 0)
            {
                var user = userService.getuserbyid(userid);
                model = new UserViewModel
                {
                    id = user.id,
                    emailid = user.emailid,
                    firstname = user.firstname,
                    lastname = user.lastname,
                    mobilenumber = user.mobilenumber
                };

            }
    
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.id = model.id;
                user.firstname = model.firstname;
                user.lastname = model.lastname;
                user.emailid = model.emailid;
                user.mobilenumber = model.mobilenumber;
                if (model.id > 0)
                {
                    userService.updateuser(user);
                    TempData["message"] = "User information updated";
                }
                else
                {
                    userService.createuser(user);
                    TempData["message"] = "New user is added";
                    
                }
                return this.RedirectToAction("Index", "Home");
            }
           
            return View(model);
        }


        public ActionResult Delete(string id)
        {
            long userid = 0;
            long.TryParse(id, out userid);
            if (userid > 0)
            {
                 userService.deleteuser(userid);
                TempData["message"] = "User ID "+id +" is deleted";
            }
            else
            {
                TempData["errormessage"] = "Something went wrong.Please try again";
            }

            return this.RedirectToAction("Index", "Home");
        }
    }
}
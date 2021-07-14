using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BryantCornerCafe.Models;


namespace BryantCornerCafe.Controllers
{
    public class HomeController : Controller
    {

        private BryantCornerCafeContext db;
        public HomeController(BryantCornerCafeContext context)
        {
            db = context;
        }

        [HttpGet("/index")]
        public IActionResult Index()
        {
            return View("Index");
            // return View("All");
        }

        [HttpGet("/dishes")]
        public IActionResult All()
        {
            List<Dish> allDishes = db.Dishes
            .Include(Dish => Dish.Chef)
            .OrderByDescending(Dish => Dish.CreatedAt)
            .ToList();
            ViewBag.AllDishes =  allDishes;
            return View("All", allDishes);
            // return View("All");
        }


        // handles the GET request to DISPLAY the form used to create a new Post
        [HttpGet("/dishes/new")]
        public IActionResult New()
        {
            List<User> allUsers = db.Users.OrderByDescending(User => User.CreatedAt).ToList();
            ViewBag.AllUsers = allUsers;

            return View("New");
        }

        
        [HttpGet("/user/new")]
        public IActionResult NewUser()
        {
            return View("NewUser");
        }


        // Params from the URL get turned into method params.
        [HttpGet("/dish/{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("Index");
            }

            return View("Detail", dish);
        }

        
        [HttpGet("/user/{userId}")]
        public IActionResult UserDetails(int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            if (user == null)
            {
                return RedirectToAction("Index");
            }

            return View("UserDetail", user);
        }


            [HttpPost("/dishes/create")]
        public IActionResult CreateProd(Dish newDish)
        {
            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("New");
            }

            // ModelState IS valid

            newDish.ChefId = newDish.ChefId;
            db.Dishes.Add(newDish); 
            // db doesn't update until we run save changes
            // After SaveChanges, our newDish object now has it's DishId from the db.
            db.SaveChanges();

            return RedirectToAction("All");
        }

        
            [HttpPost("/user/create")]
        public IActionResult CreateCat(User newUser)
        {
            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("NewUser");
            }

            // ModelState IS valid

            /* 
            This Add method auto generates SQL code:
            INSERT INTO Dishes (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES ("topic data", "body data", "img url data", NOW(), NOW());
            */
            db.Users.Add(newUser); //accidentally forgot to rename DB from Users to Dishes
            // db doesn't update until we run save changes
            // After SaveChanges, our newDish object now has it's DishId from the db.
            db.SaveChanges();

            return RedirectToAction("All");
        }


        [HttpGet("/dishes/edit/{dishId}")]
        public IActionResult Edit(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            return View("Edit", dish);
        }

        
        [HttpGet("/user/edit/{userId}")]
        public IActionResult EditUser(int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            return View("EditUser", user);
        }


        [HttpPost("/dishes/update/{dishId}")]
        public IActionResult Update(Dish newDish, int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("Edit");
            }
            dish.Name = newDish.Name;
            dish.Chef = newDish.Chef;
            dish.UpdatedAt = DateTime.Now;
            // ModelState IS valid

            /* 
            This Add method auto generates SQL code:
            INSERT INTO Dishes (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES ("topic data", "body data", "img url data", NOW(), NOW());
            */
            db.Dishes.Update(dish);
            db.SaveChanges();

            return RedirectToAction("All");
        }


            [HttpPost("/user/update/{userId}")]
        public IActionResult UpdateUser(User newUser, int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("Edit");
            }
            user.FirstName = newUser.FirstName;
            user.LastName = newUser.LastName;
            user.UpdatedAt = DateTime.Now;
            // ModelState IS valid

            /* 
            This Add method auto generates SQL code:
            INSERT INTO Useres (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES ("topic data", "body data", "img url data", NOW(), NOW());
            */
            db.Users.Update(user);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        
        [HttpPost("/dishes/delete/{dishId}")]

        public IActionResult Delete (int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (dish != null)
            {
                db.Dishes.Remove(dish);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }
        
        [HttpPost("/user/delete/{userId}")]
        public IActionResult DeleteUser (int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }


    }
}

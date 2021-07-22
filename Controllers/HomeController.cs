using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using BryantCornerCafe.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace BryantCornerCafe.Controllers
{
    public class HomeController : Controller
    {

        private BryantCornerCafeContext db;
        public HomeController(BryantCornerCafeContext context)
        {
            db = context;
        }

        public int? uid
        {
            get
            {
                ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                HttpContext.Session.SetInt32("UserId", 1); ////////////////////////////////////////////////////////////////////delete this 4 deployment!
                /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
                return HttpContext.Session.GetInt32("UserId");
            }
        }
        private bool isLoggedIn
        {
            get
            {
                return uid != null;
            }
        }

        [HttpGet("")]
        public IActionResult Dashboard()
        {
            return View("Dashboard");
        }


        [HttpGet("/dishes")]
        public IActionResult All()
        {
            List<Dish> allDishes = db.Dishes
            .OrderByDescending(Dish => Dish.CreatedAt)
            .ToList();
            ViewBag.AllDishes = allDishes;
            return View("All", allDishes);
        }


        [HttpGet("/viewmenu/{categoryId}")]
        public IActionResult ViewMenu(int categoryId)
        {
            Category category = db.Categories
                .Include(category => category.MySubCats)
                .ThenInclude(csRel => csRel.MySubCat)
                .ThenInclude(subc => subc.MyDishes)
                .FirstOrDefault(p => p.CategoryId == categoryId);
            // List<SubCategory> subcategories = db.SubCategories.Include(sub => sub?.CategoryId != categoryId).ToList();
            // ViewBag.MySubCats = category.MySubCats.OrderByDescending(s => s.CreatedAt).ToList();

            if (category == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("ViewMenu", category);
        }


        [HttpGet("/category/new")]
        public IActionResult NewCategory()
        {
            return View("NewCategory");
        }


        [HttpGet("/subcategory/new")]
        public IActionResult NewSubCategory()
        {
            List<Category> allCategories = db.Categories.OrderByDescending(Categories => Categories.Name).Reverse().ToList();
            ViewBag.AllCats = allCategories;

            return View("NewSubCategory");
        }


        // handles the GET request to DISPLAY the form used to create a new Dish
        [HttpGet("/dish/new")]
        public IActionResult NewDish()
        {
            List<SubCategory> allSubCategories = db.SubCategories.OrderBy(SubCategories => SubCategories.Name).ToList();
            ViewBag.AllSubCats = allSubCategories;

            return View("NewDish");
        }


        [HttpGet("/user/new")]
        public IActionResult NewUser()
        {
            return View("NewUser");
        }


        [HttpPost("/category/create")]
        public IActionResult CreateCategory(Category newCategory)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            if (!ModelState.IsValid)
            {
                // To display validation errors.
                return View("NewCategory");
            }

            db.Categories.Add(newCategory);
            db.SaveChanges();

            return RedirectToAction("NewCategory");
        }


        [HttpPost("/subcategory/create")]
        public IActionResult CreateSubCategory(SubCategory newSubCategory)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            if (!ModelState.IsValid)
            {
                // To display validation errors.
                return View("NewSubCategory");
            }

            db.SubCategories.Add(newSubCategory);
            db.SaveChanges();

            return RedirectToAction("NewSubCategory");
        }


        [HttpPost("/dish/create")]
        public IActionResult CreateDish(Dish newDish)
        {
            // if (!isLoggedIn)
            // {
            //     return RedirectToAction("LoginPage", "Login");
            // }
            Console.WriteLine("createdish start");
            if (!ModelState.IsValid)
            {
                Console.WriteLine("modelstate invalid");
                // To display validation errors.
                return View("NewDish");
            }

            Console.WriteLine("valid modelstate - before db entry");
            db.Dishes.Add(newDish);
            db.SaveChanges();
            Console.WriteLine("db saved");

            return RedirectToAction("NewDish");
        }


        [HttpGet("/dish/{dishId}")]
        public IActionResult Details(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            if (dish == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("Detail", dish);
        }


        // add password change form to page
        [HttpGet("/user/{userId}")]
        public IActionResult UserDetails(int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            if (user == null)
            {
                return RedirectToAction("Dashboard");
            }

            return View("UserDetail", user);
        }


        [HttpGet("/dishes/edit/{dishId}")]
        public IActionResult EditDish(int dishId)
        {
            Dish dish = db.Dishes.FirstOrDefault(p => p.DishId == dishId);

            return View("EditDish", dish);
        }


        [HttpGet("/category/edit/{categoryId}")]
        public IActionResult EditCategory(int categoryId)
        {
            Category category = db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);

            List<SubCategory> allSubCats = db.SubCategories
            .OrderByDescending(SubC => SubC.CreatedAt)
            .ToList();
            ViewBag.AllSubCats = allSubCats;

            return View("EditCategory", category);
        }


        [HttpGet("/subcategory/edit/{subcategoryId}")]
        public IActionResult EditSubCategory(int subcategoryId)
        {
            SubCategory subcategory = db.SubCategories.FirstOrDefault(p => p.SubCategoryId == subcategoryId);

            List<Dish> allDishes = db.Dishes
            .OrderByDescending(Dish => Dish.CreatedAt)
            .ToList();
            ViewBag.AllDishes = allDishes;

            return View("EditSubCategory", subcategory);
        }


        [HttpGet("/user/edit/{userId}")]
        public IActionResult EditUser(int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            return View("EditUser", user);
        }


        [HttpPost("/category/update/{categoryId}")]
        public IActionResult UpdateCategory(Category newCategory, int categoryId)
        {
            Category category = db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);

            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("Edit");
            }
            category.Name = newCategory.Name;
            category.Info = newCategory.Info;
            category.UpdatedAt = DateTime.Now;
            // ModelState IS valid

            //"migrate" changes to db and save 
            db.Categories.Update(category);
            db.SaveChanges();

            return RedirectToAction("ViewMenu", "Home", categoryId);
        }


        [HttpPost("/subcategory/update/{subcategoryId}")]
        public IActionResult UpdateSubCategory(SubCategory newSubCategory, int subcategoryId)
        {
            SubCategory subcategory = db.SubCategories.FirstOrDefault(p => p.SubCategoryId == subcategoryId);

            if (ModelState.IsValid == false)
            {
                /* 
                Send back to the page with the form so error messages are
                displayed with the filled in input data.
                */
                return View("Edit");
            }
            subcategory.Name = newSubCategory.Name;
            subcategory.Info = newSubCategory.Info;
            subcategory.UpdatedAt = DateTime.Now;
            // ModelState IS valid

            //"migrate" changes to db and save 
            db.SubCategories.Update(subcategory);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }


        [HttpPost("/dishes/update/{dishId}")]
        public IActionResult UpdateDish(Dish newDish, int dishId)
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
            dish.Description = newDish.Description;
            dish.Price = newDish.Price;
            dish.UpdatedAt = DateTime.Now;
            // ModelState IS valid

            /* 
            This Add method auto generates SQL code:
            INSERT INTO Dishes (Topic, Body, ImgUrl, CreatedAt, UpdatedAt)
            VALUES ("topic data", "body data", "img url data", NOW(), NOW());
            */
            db.Dishes.Update(dish);
            db.SaveChanges();

            return RedirectToAction("Dashboard");
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

            return RedirectToAction("Dashboard");
        }


        [HttpPost("/category/link/{categoryId}/{subcategoryId}")]
        public IActionResult LinkSubCat(int categoryId, int subcategoryId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            CSubRel existingLink = db.CSubRels.FirstOrDefault(link => link.CategoryId == categoryId && link.SubCategoryId == subcategoryId);

            if (existingLink != null)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("unlink");
                db.CSubRels.Remove(existingLink);
            }
            else
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("link");
                CSubRel newLink = new CSubRel()
                {
                    CategoryId = categoryId,
                    SubCategoryId = subcategoryId,
                };
                db.CSubRels.Add(newLink);
            }

            db.SaveChanges();

            return RedirectToAction("EditSubCategory", "Home", subcategoryId);
        }


        [HttpPost("/subcategory/link/{subcategoryId}/{dishId}")]
        public IActionResult LinkDish(int subcategoryId, int dishId)
        {
            if (!isLoggedIn)
            {
                return RedirectToAction("LoginPage", "Login");
            }
            SubDRel existingLink = db.SubDRels.FirstOrDefault(link => link.SubCategoryId == subcategoryId && link.SubCategoryId == subcategoryId);

            if (existingLink != null)
            {
                Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++");
                Console.WriteLine("unlink");
                db.SubDRels.Remove(existingLink);
            }
            else
            {
                SubDRel newLink = new SubDRel()
                {
                    SubCategoryId = subcategoryId,
                    DishId = dishId,
                };
                db.SubDRels.Add(newLink);
            }

            db.SaveChanges();

            return RedirectToAction("Dashboard");
        }


        [HttpPost("/Category/delete/{categoryId}")]

        public IActionResult DeleteCategory(int categoryId)
        {
            Category category = db.Categories.FirstOrDefault(p => p.CategoryId == categoryId);

            if (category != null)
            {
                db.Categories.Remove(category);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }
        [HttpPost("/subcategories/delete/{subcategoryId}")]

        public IActionResult DeleteSubCategory(int subcategoryId)
        {
            SubCategory subcategory = db.SubCategories.FirstOrDefault(p => p.SubCategoryId == subcategoryId);

            if (subcategory != null)
            {
                db.SubCategories.Remove(subcategory);
                db.SaveChanges();
            }
            return RedirectToAction("All");
        }
        [HttpPost("/dishes/delete/{dishId}")]

        public IActionResult DeleteDish(int dishId)
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
        public IActionResult DeleteUser(int userId)
        {
            User user = db.Users.FirstOrDefault(p => p.UserId == userId);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Dashboard");
        }

    }
}

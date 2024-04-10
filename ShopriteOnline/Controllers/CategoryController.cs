using Microsoft.AspNetCore.Mvc;
using ShopriteOnline.Data;
using ShopriteOnline.Models;
using System.Collections.Generic;

namespace ShopriteOnline.Controllers
{
    public class CategoryController : Controller
    {
        private readonly CategoryDbContext db;

        public CategoryController(CategoryDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            List<Category> category = db.categories.ToList();
            return View(category);
        }

        //Create
        public IActionResult Create()
        {
            return View();
        }
        //Post for creating category
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            //Custom Validation
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOrder cannot exactly match the Name.");
            }
            if (obj.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Test is an invalid value.");
            }
            if (ModelState.IsValid)
            {
                db.categories.Add(obj);
                db.SaveChanges();
                //return View();
                return RedirectToAction("Index");
            }
            return View();

        }
        //Edit
        public IActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categpryFromDb = db.categories.Find(id);
            if (categpryFromDb == null)
            {
                return NotFound();
            }
            return View(categpryFromDb);
        }
        //Edit Post
        //Update
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            if (ModelState.IsValid)
            {
                db.categories.Update(obj);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();


        }

        //Delete
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categpryFromDb = db.categories.Find(id);
            if (categpryFromDb == null)
            {
                return NotFound();
            }
            return View(categpryFromDb);
        }
        //Post Delete
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            Category? obj = db.categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            db.categories.Remove(obj);
            db.SaveChanges();
            return RedirectToAction("Index");

        }


    }
}
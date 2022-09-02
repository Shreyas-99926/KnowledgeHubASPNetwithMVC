﻿using KnowledgeHub.Web.Models.Data;
using KnowledgeHub.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KnowledgeHub.Web.Controllers
{
    public class CategoriesController : Controller
    {
        KnowledgeHUbDbContext db = new KnowledgeHUbDbContext();
        public IActionResult Index()
        {

            // fetch the catagory details
            List<Category> categories = db.categories.ToList();
            //ViewBag.CategoryData = categories;

            //ViewData["CategoryData"] = categories;

            //TempData["CategoryData"] = categories;


            return View(categories);
        }
        //for Creating two action method one view
        // /Categories/Create
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Save(Category category)//same action method can be given technically possible 
        //if same method name given routing engine gets confused. //mark this as http post method above and it will recognise.
        //also change the name in view.
        {
            //do validation before adding 
            if (!ModelState.IsValid)
                return View("Create"); //Specify view name if not save will execute 

            //if valid write it to db and return thanks 

            db.categories.Add(category);
            db.SaveChanges();
            //ViewBag.CategoryName = category.Name; //use temp data to temporarily show the feedback on the page
            TempData["Message"] = $" Category {category.Name} Successfully Created"; //no need to have a save view as message is displayed here itself.
            //return View("Index", db.categories.ToList()); //need to write lot of code the number of items need to fetch in index so use redirect method
            return RedirectToAction("Index");
            //use this method 
            //how to display the feedback once save view is deleted?
            //display message in view bag 
        }

        public IActionResult Display()
        {
            //DataSet data = new DataSet();
            //var result = from c in db.Catagories
            //             select c;
            List<Category> categories = db.categories.ToList();
            //ViewBag.CatagoryList = from c  in db.Catagories
            //                       select c;
            return View(categories);
        }
        public IActionResult Delete(int id)
        {
            var res = db.categories.Find(id);
            return View(res);
        }
        public IActionResult Del(int id)
        {
            if (!ModelState.IsValid)
                return View("Create");

            var res = db.categories.Find(id);
            db.categories.Remove(res);
            db.SaveChanges();

            return RedirectToAction("Display");
        }
        public IActionResult Edit(int id)
        {
            var res = db.categories.Find(id);
            return View(res);
        }

    }
}   
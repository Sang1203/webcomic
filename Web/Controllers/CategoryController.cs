﻿using System;
using System.Linq;
using System.Web.Mvc;
using Model.DAO;
using Model.EF;

namespace WebComic.Controllers
{
    public class CategoryController : Controller
    {
        // GET
        public ActionResult Index()
        {
            CategoryDAO categoryDao = new CategoryDAO();

            var list = categoryDao.List();
            ViewBag.ListCategory = list;
            return View();
        }

        [HttpPost]
        public ActionResult Delete()
        {
            category category = new category();
            category.CategoryId = Convert.ToInt32(Request["id"]);
            return Content("true");
        }


        public ActionResult _Navbar()
        {
            CategoryDAO categoryDao = new CategoryDAO();
            ViewBag.Data = categoryDao.List();

            return PartialView("_Navbar");
        }

        public ActionResult _FilterBar()
        {
            CategoryDAO categoryDao = new CategoryDAO();
            ViewBag.Data = categoryDao.List().OrderBy(category => category.CategoryId);

            StatusComicDAO statusComicDao = new StatusComicDAO();
            ViewBag.Status = statusComicDao.ListUser();
            
            NationDAO nationDao = new NationDAO();
            ViewBag.Nation = nationDao.List();
            
            return PartialView("_FilterBar");
        }
    }
}
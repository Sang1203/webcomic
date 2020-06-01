﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Routing;
using System.Web.Routing;
using Model.DAO;
using Model.EF;
using Model.Models;
using Newtonsoft.Json;

namespace WebComic.Controllers
{
    public class ComicController : Controller
    {
        // GET
        public ActionResult Index(int comicId)
        {
            ComicDAO comicDao = new ComicDAO();
            comic comic = comicDao.GetComicAs(comicId).Result;


            ViewBag.Title = comic.NameComic;
            ViewBag.Data = comic;

            return View();
        }

        public ActionResult Home()
        {
            var page = Convert.ToInt32(Request["page"]);

            if (page < 1)
            {
                page = 1;
            }

            ComicDAO comicDao = new ComicDAO();
            var list = comicDao.NewUpComic(new Pagination(12, page));

            // news comic

            List<comic> comics = list.Comics;
            ViewBag.ComicsMain = comics;

            int numPage = list.PageSize;
            ViewBag.Numpage = numPage;

            ViewBag.Page = page;

            return View();
        }

        public ActionResult ComicCategory()
        {
            return View();
        }

        public ActionResult _Slide()
        {
            ComicDAO comicDao = new ComicDAO();
            ViewBag.Data = comicDao.SlideComic();

            return PartialView("_Slide");
        }

        public ActionResult _ComicNew()
        {
            ComicDAO comicDao = new ComicDAO();
            ViewBag.Data = comicDao.NewComic().OrderBy(comic => comic.ReleaseDate);

            return PartialView("_ComicNew");
        }


        public ActionResult SearchAdvanced(String NameComic, String page)
        {
            SuperSearch superSearch = new SuperSearch();
            ComicDAO comicDao = new ComicDAO();

            superSearch.NameComic = NameComic;

            String url = "";

            if (superSearch.NameComic != null)
            {
                url = url + String.Format("{0}={1}", nameof(superSearch.NameComic), NameComic);
            }

            var comics = comicDao.SearchAdvanced(superSearch, new Pagination(16, Convert.ToInt32(page)));

            ViewBag.Data = comics.Comics;

            ViewBag.Numpage = comics.PageSize;

            ViewBag.Page = comics.Page;

            ViewBag.Url = url;

            return View();
        }

        public ActionResult Test(String[] arrayIn, String[] arrayNotIn, String nameComic, String status, String author,
            String nation)
        {
            List<String> listIn = new List<string>();
            List<String> listNotIn = new List<string>();

            if (arrayIn != null)
            {
                listIn = arrayIn.ToList();
            }

            if (arrayNotIn != null)
            {
                listNotIn = arrayNotIn.ToList();
            }


            SuperSearch superSearch = new SuperSearch(listIn, listNotIn, Convert.ToInt32(nation),
                Convert.ToInt32(status),
                nameComic, author);

            ComicDAO comicDao = new ComicDAO();
            Pagination pagination = new Pagination(16, 1);

            PaginationComic paginationComic = comicDao.SearchAdvanced(superSearch, pagination);
            List<comic> comics = paginationComic.Comics;
            int page = paginationComic.Page;

            String json = JsonConvert.SerializeObject(comics);

            return Content(json);
        }
    }
}
﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SPV.Controllers
{
    public class ResturantController : Controller
    {
        // GET: ResturantController
        public ActionResult Index()
        {
            return View();
        }

        // GET: ResturantController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ResturantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ResturantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResturantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ResturantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ResturantController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ResturantController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
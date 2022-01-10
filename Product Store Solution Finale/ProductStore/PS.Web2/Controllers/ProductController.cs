using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PS.Domain;
using PS.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PS.Web2.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService prdsrv;
        private readonly ICategoryService catsrv;
        public ProductController(IProductService ps, ICategoryService cs)
        {
            prdsrv = ps;
            catsrv = cs;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            return View(prdsrv.GetMany());
        }
        [HttpPost]
        public ActionResult Index(string filter)
        {
            var list = prdsrv.GetMany();
            if (!String.IsNullOrEmpty(filter))
            {
                list = list.Where(p => p.Name.ToString().Equals(filter)).ToList();
            }
            return View(list);
        }

        public ActionResult Index2()
        {
            return View(prdsrv.GetMany());
        }


        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            return View(prdsrv.GetById(id));
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            var categories = catsrv.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product p, IFormFile file)
        {
            try
            {
                p.Image2 = file.FileName;
                if (file != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads",
                    file.FileName);
                    using (System.IO.Stream stream = new FileStream(path, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                }
                prdsrv.Add(p);
                prdsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            var categories = catsrv.GetMany();
            ViewBag.CategoryId = new SelectList(categories, "CategoryId", "Name");
            return View(prdsrv.GetById(id));
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product p)
        {
            try
            {
                prdsrv.Update(p);
                prdsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(prdsrv.GetById(id));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Product p)
        {
            try
            {
                prdsrv.Delete(p);
                prdsrv.Commit();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

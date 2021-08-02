using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Mvc;

namespace Cities
{
    class CityController : Controller
    {
        private IGenericRepository<City> repository = null;
        public CityController()
        {
            this.repository = new GenericRepository<City>();
        }
        public CityController(IGenericRepository<City> repository)
        {
            this.repository = repository;
        }
       
        public ActionResult Index()
        {
            var model = repository.GetAll();
            return View(model);
        }
        
        public ActionResult AddCity()
        {
            return View();
        }
       
        public ActionResult AddCity(City model)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(model);
                repository.Save();
                return RedirectToAction("Index", "City");
            }
            return View();
        }
        
        public ActionResult EditCity(int cityID)
        {
            City model = repository.GetById(cityID);
            return View(model);
        }
        
        public ActionResult EditCity(City model)
        {
            if (ModelState.IsValid)
            {
                repository.Update(model);
                repository.Save();
                return RedirectToAction();
            }
            else
            {
                return View(model);
            }
        }
        
        public ActionResult DeleteCity(int cityID)
        {
            City model = repository.GetById(cityID);
            return View(model);
        }
        
        public ActionResult Delete(int cityID)
        {
            repository.Delete(cityID);
            repository.Save();
            return RedirectToAction("Index", "City");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.ViewModels;
using Excellency.Models;
using Microsoft.AspNetCore.Mvc;

namespace Excellency.Controllers
{
    public class ModuleController : Controller
    {
        private IModule _Module;

        public ModuleController(IModule module)
        {
            _Module = module;
        }
        public IActionResult Index()
        {
            var result = _Module.Modules().Select
                (a => new ModuleViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                }).ToList();
            var model = new ModuleIndexViewModel
            {
                Modules = result
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(ModuleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Module
                {
                    Id = model.Id,
                    Description = model.Description,
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Module.Add(department);
                }
                else
                {
                    _Module.Update(department);
                }
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _Module.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
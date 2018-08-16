using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.Models;
using Excellency.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Excellency.Controllers
{
    public class PositionController : Controller
    {
        private IPosition _Position;

        public PositionController(IPosition position)
        {
            _Position = position;
        }
        public IActionResult Index()
        {
            var result = _Position.Positions().Select
                (a => new PositionViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                }).ToList();
            var model = new PositionIndexViewModel
            {
                Positions = result
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Position
                {
                    Id = model.Id,
                    Description = model.Description,
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Position.Add(department);
                }
                else
                {
                    _Position.Update(department);
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
            _Position.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
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
    public class RoleController : Controller
    {
        private IRole _Role;

        public RoleController(IRole role)
        {
            _Role = role;
        }
        public IActionResult Index()
        {
            var result = _Role.Roles().Select
                (a => new RoleViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                }).ToList();
            var model = new RoleIndexViewModel
            {
                Roles = result
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Role
                {
                    Id = model.Id,
                    Description = model.Description,
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Role.Add(department);
                }
                else
                {
                    _Role.Update(department);
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
            _Role.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
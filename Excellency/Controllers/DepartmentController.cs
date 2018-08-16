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
    public class DepartmentController : Controller
    {
        private IDepartment _Department;

        public DepartmentController(IDepartment department)
        {
            _Department = department;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            var result = _Department.Departments().Select
                (a => new DepartmentViewModel
                {
                    Id = a.Id,
                    Description = a.Description
                }).ToList();
            var model = new DepartmentIndexViewModel{
                Departments = result
            };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(DepartmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var department = new Department
                {
                    Id = model.Id,
                    Description = model.Description,
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Department.Add(department);
                }
                else
                {
                    _Department.Update(department);
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
            _Department.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}

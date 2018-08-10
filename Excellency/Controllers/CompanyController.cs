using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Excellency.Models;
namespace Excellency.Controllers
{
    public class CompanyController : Controller
    {
        private ICompany _Company;

        public CompanyController(ICompany company)
        {
            _Company = company;
        }
        public IActionResult Index()
        {
            var result = _Company.Companies().Select
                (
                   a => new CompanyViewModel
                   {
                       Id = a.Id,
                       Description = a.Description
                   }
                ).ToList();
            var model = new CompanyIndexViewModel();
            model.Companies = result;
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(CompanyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var company = new Company
                {
                    Id = model.Id,
                    Description = model.Description,
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Company.Add(company);
                }
                else
                {
                    _Company.Update(company);
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
            _Company.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
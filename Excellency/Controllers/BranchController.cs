using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Excellency.Models;

namespace Excellency.Controllers
{
    public class BranchController : Controller
    {
        private IBranch _Branch;

        public BranchController(IBranch branch)
        {
            _Branch = branch;
        }

        public IActionResult Index()
        {
            var result = _Branch.Branches().Select
                (
                a => new BranchViewModel
                {
                    Id = a.Id,
                    Description = a.Description,
                    Company = a.Company.Description
                }
                ).ToList();
            var model = new BranchIndexViewModel
            {
                Branches = result,
                Companies = this.CompanyList()
            };
            return View(model);
        }

        private IEnumerable<SelectListItem> CompanyList()
        {
            var result = _Branch.Companies().Select
                (
                a => new SelectListItem
                {
                    Value = a.Id.ToString(),
                    Text = a.Description
                }
                ).ToList();
            return result;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(BranchViewModel model)
        {
            if (ModelState.IsValid)
            {
                var branch = new Branch
                {
                    Id = model.Id,
                    Description = model.Description,
                    Company = _Branch.GetCompanyById(int.Parse(model.CompanyId))
                };
                if (model.Id.ToString().Length <= 0)
                {
                    _Branch.Add(branch);
                }
                else
                {
                    _Branch.Update(branch);
                }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _Branch.RemoveById(id);
            return RedirectToAction("Index");
        }
    }
}
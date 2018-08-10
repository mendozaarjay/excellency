using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View();
        }
    }
}
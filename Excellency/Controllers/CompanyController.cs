using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Excellency.Interfaces;
using Excellency.ViewModels;
using Microsoft.AspNetCore.Mvc;

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
    }
}
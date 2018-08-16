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
    public class RoleModuleController : Controller
    {
        private IRoleModuleAssignment _RoleModule;

        public RoleModuleController(IRoleModuleAssignment roleModule)
        {
            _RoleModule = roleModule;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Save(RoleModuleAssignmentViewModel model)
        {
            if (ModelState.IsValid)
            {
                var header = new RoleModulesHeader
                {
                    Id = model.Header.Id,
                    Role = _RoleModule.GetRoleById(int.Parse(model.Header.RoleId))
                };
                var lineitems = new List<RoleModulesLine>();

                foreach(var item in model.LineItems)
                {
                    var line = new RoleModulesLine
                    {
                        Id = item.Id,
                        Approve = item.Approve,
                        Delete = item.Delete,
                        Export = item.Export,
                        Import = item.Import,
                        New = item.New,
                        Print = item.Print,
                        Post = item.Post,
                        Save = item.Save,
                        Search = item.Search,
                        Module = _RoleModule.GetModuleById(int.Parse(item.Module))
                    };
                    lineitems.Add(line);
                }
                if (header.Id.ToString().Length <= 0)
                {
                    _RoleModule.Add(header, lineitems);
                }
                else { _RoleModule.Update(header, lineitems); }
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _RoleModule.RemoveById(id);
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteLineItem(int id)
        {
            _RoleModule.RemoveLineById(id);
            return RedirectToAction("Index");
        }
    }
}
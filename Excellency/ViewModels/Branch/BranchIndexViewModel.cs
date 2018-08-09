using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Excellency.ViewModels
{
    public class BranchIndexViewModel
    {
        public BranchViewModel Branch { get; set; }
        public IEnumerable<BranchViewModel> Branches { get; set; }
        public IEnumerable<SelectListItem> Companies { get; set; }
    }
}

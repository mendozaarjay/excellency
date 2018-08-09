using System.Collections.Generic;

namespace Excellency.ViewModels
{
    public class CompanyIndexViewModel
    {
        public CompanyViewModel Company { get; set; }
        public IEnumerable<CompanyViewModel> Companies { get; set; }
    }
}

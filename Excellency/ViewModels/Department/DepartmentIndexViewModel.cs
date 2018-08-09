using System.Collections.Generic;

namespace Excellency.ViewModels
{
    public class DepartmentIndexViewModel
    {
        public DepartmentViewModel Department { get; set; }
        public IEnumerable<DepartmentViewModel> Departments { get; set; }
    }
}

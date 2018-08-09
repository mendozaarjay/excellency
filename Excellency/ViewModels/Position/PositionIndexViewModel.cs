using System.Collections.Generic;

namespace Excellency.ViewModels
{
    public class PositionIndexViewModel
    {
        public PositionViewModel Position { get; set; }
        public IEnumerable<PositionViewModel> Positions { get; set; }
    }
}

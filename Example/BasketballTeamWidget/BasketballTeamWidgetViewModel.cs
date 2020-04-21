using System.Collections.Generic;

namespace MedioClinic.Models.Widgets.BasketballTeamWidget
{
    public class BasketballTeamWidgetViewModel
    {
        public string Name { get; set; }
        public BasketballCoachViewModel Coach { get; set; }
        public IEnumerable<BasketballPlayerViewModel> Roster { get; set; }
    }

    public class BasketballPlayerViewModel
    {
        public string FullName { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
    }

    public class BasketballCoachViewModel
    {
        public string FullName { get; set; }
    }
}

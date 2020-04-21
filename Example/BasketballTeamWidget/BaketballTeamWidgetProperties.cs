using CMS.DocumentEngine.Types.MedioClinic;
using Kentico.Forms.Web.Mvc;
using Kentico.PageBuilder.Web.Mvc;
using MedioClinic.Models.FormComponents.DocumentMultiSelection;
using MedioClinic.Models.FormComponents.DocumentSelection;

namespace MedioClinic.Models.Widgets.BasketballTeamWidget
{
    public class BasketballTeamWidgetProperties : IWidgetProperties
    {
        [EditingComponent(TextInputComponent.IDENTIFIER, Order = 100)]
        public string Name { get; set; }

        [EditingComponent(DocumentSelectionComponent.Identifier, Order = 200, Label = "Head coach")]
        [EditingComponentProperty("PageTypeName", BasketballCoach.CLASS_NAME)]
        public string CoachId { get; set; }

        [EditingComponent(DocumentMultiSelectionComponent.Identifier, Order = 300, Label = "Roster")]
        [EditingComponentProperty("PageTypeName", BasketballPlayer.CLASS_NAME)]
        public string PlayerIds { get; set; }
    }
}

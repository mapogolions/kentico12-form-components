using Kentico.Forms.Web.Mvc;
using MedioClinic.Models.FormComponents.PageTypeSelection;

namespace MedioClinic.Models.FormComponents.DocumentSelection
{
    public class DocumentSelectionProperties : SelectorProperties
    {
        [EditingComponent(PageTypeSelectionComponent.Identifier)]
        public string PageTypeName { get; set; }
    }
}

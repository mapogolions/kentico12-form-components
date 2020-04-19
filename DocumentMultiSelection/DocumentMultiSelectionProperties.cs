using Kentico.Forms.Web.Mvc;
using MedioClinic.Models.FormComponents.PageTypeSelection;

namespace MedioClinic.Models.FormComponents.DocumentMultiSelection
{
    public class DocumentMultiSelectionProperties : SelectorProperties
    {
        [EditingComponent(PageTypeSelectionComponent.Identifier)]
        public string PageTypeName { get; set; }
    }
}
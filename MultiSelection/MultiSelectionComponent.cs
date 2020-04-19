using System;
using System.Linq;
using System.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using MedioClinic.Models.FormComponents.MultiSelection;

[assembly: RegisterFormComponent(
    MultiSelectionComponent.Identifier,
    typeof(MultiSelectionComponent),
    "{$FormComponent.MultiSelection.Name$}",
    Description = "{$FormComponent.MultiSelection.Description$}",
    IconClass = "icon-menu")]

namespace MedioClinic.Models.FormComponents.MultiSelection
{
    public class MultiSelectionComponent : BaseMultiSelectionComponent<MultiSelectionProperties>
    {
        public const string Identifier = "MedioClinic.FormComponent.MultiSelection";

        public override MultiSelectList Items()
        {
            var items = Enumerable.Empty<string>();
            if (!string.IsNullOrEmpty(Properties.DataSource))
            {
                items = Properties.DataSource.Split(new[] {"\r\n"}, StringSplitOptions.None);
            }
            return new MultiSelectList(items);
        }
    }
}
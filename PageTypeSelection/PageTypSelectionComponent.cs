using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using CMS.SiteProvider;
using Kentico.Forms.Web.Mvc;
using MedioClinic.Models.FormComponents.PageTypeSelection;

[assembly: RegisterFormComponent(
    PageTypeSelectionComponent.Identifier,
    typeof(PageTypeSelectionComponent),
    "{$FormComponent.PageTypeSelection.Name$}",
    Description = "{$FormComponent.PageTypeSelection.Description$}",
    IconClass = "icon-menu")]

namespace MedioClinic.Models.FormComponents.PageTypeSelection
{
    public class PageTypeSelectionComponent : SelectorFormComponent<PageTypeSelectionProperties>
    {
        public const string Identifier = "MedioClinic.FormComponent.PageTypeSelection";

        protected override IEnumerable<SelectListItem> GetItems()
        {
            var asm = typeof(PageTypesLocationAttribute).Assembly;
            var pageTypes = asm.DefinedTypes.Where(it => typeof(TreeNode).IsAssignableFrom(it)).ToList();
            return pageTypes?.Select(it => new SelectListItem
            {
                Text = it.Name,
                Value = $"{SiteContext.CurrentSiteName}.{it.Name}"
            });
        }
    }
}

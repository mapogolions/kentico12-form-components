using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.Web.Mvc;
using MedioClinic.Models.FormComponents.DocumentSelection;

[assembly: RegisterFormComponent(
    DocumentSelectionComponent.Identifier,
    typeof(DocumentSelectionComponent),
    "{$FormComponent.DocumentSelection.Name$}",
    Description = "{$FormComponent.DocumentSelection.Description$}",
    IconClass = "icon-menu")]

namespace MedioClinic.Models.FormComponents.DocumentSelection
{
    public class DocumentSelectionComponent : SelectorFormComponent<DocumentSelectionProperties>
    {
        public const string Identifier = "MedioClinic.FormComponent.DocumentSelection";

        protected override IEnumerable<SelectListItem> GetItems()
        {
            if (string.IsNullOrEmpty(Properties.PageTypeName))
            {
                return Enumerable.Empty<SelectListItem>();
            }
            return DocumentHelper.GetDocuments(Properties.PageTypeName)
                .AddColumns("DocumentID", "DocumentName")
                .OnSite(SiteContext.CurrentSiteID)
                .LatestVersion()
                .Published(false)
                .Culture(System.Web.HttpContext.Current.Kentico().Preview().CultureName)
                .Select(it => new SelectListItem
                {
                    Text = it.DocumentName,
                    Value = it.DocumentID.ToString()
                });
        }
    }
}

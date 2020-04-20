using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CMS.DocumentEngine;
using CMS.SiteProvider;
using Kentico.Content.Web.Mvc;
using Kentico.Forms.Web.Mvc;
using Kentico.Web.Mvc;
using MedioClinic.Models.FormComponents.DocumentMultiSelection;

[assembly: RegisterFormComponent(
    DocumentMultiSelectionComponent.Identifier,
    typeof(DocumentMultiSelectionComponent),
    "{$FormComponent.DocumentMultiSelection.Name$}",
    Description = "{$FormComponent.DocumentMultiSelection.Description$}",
    IconClass = "icon-menu")]

namespace MedioClinic.Models.FormComponents.DocumentMultiSelection
{
    public class DocumentMultiSelectionComponent : BaseMultiSelectionComponent<DocumentMultiSelectionProperties>
    {
        public const string Identifier = "MedioClinic.FormComponent.DocumentMultiSelection";

        public override MultiSelectList Items()
        {
            return new MultiSelectList(GetDocuments(), "DocumentID", "DocumentName");
        }

        private IEnumerable<TreeNode> GetDocuments()
        {
            if (string.IsNullOrEmpty(Properties.PageTypeName))
            {
                return Enumerable.Empty<TreeNode>();
            }
            return DocumentHelper.GetDocuments(Properties.PageTypeName)
                .AddColumns("DocumentID", "DocumentName")
                .OnSite(SiteContext.CurrentSiteID)
                .LatestVersion()
                .Published(false)
                .Culture(System.Web.HttpContext.Current.Kentico().Preview().CultureName);
        }
    }
}

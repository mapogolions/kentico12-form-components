using System;
using System.Web.Mvc;
using Kentico.Forms.Web.Mvc;

namespace MedioClinic.Models.FormComponents
{
    public abstract  class BaseMultiSelectionComponent<TProperties> : FormComponent<TProperties, string>
        where TProperties : SelectorProperties, new()
    {
        [BindableProperty]
        public string[] SelectedItems { get; set; } = Array.Empty<string>();

        public override string LabelForPropertyName => nameof(SelectedItems);


        public override string GetValue() => string.Join(",", SelectedItems);

        public override void SetValue(string value)
        {
            SelectedItems = string.IsNullOrEmpty(value)
                ? Array.Empty<string>() : value.Split(',');
        }

        public abstract MultiSelectList Items();
    }
}

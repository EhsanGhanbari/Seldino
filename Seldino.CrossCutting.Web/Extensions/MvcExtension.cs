using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Web.Mvc;

namespace Seldino.CrossCutting.Web.Extensions
{
    public static class MvcExtension
    {
        public static IEnumerable<string> GetMessages(this ModelStateDictionary modelState)
        {
            if (modelState.Any(x => x.Value.Errors.Any()))
            {
                foreach (var error in modelState.Values.SelectMany(value => value.Errors))
                {
                    yield return error.ErrorMessage;
                }
            }
        }

        public static MvcHtmlString EnumCheckBoxListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var enumModelType = metadata.ModelType;

            // Check to make sure this is an enum.
            if (!enumModelType.IsEnum)
            {
                throw new ArgumentException("This helper can only be used with enums. Type used was: " +
                                            enumModelType.FullName + ".");
            }

            // Create string for Element.
            var stringBuilder = new StringBuilder();

            foreach (Enum item in Enum.GetValues(enumModelType))
            {
                if (Convert.ToInt32(item) != 0)
                {
                    var templateInfo = htmlHelper.ViewData.TemplateInfo;

                    var id = templateInfo.GetFullHtmlFieldId(item.ToString());

                    //Derive property name for checkbox name
                    var body = (MemberExpression)expression.Body;

                    var propertyName = body.Member.Name;

                    var name = templateInfo.GetFullHtmlFieldName(propertyName);

                    //Get currently select values from the ViewData model
                    TEnum selectedValues = expression.Compile().Invoke(htmlHelper.ViewData.Model);

                    var label = new TagBuilder("label");

                    label.Attributes["for"] = id;

                    label.Attributes["style"] = "display: inline-block;";

                    var field = item.GetType().GetField(item.ToString());

                    // Add checkbox.
                    var checkbox = new TagBuilder("input");

                    checkbox.Attributes["id"] = id;

                    checkbox.Attributes["name"] = name;

                    checkbox.Attributes["type"] = "checkbox";

                    checkbox.Attributes["value"] = item.ToString();

                    if ((selectedValues as Enum != null) && ((selectedValues as Enum).HasFlag(item)))
                    {
                        checkbox.Attributes["checked"] = "checked";
                    }
                    stringBuilder.AppendLine(checkbox.ToString());

                    // Check to see if Display attribute has been set for item.
                    var display = (DisplayAttribute)
                        field.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();

                    label.SetInnerText(display != null ? display.Name : field.Name);

                    stringBuilder.AppendLine(label.ToString());

                    // Add line break.
                    stringBuilder.AppendLine("<br />");
                }
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        public static MvcHtmlString EnumRadioButtonListFor<TModel, TEnum>(this HtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TEnum>> expression)
        {
            var metadata = ModelMetadata.FromLambdaExpression(expression, htmlHelper.ViewData);

            var enumModelType = metadata.ModelType;

            // Check to make sure this is an enum.
            if (!enumModelType.IsEnum)
            {
                throw new ArgumentException("This helper can only be used with enums. Type used was: " +
                                            enumModelType.FullName + ".");
            }

            // Create string for Element.
            var stringBuilder = new StringBuilder();

            foreach (Enum item in Enum.GetValues(enumModelType))
            {
                if (Convert.ToInt32(item) != 0)
                {
                    var templateInfo = htmlHelper.ViewData.TemplateInfo;

                    var id = templateInfo.GetFullHtmlFieldId(item.ToString());

                    //Derive property name for checkbox name
                    var body = (MemberExpression)expression.Body;

                    var propertyName = body.Member.Name;

                    var name = templateInfo.GetFullHtmlFieldName(propertyName);

                    //Get currently select values from the ViewData model
                    TEnum selectedValues = expression.Compile().Invoke(htmlHelper.ViewData.Model);

                    var label = new TagBuilder("label");

                    label.Attributes["for"] = id;

                    var field = item.GetType().GetField(item.ToString());

                    // Add checkbox.
                    var checkbox = new TagBuilder("input");

                    checkbox.Attributes["id"] = id;

                    checkbox.Attributes["name"] = name;

                    checkbox.Attributes["type"] = "radio";

                    checkbox.Attributes["value"] = item.ToString();

                    if ((selectedValues as Enum != null) && ((selectedValues as Enum).HasFlag(item)))
                    {
                        checkbox.Attributes["checked"] = "checked";
                    }
                    stringBuilder.AppendLine(checkbox.ToString());

                    // Check to see if Display attribute has been set for item.
                    var display = (DisplayAttribute)field.GetCustomAttributes(typeof(DisplayAttribute), true).FirstOrDefault();

                    label.InnerHtml = display != null ? display.Name : field.Name;

                    var descriptionAttribute = (DescriptionAttribute)field.GetCustomAttributes(typeof(DescriptionAttribute), true).FirstOrDefault();

                    if (descriptionAttribute != null)
                    {
                        var spanTag = new TagBuilder("span");

                        spanTag.AddCssClass("description");

                        spanTag.SetInnerText(descriptionAttribute.Description ?? String.Empty);

                        label.InnerHtml += spanTag.ToString();
                    }

                    stringBuilder.AppendLine(label.ToString());

                    // Add line break.
                    stringBuilder.AppendLine("<br />");
                }
            }

            return MvcHtmlString.Create(stringBuilder.ToString());
        }

        public static MvcHtmlString EnumDropDownList<TModel>(this HtmlHelper helper, string name)
        {
            var selectTag = new TagBuilder("select");

            selectTag.Attributes.Add("name", name);

            foreach (var item in Enum.GetValues(typeof(TModel)).Cast<TModel>())
            {
                var optionTag = new TagBuilder("option");

                optionTag.Attributes.Add("value", Convert.ToInt32(item).ToString());

                optionTag.SetInnerText(item.GetDisplayName());

                selectTag.InnerHtml += optionTag.ToString();
            }

            return MvcHtmlString.Create(selectTag.ToString());
        }

        public static MvcHtmlString CheckBoxList(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> items)
        {
            if (items != null && items.Any())
            {
                var divTag = new TagBuilder("div");

                long checkBoxIndex = 0;

                foreach (var listItem in items)
                {
                    //  <input>
                    var tagBuilder = new TagBuilder("input");

                    tagBuilder.Attributes.Add("type", "checkbox");

                    string checkboxId = $"{name}_{checkBoxIndex}";

                    tagBuilder.Attributes.Add("id", checkboxId);

                    tagBuilder.Attributes.Add("name", name);

                    tagBuilder.Attributes.Add("value", listItem.Value);

                    divTag.InnerHtml += tagBuilder.ToString(TagRenderMode.SelfClosing);

                    checkBoxIndex++;

                    //  <label>
                    tagBuilder = new TagBuilder("label");

                    tagBuilder.Attributes.Add("for", checkboxId);

                    tagBuilder.SetInnerText(listItem.Text);

                    divTag.InnerHtml += tagBuilder.ToString(TagRenderMode.Normal);

                    //  <br />
                    tagBuilder = new TagBuilder("br");

                    divTag.InnerHtml += tagBuilder.ToString(TagRenderMode.SelfClosing);
                }

                return MvcHtmlString.Create(divTag.ToString(TagRenderMode.Normal));
            }

            return MvcHtmlString.Empty;
        }

        /// <summary>
        ///  http://biasecurities.com/2011/01/asp-net-mvc-selectlist-extension-methods/
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="items"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <param name="selectedValue"></param>
        /// <returns></returns>
        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, string selectedValue)
        {
            return items.ToSelectListItems(name, value, selectedValue, false);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, string selectedValue, bool includeNotApplicable, string notApplicableValue = "", string notApplicableText = "(Not Applicable)")
        {
            return items.ToSelectListItems(name, value, x => value(x) == selectedValue, includeNotApplicable, notApplicableValue, notApplicableText);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected)
        {
            return items.ToSelectListItems(name, value, isSelected, false);
        }

        public static IEnumerable<SelectListItem> ToSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected, bool includeNotApplicable, string notApplicableValue = "", string notApplicableText = "(Not Applicable)")
        {
            if (includeNotApplicable)
            {
                var returnItems = new List<SelectListItem>
                {
                    new SelectListItem
                    {
                        Text = notApplicableText,
                        Value = notApplicableValue,
                        Selected = false
                    }
                };

                if (items != null)
                {
                    returnItems.AddRange(items.Select(item => new SelectListItem
                    {
                        Text = name(item),
                        Value = value(item),
                        Selected = isSelected(item)
                    }));
                }
                return returnItems;
            }

            if (items == null)
                return new List<SelectListItem>();

            return items.Select(item => new SelectListItem
            {
                Text = name(item),
                Value = value(item),
                Selected = isSelected(item)
            });
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<int> selectedValues)
        {
            if (selectedValues == null)
                selectedValues = new List<int>();
            return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<long> selectedValues)
        {
            if (selectedValues == null)
                selectedValues = new List<long>();
            return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<double> selectedValues)
        {
            if (selectedValues == null)
                selectedValues = new List<double>();
            return ToMultiSelectListItems(items, name, value, (IEnumerable<int>) selectedValues.Select(x => x.ToString()));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<decimal> selectedValues)
        {
            if (selectedValues == null)
                selectedValues = new List<decimal>();
            return items.ToMultiSelectListItems(name, value, selectedValues.Select(x => x.ToString()));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, IEnumerable<string> selectedValues)
        {
            if (items == null)
                return new List<SelectListItem>();

            if (selectedValues == null)
                selectedValues = new List<string>();

            return items.ToMultiSelectListItems(name, value, x => selectedValues.Contains(value(x)));
        }

        public static IEnumerable<SelectListItem> ToMultiSelectListItems<T>(this IEnumerable<T> items, Func<T, string> name, Func<T, string> value, Func<T, bool> isSelected)
        {
            if (items == null)
                return new List<SelectListItem>();

            return items.Select(item => new SelectListItem
            {
                Text = name(item),
                Value = value(item),
                Selected = isSelected(item)
            });
        }

        /// <summary>
        /// Helper for enum
        /// </summary>
        /// <typeparam name="TEnum"></typeparam>
        /// <param name="enumObj"></param>
        /// <returns></returns>
        public static SelectList ToSelectList<TEnum>(this TEnum enumObj)
            where TEnum : struct, IComparable, IFormattable, IConvertible
        {
            var values = from TEnum e in Enum.GetValues(typeof(TEnum))
                select new { Id = e, Name = e.ToString() };
            return new SelectList(values, "Id", "Name", enumObj);
        }
    }
}

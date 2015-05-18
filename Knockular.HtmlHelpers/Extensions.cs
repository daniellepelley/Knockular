using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Knockular.HtmlHelpers
{
    public static class Extensions
    {
        public static IHtmlStringBuilderFactory HtmlStringBuilderFactory { get; set; }

        public static bool IsAngular(this HtmlHelper helper)
        {
            return HtmlStringBuilderFactory.Create() is AngularHtmlStringBuilder;
        }

        public static bool IsKnockout(this HtmlHelper helper)
        {
            return HtmlStringBuilderFactory.Create() is KnockoutHtmlStringBuilder;
        }

        public static IHtmlStringBuilder Bind(this HtmlHelper helper, string property)
        {
            var builder = HtmlStringBuilderFactory.Create();
            builder.Bind(property);
            return builder;
        }

        public static IHtmlStringBuilder Click(this HtmlHelper helper, string function)
        {
            var builder = HtmlStringBuilderFactory.Create();
            builder.Click(function);
            return builder;
        }

        public static IHtmlStringBuilder Visible(this HtmlHelper helper, string flag)
        {
            var builder = HtmlStringBuilderFactory.Create();
            builder.Visible(flag);
            return builder;
        }

        public static IHtmlString Template(this HtmlHelper helper, string partialView, string templateId)
        {
            var stringBuilder = new StringBuilder();
            var html = helper.Partial(partialView).ToHtmlString();

            if (helper.IsAngular())
            {
                stringBuilder.AppendLine(string.Format(@"<script type=""text/ng-template"" id=""{0}"">", templateId));
                stringBuilder.AppendLine(html);
                stringBuilder.AppendLine("</script>");
            }
            else
            {
                stringBuilder.AppendLine(string.Format(@"<script type=""text/html"" id=""{0}"">", templateId));
                stringBuilder.AppendLine(html);
                stringBuilder.AppendLine("</script>");
            }

            return new HtmlString(stringBuilder.ToString());
        }

        public static IHtmlString UseTemplate(this HtmlHelper helper, string templateId)
        {
            var builder = HtmlStringBuilderFactory.Create();
            builder.UseTemplate(templateId);
            return builder;
        }

        public static HtmlSelfClosingBuilder ForEach(this HtmlHelper helper, string collectionName, string itemName)
        {
            string attribute;

            if (helper.IsAngular())
            {
                var value = string.Format("{0} in {1}", itemName, collectionName);
                attribute = string.Format(@"{0}=""{1}""", "ng-repeat", value);
            }
            else
            {
                var value = string.Format(@"data: {0}, as: '{1}'", collectionName, itemName);
                attribute = string.Format(@"data-bind=""foreach: {0}""", "{ " + value + " }");
                
            }

            Func<string> openFunc = () => "<div " + attribute + ">";
            Func<string> closeFunc = () => "</div>";

            return new HtmlSelfClosingBuilder(helper, openFunc, closeFunc);
        }
    }
}

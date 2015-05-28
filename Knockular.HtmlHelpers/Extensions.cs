using System;
using System.IO;
using System.Reflection.Emit;
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
            return HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext) is AngularHtmlStringBuilder;
        }

        public static bool IsKnockout(this HtmlHelper helper)
        {
            return HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext) is KnockoutHtmlStringBuilder;
        }

        public static IHtmlString IfAngular(this HtmlHelper helper, string html)
        {
            return helper.IsAngular() ? 
                new HtmlString(html) : 
                new HtmlString(string.Empty);
        }

        public static IHtmlString IfKnockout(this HtmlHelper helper, string html)
        {
            return helper.IsKnockout() ? 
                new HtmlString(html) : 
                new HtmlString(string.Empty);
        }

        public static IHtmlStringBuilder Bind(this HtmlHelper helper, string property)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.Bind(property);
            return builder;
        }

        public static IHtmlStringBuilder BindTwoWay(this HtmlHelper helper, string property)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.BindTwoWay(property);
            return builder;
        }

        public static IHtmlStringBuilder Date(this HtmlHelper helper, string property, string format)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.Date(property, format);
            return builder;
        }

        public static IHtmlStringBuilder Click(this HtmlHelper helper, string function)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.Click(function);
            return builder;
        }

        public static IHtmlStringBuilder Visible(this HtmlHelper helper, string flag)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.Visible(flag);
            return builder;
        }

        public static IHtmlStringBuilder If(this HtmlHelper helper, string flag)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.If(flag);
            return builder;
        }

        public static IHtmlString Template(this HtmlHelper helper, string templateId, string partialView)
        {
            var stringBuilder = new StringBuilder();
            var html = helper.Partial(partialView).ToHtmlString();

            if (helper.IsAngular())
            {
                stringBuilder.AppendLine(string.Format(@"<script type=""text/ng-template"" id=""{0}"">", templateId));
                stringBuilder.AppendLine(html);
                stringBuilder.AppendLine("</script>");
            }
            else if (helper.IsKnockout())
            {
                stringBuilder.AppendLine(string.Format(@"<script type=""text/html"" id=""{0}"">", templateId));
                stringBuilder.AppendLine(html);
                stringBuilder.AppendLine("</script>");
            }

            return new HtmlString(stringBuilder.ToString());
        }

        public static IHtmlString UseTemplate(this HtmlHelper helper, string templateId)
        {
            var builder = HtmlStringBuilderFactory.Create(helper.ViewContext.HttpContext);
            builder.UseTemplate(templateId);
            return builder;
        }

        public static HtmlSelfClosingBuilder ForEach(this HtmlHelper helper, string collectionName, string itemName)
        {
            return helper.ForEach(collectionName, itemName, "div");
        }

        public static HtmlSelfClosingBuilder ForEach(this HtmlHelper helper, string collectionName, string itemName, string tagName)
        {
            string attribute;

            if (helper.IsAngular())
            {
                var value = string.Format("{0} in {1}", itemName, collectionName);
                attribute = string.Format(@"{0}=""{1}""", "ng-repeat", value);
            }
            else if (helper.IsKnockout())
            {
                var value = string.Format(@"data: {0}, as: '{1}'", collectionName, itemName);
                attribute = string.Format(@"data-bind=""foreach: {0}""", "{ " + value + " }");
            }
            else
            {
                return new HtmlSelfClosingBuilder(helper, () => string.Empty, () => string.Empty);
            }

            Func<string> openFunc = () => "<" + tagName + " " + attribute + ">";
            Func<string> closeFunc = () => "</" + tagName + ">";

            return new HtmlSelfClosingBuilder(helper, openFunc, closeFunc);
        }

        public static HtmlSelfClosingBuilder Context(this HtmlHelper helper, string parentPath, string childPath)
        {
            string attribute;

            if (helper.IsAngular())
            {
                var value = string.Format("{0} in [{1}]", childPath, parentPath);
                attribute = string.Format(@"{0}=""{1}""", "ng-repeat", value);
            }
            else
            {
                var value = string.Format(@"data: [{0}], as: '{1}'", parentPath, childPath);
                attribute = string.Format(@"data-bind=""foreach: {0}""", "{ " + value + " }");

            }

            Func<string> openFunc = () => "<div " + attribute + ">";
            Func<string> closeFunc = () => "</div>";

            return new HtmlSelfClosingBuilder(helper, openFunc, closeFunc);
        }

        public static IHtmlString Href(this HtmlHelper helper, string angularLink, string knockoutLink)
        {
            return helper.IsAngular()
                ? new HtmlString(string.Format(@"ng-href=""{0}""", angularLink))
                : new HtmlString(@"data-bind=""attr: { href: " + knockoutLink + @" }""");
        }
    }

    public interface IHtmlHrefBuilder : IHtmlString
    {
        
    }

    //public class AngularHtmlHrefBuilder : IHtmlHrefBuilder
    //{
    //    private string _link;

    //    public AngularHtmlHrefBuilder(string link)
    //    {
    //        _link = link;
    //    }

    //    public string ToHtmlString()
    //    {

    //    }
    //}

    //public class KnockoutHtmlHrefBuilder : IHtmlHrefBuilder
    //{
    //    public string ToHtmlString()
    //    {
            
    //    }
    //}
}

using System;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Knockular.HtmlHelpers.Spike
{
    public static class Extensions
    {
        public static IHtmlBuilderFactory HtmlBuilderFactory { get; set; }

        public static bool IsAngular(this HtmlHelper helper)
        {
            return HtmlBuilderFactory.Create() is AngularHtmlBuilder;
        }

        public static bool IsKnockout(this HtmlHelper helper)
        {
            return HtmlBuilderFactory.Create() is KnockoutHtmlBuilder;
        }

        public static HtmlStringBuilder Bind(this HtmlHelper helper, string property)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            return new HtmlStringBuilder(htmlBuilder.Bind(property));
        }

        public static HtmlStringBuilder Bind(this HtmlStringBuilder htmlStringBuilder, string property)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            htmlStringBuilder.AddString(htmlBuilder.Bind(property));
            return htmlStringBuilder;
        }

        public static HtmlStringBuilder Click(this HtmlHelper helper, string function)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            return new HtmlStringBuilder(htmlBuilder.Click(function));
        }

        public static HtmlStringBuilder Click(this HtmlStringBuilder htmlStringBuilder, string property)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            htmlStringBuilder.AddString(htmlBuilder.Click(property));
            return htmlStringBuilder;
        }

        public static HtmlStringBuilder Visible(this HtmlHelper helper, string flag)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            return new HtmlStringBuilder(htmlBuilder.Visible(flag));
        }

        public static HtmlStringBuilder Visible(this HtmlStringBuilder htmlStringBuilder, string property)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            htmlStringBuilder.AddString(htmlBuilder.Visible(property));
            return htmlStringBuilder;
        }

        public static IHtmlString Template(this HtmlHelper helper, string partialView, string templateId)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            var html = helper.Partial(partialView).ToHtmlString();
            return new MvcHtmlString(htmlBuilder.Template(html, templateId));
        }

        public static IHtmlString UseTemplate(this HtmlHelper helper, string templateId)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            return new HtmlStringBuilder(htmlBuilder.UseTemplate(templateId));
        }

        public static HtmlStringBuilder UseTemplate(this HtmlStringBuilder htmlStringBuilder, string property)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();
            htmlStringBuilder.AddString(htmlBuilder.UseTemplate(property));
            return htmlStringBuilder;
        }

        public static HtmlSelfClosingBuilder ForEach(this HtmlHelper helper, string collectionName, string itemName)
        {
            var htmlBuilder = HtmlBuilderFactory.Create();

            Func<string> openFunc = () => "<div " + htmlBuilder.ForEach(collectionName, itemName) + ">";
            Func<string> closeFunc = () => "</div>";

            return new HtmlSelfClosingBuilder(helper, openFunc, closeFunc);
        }
    }

    public class HtmlStringBuilder : IHtmlString
    {
        private readonly StringBuilder _stringBuilder;

        public HtmlStringBuilder(string html)
        {
            _stringBuilder = new StringBuilder();
            _stringBuilder.Append(html);
        }

        internal void AddString(string str)
        {
            _stringBuilder.Append(" ");
            _stringBuilder.Append(str);
        }

        public string ToHtmlString()
        {
            return _stringBuilder.ToString();
        }
    }
}

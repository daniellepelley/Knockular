using System.Text;

namespace Knockular.HtmlHelpers.Spike
{
    public class KnockoutHtmlBuilder : IHtmlBuilder
    {
        public string Bind(string property)
        {
            return Build("text", property);
        }

        public string Click(string function)
        {
            return Build("click", function);
        }

        public string Visible(string flag)
        {
            return Build("visible", flag);
        }

        public string ForEach(string collectionName, string itemName)
        {
            var value = string.Format(@"data: {0}, as: '{1}'", collectionName, itemName);
            return Build("foreach", "{" + value + "}");
        }

        public string Template(string html, string templateId)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(@"<script type=""text/html"" id=""{0}"">", templateId));
            stringBuilder.AppendLine(html);
            stringBuilder.AppendLine("</script>");
            return stringBuilder.ToString();
        }

        public string UseTemplate(string templateId)
        {
            var value = "{" + string.Format(" name: '{0}' ", templateId) + "}";
            return Build("template", value);
        }

        private string Build(string type, string value)
        {
            return string.Format(@"data-bind=""{0}: {1}""", type, value);
        }
    }
}
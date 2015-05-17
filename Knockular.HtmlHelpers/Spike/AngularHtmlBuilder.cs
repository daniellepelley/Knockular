using System.Text;

namespace Knockular.HtmlHelpers.Spike
{
    public class AngularHtmlBuilder : IHtmlBuilder
    {
        public string Bind(string property)
        {
            return Build("ng-bind", property);
        }

        public string Click(string function)
        {
            return Build("ng-click", function + (function.Contains("(") ? string.Empty : "()"));
        }

        public string Visible(string flag)
        {
            return Build("ng-show", flag);
        }

        public string ForEach(string collectionName, string itemName)
        {
            var value = string.Format("{0} in {1}", itemName, collectionName);
            return Build("ng-repeat", value);
        }

        public string Template(string html, string templateId)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(string.Format(@"<script type=""text/ng-template"" id=""{0}"">", templateId));
            stringBuilder.AppendLine(html);
            stringBuilder.AppendLine("</script>");
            return stringBuilder.ToString();
        }

        public string UseTemplate(string templateId)
        {
            return Build("ng-include", "'" + templateId + "'");
        }

        private string Build(string type, string value)
        {
            return string.Format(@"{0}=""{1}""", type, value);
        }
    }
}
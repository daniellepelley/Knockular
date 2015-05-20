namespace Knockular.HtmlHelpers
{
    public class AngularHtmlStringBuilder : IHtmlStringBuilder
    {
        private string _output = string.Empty;

        private string Build(string type, string value)
        {
            return string.Format(@"{0}=""{1}""", type, value);
        }

        public IHtmlStringBuilder Click(string function)
        {
            _output += Build(" ng-click", function + (function.Contains("(") ? string.Empty : "()"));
            return this;
        }

        public IHtmlStringBuilder Bind(string property)
        {
            _output += Build(" ng-bind", property);
            return this;
        }

        public IHtmlStringBuilder Visible(string flag)
        {
            _output += Build("ng-show", flag);
            return this;
        }

        public IHtmlStringBuilder If(string flag)
        {
            _output += Build("ng-if", flag);
            return this;
        }

        public IHtmlStringBuilder UseTemplate(string templateId)
        {
            _output += Build("ng-include", "'" + templateId + "'");
            return this;
        }



        public string ToHtmlString()
        {
            return _output.Trim();
        }
    }
}
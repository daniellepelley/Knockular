using System.Collections.Generic;

namespace Knockular.HtmlHelpers
{
    public class KnockoutHtmlStringBuilder : IHtmlStringBuilder
    {
        private readonly List<string> _output = new List<string>();

        private string Build(string type, string value)
        {
            return string.Format(@"{0}: {1}", type, value);
        }

        public IHtmlStringBuilder Click(string function)
        {
            _output.Add(Build("click", function));
            return this;
        }

        public IHtmlStringBuilder Bind(string property)
        {
            _output.Add(Build("text", property));
            return this;
        }

        public IHtmlStringBuilder Visible(string flag)
        {
            _output.Add(Build("visible", flag + "()"));
            return this;
        }

        public IHtmlStringBuilder If(string flag)
        {
            _output.Add(Build("if", flag + "()"));
            return this;
        }

        public IHtmlStringBuilder UseTemplate(string templateId)
        {
            var value = "{" + string.Format(" name: '{0}' ", templateId) + "}";
            _output.Add(Build("template", value));
            return this;
        }

        public string ToHtmlString()
        {
            return string.Format(@"data-bind=""{0}""", string.Join(", ", _output));
        }
    }
}
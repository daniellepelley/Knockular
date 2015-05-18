using System.Web;

namespace Knockular.HtmlHelpers
{
    public interface IHtmlStringBuilder : IHtmlString
    {
        IHtmlStringBuilder Bind(string property);
        IHtmlStringBuilder Click(string function);
        IHtmlStringBuilder Visible(string flag);
        IHtmlStringBuilder UseTemplate(string templateId);
    }
}
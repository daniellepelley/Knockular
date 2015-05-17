namespace Knockular.HtmlHelpers.Spike
{
    public interface IHtmlBuilder
    {
        string Bind(string property);
        string Click(string function);
        string Visible(string flag);
        string ForEach(string collectionName, string itemName);
        string Template(string html, string templateId);
        string UseTemplate(string templateId);
    }
}
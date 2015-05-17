namespace Knockular.HtmlHelpers
{
    public interface IHtmlStringBuilderFactory
    {
        IHtmlStringBuilder Create();
    }

    public class KnockoutHtmlStringBuilderFactory : IHtmlStringBuilderFactory
    {
        public IHtmlStringBuilder Create()
        {
            return new KnockoutHtmlStringBuilder();
        }
    }

    public class AngularHtmlStringBuilderFactory : IHtmlStringBuilderFactory
    {
        public IHtmlStringBuilder Create()
        {
            return new AngularHtmlStringBuilder();
        }
    }
}
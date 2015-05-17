namespace Knockular.HtmlHelpers.Spike
{
    public interface IHtmlBuilderFactory
    {
        IHtmlBuilder Create();
    }

    public class AngularHtmlBuilderFactory : IHtmlBuilderFactory
    {
        public IHtmlBuilder Create()
        {
            return new AngularHtmlBuilder();
        }
    }

    public class KnockoutHtmlBuilderFactory : IHtmlBuilderFactory
    {
        public IHtmlBuilder Create()
        {
            return new KnockoutHtmlBuilder();
        }
    }
}
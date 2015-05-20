using System.Web;

namespace Knockular.HtmlHelpers
{
    public interface IHtmlStringBuilderFactory
    {
        IHtmlStringBuilder Create(HttpContextBase httpContext);
    }

    public class KnockoutHtmlStringBuilderFactory : IHtmlStringBuilderFactory
    {
        public IHtmlStringBuilder Create()
        {
            return new KnockoutHtmlStringBuilder();
        }

        public IHtmlStringBuilder Create(HttpContextBase httpContext)
        {
            return Create();
        }
    }

    public class AngularHtmlStringBuilderFactory : IHtmlStringBuilderFactory
    {
        public IHtmlStringBuilder Create()
        {
            return new AngularHtmlStringBuilder();
        }

        public IHtmlStringBuilder Create(HttpContextBase httpContext)
        {
            return Create();
        }
    }
}
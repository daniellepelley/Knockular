using System.Web.UI;

namespace Knockular.HtmlHelper.Test
{
    public class HtmlHelperTestBase
    {
        protected System.Web.Mvc.HtmlHelper CreateHtmlHelper()
        {
            var builder = new HtmlHelperBuilder();
            return builder.Build();
        }

        protected HtmlHelperBuilder CreateHtmlHelperBuilder()
        {
            return new HtmlHelperBuilder();
        }
    }
}

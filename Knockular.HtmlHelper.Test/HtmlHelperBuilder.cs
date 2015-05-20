using System.IO;
using System.Web.Mvc;
using Moq;

namespace Knockular.HtmlHelper.Test
{
    public class HtmlHelperBuilder
    {
        private readonly StringWriter _stringWriter;
        private readonly Mock<ViewContext> _mockViewContext;

        public HtmlHelperBuilder()
        {
            _stringWriter = new StringWriter();
            _mockViewContext = new Mock<ViewContext>();
            _mockViewContext.Setup(x => x.Writer).Returns(_stringWriter);
        }

        public System.Web.Mvc.HtmlHelper Build()
        {
            return new System.Web.Mvc.HtmlHelper(_mockViewContext.Object, Mock.Of<IViewDataContainer>());
        }

        public string GetOutput()
        {
            return _stringWriter.ToString();
        }
    }
}
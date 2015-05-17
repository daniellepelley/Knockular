using System;
using System.Web;
using System.Web.Mvc;

namespace Knockular.HtmlHelpers
{
    public class HtmlSelfClosingBuilder : IDisposable, IHtmlString
    {
        private readonly HtmlHelper _helper;
        private readonly Func<string> _closeFunc;

        public HtmlSelfClosingBuilder(HtmlHelper helper, Func<string> openFunc, Func<string> closeFunc)
        {
            _closeFunc = closeFunc;
            _helper = helper;
            _helper.ViewContext.Writer.WriteLine(openFunc());
        }

        public void Dispose()
        {
            _helper.ViewContext.Writer.WriteLine(_closeFunc());
        }

        public string ToHtmlString()
        {
            throw new NotSupportedException("HtmlSelfClosingBuilder should only be used with @using() in razor views");
        }
    }
}
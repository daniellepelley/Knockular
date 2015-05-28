using System.Text;
using Knockular.HtmlHelpers;
using NUnit.Framework;

namespace Knockular.HtmlHelper.Test
{
    public class KnockoutHtmlBuilderTests : HtmlHelperTestBase
    {
        [Test]
        public void Bind()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""text: property""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BindTwoWay()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""value: property, valueUpdate: 'afterkeydown'""";

            var actual = CreateHtmlHelper()
                .BindTwoWay("property")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Date()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""dateString: property, dateFormat: 'dd/MM/yyyy'""";

            var actual = CreateHtmlHelper()
                .Date("property", "dd/MM/yyyy")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Click()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""click: function""";

            var actual = CreateHtmlHelper()
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Visible()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""visible: isVisible()""";

            var actual = CreateHtmlHelper()
                .Visible("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void If()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""if: isVisible()""";

            var actual = CreateHtmlHelper()
                .If("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void UseTemplate()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""template: { name: 'myTemplate' }""";

            var actual = CreateHtmlHelper()
                .UseTemplate("myTemplate")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BindAndClick()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();
            
            var expected = @"data-bind=""text: property, click: function""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForEach()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"<div data-bind=""foreach: { data: items, as: 'item' }"">");
            stringBuilder.AppendLine(@"</div>");
            var expected = stringBuilder.ToString();

            var builder = CreateHtmlHelperBuilder();

            using (builder.Build()
                .ForEach("items", "item")) { }

            var actual = builder.GetOutput();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Context()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var stringBuilder = new StringBuilder();

            stringBuilder.AppendLine(@"<div data-bind=""foreach: { data: [value], as: 'myValue' }"">");
            stringBuilder.AppendLine(@"</div>");
            var expected = stringBuilder.ToString();

            var builder = CreateHtmlHelperBuilder();

            using (builder.Build()
                .Context("value", "myValue")) { }

            var actual = builder.GetOutput();

            Assert.AreEqual(expected, actual);
        }
    }
}
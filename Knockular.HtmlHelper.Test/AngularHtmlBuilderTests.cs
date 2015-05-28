using System.Text;
using Knockular.HtmlHelpers;
using NUnit.Framework;

namespace Knockular.HtmlHelper.Test
{
    public class AngularHtmlBuilderTests : HtmlHelperTestBase
    {
        [Test]
        public void Bind()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-bind=""property""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BindTwoWay()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-model=""property""";

            var actual = CreateHtmlHelper()
                .BindTwoWay("property")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Date()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-bind=""(property | date: 'dd/MM/yyyy')""";

            var actual = CreateHtmlHelper()
                .Date("property", "dd/MM/yyyy")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AngularClick()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-click=""function()""";

            var actual = CreateHtmlHelper()
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Visible()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-show=""isVisible""";

            var actual = CreateHtmlHelper()
                .Visible("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void If()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-if=""isVisible""";

            var actual = CreateHtmlHelper()
                .If("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void BindAndClick()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();

            var expected = @"ng-bind=""property"" ng-click=""function()""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void ForEach()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            
            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"<div ng-repeat=""item in items"">");
            stringBuilder.AppendLine(@"</div>");
            var expected = stringBuilder.ToString();

            var builder = CreateHtmlHelperBuilder();

            using(builder.Build()
                .ForEach("items", "item")) { }

            var actual = builder.GetOutput();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void Context()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();

            var stringBuilder = new StringBuilder();
            stringBuilder.AppendLine(@"<div ng-repeat=""myValue in [value]"">");
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
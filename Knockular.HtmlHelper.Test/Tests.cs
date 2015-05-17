using Knockular.HtmlHelpers;
using System.Web.Mvc;
using Moq;
using NUnit.Framework;

namespace Knockular.HtmlHelper.Test
{
    public class Tests
    {
        private System.Web.Mvc.HtmlHelper CreateHtmlHelper()
        {
            return new System.Web.Mvc.HtmlHelper(new ViewContext(), Mock.Of<IViewDataContainer>());
        }
        
        [Test]
        public void AngularBind()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-bind=""property""";

            var actual = CreateHtmlHelper()
                .Bind("property")
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
        public void AngularVisible()
        {
            Extensions.HtmlStringBuilderFactory = new AngularHtmlStringBuilderFactory();
            var expected = @"ng-show=""isVisible""";

            var actual = CreateHtmlHelper()
                .Visible("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KnockoutBind()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""text: property""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KnockoutClick()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""click: function""";

            var actual = CreateHtmlHelper()
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KnockoutVisible()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""visible: isVisible""";

            var actual = CreateHtmlHelper()
                .Visible("isVisible")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void KnockoutUseTemplate()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();

            var expected = @"data-bind=""template: { name: 'myTemplate' }""";

            var actual = CreateHtmlHelper()
                .UseTemplate("myTemplate")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void AngularBindAndClick()
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
        public void KnockoutBindAndClick()
        {
            Extensions.HtmlStringBuilderFactory = new KnockoutHtmlStringBuilderFactory();
            
            var expected = @"data-bind=""text: property, click: function""";

            var actual = CreateHtmlHelper()
                .Bind("property")
                .Click("function")
                .ToHtmlString();

            Assert.AreEqual(expected, actual);
        }
    }
}

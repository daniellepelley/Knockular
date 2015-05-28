using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knockular.HtmlHelpers;
using NUnit.Framework;

namespace Knockular.HtmlHelper.Test
{
    public class KnockoutScriptsTest
    {
        [Test]
        //[Ignore]
        public void DateBindingLoads()
        {
            Assert.IsNotNullOrEmpty(KnockoutScripts.DateBinding.ToString());
        }

    }
}

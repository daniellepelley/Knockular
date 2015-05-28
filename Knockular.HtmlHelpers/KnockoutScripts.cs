using System.IO;
using System.Reflection;
using System.Web;

namespace Knockular.HtmlHelpers
{
    public class KnockoutScripts
    {
        public static IHtmlString DateBinding
        {
            get
            {
                return new HtmlString(Load("Script.koDate.js"));
            }
        }

        public static string Load(string file)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = string.Format("Knockular.HtmlHelpers.{0}", file);

            using (var stream = assembly.GetManifestResourceStream(resourceName))
            {
                if (stream != null)
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        return reader.ReadToEnd();
                    }
                }
            }
            throw new FileNotFoundException();
        }
    }
}

using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace Molla.Presentation.Utilities
{
    public static class YesAndNoHtmlHelper
    {
        public static HtmlString YesNo(this HtmlHelper htmlHelper, bool yesNo)
        {
            var text = yesNo ? "فعال" : "غیرفعال";
            return new HtmlString(text);
        }
    }
}

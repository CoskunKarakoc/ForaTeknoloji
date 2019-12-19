using System.Text;
using System.Web.Mvc;

namespace ForaTeknoloji.PresentationLayer.TagHelpers
{
    public static class PagingTagHelper
    {
        public static MvcHtmlString CustomPage(this HtmlHelper htmlHelper, int PageSize, int PageCount, int CurrenPage)
        {
            var tagBuilder = new TagBuilder("nav");
            tagBuilder.MergeAttribute("aria-label", "Page navigation example");
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append("<ul class='pagination'>");
            for (int i = 1; i <= PageCount; i++)
            {
                stringBuilder.AppendFormat("<li class='page-item {0}'>", i == CurrenPage ? "active" : "");
                stringBuilder.AppendFormat("<a class='page-link' href='/report/index?page={0}'>{1}</a>", i,i);
                stringBuilder.Append("</li>");
            }

            stringBuilder.Append("</ul>");
            tagBuilder.InnerHtml = stringBuilder.ToString();
            return MvcHtmlString.Create(tagBuilder.ToString());
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace M0502.CustomHelpers
{
    public static class Helpers
    {
        public static MvcHtmlString CurrenTime(this HtmlHelper helper)
        {
            return new MvcHtmlString(DateTime.Now.ToShortTimeString());
        }

        public static MvcHtmlString DataGridFor(this HtmlHelper helper, IEnumerable items)
        {
            var sb = new StringBuilder();
            if (items != null)
            {
                sb.Append("<table class=\"DataGrid\">");
                string[] PropertyNames = null;
                bool Alt = false;
                foreach (var item in items)
                {
                    if (PropertyNames == null)
                    {
                        PropertyNames = item.GetType().GetProperties().Where(p => !p.PropertyType.IsClass 
                        || p.PropertyType == typeof(string)).Select(p => p.Name).ToArray();
                        sb.Append("<tr>");
                        foreach (var e in PropertyNames)
                        {
                            string DisplayName = ModelMetadataProviders.Current.GetMetadataForProperty(
                                null, item.GetType(), e).DisplayName;
                            DisplayName = DisplayName ?? e;
                            sb.AppendFormat("<th>{0}</th>", DisplayName);
                        }
                        sb.Append("</tr>");
                    }
                    sb.AppendFormat("<tr {0}>", Alt ? "class=\"Alt\"" : "");
                    foreach (var p in PropertyNames)
                    {
                        sb.AppendFormat("<td>{0}</td>", item.GetType().GetProperty(p).GetValue(item));
                    }
                    sb.Append("</tr>");
                    Alt = !Alt;
                }
                sb.Append("</table>");
            }
            return new MvcHtmlString(sb.ToString());
        }
    }
}
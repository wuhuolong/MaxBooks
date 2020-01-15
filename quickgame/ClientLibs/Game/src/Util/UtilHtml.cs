using System;
using System.Text.RegularExpressions;

public static class UtilHtml
{

    private const string PRE_STRONG = @"<strong>";
    private const string PRE_STRONG_2 = @"<strong style="">";
    private const string SUF_STRONG = @"</strong>";

    private const string NBSP = @"&nbsp;";

    private const string PRE_REP_STRONG = @"<b>";
    private const string SUF_REP_STRONG = @"</b>";

    private const string PRE_SPAN = "<span style=\"color:#\\w+;\">";
    private const string SUF_SPAN = "</span>";

    private const string PRE_REP_SPAN = @"<color={0}>";
    private const string SUF_REP_SPAN = @"</color>";

    private const string BR_1 = @"<br />";


    public static string HtmlToText(string html)
    {
        //p
        html.Replace(" ", "\u3000");
        html = html.Replace(@"<p>", "");
        html = html.Replace(@"</p>", Environment.NewLine);


        //nbsp
        html = html.Replace(NBSP, "\u3000");
        html = html.Replace(PRE_STRONG_2, PRE_REP_STRONG);

        //bold
        html = html.Replace(PRE_STRONG, PRE_REP_STRONG);
        html = html.Replace(SUF_STRONG, SUF_REP_STRONG);

        //color
        Regex reg = new Regex(PRE_SPAN);

        var matCollection = reg.Matches(html);

        foreach (Match mat in matCollection)
        {
            string str = mat.Captures[0].Value;

            string color = str.Substring(str.IndexOf(':') + 1, str.IndexOf(';') - str.IndexOf(':') - 1);
            html = html.Replace(str, string.Format(PRE_REP_SPAN, color));
        }

        html = html.Replace(SUF_SPAN, SUF_REP_SPAN);


        //href



        //newline
        html = html.Replace(BR_1, Environment.NewLine);

        return html;
    }

}
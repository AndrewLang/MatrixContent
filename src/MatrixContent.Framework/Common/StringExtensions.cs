using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MatrixContent.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public static class StringExtensions
    {
        static Regex StripHtmlRegex = new Regex("<[^>]*>",RegexOptions.Compiled);
        // white space, em-dash, en-dash, underscore
        static readonly Regex WordDelimiters = new Regex(@"[\s—–_]",RegexOptions.Compiled);
        // characters that are not valid
        static readonly Regex InvalidChars = new Regex(@"[^a-z0-9\-]",RegexOptions.Compiled);
        // multiple hyphens
        static readonly Regex MultipleHyphens = new Regex(@"-{2,}",RegexOptions.Compiled);

        public static string ToJsonString(this object obj)
        {
            if(obj == null)
                return string.Empty;
            return JsonConvert.SerializeObject(obj);
        }


        /// <summary>
        /// Removes all HTML tags from the passed <see cref="string">string</see>.
        /// </summary>
        /// <param name="value">The <see cref="string">string</see> whose values should be replaced.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "&lt;body&gt;Hello, World!&lt;/body&gt;";
        ///         string results = s.StripTags();
        ///     </code>
        /// </example>
        public static string StripTags(this string value)
        {
            Regex stripTags = new Regex("<(.|\n)+?>");

            return stripTags.Replace(value,string.Empty);
        }
        /// <summary>
        ///  Removes all HTML tags from a given string
        /// </summary>
        /// <param name="html">The HTML.</param>
        /// <returns></returns>
        public static string StripHtml(this string html)
        {
            if(string.IsNullOrEmpty(html))
                return string.Empty;

            return StripHtmlRegex.Replace(html,string.Empty);
        }
        /// <summary>
        /// Replaces underscores with a space.
        /// </summary>
        /// <param name="value"><see cref="string">String</see> to examine.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello_World!_How_are_you_today?";
        ///         string results = s.SlugDecode();
        ///     </code>
        /// </example>
        public static string SlugDecode(this string value)
        {
            return value.Replace("_"," ");
        }
        /// <summary>
        /// Replaces spaces with a underscores.
        /// </summary>
        /// <param name="value"><see cref="string">String</see> to examine.</param>
        /// <returns>The resulting <see cref="string">string</see>.</returns>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello World! How are you today?";
        ///         string results = s.SlugEncode();
        ///     </code>
        /// </example>
        public static string SlugEncode(this string value)
        {
            return value.Replace(" ","_");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToSlug(this string value)
        {
            value = value.Trim()
                         .Trim('　')
                         .Replace(" ","-")
                         .Replace("　","-");

            // convert to lower case
            value = value.ToLowerInvariant();

            // remove diacritics (accents)
            value = RemoveDiacritics(value);

            // ensure all word delimiters are hyphens
            value = WordDelimiters.Replace(value,"-");

            // strip out invalid characters
            //value = InvalidChars.Replace( value,"" );

            // replace multiple hyphens (-) with a single hyphen
            value = MultipleHyphens.Replace(value,"-");

            // trim hyphens (-) from ends
            return value.Trim('-');
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="stIn"></param>
        /// <returns></returns>
        private static string RemoveDiacritics(string stIn)
        {
            string stFormD = stIn.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();

            for(int ich = 0;ich < stFormD.Length;ich++)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if(uc != UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }

            return (sb.ToString().Normalize(NormalizationForm.FormC));
        }
        /// <summary>
        /// Decodes the base64.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string DecodeBase64(this string content)
        {
            if(string.IsNullOrEmpty(content))
                return string.Empty;

            byte[] data = Convert.FromBase64String(content);
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        /// Encodes the base64.
        /// </summary>
        /// <param name="content">The content.</param>
        /// <returns></returns>
        public static string EncodeBase64(this string content)
        {
            if(string.IsNullOrEmpty(content))
                return string.Empty;

            byte[] data = Encoding.UTF8.GetBytes(content);
            return Convert.ToBase64String(data);
        }
        /// <summary>
        /// Truncates the <see cref="string">string</see> to a specified length and replace the truncated to a ...
        /// </summary>
        /// <param name="value"><see cref="string">String</see> that will be truncated.</param>
        /// <param name="maxLength">Total length of characters to maintain before the truncate happens.</param>
        /// <returns>Truncated <see cref="string">string</see>.</returns>
        /// <remarks>maxLength is inclusive of the three characters in the ellipsis.</remarks>
        /// <example>
        ///     <code language="c#">
        ///         string s = "Hello, World!";
        ///         string results = s.Truncate(5);
        ///     </code>
        /// </example>
        public static string Truncate(this string value,int maxLength)
        {
            // replaces the truncated string to a ...
            string suffix = "...";

            string truncatedString = value;

            if(maxLength <= 0)
            {
                return truncatedString;
            }

            int strLength = maxLength - suffix.Length;

            if(strLength <= 0)
            {
                return truncatedString;
            }

            if(value == null || value.Length <= maxLength)
            {
                return truncatedString;
            }

            truncatedString = value.Substring(0,strLength);
            truncatedString = truncatedString.TrimEnd();
            truncatedString += suffix;

            return truncatedString;
        }
    }
}

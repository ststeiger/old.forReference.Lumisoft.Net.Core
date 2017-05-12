
// Copyright 2017-+infinity Stefan Steiger
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// 
//     http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.


// Simulates System.Web.HttpUtility for .NET Core 


#define DOTNETCORE_LEGACY_COMPATIBILITY 
#if DOTNETCORE_LEGACY_COMPATIBILITY


namespace System.Web
{


    internal class HttpUtility
    {


        public static string HtmlEncode(string url)
        {
            return System.Net.WebUtility.HtmlEncode(url);
        }


        public static string HtmlDecode(string url)
        {
            return System.Net.WebUtility.HtmlDecode(url);
        }


        public static string UrlEncode(string url)
        {
            return System.Net.WebUtility.UrlEncode(url);
        }

        public static string UrlDecode(string url)
        {
            return System.Net.WebUtility.UrlDecode(url);
        }


        public static String JavaScriptStringEncode(string value)
        {
            return JavaScriptStringEncode(value, false);
        }


        public static String JavaScriptStringEncode(string value, bool addDoubleQuotes)
        {
            string encoded = Internal_JavaScriptStringEncode(value);
            return (addDoubleQuotes) ? "\"" + encoded + "\"" : encoded;
        }


        private static bool CharRequiresJavaScriptEncoding(char c)
        {
            // https://referencesource.microsoft.com/#system.web/Util/AppSettings.cs,3e4a0d913694c831
            // bool JavaScriptEncodeAmpersand = !AppSettings.JavaScriptDoNotEncodeAmpersand;
            bool JavaScriptEncodeAmpersand = false;

            return c < 0x20 // control chars always have to be encoded
                || c == '\"' // chars which must be encoded per JSON spec
                || c == '\\'
                || c == '\'' // HTML-sensitive chars encoded for safety
                || c == '<'
                || c == '>'
                || (c == '&' && JavaScriptEncodeAmpersand) // Bug Dev11 #133237. Encode '&' to provide additional security for people who incorrectly call the encoding methods (unless turned off by backcompat switch)
                || c == '\u0085' // newline chars (see Unicode 6.2, Table 5-1 [http://www.unicode.org/versions/Unicode6.2.0/ch05.pdf]) have to be encoded (DevDiv #663531)
                || c == '\u2028'
                || c == '\u2029';
        }


        private static void AppendCharAsUnicodeJavaScript(System.Text.StringBuilder builder, char c)
        {
            builder.Append("\\u");
            builder.Append(((int)c).ToString("x4", System.Globalization.CultureInfo.InvariantCulture));
        }


        private static string Internal_JavaScriptStringEncode(string value)
        {
            if (String.IsNullOrEmpty(value))
            {
                return String.Empty;
            }

            System.Text.StringBuilder b = null;
            int startIndex = 0;
            int count = 0;
            for (int i = 0; i < value.Length; i++)
            {
                char c = value[i];

                // Append the unhandled characters (that do not require special treament)
                // to the string builder when special characters are detected.
                if (CharRequiresJavaScriptEncoding(c))
                {
                    if (b == null)
                    {
                        b = new System.Text.StringBuilder(value.Length + 5);
                    }

                    if (count > 0)
                    {
                        b.Append(value, startIndex, count);
                    }

                    startIndex = i + 1;
                    count = 0;
                }

                switch (c)
                {
                    case '\r':
                        b.Append("\\r");
                        break;
                    case '\t':
                        b.Append("\\t");
                        break;
                    case '\"':
                        b.Append("\\\"");
                        break;
                    case '\\':
                        b.Append("\\\\");
                        break;
                    case '\n':
                        b.Append("\\n");
                        break;
                    case '\b':
                        b.Append("\\b");
                        break;
                    case '\f':
                        b.Append("\\f");
                        break;
                    default:
                        if (CharRequiresJavaScriptEncoding(c))
                        {
                            AppendCharAsUnicodeJavaScript(b, c);
                        }
                        else
                        {
                            count++;
                        }
                        break;
                }
            }

            if (b == null)
            {
                return value;
            }

            if (count > 0)
            {
                b.Append(value, startIndex, count);
            }

            return b.ToString();
        }


    }


}

#endif 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ExtendsApi.Methods
{
    public static class StringExtension
    {
        /// <summary>
        /// Check if in the list the value chosed is contained
        /// </summary>
        /// <param name="source">
        /// The List of strings
        /// </param>
        /// <param name="value">
        /// The item to contains
        /// </param>
        /// <returns>
        /// </returns>
        public static bool Contains(this IEnumerable<string> source, string value)
        {
            var returnBool = false;

            foreach (var item in source)
            {
                returnBool = item.ToUpper().Contains(value.ToUpper());

                if (returnBool)
                {
                    return returnBool;
                }
            }

            return returnBool;
        }

        /// <summary>
        /// Check if in the source the value chosed is equals but putted to upper to check
        /// </summary>
        /// <param name="source">
        /// The List of strings
        /// </param>
        /// <param name="value">
        /// The item to be equal
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ToUpperEquals(this string source, string value)
        {
            if (string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var response = source.ToUpper().Equals(value.ToUpper());

            return response;
        }

        /// <summary>
        /// Check if in the int32 source the value chosed is equals but putted to upper to check
        /// </summary>
        /// <param name="source">
        /// The List of strings
        /// </param>
        /// <param name="value">
        /// The item to be equal
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ToUpperEquals(this int source, string value)
        {
            if (string.IsNullOrWhiteSpace(source.ToString()) && string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(source.ToString()) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var response = source.ToString().ToUpper().Equals(value.ToUpper());

            return response;
        }

        /// <summary>
        /// Take a string and split with spaces. HelloWorld =&gt; Hello World
        /// </summary>
        /// <param name="value">
        /// The value to split
        /// </param>
        /// <returns>
        /// </returns>
        public static string SplitWithSpace(this string value)
        {
            return Regex.Replace(value, "(?<!^)([A-Z][a-z]|(?<=[a-z])[A-Z])", " $1", RegexOptions.Compiled).Trim();
        }

        /// <summary>
        /// This converts to camel case Location_ID =&gt; LocationId, and testLEFTSide =&gt; TestLeftSide
        /// </summary>
        /// <param name="value">
        /// The value to convert to CamelCase
        /// </param>
        /// <returns>
        /// </returns>
        public static string ToCamelCase(this string value)
        {
            var x = value.Replace("_", "");
            if (x.Length == 0) return "Null";
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            return char.ToUpper(x[0]) + x.Substring(1);
        }

        /// <summary>
        /// This converts to pascal case Location_ID =&gt; locationId, and TestLEFTSide =&gt; testLeftSide
        /// </summary>
        /// <param name="value">
        /// The value to convert to PascalCase
        /// </param>
        /// <returns>
        /// </returns>
        public static string ToPascalCase(this string value)
        {
            var x = value.Replace("_", "");
            if (x.Length == 0) return "Null";
            x = Regex.Replace(x, "([A-Z])([A-Z]+)($|[A-Z])",
                m => m.Groups[1].Value + m.Groups[2].Value.ToLower() + m.Groups[3].Value);
            return char.ToUpper(x[0]) + x.Substring(1);
        }

        /// <summary>
        /// Transform a String to Boolean. Like 0 = true and 1 = false
        /// </summary>
        /// <param name="value">
        /// The string value to Convert
        /// </param>
        /// <returns>
        /// true or false default false
        /// </returns>
        public static bool FromStringToBool(this string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return false;
            }
            else if (value.Equals("1"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Transform a Boolean to String. Like 0 = true and 1 = false
        /// </summary>
        /// <param name="value">
        /// The string value to Convert
        /// </param>
        /// <returns>
        /// 0 or 1 default 1
        /// </returns>
        public static string FromBoolToString(this bool value)
        {
            if (value)
            {
                return "1";
            }
            else
            {
                return "0";
            }
        }

        /// <summary>
        /// Check if in the source the value chosed is contained but putted to upper to check
        /// </summary>
        /// <param name="source">
        /// The List of strings
        /// </param>
        /// <param name="value">
        /// The item to contains
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ToUpperContains(this string source, string value)
        {
            if (string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var response = source.ToUpper().Contains(value.ToUpper());

            return response;
        }

        public static float SumT(this IEnumerable<float> source)
        {
            double sum = 0; ;

            foreach (var item in source)
            {
                sum += item;
            }

            return (float)sum;
        }

        /// <summary>
        /// Check if string is Base64
        /// </summary>
        /// <param name="base64">
        /// </param>
        /// <returns>
        /// </returns>
        public static bool IsBase64String(this string base64)
        {
            Span<byte> buffer = new Span<byte>(new byte[base64.Length]);
            return Convert.TryFromBase64String(base64, buffer, out int _);
        }

        public static string EscapeXml(this string s)
        {
            string toxml = s;
            if (!string.IsNullOrEmpty(toxml))
            {
                // replace literal values with entities
                toxml = toxml.Replace("&", "&amp;");
                toxml = toxml.Replace("'", "&apos;");
                toxml = toxml.Replace("\"", "&quot;");
                toxml = toxml.Replace(">", "&gt;");
                toxml = toxml.Replace("<", "&lt;");
            }
            return toxml;
        }

        public static string UnescapeXml(this string s)
        {
            string unxml = s;
            if (!string.IsNullOrEmpty(unxml))
            {
                // replace entities with literal values
                unxml = unxml.Replace("&apos;", "'");
                unxml = unxml.Replace("&quot;", "\"");
                unxml = unxml.Replace("&gt;", ">");
                unxml = unxml.Replace("&lt;", "<");
                unxml = unxml.Replace("&amp;", "&");
            }
            return unxml;
        }

        public static string PropertyNameValueToString<TClass>(this TClass classObj)
        {
            var text = string.Empty;

            if (classObj != null)
            {
                var props = classObj.GetType().GetProperties();

                if (props.Length >= 1)
                {
                    var firstPropertyInfo = props.FirstOrDefault();

                    if (firstPropertyInfo != null)
                    {
                        if (props.ToList().Remove(firstPropertyInfo))
                        {
                            text += $"{firstPropertyInfo.Name} {firstPropertyInfo.GetValue(classObj, null)}";

                            if (props.Length >= 1)
                            {
                                var lastPropertyInfo = props.LastOrDefault();

                                if (lastPropertyInfo != null)
                                {
                                    if (props.ToList().Remove(lastPropertyInfo))
                                    {
                                        if (props.Length >= 1)
                                        {
                                            foreach (var propertyInfo in props)
                                            {
                                                text += $", {propertyInfo.Name} {propertyInfo.GetValue(classObj, null)}";
                                            }
                                        }

                                        text += $"en {firstPropertyInfo.Name} {firstPropertyInfo.GetValue(classObj, null)}";
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return text;
        }

        /// <summary>
        /// Check if in the source the value chosed is ending with but putted to upper to check
        /// </summary>
        /// <param name="source">
        /// The List of strings
        /// </param>
        /// <param name="value">
        /// The item to be equal
        /// </param>
        /// <returns>
        /// </returns>
        public static bool ToUpperEndsWith(this string source, string value)
        {
            if (string.IsNullOrWhiteSpace(source) && string.IsNullOrWhiteSpace(value))
            {
                return true;
            }

            if (string.IsNullOrWhiteSpace(source) || string.IsNullOrWhiteSpace(value))
            {
                return false;
            }

            var response = source.ToUpper().EndsWith(value.ToUpper());

            return response;
        }
    }
}

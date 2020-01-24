using System;
using System.Collections.Generic;
using System.Reflection;

namespace ExtendsApi.Methods
{
    public static class BooleanChecks
    {
        public static bool CheckContains(this int element, string contains)
        {
            var response =
                element != 0 &&
                element != default &&
                element.ToString().Trim().ToLower().Contains(contains.Trim().ToLower());
            return response;
        }

        public static bool CheckContains(this int? element, string contains)
        {
            var response =
                element != null &&
                element.HasValue &&
                element.Value.ToString().Trim().ToLower().Contains(contains.Trim().ToLower());
            return response;
        }

        public static bool CheckContains(this decimal element, string contains)
        {
            var response =
                element != 0 &&
                element != default &&
                element.ToString().Trim().ToLower().Contains(contains.Trim().ToLower());
            return response;
        }

        public static bool CheckContains(this decimal? element, string contains)
        {
            var response =
                element != null &&
                element.HasValue &&
                element.Value.ToString().Trim().ToLower().Contains(contains.Trim().ToLower());
            return response;
        }

        public static bool CheckContains(this string element, string contains)
        {
            var response =
                element != null &&
                !string.IsNullOrWhiteSpace(element) &&
                element.ToString().Trim().ToLower().Contains(contains.Trim().ToLower());
            return response;
        }

        public static bool CheckContains(this DateTime element, string contains)
        {
            var response = (
                    element != null &&
                    element != DateTime.MinValue &&
                    element != default &&
                    (
                        element.ToLongDateString().Trim().ToLower().Contains(contains.Trim().ToLower()) ||
                        element.ToLongTimeString().Trim().ToLower().Contains(contains.Trim().ToLower())
                    )
                );
            return response;
        }

        public static bool CheckContains(this DateTime? element, string contains)
        {
            var response = (
                    element != null &&
                    element.HasValue &&
                    (
                        element.Value.ToLongDateString().Trim().ToLower().Contains(contains.Trim().ToLower()) ||
                        element.Value.ToLongTimeString().Trim().ToLower().Contains(contains.Trim().ToLower())
                    )
                );
            return response;
        }

        public static bool CheckSomeFields(this object element, Dictionary<string, string> ContainsSomeFields)
        {
            var response = false;
            foreach (var item in ContainsSomeFields)
            {
                var x = GetPropValue(element, item.Key);
                response = x.ToString().CheckContains(item.Value);
                if (response == true)
                    break;
            }

            return response;
        }

        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetRuntimeProperty(propName)?.GetValue(src, null);
        }
    }
}

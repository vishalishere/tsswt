using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.Linq;

namespace HP.SW.SWT.Extensions
{
    public static class EnumExtensions
    {
        public static string ToReadableString(this Enum e)
        {
            return Regex.Replace(e.ToString(), "(?<=[A-Z])(?=[A-Z][a-z])|(?<=[^A-Z])(?=[A-Z])|(?<=[A-Za-z])(?=[^A-Za-z])", " ");
        }
    }

    public static class Enums
    {
        public static List<T> Get<T>()
        {
            return Enum.GetValues(typeof(T)).Cast<T>().ToList();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HP.SW.SWT.Extensions
{
    public static class StringExtensions
    {
        private static List<string> NotCapitalizableWords = new List<string> { "a", "de", "el", "en" };

        private static bool NotCapitalizable(string word)
        {
            return NotCapitalizableWords.Where(w => w == word.ToLowerInvariant()).Count() > 0;
        }

        public static string ToCapitalizedString(this String toCapitalize)
        {
            string[] words = toCapitalize.Split(' ');

            string res = words[0].Substring(0, 1).ToUpper() + words[0].Substring(1) + ' ';
            foreach (string word in words.Skip(1))
            {
                if (StringExtensions.NotCapitalizable(word))
                {
                    res += word;
                }
                else
                {
                    res += word.Substring(0, 1).ToUpper() + word.Substring(1) + ' ';
                }
            }
            
            return res.TrimEnd(' ');
        }
    }
}

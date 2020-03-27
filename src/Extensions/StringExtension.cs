using System;

namespace PersonelTakip.Extensions
{
    public static class StringExtension
    {
        public static string ToEnglishChars(this string text)
        {
            text = text.Replace("ı", "i");
            text = text.Replace("ö", "o");
            text = text.Replace("ü", "u");
            text = text.Replace("ş", "s");
            text = text.Replace("ğ", "g");
            text = text.Replace("ç", "c");
            text = text.Replace("Ü", "U");
            text = text.Replace("İ", "I");
            text = text.Replace("Ö", "O");
            text = text.Replace("Ü", "U");
            text = text.Replace("Ş", "S");
            text = text.Replace("Ğ", "G");
            text = text.Replace("Ç", "C");
            return text;
        }


        /// <summary>
        /// Returns the input string with the first character converted to uppercase
        /// </summary>
        public static string FirstLetterToUpperCase(this string s)
        {
            if (string.IsNullOrEmpty(s))
                throw new ArgumentException("There is no first letter");

            char[] a = s.ToCharArray();
            a[0] = char.ToUpper(a[0]);
            return new string(a);
        }

    }
}
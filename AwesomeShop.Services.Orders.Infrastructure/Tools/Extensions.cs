﻿using System;
using System.Text;

namespace AwesomeShop.Services.Orders.Infrastructure.Tools
{
    public static class Extensions
    {
        public static string ToDashCase(this string text)
        { 
            if (text is null) throw new ArgumentNullException(nameof(text));
            if (text.Length < 2) return text;

            var sb = new StringBuilder();
            sb.Append(char.ToLowerInvariant(text[0]));
            for (int i = 1; i < text.Length; i++)
            {
                char c = text[i];
                if (char.IsUpper(c))
                {
                    sb.Append('-');
                    sb.Append(char.ToLowerInvariant(c));
                }
                else
                    sb.Append(c);
            }
            return sb.ToString();
        }
    }
}

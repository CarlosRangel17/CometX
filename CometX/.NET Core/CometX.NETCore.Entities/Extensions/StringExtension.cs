using System;
using System.Collections.Generic;
using System.Text;

namespace CometX.NETCore.Entities.Extensions
{
    public static class StringExtension
    {
        public static string Left(this string genericString, int maxLength)
        {
            if (string.IsNullOrWhiteSpace(genericString))
            {
                genericString = "";
            }
            else if (genericString.Length > maxLength)
            {
                genericString = genericString.Substring(0, Math.Min(maxLength, genericString.Length));
            }

            return genericString;
        }

        public static string Right(this string genericString, int maxLength = 0)
        {
            if (string.IsNullOrWhiteSpace(genericString))
            {
                genericString = "";
            }
            else if (genericString.Length > maxLength)
            {
                genericString = genericString.Substring(genericString.Length - maxLength, maxLength);
            }

            return genericString;
        }
    }
}

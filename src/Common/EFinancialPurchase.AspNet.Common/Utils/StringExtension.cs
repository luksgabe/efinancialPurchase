﻿namespace EFinancialPurchase.AspNet.Common.Utils
{
    public static class StringExtension
    {
        public static string SpliteHttpCode(this string message)
        {
            if (message.Contains("Unauthorized"))
            {
                return message.Substring(12);
            }

            return message;
        }
    }
}

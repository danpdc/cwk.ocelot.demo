using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;

namespace Cwk.Ocelot.Demo.Common
{
    public class HttpHeadersHelper
    {
        public const string _usernameHeader = "Username";
        public const string _jobTitleHeader = "JobTitle";

        public static Tuple<string, string> ExtractHeaders(KeyValuePair<string, StringValues>[] headers)
        {
            string username = ExtractHeaders(_usernameHeader, headers);
            string jobTitle = ExtractHeaders(_jobTitleHeader, headers);
            return new Tuple<string, string>(username, jobTitle);
        }

        public static void DisplayHeaders(Tuple<string, string> headerValues)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Username: {headerValues.Item1}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Job Title: {headerValues.Item2}");
            Console.ResetColor();
        }

        private static string ExtractHeaders(string headerKey, KeyValuePair<string, StringValues>[] headers)
        {
            string headerValue = null;
            foreach (var pair in headers)
            {
                if (pair.Key == headerKey)
                    headerValue = pair.Value;
            }
            return headerValue;
        }
    }
}

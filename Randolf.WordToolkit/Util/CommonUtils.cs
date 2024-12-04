using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Office.Interop.Word;
using System.Text.RegularExpressions;

namespace Randolf.WordToolkit.Util
{
    public static class CommonUtils
    {

        /// <summary>
        /// format the get string
        /// </summary>
        /// <param name="text">raw string</param>
        /// <returns>formatted string</returns>
        public static string FormatString(string text)
        {
            char[] trimChars = { ' ', '\n', '\r', '\t'};
            return text.Trim(trimChars).Replace('\u001e', '-');
        }

        /// <summary>
        /// format the field and return the formatted text
        /// </summary>
        /// <param name="field">target field</param>
        /// <returns>formatted text</returns>
        public static string FormatField(Field field)
        {
            return FormatString(field.Result.Sentences.First.Text);
        }

        /// <summary>
        /// Get the label of a field. 
        /// Example: "Figure 1.1 example structure" -> ["Figure", " ", "1.1"]
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<string> GetFieldLabel(string input) {
            var match = Regex.Match(input, @"((?<name>[^\d\s]+)(?<bar>\s+)(?<id>\d+[-.]?\d*))");
            var label_list = new List<string>();
            label_list.Add(match.Groups["name"].Value);
            label_list.Add(match.Groups["bar"].Value);
            label_list.Add(match.Groups["id"].Value);
            return label_list;
        }

        #region Hash Calculation

        public static List<string> CalculateHash(List<string> inputStringList)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                return inputStringList.Select(s => GetHash(sha256Hash, s))
                    .ToList();
            }
        }
        
        private static string GetHash(HashAlgorithm hashAlgorithm, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyHash(HashAlgorithm hashAlgorithm, string input, string hash)
        {
            // Hash the input.
            var hashOfInput = GetHash(hashAlgorithm, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            return comparer.Compare(hashOfInput, hash) == 0;
        }
        
        #endregion

        
    }

}
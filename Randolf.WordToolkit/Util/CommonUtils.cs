using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.Office.Interop.Word;

namespace Randolf.WordToolkit.Util
{
    public static class CommonUtils
    {
        /// <summary>
        /// return the all captions
        /// </summary>
        /// <param name="selectNonBuiltin">if only return non-builtin caption types</param>
        /// <returns>CaptionLabel list</returns>
        public static List<CaptionLabel> LoadCaptionLabels(bool selectNonBuiltin = true)
        {
            var captionList = Globals.ThisAddIn.Application.CaptionLabels;
            List<CaptionLabel> targetCaptionLists = new List<CaptionLabel>();
            foreach (CaptionLabel captionLabel in captionList)
            {
                if (selectNonBuiltin)
                {
                    if (captionLabel.BuiltIn is false)
                    {
                        targetCaptionLists.Add(captionLabel);
                    }
                }
                else
                {
                    targetCaptionLists.Add(captionLabel);
                }
                // Debug.WriteLine($"{captionLabel.BuiltIn}: {captionLabel.Name}");
            }

            return targetCaptionLists;
        }

        /// <summary>
        /// format the get string
        /// </summary>
        /// <param name="text">raw string</param>
        /// <returns>formatted string</returns>
        public static string FormatString(string text)
        {
            char[] trimChars = { ' ', '\n', '\r'};
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
    }

}
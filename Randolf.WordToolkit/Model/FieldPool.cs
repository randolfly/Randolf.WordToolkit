using System.Collections.Generic;
using System.Linq;
using FuzzySharp;
using Microsoft.Office.Interop.Word;
using Randolf.WordToolkit.Util;

namespace Randolf.WordToolkit.Model
{
    public class FieldPool
    {
        public List<Field> FieldResult { get; } = new List<Field>();
        private List<CaptionLabel> CaptionLabels { get; set; }

        public void LoadFieldDictionary()
        {
            CaptionLabels = LoadCaptionLabels();
            FieldResult.Clear();
            var captionLabelNames = CaptionLabels.Select(x => x.Name).ToList();
            foreach (var captionLabelName in captionLabelNames)
                FieldResult.AddRange(Globals.ThisAddIn.Application.ActiveDocument.Fields.Cast<Field>()
                    .Where(f => f.Code.Text.Trim().StartsWith($"SEQ {captionLabelName}")) // remove reference fields
                    .GroupBy(CommonUtils.FormatField)
                    .Select(f => f.FirstOrDefault())
                    .ToList());
        }

        /// <summary>
        ///     use fuzzy search method to search fields
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public List<Field> SearchFields(string searchText)
        {
            return FieldResult
                .OrderByDescending(f => GetSimilarityScore(searchText, f))
                .ToList();
        }

        public int GetSimilarityScore(string searchText, Field field)
        {
            return Fuzz.PartialTokenSetRatio(searchText, CommonUtils.FormatField(field));
        }

        public List<Field> GetFieldsFromText(List<string> stringList)
        {
            return FieldResult
                .Where(f => stringList.Contains(CommonUtils.FormatField(f)))
                .ToList();
        }


        /// <summary>
        ///     from selected fields get ranges
        /// </summary>
        /// <param name="selectedFields"></param>
        /// <returns></returns>
        public List<Range> GetRangesFromField(List<Field> selectedFields)
        {
            var selectedRanges = selectedFields
                .Select(f => f.Result.Sentences.First)
                .Select(r => r.Words.First)
                .ToList();
            var resultRange = new List<Range>(selectedFields.Count*2);
            for (var i=0;i< selectedRanges.Count;i++)
            {
                var fieldLabels = CommonUtils.GetFieldLabel(
                    CommonUtils.FormatString(
                        selectedFields[i].Result.Sentences.First.Text));
                var range1 = selectedRanges[i];
                var range2 = selectedRanges[i].Duplicate;
                range2.MoveEnd(WdUnits.wdCharacter, 
                    fieldLabels[1].Length + fieldLabels[2].Length);
                range2.MoveStart(WdUnits.wdCharacter, 
                    (fieldLabels[0].Length + fieldLabels[1].Length));
                
                resultRange.Add(range1);
                resultRange.Add(range2);
            }
            return resultRange;
        }

        /// <summary>
        /// generate bookmark names
        /// </summary>
        /// <param name="selectedText">label field name</param>
        /// <returns></returns>
        public static List<string> GetBookmarkNames(List<string> selectedText) {
            var bookmarkNames = new List<string>(selectedText.Count * 2);
            var hashList = CommonUtils.CalculateHash(selectedText);
            for (int i = 0; i < hashList.Count; i++)
            {
                // Get the first 6 characters of the hash
                var hashPrefix = hashList[i].Substring(0, 6); 
                var text1 = $"_Ref{hashPrefix}1";
                var text2 = $"_Ref{hashPrefix}2";
                bookmarkNames.Add(text1);
                bookmarkNames.Add(text2);
            }
            return bookmarkNames;
        }

        /// <summary>
        ///     add bookmarks to selected range
        /// </summary>
        /// <param name="ranges">selected range</param>
        /// <returns>bookmarks list</returns>
        public List<Bookmark> AddBookmarks(List<Range> ranges, List<string> bookmarkNames)
        {
            var bookmarkList = new List<Bookmark>();
            for (var i = 0; i < ranges.Count; i++)
                if (ranges[i].Bookmarks.Exists(bookmarkNames[i]))
                {
                    bookmarkList.Add(ranges[i].Bookmarks[bookmarkNames[i]]);
                }
                else
                {
                    var bookmark = ranges[i].Bookmarks.Add(bookmarkNames[i], ranges[i]);
                    bookmarkList.Add(bookmark);
                    
                }

            foreach (var bookmark in bookmarkNames)
                Globals.ThisAddIn.Application.Selection.Fields.Add(Globals.ThisAddIn.Application.Selection.Range,
                    WdFieldType.wdFieldRef, bookmark);
            return bookmarkList;
        }

        /// <summary>
        ///     return the all captions
        /// </summary>
        /// <param name="selectNonBuiltin">if only return non-builtin caption types</param>
        /// <returns>CaptionLabel list</returns>
        public List<CaptionLabel> LoadCaptionLabels(bool selectNonBuiltin = true)
        {
            var captionList = Globals.ThisAddIn.Application.CaptionLabels;
            var targetCaptionLists = new List<CaptionLabel>();
            foreach (CaptionLabel captionLabel in captionList)
                if (selectNonBuiltin)
                {
                    if (captionLabel.BuiltIn is false) targetCaptionLists.Add(captionLabel);
                }
                else
                {
                    targetCaptionLists.Add(captionLabel);
                }

            // Debug.WriteLine($"{captionLabel.BuiltIn}: {captionLabel.Name}");
            return targetCaptionLists;
        }
    }
}
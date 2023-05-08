using System.Collections.Generic;
using System.Linq;
using Microsoft.Office.Interop.Word;
using Randolf.WordToolkit.Util;

namespace Randolf.WordToolkit.Model
{
    public class FieldPool
    {
        public List<Field> FieldResult { get; private set; }

        public void LoadFieldDictionary()
        {
            FieldResult = Globals.ThisAddIn.Application.ActiveDocument.Fields.Cast<Field>()
                .GroupBy(CommonUtils.FormatField)
                .Select(f => f.FirstOrDefault())
                .ToList();
        }

        public List<Field> SearchFields(string searchText)
        {
            return FieldResult.Where(f => CommonUtils.FormatField(f).Contains(searchText)).ToList();
        }
    }

}


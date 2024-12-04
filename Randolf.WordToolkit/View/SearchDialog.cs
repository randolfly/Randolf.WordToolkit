using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word;

using Randolf.WordToolkit.Model;
using Randolf.WordToolkit.Util;

namespace Randolf.WordToolkit.View
{
    public partial class SearchDialog : Form
    {
        public FieldPool FieldPool { get; }
        private BindingList<string> SearchTextResult { get; set; } = new BindingList<string>();

        public SearchDialog(FieldPool fieldPool) {
            FieldPool = fieldPool;
            InitializeComponent();
            this.list_SearchResult.DataSource = SearchTextResult;
        }

        private void txt_SearchInput_TextChanged(object sender, EventArgs e) {
            var searchResult = FieldPool
                .SearchFields(CommonUtils.FormatString(this.txt_SearchInput.Text));
            SearchTextResult.Clear();
            foreach (var field in searchResult)
            {
                SearchTextResult.Add(CommonUtils.FormatField(field));
            }
        }

        private void btn_InsertFields_Click(object sender, EventArgs e) {
            var selectedText = this.list_SearchResult.SelectedItems.Cast<string>().ToList();
            var selectedFields = FieldPool.GetFieldsFromText(selectedText);
            var selectedRanges = FieldPool.GetRangesFromField(selectedFields);
            var bookmarkNames = FieldPool.GetBookmarkNames(selectedText);

            FieldPool.AddBookmarks(selectedRanges, bookmarkNames);
        }

        private void button1_Click(object sender, EventArgs e) {
            FieldPool.LoadFieldDictionary();
        }
    }
}

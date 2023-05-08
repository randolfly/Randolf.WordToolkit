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

        public SearchDialog(FieldPool fieldPool)
        {
            FieldPool = fieldPool;
            InitializeComponent();
        }

        private void txt_SearchInput_TextChanged(object sender, EventArgs e)
        {
            var searchResult = FieldPool.SearchFields(CommonUtils.FormatString(this.txt_SearchInput.Text));
            this.list_SearchResult.Items.Clear();
            this.list_SearchResult.View = System.Windows.Forms.View.List;
            this.list_SearchResult.BeginUpdate();
            foreach (var field in searchResult)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = CommonUtils.FormatField(field);
                this.list_SearchResult.Items.Add(lvi);
            }


            this.list_SearchResult.EndUpdate();
        }

        private void btn_InsertFields_Click(object sender, EventArgs e)
        {
            var selectedText =
                this.list_SearchResult.SelectedItems
                    .Cast<ListViewItem>()
                    .Select(s => s.Text)
                    .ToList();
            var selectedFields = FieldPool.GetFieldsFromText(selectedText);
            var selectedRanges = FieldPool.GetRangesFromField(selectedFields);
            var bookmarkNames = FieldPool.GetBookmarkNames(selectedText);

            FieldPool.AddBookmarks(selectedRanges, bookmarkNames);
        }
    }
}

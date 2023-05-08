using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
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
    }
}

using System.Diagnostics;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using Randolf.WordToolkit.Model;
using Randolf.WordToolkit.Util;
using Randolf.WordToolkit.View;

namespace Randolf.WordToolkit
{
    public partial class MainRibbon
    {
        public FieldPool FieldPool { get; set; } = new FieldPool();

        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        private void btn_ShowCaption_Click(object sender, RibbonControlEventArgs e)
        {
            FieldPool.LoadFieldDictionary();
            foreach (var field in FieldPool.FieldResult)
            {
                Debug.WriteLine($"{CommonUtils.FormatField(field)}");
            }
            var searchDialog = new SearchDialog(FieldPool);
            searchDialog.ShowDialog();
        }
    }
}
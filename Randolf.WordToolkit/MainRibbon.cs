using System.Diagnostics;
using Microsoft.Office.Tools.Ribbon;
using Randolf.WordToolkit.Model;
using Randolf.WordToolkit.Util;
using Randolf.WordToolkit.View;
//调用WINDOWS API函数时要用到

//写入注册表时要用到

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
            SearchAndInsertField();
        }

        private void SearchAndInsertField()
        {
            FieldPool.LoadFieldDictionary();
            foreach (var field in FieldPool.FieldResult) Debug.WriteLine($"{CommonUtils.FormatField(field)}");

            var searchDialog = new SearchDialog(FieldPool);
            searchDialog.ShowDialog();
        }
    }
}
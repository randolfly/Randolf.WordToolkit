using System.Linq;
using System.Windows.Forms;
using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using Randolf.WordToolkit.Model;
using Randolf.WordToolkit.View;

//调用WINDOWS API函数时要用到

//写入注册表时要用到

namespace Randolf.WordToolkit
{
    public partial class MainRibbon
    {
        public FieldPool FieldPool { get; set; } = new FieldPool();
        public PicStyle PicStyle { get; set; } = new PicStyle();


        private void MainRibbon_Load(object sender, RibbonUIEventArgs e)
        {
        }

        #region Caption Manage

        private void btn_ShowCaption_Click(object sender, RibbonControlEventArgs e)
        {
            SearchAndInsertField();
        }

        private void SearchAndInsertField()
        {
            FieldPool.LoadFieldDictionary();
            var searchDialog = new SearchDialog(FieldPool);
            searchDialog.ShowDialog();
        }

        #endregion


        #region Pic Manage

        private void edt_picWidth_TextChanged(object sender, RibbonControlEventArgs e)
        {
            PicStyle.Width = float.Parse(edt_picWidth.Text);
        }

        private void edt_picHeight_TextChanged(object sender, RibbonControlEventArgs e)
        {
            PicStyle.Height = float.Parse(edt_picHeight.Text);
        }

        private void btn_updatePic_Click(object sender, RibbonControlEventArgs e)
        {
            UpdatePictures();
        }

        private void UpdatePictures()
        {
            var inlineShapes = Globals.ThisAddIn.Application.ActiveDocument.InlineShapes
                .Cast<InlineShape>().ToList();

            MessageBox.Show($@"pic width: {PicStyle.Width:##.00}
pic height: {PicStyle.Height:##.000}
pic number: {inlineShapes.Count}");

            inlineShapes.ForEach(shape =>
            {
                shape.Width = PicStyle.Width;
                shape.Height = PicStyle.Height;
            });
        }

        #endregion
    }
}
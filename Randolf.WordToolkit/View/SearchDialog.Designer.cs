namespace Randolf.WordToolkit.View
{
    partial class SearchDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.txt_SearchInput = new System.Windows.Forms.TextBox();
            this.list_SearchResult = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // txt_SearchInput
            // 
            this.txt_SearchInput.Location = new System.Drawing.Point(25, 28);
            this.txt_SearchInput.Name = "txt_SearchInput";
            this.txt_SearchInput.Size = new System.Drawing.Size(384, 28);
            this.txt_SearchInput.TabIndex = 0;
            this.txt_SearchInput.TextChanged += new System.EventHandler(this.txt_SearchInput_TextChanged);
            // 
            // list_SearchResult
            // 
            this.list_SearchResult.HideSelection = false;
            this.list_SearchResult.Location = new System.Drawing.Point(25, 81);
            this.list_SearchResult.Name = "list_SearchResult";
            this.list_SearchResult.Size = new System.Drawing.Size(384, 380);
            this.list_SearchResult.TabIndex = 1;
            this.list_SearchResult.UseCompatibleStateImageBehavior = false;
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 480);
            this.Controls.Add(this.list_SearchResult);
            this.Controls.Add(this.txt_SearchInput);
            this.Name = "SearchDialog";
            this.Text = "SearchDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SearchInput;
        private System.Windows.Forms.ListView list_SearchResult;
    }
}
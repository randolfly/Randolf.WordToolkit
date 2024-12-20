﻿namespace Randolf.WordToolkit.View
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
            this.btn_InsertFields = new System.Windows.Forms.Button();
            this.list_SearchResult = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txt_SearchInput
            // 
            this.txt_SearchInput.Location = new System.Drawing.Point(13, 48);
            this.txt_SearchInput.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txt_SearchInput.Name = "txt_SearchInput";
            this.txt_SearchInput.Size = new System.Drawing.Size(403, 31);
            this.txt_SearchInput.TabIndex = 0;
            this.txt_SearchInput.MouseLeave += new System.EventHandler(this.txt_SearchInput_TextChanged);
            // 
            // btn_InsertFields
            // 
            this.btn_InsertFields.Cursor = System.Windows.Forms.Cursors.Default;
            this.btn_InsertFields.Location = new System.Drawing.Point(424, 44);
            this.btn_InsertFields.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btn_InsertFields.Name = "btn_InsertFields";
            this.btn_InsertFields.Size = new System.Drawing.Size(68, 35);
            this.btn_InsertFields.TabIndex = 2;
            this.btn_InsertFields.Text = "Insert";
            this.btn_InsertFields.UseVisualStyleBackColor = true;
            this.btn_InsertFields.Click += new System.EventHandler(this.btn_InsertFields_Click);
            // 
            // list_SearchResult
            // 
            this.list_SearchResult.FormattingEnabled = true;
            this.list_SearchResult.ItemHeight = 23;
            this.list_SearchResult.Location = new System.Drawing.Point(13, 103);
            this.list_SearchResult.Name = "list_SearchResult";
            this.list_SearchResult.ScrollAlwaysVisible = true;
            this.list_SearchResult.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.list_SearchResult.Size = new System.Drawing.Size(558, 441);
            this.list_SearchResult.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Default;
            this.button1.Location = new System.Drawing.Point(503, 45);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 35);
            this.button1.TabIndex = 4;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SearchDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(599, 576);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.list_SearchResult);
            this.Controls.Add(this.btn_InsertFields);
            this.Controls.Add(this.txt_SearchInput);
            this.Font = new System.Drawing.Font("Microsoft YaHei", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SearchDialog";
            this.Text = "SearchDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_SearchInput;
        private System.Windows.Forms.Button btn_InsertFields;
        private System.Windows.Forms.ListBox list_SearchResult;
        private System.Windows.Forms.Button button1;
    }
}
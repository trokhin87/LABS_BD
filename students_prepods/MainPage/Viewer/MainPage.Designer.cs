namespace students_prepods.MainPage.Viewer
{
    partial class MainPage
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
            dataTableMark = new DataGridView();
            TextMark = new TextBox();
            lblMark = new Label();
            update = new Button();
            delete = new Button();
            TextSearch = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dataTableMark).BeginInit();
            SuspendLayout();
            // 
            // dataTableMark
            // 
            dataTableMark.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataTableMark.Location = new Point(-3, -2);
            dataTableMark.Name = "dataTableMark";
            dataTableMark.Size = new Size(552, 449);
            dataTableMark.TabIndex = 0;
            // 
            // TextMark
            // 
            TextMark.Location = new Point(623, 122);
            TextMark.Name = "TextMark";
            TextMark.Size = new Size(100, 23);
            TextMark.TabIndex = 1;
            // 
            // lblMark
            // 
            lblMark.AutoSize = true;
            lblMark.Location = new Point(569, 125);
            lblMark.Name = "lblMark";
            lblMark.Size = new Size(48, 15);
            lblMark.TabIndex = 2;
            lblMark.Text = "Оценка";
            // 
            // update
            // 
            update.Location = new Point(569, 195);
            update.Name = "update";
            update.Size = new Size(75, 23);
            update.TabIndex = 4;
            update.Text = "update";
            update.UseVisualStyleBackColor = true;
            // 
            // delete
            // 
            delete.Location = new Point(700, 195);
            delete.Name = "delete";
            delete.Size = new Size(75, 23);
            delete.TabIndex = 5;
            delete.Text = "delete";
            delete.UseVisualStyleBackColor = true;
            // 
            // TextSearch
            // 
            TextSearch.Location = new Point(647, 296);
            TextSearch.Name = "TextSearch";
            TextSearch.Size = new Size(100, 23);
            TextSearch.TabIndex = 6;
            // 
            // MainPage
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TextSearch);
            Controls.Add(delete);
            Controls.Add(update);
            Controls.Add(lblMark);
            Controls.Add(TextMark);
            Controls.Add(dataTableMark);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "MainPage";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)dataTableMark).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox TextMark;
        private Label lblMark;
        private Button update;
        private Button delete;
        public DataGridView dataTableMark;
        private TextBox TextSearch;
    }
}
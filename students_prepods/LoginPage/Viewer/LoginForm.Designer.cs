namespace students_prepods.LoginPage.Viewer
{
    partial class LoginForm
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
            button1 = new Button();
            textID = new TextBox();
            TextPass = new TextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(279, 242);
            button1.Name = "button1";
            button1.Size = new Size(97, 31);
            button1.TabIndex = 0;
            button1.Text = "Log in";
            button1.UseVisualStyleBackColor = true;
            // 
            // textID
            // 
            textID.Location = new Point(252, 108);
            textID.Name = "textID";
            textID.Size = new Size(157, 26);
            textID.TabIndex = 1;
            // 
            // TextPass
            // 
            TextPass.Location = new Point(252, 178);
            TextPass.Name = "TextPass";
            TextPass.Size = new Size(157, 26);
            TextPass.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(211, 111);
            label1.Name = "label1";
            label1.Size = new Size(24, 18);
            label1.TabIndex = 3;
            label1.Text = "Id";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(157, 181);
            label2.Name = "label2";
            label2.Size = new Size(78, 18);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(9F, 18F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(667, 413);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(TextPass);
            Controls.Add(textID);
            Controls.Add(button1);
            Font = new Font("Verdana", 11.25F, FontStyle.Italic, GraphicsUnit.Point, 204);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(4);
            Name = "LoginForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private TextBox textID;
        private TextBox TextPass;
        private Label label1;
        private Label label2;
    }
}
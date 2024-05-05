namespace poker_cliente
{
    partial class register_form
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
            this.label3 = new System.Windows.Forms.Label();
            this.Correo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pass_box = new System.Windows.Forms.TextBox();
            this.mail_box = new System.Windows.Forms.TextBox();
            this.user_box = new System.Windows.Forms.TextBox();
            this.register_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(398, 314);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Contraseña";
            // 
            // Correo
            // 
            this.Correo.AutoSize = true;
            this.Correo.Location = new System.Drawing.Point(414, 234);
            this.Correo.Name = "Correo";
            this.Correo.Size = new System.Drawing.Size(57, 20);
            this.Correo.TabIndex = 12;
            this.Correo.Text = "Correo";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(369, 151);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 11;
            this.label1.Text = "Nombre de usuario";
            // 
            // pass_box
            // 
            this.pass_box.Location = new System.Drawing.Point(382, 350);
            this.pass_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pass_box.Name = "pass_box";
            this.pass_box.PasswordChar = '*';
            this.pass_box.Size = new System.Drawing.Size(112, 26);
            this.pass_box.TabIndex = 10;
            // 
            // mail_box
            // 
            this.mail_box.Location = new System.Drawing.Point(382, 271);
            this.mail_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.mail_box.Name = "mail_box";
            this.mail_box.Size = new System.Drawing.Size(112, 26);
            this.mail_box.TabIndex = 9;
            // 
            // user_box
            // 
            this.user_box.Location = new System.Drawing.Point(382, 189);
            this.user_box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.user_box.Name = "user_box";
            this.user_box.Size = new System.Drawing.Size(112, 26);
            this.user_box.TabIndex = 8;
            // 
            // register_btn
            // 
            this.register_btn.Location = new System.Drawing.Point(371, 424);
            this.register_btn.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.register_btn.Name = "register_btn";
            this.register_btn.Size = new System.Drawing.Size(135, 58);
            this.register_btn.TabIndex = 7;
            this.register_btn.Text = "Registrar";
            this.register_btn.UseVisualStyleBackColor = true;
            // 
            // register_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 632);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Correo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pass_box);
            this.Controls.Add(this.mail_box);
            this.Controls.Add(this.user_box);
            this.Controls.Add(this.register_btn);
            this.Name = "register_form";
            this.Text = "Registro de usuario";
            this.Load += new System.EventHandler(this.register_form_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Correo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox pass_box;
        private System.Windows.Forms.TextBox mail_box;
        private System.Windows.Forms.TextBox user_box;
        private System.Windows.Forms.Button register_btn;
    }
}
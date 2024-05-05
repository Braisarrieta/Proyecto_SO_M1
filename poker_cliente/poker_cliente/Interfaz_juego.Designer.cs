namespace poker_cliente
{
    partial class Interfaz_juego
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.Chatlabel = new System.Windows.Forms.Label();
            this.ChatEnviar = new System.Windows.Forms.Button();
            this.ChatOutput = new System.Windows.Forms.TextBox();
            this.ChatInput = new System.Windows.Forms.TextBox();
            this.Mano1 = new System.Windows.Forms.Panel();
            this.Mano2 = new System.Windows.Forms.Panel();
            this.Mano3 = new System.Windows.Forms.Panel();
            this.Mano4 = new System.Windows.Forms.Panel();
            this.Mano5 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Chatlabel);
            this.panel2.Controls.Add(this.ChatEnviar);
            this.panel2.Controls.Add(this.ChatOutput);
            this.panel2.Controls.Add(this.ChatInput);
            this.panel2.Location = new System.Drawing.Point(13, 13);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(449, 486);
            this.panel2.TabIndex = 2;
            // 
            // Chatlabel
            // 
            this.Chatlabel.AutoSize = true;
            this.Chatlabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Chatlabel.Location = new System.Drawing.Point(36, 20);
            this.Chatlabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Chatlabel.Name = "Chatlabel";
            this.Chatlabel.Size = new System.Drawing.Size(81, 32);
            this.Chatlabel.TabIndex = 3;
            this.Chatlabel.Text = "Chat ";
            // 
            // ChatEnviar
            // 
            this.ChatEnviar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatEnviar.Location = new System.Drawing.Point(309, 430);
            this.ChatEnviar.Margin = new System.Windows.Forms.Padding(4);
            this.ChatEnviar.Name = "ChatEnviar";
            this.ChatEnviar.Size = new System.Drawing.Size(106, 39);
            this.ChatEnviar.TabIndex = 2;
            this.ChatEnviar.Text = "Enviar";
            this.ChatEnviar.UseVisualStyleBackColor = true;
            // 
            // ChatOutput
            // 
            this.ChatOutput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatOutput.Enabled = false;
            this.ChatOutput.Location = new System.Drawing.Point(42, 60);
            this.ChatOutput.Margin = new System.Windows.Forms.Padding(4);
            this.ChatOutput.Multiline = true;
            this.ChatOutput.Name = "ChatOutput";
            this.ChatOutput.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.ChatOutput.Size = new System.Drawing.Size(373, 360);
            this.ChatOutput.TabIndex = 1;
            // 
            // ChatInput
            // 
            this.ChatInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ChatInput.Location = new System.Drawing.Point(39, 430);
            this.ChatInput.Margin = new System.Windows.Forms.Padding(4);
            this.ChatInput.Name = "ChatInput";
            this.ChatInput.Size = new System.Drawing.Size(259, 26);
            this.ChatInput.TabIndex = 0;
            // 
            // Mano1
            // 
            this.Mano1.BackColor = System.Drawing.Color.Transparent;
            this.Mano1.Location = new System.Drawing.Point(114, 673);
            this.Mano1.Margin = new System.Windows.Forms.Padding(4);
            this.Mano1.Name = "Mano1";
            this.Mano1.Size = new System.Drawing.Size(197, 300);
            this.Mano1.TabIndex = 3;
            // 
            // Mano2
            // 
            this.Mano2.BackColor = System.Drawing.Color.Transparent;
            this.Mano2.Location = new System.Drawing.Point(349, 673);
            this.Mano2.Margin = new System.Windows.Forms.Padding(4);
            this.Mano2.Name = "Mano2";
            this.Mano2.Size = new System.Drawing.Size(197, 300);
            this.Mano2.TabIndex = 4;
            // 
            // Mano3
            // 
            this.Mano3.BackColor = System.Drawing.Color.Transparent;
            this.Mano3.Location = new System.Drawing.Point(598, 673);
            this.Mano3.Margin = new System.Windows.Forms.Padding(4);
            this.Mano3.Name = "Mano3";
            this.Mano3.Size = new System.Drawing.Size(197, 300);
            this.Mano3.TabIndex = 4;
            // 
            // Mano4
            // 
            this.Mano4.BackColor = System.Drawing.Color.Transparent;
            this.Mano4.Location = new System.Drawing.Point(830, 673);
            this.Mano4.Margin = new System.Windows.Forms.Padding(4);
            this.Mano4.Name = "Mano4";
            this.Mano4.Size = new System.Drawing.Size(197, 300);
            this.Mano4.TabIndex = 4;
            this.Mano4.Paint += new System.Windows.Forms.PaintEventHandler(this.panel4_Paint);
            // 
            // Mano5
            // 
            this.Mano5.BackColor = System.Drawing.Color.Transparent;
            this.Mano5.Location = new System.Drawing.Point(1064, 673);
            this.Mano5.Margin = new System.Windows.Forms.Padding(4);
            this.Mano5.Name = "Mano5";
            this.Mano5.Size = new System.Drawing.Size(197, 300);
            this.Mano5.TabIndex = 4;
            // 
            // Interfaz_juego
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::poker_cliente.Properties.Resources.fondo;
            this.ClientSize = new System.Drawing.Size(1405, 1017);
            this.Controls.Add(this.Mano5);
            this.Controls.Add(this.Mano4);
            this.Controls.Add(this.Mano3);
            this.Controls.Add(this.Mano2);
            this.Controls.Add(this.Mano1);
            this.Controls.Add(this.panel2);
            this.Name = "Interfaz_juego";
            this.Text = "Interfaz_juego";
            this.Load += new System.EventHandler(this.Interfaz_juego_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Chatlabel;
        private System.Windows.Forms.Button ChatEnviar;
        private System.Windows.Forms.TextBox ChatOutput;
        private System.Windows.Forms.TextBox ChatInput;
        private System.Windows.Forms.Panel Mano1;
        private System.Windows.Forms.Panel Mano2;
        private System.Windows.Forms.Panel Mano3;
        private System.Windows.Forms.Panel Mano4;
        private System.Windows.Forms.Panel Mano5;
    }
}
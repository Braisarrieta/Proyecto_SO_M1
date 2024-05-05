namespace poker_cliente
{
    partial class Principal_LogOut
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.Connector_button = new System.Windows.Forms.Button();
            this.Desconectar = new System.Windows.Forms.Button();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.ConexionStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.inicioDeSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.registroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.consolaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ConsolaControl = new System.Windows.Forms.TextBox();
            this.Titulo = new System.Windows.Forms.Label();
            this.IP_Box = new System.Windows.Forms.ComboBox();
            this.menuStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // Connector_button
            // 
            this.Connector_button.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Connector_button.Location = new System.Drawing.Point(339, 184);
            this.Connector_button.Name = "Connector_button";
            this.Connector_button.Size = new System.Drawing.Size(222, 79);
            this.Connector_button.TabIndex = 0;
            this.Connector_button.Text = "Conectar";
            this.Connector_button.UseVisualStyleBackColor = true;
            this.Connector_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // Desconectar
            // 
            this.Desconectar.Font = new System.Drawing.Font("Arial Narrow", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Desconectar.Location = new System.Drawing.Point(339, 328);
            this.Desconectar.Name = "Desconectar";
            this.Desconectar.Size = new System.Drawing.Size(222, 79);
            this.Desconectar.TabIndex = 1;
            this.Desconectar.Text = "Desconectar";
            this.Desconectar.UseVisualStyleBackColor = true;
            this.Desconectar.Click += new System.EventHandler(this.Desconectar_Click);
            // 
            // menuStrip2
            // 
            this.menuStrip2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.menuStrip2.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.menuStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ConexionStripMenuItem1,
            this.toolsToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip2.Size = new System.Drawing.Size(989, 33);
            this.menuStrip2.TabIndex = 4;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // ConexionStripMenuItem1
            // 
            this.ConexionStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inicioDeSesiónToolStripMenuItem,
            this.registroToolStripMenuItem});
            this.ConexionStripMenuItem1.Name = "ConexionStripMenuItem1";
            this.ConexionStripMenuItem1.Size = new System.Drawing.Size(102, 29);
            this.ConexionStripMenuItem1.Text = "Conexión";
            this.ConexionStripMenuItem1.Visible = false;
            // 
            // inicioDeSesiónToolStripMenuItem
            // 
            this.inicioDeSesiónToolStripMenuItem.Name = "inicioDeSesiónToolStripMenuItem";
            this.inicioDeSesiónToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.inicioDeSesiónToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.inicioDeSesiónToolStripMenuItem.Text = "Inicio de Sesión";
            // 
            // registroToolStripMenuItem
            // 
            this.registroToolStripMenuItem.Name = "registroToolStripMenuItem";
            this.registroToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.registroToolStripMenuItem.Size = new System.Drawing.Size(294, 34);
            this.registroToolStripMenuItem.Text = "Registro";
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.consolaToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // consolaToolStripMenuItem
            // 
            this.consolaToolStripMenuItem.CheckOnClick = true;
            this.consolaToolStripMenuItem.Name = "consolaToolStripMenuItem";
            this.consolaToolStripMenuItem.Size = new System.Drawing.Size(270, 34);
            this.consolaToolStripMenuItem.Text = "Consola";
            // 
            // ConsolaControl
            // 
            this.ConsolaControl.Location = new System.Drawing.Point(0, 534);
            this.ConsolaControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.ConsolaControl.Multiline = true;
            this.ConsolaControl.Name = "ConsolaControl";
            this.ConsolaControl.ReadOnly = true;
            this.ConsolaControl.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConsolaControl.Size = new System.Drawing.Size(989, 159);
            this.ConsolaControl.TabIndex = 6;
            this.ConsolaControl.Visible = false;
            // 
            // Titulo
            // 
            this.Titulo.AutoSize = true;
            this.Titulo.Location = new System.Drawing.Point(335, 84);
            this.Titulo.Name = "Titulo";
            this.Titulo.Size = new System.Drawing.Size(160, 20);
            this.Titulo.TabIndex = 9;
            this.Titulo.Text = "Seleciona un servidor";
            // 
            // IP_Box
            // 
            this.IP_Box.FormattingEnabled = true;
            this.IP_Box.Items.AddRange(new object[] {
            "10.4.119.5",
            "192.168.56.101",
            "192.168.56.102"});
            this.IP_Box.Location = new System.Drawing.Point(334, 108);
            this.IP_Box.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.IP_Box.MaxLength = 15;
            this.IP_Box.Name = "IP_Box";
            this.IP_Box.Size = new System.Drawing.Size(227, 28);
            this.IP_Box.TabIndex = 8;
            this.IP_Box.SelectedIndexChanged += new System.EventHandler(this.IP_Box_SelectedIndexChanged);
            // 
            // Principal_LogOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(989, 692);
            this.Controls.Add(this.Titulo);
            this.Controls.Add(this.IP_Box);
            this.Controls.Add(this.ConsolaControl);
            this.Controls.Add(this.menuStrip2);
            this.Controls.Add(this.Desconectar);
            this.Controls.Add(this.Connector_button);
            this.Name = "Principal_LogOut";
            this.Text = "Conexión";
            this.Load += new System.EventHandler(this.Principal_Logged_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Connector_button;
        private System.Windows.Forms.Button Desconectar;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem ConexionStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem inicioDeSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registroToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem consolaToolStripMenuItem;
        public System.Windows.Forms.TextBox ConsolaControl;
        private System.Windows.Forms.Label Titulo;
        private System.Windows.Forms.ComboBox IP_Box;
    }
}


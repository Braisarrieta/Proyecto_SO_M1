namespace poker_cliente
{
    partial class Principal_Logged
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Principal_Logged));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.logOut = new System.Windows.Forms.ToolStripSplitButton();
            this.Conectados = new System.Windows.Forms.ToolStrip();
            this.panelConectados = new System.Windows.Forms.ToolStripSplitButton();
            this.dataGridConectados = new System.Windows.Forms.DataGridView();
            this.CrearPartida = new System.Windows.Forms.Panel();
            this.DGVInvitados = new System.Windows.Forms.DataGridView();
            this.Invitado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Accepted = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.EnviarPartida = new System.Windows.Forms.Button();
            this.LabelInvitado3 = new System.Windows.Forms.Label();
            this.LabelInvitado2 = new System.Windows.Forms.Label();
            this.LabelInvitado1 = new System.Windows.Forms.Label();
            this.SelecctionarLablel = new System.Windows.Forms.Label();
            this.LabelMode = new System.Windows.Forms.Label();
            this.Titulo_invitar = new System.Windows.Forms.Label();
            this.Jugador3ComboBox = new System.Windows.Forms.ComboBox();
            this.Jugador2ComboBox = new System.Windows.Forms.ComboBox();
            this.Jugador1ComboBox = new System.Windows.Forms.ComboBox();
            this.ModeComboBox = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.Conectados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).BeginInit();
            this.CrearPartida.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvitados)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logOut});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1433, 34);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // logOut
            // 
            this.logOut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.logOut.Image = ((System.Drawing.Image)(resources.GetObject("logOut.Image")));
            this.logOut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(98, 29);
            this.logOut.Text = "Log Out";
            this.logOut.ToolTipText = "Log out";
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // Conectados
            // 
            this.Conectados.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.Conectados.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.panelConectados});
            this.Conectados.Location = new System.Drawing.Point(0, 34);
            this.Conectados.Name = "Conectados";
            this.Conectados.Size = new System.Drawing.Size(1433, 34);
            this.Conectados.TabIndex = 1;
            this.Conectados.Text = "toolStrip2";
            this.Conectados.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.toolStrip2_ItemClicked);
            // 
            // panelConectados
            // 
            this.panelConectados.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.panelConectados.Image = ((System.Drawing.Image)(resources.GetObject("panelConectados.Image")));
            this.panelConectados.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.panelConectados.Name = "panelConectados";
            this.panelConectados.Size = new System.Drawing.Size(127, 29);
            this.panelConectados.Text = "Conectados";
            this.panelConectados.Click += new System.EventHandler(this.conectados_Click);
            // 
            // dataGridConectados
            // 
            this.dataGridConectados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridConectados.Location = new System.Drawing.Point(84, 514);
            this.dataGridConectados.Name = "dataGridConectados";
            this.dataGridConectados.RowHeadersWidth = 62;
            this.dataGridConectados.RowTemplate.Height = 28;
            this.dataGridConectados.Size = new System.Drawing.Size(298, 290);
            this.dataGridConectados.TabIndex = 2;
            // 
            // CrearPartida
            // 
            this.CrearPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.CrearPartida.AutoSize = true;
            this.CrearPartida.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CrearPartida.Controls.Add(this.DGVInvitados);
            this.CrearPartida.Controls.Add(this.EnviarPartida);
            this.CrearPartida.Controls.Add(this.LabelInvitado3);
            this.CrearPartida.Controls.Add(this.LabelInvitado2);
            this.CrearPartida.Controls.Add(this.LabelInvitado1);
            this.CrearPartida.Controls.Add(this.SelecctionarLablel);
            this.CrearPartida.Controls.Add(this.LabelMode);
            this.CrearPartida.Controls.Add(this.Titulo_invitar);
            this.CrearPartida.Controls.Add(this.Jugador3ComboBox);
            this.CrearPartida.Controls.Add(this.Jugador2ComboBox);
            this.CrearPartida.Controls.Add(this.Jugador1ComboBox);
            this.CrearPartida.Controls.Add(this.ModeComboBox);
            this.CrearPartida.Location = new System.Drawing.Point(576, 83);
            this.CrearPartida.Name = "CrearPartida";
            this.CrearPartida.Size = new System.Drawing.Size(845, 551);
            this.CrearPartida.TabIndex = 5;
            this.CrearPartida.Visible = false;
            // 
            // DGVInvitados
            // 
            this.DGVInvitados.AllowUserToAddRows = false;
            this.DGVInvitados.AllowUserToDeleteRows = false;
            this.DGVInvitados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGVInvitados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGVInvitados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGVInvitados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Invitado,
            this.Accepted});
            this.DGVInvitados.Location = new System.Drawing.Point(405, 232);
            this.DGVInvitados.Name = "DGVInvitados";
            this.DGVInvitados.ReadOnly = true;
            this.DGVInvitados.RowHeadersWidth = 51;
            this.DGVInvitados.RowTemplate.Height = 24;
            this.DGVInvitados.Size = new System.Drawing.Size(387, 257);
            this.DGVInvitados.TabIndex = 6;
            // 
            // Invitado
            // 
            this.Invitado.HeaderText = "Invitado";
            this.Invitado.MinimumWidth = 6;
            this.Invitado.Name = "Invitado";
            this.Invitado.ReadOnly = true;
            // 
            // Accepted
            // 
            this.Accepted.HeaderText = "Accepted?";
            this.Accepted.MinimumWidth = 6;
            this.Accepted.Name = "Accepted";
            this.Accepted.ReadOnly = true;
            this.Accepted.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Accepted.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // EnviarPartida
            // 
            this.EnviarPartida.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnviarPartida.Font = new System.Drawing.Font("Microsoft Sans Serif", 22.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnviarPartida.Location = new System.Drawing.Point(479, 101);
            this.EnviarPartida.Name = "EnviarPartida";
            this.EnviarPartida.Size = new System.Drawing.Size(229, 95);
            this.EnviarPartida.TabIndex = 5;
            this.EnviarPartida.Text = "Invitar";
            this.EnviarPartida.UseVisualStyleBackColor = true;
            // 
            // LabelInvitado3
            // 
            this.LabelInvitado3.AutoSize = true;
            this.LabelInvitado3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado3.Location = new System.Drawing.Point(45, 374);
            this.LabelInvitado3.Name = "LabelInvitado3";
            this.LabelInvitado3.Size = new System.Drawing.Size(115, 29);
            this.LabelInvitado3.TabIndex = 4;
            this.LabelInvitado3.Text = "Invitado 3";
            this.LabelInvitado3.Visible = false;
            // 
            // LabelInvitado2
            // 
            this.LabelInvitado2.AutoSize = true;
            this.LabelInvitado2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado2.Location = new System.Drawing.Point(45, 292);
            this.LabelInvitado2.Name = "LabelInvitado2";
            this.LabelInvitado2.Size = new System.Drawing.Size(115, 29);
            this.LabelInvitado2.TabIndex = 4;
            this.LabelInvitado2.Text = "Invitado 2";
            this.LabelInvitado2.Visible = false;
            // 
            // LabelInvitado1
            // 
            this.LabelInvitado1.AutoSize = true;
            this.LabelInvitado1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelInvitado1.Location = new System.Drawing.Point(45, 214);
            this.LabelInvitado1.Name = "LabelInvitado1";
            this.LabelInvitado1.Size = new System.Drawing.Size(115, 29);
            this.LabelInvitado1.TabIndex = 4;
            this.LabelInvitado1.Text = "Invitado 1";
            this.LabelInvitado1.Visible = false;
            // 
            // SelecctionarLablel
            // 
            this.SelecctionarLablel.AutoSize = true;
            this.SelecctionarLablel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SelecctionarLablel.Location = new System.Drawing.Point(45, 171);
            this.SelecctionarLablel.Name = "SelecctionarLablel";
            this.SelecctionarLablel.Size = new System.Drawing.Size(272, 29);
            this.SelecctionarLablel.TabIndex = 4;
            this.SelecctionarLablel.Text = "Selecciona los invitados";
            // 
            // LabelMode
            // 
            this.LabelMode.AutoSize = true;
            this.LabelMode.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LabelMode.Location = new System.Drawing.Point(45, 92);
            this.LabelMode.Name = "LabelMode";
            this.LabelMode.Size = new System.Drawing.Size(423, 29);
            this.LabelMode.TabIndex = 4;
            this.LabelMode.Text = "Selecciona cuantos jugadores quieres";
            // 
            // Titulo_invitar
            // 
            this.Titulo_invitar.AutoSize = true;
            this.Titulo_invitar.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Titulo_invitar.Location = new System.Drawing.Point(42, 34);
            this.Titulo_invitar.Name = "Titulo_invitar";
            this.Titulo_invitar.Size = new System.Drawing.Size(323, 55);
            this.Titulo_invitar.TabIndex = 3;
            this.Titulo_invitar.Text = "Crear Partida";
            // 
            // Jugador3ComboBox
            // 
            this.Jugador3ComboBox.FormattingEnabled = true;
            this.Jugador3ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador3ComboBox.Location = new System.Drawing.Point(50, 412);
            this.Jugador3ComboBox.Name = "Jugador3ComboBox";
            this.Jugador3ComboBox.Size = new System.Drawing.Size(204, 28);
            this.Jugador3ComboBox.TabIndex = 0;
            this.Jugador3ComboBox.Visible = false;
            // 
            // Jugador2ComboBox
            // 
            this.Jugador2ComboBox.FormattingEnabled = true;
            this.Jugador2ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador2ComboBox.Location = new System.Drawing.Point(50, 330);
            this.Jugador2ComboBox.Name = "Jugador2ComboBox";
            this.Jugador2ComboBox.Size = new System.Drawing.Size(204, 28);
            this.Jugador2ComboBox.TabIndex = 0;
            this.Jugador2ComboBox.Visible = false;
            // 
            // Jugador1ComboBox
            // 
            this.Jugador1ComboBox.FormattingEnabled = true;
            this.Jugador1ComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.Jugador1ComboBox.Location = new System.Drawing.Point(50, 252);
            this.Jugador1ComboBox.Name = "Jugador1ComboBox";
            this.Jugador1ComboBox.Size = new System.Drawing.Size(204, 28);
            this.Jugador1ComboBox.TabIndex = 0;
            this.Jugador1ComboBox.Visible = false;
            // 
            // ModeComboBox
            // 
            this.ModeComboBox.FormattingEnabled = true;
            this.ModeComboBox.Items.AddRange(new object[] {
            "2",
            "4"});
            this.ModeComboBox.Location = new System.Drawing.Point(50, 130);
            this.ModeComboBox.Name = "ModeComboBox";
            this.ModeComboBox.Size = new System.Drawing.Size(204, 28);
            this.ModeComboBox.TabIndex = 0;
            // 
            // Principal_Logged
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1433, 894);
            this.Controls.Add(this.CrearPartida);
            this.Controls.Add(this.dataGridConectados);
            this.Controls.Add(this.Conectados);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Principal_Logged";
            this.Text = "Principal_Logged";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.Conectados.ResumeLayout(false);
            this.Conectados.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridConectados)).EndInit();
            this.CrearPartida.ResumeLayout(false);
            this.CrearPartida.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGVInvitados)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStrip Conectados;
        private System.Windows.Forms.ToolStripSplitButton logOut;
        private System.Windows.Forms.ToolStripSplitButton panelConectados;
        private System.Windows.Forms.DataGridView dataGridConectados;
        private System.Windows.Forms.Panel CrearPartida;
        private System.Windows.Forms.DataGridView DGVInvitados;
        private System.Windows.Forms.DataGridViewTextBoxColumn Invitado;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Accepted;
        private System.Windows.Forms.Button EnviarPartida;
        private System.Windows.Forms.Label LabelInvitado3;
        private System.Windows.Forms.Label LabelInvitado2;
        private System.Windows.Forms.Label LabelInvitado1;
        private System.Windows.Forms.Label SelecctionarLablel;
        private System.Windows.Forms.Label LabelMode;
        private System.Windows.Forms.Label Titulo_invitar;
        private System.Windows.Forms.ComboBox Jugador3ComboBox;
        private System.Windows.Forms.ComboBox Jugador2ComboBox;
        private System.Windows.Forms.ComboBox Jugador1ComboBox;
        private System.Windows.Forms.ComboBox ModeComboBox;
    }
}
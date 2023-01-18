namespace ProjetoControleDeVendas.View {
    partial class FrmMenu {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFuncionarios = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaFornecedores = new System.Windows.Forms.ToolStripMenuItem();
            this.menuProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuCadastroProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConsultaProdutos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuVendas = new System.Windows.Forms.ToolStripMenuItem();
            this.menuNovaVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHistoricoVenda = new System.Windows.Forms.ToolStripMenuItem();
            this.menuConfiguracoes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuTrocarUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSairSistema = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtData = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtHora = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
            this.txtUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuClientes,
            this.menuFuncionarios,
            this.menuFornecedores,
            this.menuProdutos,
            this.menuVendas,
            this.menuConfiguracoes});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuClientes
            // 
            this.menuClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroCliente,
            this.menuConsultaClientes});
            this.menuClientes.Image = global::ProjetoControleDeVendas.Properties.Resources.business_office_group_management_partnership_teamwork_team_icon_232671;
            this.menuClientes.Name = "menuClientes";
            this.menuClientes.Size = new System.Drawing.Size(77, 20);
            this.menuClientes.Text = "Clientes";
            // 
            // menuCadastroCliente
            // 
            this.menuCadastroCliente.Name = "menuCadastroCliente";
            this.menuCadastroCliente.Size = new System.Drawing.Size(182, 22);
            this.menuCadastroCliente.Text = "Cadastro de Clientes";
            this.menuCadastroCliente.Click += new System.EventHandler(this.menuCadastroCliente_Click);
            // 
            // menuConsultaClientes
            // 
            this.menuConsultaClientes.Name = "menuConsultaClientes";
            this.menuConsultaClientes.Size = new System.Drawing.Size(182, 22);
            this.menuConsultaClientes.Text = "Consulta de Clientes";
            this.menuConsultaClientes.Click += new System.EventHandler(this.menuConsultaClientes_Click);
            // 
            // menuFuncionarios
            // 
            this.menuFuncionarios.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFuncionarios,
            this.menuConsultaFuncionarios});
            this.menuFuncionarios.Image = global::ProjetoControleDeVendas.Properties.Resources.curriculum_profile_biodata_resume_portofolio_cv_vitae_icon_232635;
            this.menuFuncionarios.Name = "menuFuncionarios";
            this.menuFuncionarios.Size = new System.Drawing.Size(103, 20);
            this.menuFuncionarios.Text = "Funcionários";
            // 
            // menuCadastroFuncionarios
            // 
            this.menuCadastroFuncionarios.Name = "menuCadastroFuncionarios";
            this.menuCadastroFuncionarios.Size = new System.Drawing.Size(208, 22);
            this.menuCadastroFuncionarios.Text = "Cadastro de Funcionários";
            this.menuCadastroFuncionarios.Click += new System.EventHandler(this.menuCadastroFuncionarios_Click);
            // 
            // menuConsultaFuncionarios
            // 
            this.menuConsultaFuncionarios.Name = "menuConsultaFuncionarios";
            this.menuConsultaFuncionarios.Size = new System.Drawing.Size(208, 22);
            this.menuConsultaFuncionarios.Text = "Consulta de Funcionários";
            this.menuConsultaFuncionarios.Click += new System.EventHandler(this.menuConsultaFuncionarios_Click);
            // 
            // menuFornecedores
            // 
            this.menuFornecedores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroFornecedores,
            this.menuConsultaFornecedores});
            this.menuFornecedores.Image = global::ProjetoControleDeVendas.Properties.Resources.presentation_meeting_chat_talk_conversation_conference_communication_icon_232642;
            this.menuFornecedores.Name = "menuFornecedores";
            this.menuFornecedores.Size = new System.Drawing.Size(106, 20);
            this.menuFornecedores.Text = "Fornecedores";
            this.menuFornecedores.Click += new System.EventHandler(this.menuFornecedores_Click);
            // 
            // menuCadastroFornecedores
            // 
            this.menuCadastroFornecedores.Name = "menuCadastroFornecedores";
            this.menuCadastroFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuCadastroFornecedores.Text = "Cadastro de Fornecedores";
            this.menuCadastroFornecedores.Click += new System.EventHandler(this.menuCadastroFornecedores_Click);
            // 
            // menuConsultaFornecedores
            // 
            this.menuConsultaFornecedores.Name = "menuConsultaFornecedores";
            this.menuConsultaFornecedores.Size = new System.Drawing.Size(211, 22);
            this.menuConsultaFornecedores.Text = "Consulta de Fornecedores";
            this.menuConsultaFornecedores.Click += new System.EventHandler(this.menuConsultaFornecedores_Click);
            // 
            // menuProdutos
            // 
            this.menuProdutos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuCadastroProdutos,
            this.menuConsultaProdutos});
            this.menuProdutos.Image = global::ProjetoControleDeVendas.Properties.Resources.box_package_icon_232146;
            this.menuProdutos.Name = "menuProdutos";
            this.menuProdutos.Size = new System.Drawing.Size(83, 20);
            this.menuProdutos.Text = "Produtos";
            // 
            // menuCadastroProdutos
            // 
            this.menuCadastroProdutos.Name = "menuCadastroProdutos";
            this.menuCadastroProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuCadastroProdutos.Text = "Cadastro de Produtos";
            this.menuCadastroProdutos.Click += new System.EventHandler(this.menuCadastroProdutos_Click);
            // 
            // menuConsultaProdutos
            // 
            this.menuConsultaProdutos.Name = "menuConsultaProdutos";
            this.menuConsultaProdutos.Size = new System.Drawing.Size(188, 22);
            this.menuConsultaProdutos.Text = "Consulta de Produtos";
            this.menuConsultaProdutos.Click += new System.EventHandler(this.menuConsultaProdutos_Click);
            // 
            // menuVendas
            // 
            this.menuVendas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuNovaVenda,
            this.menuHistoricoVenda});
            this.menuVendas.Image = global::ProjetoControleDeVendas.Properties.Resources.income_money_bag_investment_finance_revenue_profit_dollar_icon_232660;
            this.menuVendas.Name = "menuVendas";
            this.menuVendas.Size = new System.Drawing.Size(72, 20);
            this.menuVendas.Text = "Vendas";
            // 
            // menuNovaVenda
            // 
            this.menuNovaVenda.Name = "menuNovaVenda";
            this.menuNovaVenda.Size = new System.Drawing.Size(180, 22);
            this.menuNovaVenda.Text = "Nova Venda";
            this.menuNovaVenda.Click += new System.EventHandler(this.menuNovaVenda_Click);
            // 
            // menuHistoricoVenda
            // 
            this.menuHistoricoVenda.Name = "menuHistoricoVenda";
            this.menuHistoricoVenda.Size = new System.Drawing.Size(180, 22);
            this.menuHistoricoVenda.Text = "Histórico de Vendas";
            this.menuHistoricoVenda.Click += new System.EventHandler(this.menuHistoricoVenda_Click);
            // 
            // menuConfiguracoes
            // 
            this.menuConfiguracoes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuTrocarUsuario,
            this.menuSairSistema});
            this.menuConfiguracoes.Image = global::ProjetoControleDeVendas.Properties.Resources.settings_cog_icon_232492;
            this.menuConfiguracoes.Name = "menuConfiguracoes";
            this.menuConfiguracoes.Size = new System.Drawing.Size(112, 20);
            this.menuConfiguracoes.Text = "Configurações";
            // 
            // menuTrocarUsuario
            // 
            this.menuTrocarUsuario.Name = "menuTrocarUsuario";
            this.menuTrocarUsuario.Size = new System.Drawing.Size(180, 22);
            this.menuTrocarUsuario.Text = "Trocar de Usuário";
            this.menuTrocarUsuario.Click += new System.EventHandler(this.menuTrocarUsuario_Click);
            // 
            // menuSairSistema
            // 
            this.menuSairSistema.Name = "menuSairSistema";
            this.menuSairSistema.Size = new System.Drawing.Size(180, 22);
            this.menuSairSistema.Text = "Sair do Sistema";
            this.menuSairSistema.Click += new System.EventHandler(this.menuSairSistema_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.txtData,
            this.txtHora,
            this.toolStripStatusLabel4,
            this.txtUsuario});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(65, 17);
            this.toolStripStatusLabel1.Text = "Data Atual:";
            // 
            // txtData
            // 
            this.txtData.Name = "txtData";
            this.txtData.Size = new System.Drawing.Size(65, 17);
            this.txtData.Text = "17/08/2003";
            // 
            // txtHora
            // 
            this.txtHora.Name = "txtHora";
            this.txtHora.Size = new System.Drawing.Size(118, 17);
            this.txtHora.Text = "toolStripStatusLabel3";
            // 
            // toolStripStatusLabel4
            // 
            this.toolStripStatusLabel4.Name = "toolStripStatusLabel4";
            this.toolStripStatusLabel4.Size = new System.Drawing.Size(50, 17);
            this.toolStripStatusLabel4.Text = "Usuário:";
            // 
            // txtUsuario
            // 
            this.txtUsuario.Name = "txtUsuario";
            this.txtUsuario.Size = new System.Drawing.Size(118, 17);
            this.txtUsuario.Text = "toolStripStatusLabel5";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ProjetoControleDeVendas.Properties.Resources.BIN_1194_oJerOnnP2O4RM8FWHcGZiZisQupJv3AmqU8gJ36tiWGPfu1oL3hq48xEVS1UgDaf;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.ControlBox = false;
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Menu Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroCliente;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaClientes;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFuncionarios;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaFornecedores;
        private System.Windows.Forms.ToolStripMenuItem menuCadastroProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuConsultaProdutos;
        private System.Windows.Forms.ToolStripMenuItem menuVendas;
        private System.Windows.Forms.ToolStripMenuItem menuNovaVenda;
        private System.Windows.Forms.ToolStripMenuItem menuConfiguracoes;
        private System.Windows.Forms.ToolStripMenuItem menuTrocarUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuSairSistema;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel4;
        public System.Windows.Forms.ToolStripMenuItem menuProdutos;
        public System.Windows.Forms.ToolStripMenuItem menuHistoricoVenda;
        public System.Windows.Forms.ToolStripStatusLabel txtData;
        public System.Windows.Forms.ToolStripStatusLabel txtHora;
        public System.Windows.Forms.ToolStripStatusLabel txtUsuario;
        private System.Windows.Forms.Timer timer1;
        public System.Windows.Forms.ToolStripMenuItem menuFuncionarios;
        public System.Windows.Forms.ToolStripMenuItem menuFornecedores;
    }
}
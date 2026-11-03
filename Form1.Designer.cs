namespace ProyectoDeskstop
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Panel panelCabecera;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label lblLogo;
        private System.Windows.Forms.Label lblTituloPagina;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnNotificaciones;
        private System.Windows.Forms.Panel panelSeparador;
        private System.Windows.Forms.Label picAvatar;
        private System.Windows.Forms.Label lblUsuario;
        private System.Windows.Forms.Label lblRol;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenido;
        private System.Windows.Forms.Button btnInicio;
        private System.Windows.Forms.Button btnProyectos;
        private System.Windows.Forms.Button btnTareas;
        private System.Windows.Forms.Button btnResumen;
        private System.Windows.Forms.Button btnAjustes;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.panelContenido = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.panelCabecera = new System.Windows.Forms.Panel();
            this.panelLogo = new System.Windows.Forms.Panel();
            this.lblLogo = Ui.Lbl("Planea", 16F, true, 20, 22, System.Drawing.Color.White);
            this.lblTituloPagina = Ui.Lbl("Inicio", 13F, true, 264, 24, Ui.Texto);
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnNotificaciones = Ui.Boton("🔔", 940, 20, 36, 30, false);
            this.panelSeparador = new System.Windows.Forms.Panel();
            this.picAvatar = Ui.Caja("AS", 1008, 18, 36);
            this.lblUsuario = Ui.Lbl("Alex Serra", 9.5F, true, 1054, 16, Ui.Texto);
            this.lblRol = Ui.Lbl("Usuario", 8F, false, 1054, 36, Ui.Gris);

            this.btnInicio = Ui.MenuBoton("Inicio", 24);
            this.btnProyectos = Ui.MenuBoton("Proyectos", 74);
            this.btnTareas = Ui.MenuBoton("Tareas", 124);
            this.btnResumen = Ui.MenuBoton("Resumen", 174);
            this.btnAjustes = Ui.MenuBoton("Ajustes", 224);
            this.SuspendLayout();

            // panelContenido (ocupa el resto de la ventana)
            this.panelContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenido.BackColor = Ui.Fondo;
            this.panelContenido.Name = "panelContenido";

            // panelMenu (lateral izquierdo, bajo la cabecera)
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenu.Width = 240;
            this.panelMenu.BackColor = Ui.Marino;
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Controls.Add(this.btnInicio);
            this.panelMenu.Controls.Add(this.btnProyectos);
            this.panelMenu.Controls.Add(this.btnTareas);
            this.panelMenu.Controls.Add(this.btnResumen);
            this.panelMenu.Controls.Add(this.btnAjustes);

            // panelLogo (bloque azul de la cabecera, alineado con el menú)
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelLogo.Width = 240;
            this.panelLogo.BackColor = Ui.Marino;
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Controls.Add(this.lblLogo);

            // txtBuscar
            this.txtBuscar.Location = new System.Drawing.Point(640, 20);
            this.txtBuscar.Size = new System.Drawing.Size(260, 30);
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscar.ForeColor = Ui.Gris;
            this.txtBuscar.Text = "Buscar en Planea...";
            this.txtBuscar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.txtBuscar.Name = "txtBuscar";

            // btnNotificaciones
            this.btnNotificaciones.Font = new System.Drawing.Font("Segoe UI Emoji", 10F);
            this.btnNotificaciones.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.btnNotificaciones.Name = "btnNotificaciones";

            // separador vertical
            this.panelSeparador.Location = new System.Drawing.Point(992, 18);
            this.panelSeparador.Size = new System.Drawing.Size(1, 36);
            this.panelSeparador.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.panelSeparador.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.panelSeparador.Name = "panelSeparador";

            this.picAvatar.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.picAvatar.Name = "picAvatar";
            this.lblUsuario.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblUsuario.Name = "lblUsuario";
            this.lblRol.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            this.lblRol.Name = "lblRol";

            // panelCabecera (franja superior completa)
            this.panelCabecera.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelCabecera.Height = 72;
            this.panelCabecera.BackColor = System.Drawing.Color.White;
            this.panelCabecera.Name = "panelCabecera";
            this.panelCabecera.Controls.Add(this.panelLogo);
            this.panelCabecera.Controls.Add(this.lblTituloPagina);
            this.panelCabecera.Controls.Add(this.txtBuscar);
            this.panelCabecera.Controls.Add(this.btnNotificaciones);
            this.panelCabecera.Controls.Add(this.panelSeparador);
            this.panelCabecera.Controls.Add(this.picAvatar);
            this.panelCabecera.Controls.Add(this.lblUsuario);
            this.panelCabecera.Controls.Add(this.lblRol);

            this.btnInicio.Click += new System.EventHandler(this.btnInicio_Click);
            this.btnProyectos.Click += new System.EventHandler(this.btnProyectos_Click);
            this.btnTareas.Click += new System.EventHandler(this.btnTareas_Click);
            this.btnResumen.Click += new System.EventHandler(this.btnResumen_Click);
            this.btnAjustes.Click += new System.EventHandler(this.btnAjustes_Click);

            // Form1
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1200, 780);
            this.MinimumSize = new System.Drawing.Size(1000, 650);
            this.BackColor = Ui.Fondo;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Planea - ProyectoDeskstop";
            this.Controls.Add(this.panelContenido);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelCabecera);
            this.Name = "Form1";
            this.ResumeLayout(false);
        }
    }
}

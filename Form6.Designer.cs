namespace ProyectoDeskstop
{
    partial class Form6
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblAjustesEtiqueta;
        private System.Windows.Forms.Label lblAjustesTitulo;
        private System.Windows.Forms.Label lblAjustesSub;
        private System.Windows.Forms.Button btnSecPerfil;
        private System.Windows.Forms.Button btnSecIdioma;
        private System.Windows.Forms.Button btnSecNotificaciones;
        private System.Windows.Forms.Button btnSecPreferencias;
        private System.Windows.Forms.Panel panelSeccion;
        private System.Windows.Forms.Panel panelPerfil;
        private System.Windows.Forms.Label lblPerfilTitulo;
        private System.Windows.Forms.Label lblPerfilSub;
        private System.Windows.Forms.Label lblAvatarPerfil;
        private System.Windows.Forms.Label lblPerfilNombre;
        private System.Windows.Forms.Label lblPerfilEmail;
        private System.Windows.Forms.Label lblPerfilRol;
        private System.Windows.Forms.Label lblNombreTitulo;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Button btnGuardarNombre;
        private System.Windows.Forms.Label lblGuardado;
        private System.Windows.Forms.Label lblRolTitulo;
        private System.Windows.Forms.RadioButton rbUsuario;
        private System.Windows.Forms.RadioButton rbAdministrador;
        private System.Windows.Forms.Button btnCerrarSesion;
        private System.Windows.Forms.Panel panelOtraSeccion;
        private System.Windows.Forms.Label lblOtraSeccion;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            this.lblAjustesEtiqueta = new System.Windows.Forms.Label();
            this.lblAjustesTitulo = new System.Windows.Forms.Label();
            this.lblAjustesSub = new System.Windows.Forms.Label();
            this.btnSecPerfil = new System.Windows.Forms.Button();
            this.btnSecIdioma = new System.Windows.Forms.Button();
            this.btnSecNotificaciones = new System.Windows.Forms.Button();
            this.btnSecPreferencias = new System.Windows.Forms.Button();
            this.panelSeccion = new System.Windows.Forms.Panel();
            this.panelPerfil = new System.Windows.Forms.Panel();
            this.lblPerfilTitulo = new System.Windows.Forms.Label();
            this.lblPerfilSub = new System.Windows.Forms.Label();
            this.lblAvatarPerfil = new System.Windows.Forms.Label();
            this.lblPerfilNombre = new System.Windows.Forms.Label();
            this.lblPerfilEmail = new System.Windows.Forms.Label();
            this.lblPerfilRol = new System.Windows.Forms.Label();
            this.lblNombreTitulo = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.btnGuardarNombre = new System.Windows.Forms.Button();
            this.lblGuardado = new System.Windows.Forms.Label();
            this.lblRolTitulo = new System.Windows.Forms.Label();
            this.rbUsuario = new System.Windows.Forms.RadioButton();
            this.rbAdministrador = new System.Windows.Forms.RadioButton();
            this.btnCerrarSesion = new System.Windows.Forms.Button();
            this.panelOtraSeccion = new System.Windows.Forms.Panel();
            this.lblOtraSeccion = new System.Windows.Forms.Label();
            this.panelSeccion.SuspendLayout();
            this.panelPerfil.SuspendLayout();
            this.panelOtraSeccion.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblAjustesEtiqueta
            // 
            this.lblAjustesEtiqueta.AutoSize = true;
            this.lblAjustesEtiqueta.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblAjustesEtiqueta.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblAjustesEtiqueta.Location = new System.Drawing.Point(30, 20);
            this.lblAjustesEtiqueta.Name = "lblAjustesEtiqueta";
            this.lblAjustesEtiqueta.Text = "TU ESPACIO";
            // 
            // lblAjustesTitulo
            // 
            this.lblAjustesTitulo.AutoSize = true;
            this.lblAjustesTitulo.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblAjustesTitulo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblAjustesTitulo.Location = new System.Drawing.Point(30, 40);
            this.lblAjustesTitulo.Name = "lblAjustesTitulo";
            this.lblAjustesTitulo.Text = "Ajustes";
            // 
            // lblAjustesSub
            // 
            this.lblAjustesSub.AutoSize = true;
            this.lblAjustesSub.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblAjustesSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblAjustesSub.Location = new System.Drawing.Point(30, 85);
            this.lblAjustesSub.Name = "lblAjustesSub";
            this.lblAjustesSub.Text = "Configura tu perfil y las preferencias de Planea.";
            // 
            // btnSecPerfil
            // 
            this.btnSecPerfil.BackColor = System.Drawing.Color.FromArgb(219, 234, 254);
            this.btnSecPerfil.FlatAppearance.BorderSize = 0;
            this.btnSecPerfil.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecPerfil.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnSecPerfil.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnSecPerfil.Location = new System.Drawing.Point(30, 130);
            this.btnSecPerfil.Name = "btnSecPerfil";
            this.btnSecPerfil.Size = new System.Drawing.Size(200, 36);
            this.btnSecPerfil.Tag = "Perfil";
            this.btnSecPerfil.Text = "Perfil";
            this.btnSecPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecPerfil.UseVisualStyleBackColor = false;
            this.btnSecPerfil.Click += new System.EventHandler(this.btnSeccion_Click);
            // 
            // btnSecIdioma
            // 
            this.btnSecIdioma.BackColor = System.Drawing.Color.White;
            this.btnSecIdioma.FlatAppearance.BorderSize = 0;
            this.btnSecIdioma.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecIdioma.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSecIdioma.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.btnSecIdioma.Location = new System.Drawing.Point(30, 175);
            this.btnSecIdioma.Name = "btnSecIdioma";
            this.btnSecIdioma.Size = new System.Drawing.Size(200, 36);
            this.btnSecIdioma.Tag = "Idioma";
            this.btnSecIdioma.Text = "Idioma";
            this.btnSecIdioma.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecIdioma.UseVisualStyleBackColor = false;
            this.btnSecIdioma.Click += new System.EventHandler(this.btnSeccion_Click);
            // 
            // btnSecNotificaciones
            // 
            this.btnSecNotificaciones.BackColor = System.Drawing.Color.White;
            this.btnSecNotificaciones.FlatAppearance.BorderSize = 0;
            this.btnSecNotificaciones.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecNotificaciones.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSecNotificaciones.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.btnSecNotificaciones.Location = new System.Drawing.Point(30, 220);
            this.btnSecNotificaciones.Name = "btnSecNotificaciones";
            this.btnSecNotificaciones.Size = new System.Drawing.Size(200, 36);
            this.btnSecNotificaciones.Tag = "Notificaciones";
            this.btnSecNotificaciones.Text = "Notificaciones";
            this.btnSecNotificaciones.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecNotificaciones.UseVisualStyleBackColor = false;
            this.btnSecNotificaciones.Click += new System.EventHandler(this.btnSeccion_Click);
            // 
            // btnSecPreferencias
            // 
            this.btnSecPreferencias.BackColor = System.Drawing.Color.White;
            this.btnSecPreferencias.FlatAppearance.BorderSize = 0;
            this.btnSecPreferencias.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSecPreferencias.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnSecPreferencias.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.btnSecPreferencias.Location = new System.Drawing.Point(30, 265);
            this.btnSecPreferencias.Name = "btnSecPreferencias";
            this.btnSecPreferencias.Size = new System.Drawing.Size(200, 36);
            this.btnSecPreferencias.Tag = "Preferencias";
            this.btnSecPreferencias.Text = "Preferencias";
            this.btnSecPreferencias.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSecPreferencias.UseVisualStyleBackColor = false;
            this.btnSecPreferencias.Click += new System.EventHandler(this.btnSeccion_Click);
            // 
            // panelSeccion
            // 
            this.panelSeccion.BackColor = System.Drawing.Color.White;
            this.panelSeccion.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSeccion.Controls.Add(this.panelPerfil);
            this.panelSeccion.Controls.Add(this.panelOtraSeccion);
            this.panelSeccion.Location = new System.Drawing.Point(250, 130);
            this.panelSeccion.Name = "panelSeccion";
            this.panelSeccion.Size = new System.Drawing.Size(710, 400);
            // 
            // panelPerfil
            // 
            this.panelPerfil.BackColor = System.Drawing.Color.White;
            this.panelPerfil.Controls.Add(this.lblPerfilTitulo);
            this.panelPerfil.Controls.Add(this.lblPerfilSub);
            this.panelPerfil.Controls.Add(this.lblAvatarPerfil);
            this.panelPerfil.Controls.Add(this.lblPerfilNombre);
            this.panelPerfil.Controls.Add(this.lblPerfilEmail);
            this.panelPerfil.Controls.Add(this.lblPerfilRol);
            this.panelPerfil.Controls.Add(this.lblNombreTitulo);
            this.panelPerfil.Controls.Add(this.txtNombre);
            this.panelPerfil.Controls.Add(this.btnGuardarNombre);
            this.panelPerfil.Controls.Add(this.lblGuardado);
            this.panelPerfil.Controls.Add(this.lblRolTitulo);
            this.panelPerfil.Controls.Add(this.rbUsuario);
            this.panelPerfil.Controls.Add(this.rbAdministrador);
            this.panelPerfil.Controls.Add(this.btnCerrarSesion);
            this.panelPerfil.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPerfil.Location = new System.Drawing.Point(0, 0);
            this.panelPerfil.Name = "panelPerfil";
            this.panelPerfil.Size = new System.Drawing.Size(708, 398);
            // 
            // lblPerfilTitulo
            // 
            this.lblPerfilTitulo.AutoSize = true;
            this.lblPerfilTitulo.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblPerfilTitulo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblPerfilTitulo.Location = new System.Drawing.Point(20, 18);
            this.lblPerfilTitulo.Name = "lblPerfilTitulo";
            this.lblPerfilTitulo.Text = "Perfil";
            // 
            // lblPerfilSub
            // 
            this.lblPerfilSub.AutoSize = true;
            this.lblPerfilSub.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPerfilSub.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPerfilSub.Location = new System.Drawing.Point(20, 42);
            this.lblPerfilSub.Name = "lblPerfilSub";
            this.lblPerfilSub.Text = "Información visible para el resto del equipo";
            // 
            // lblAvatarPerfil
            // 
            this.lblAvatarPerfil.BackColor = System.Drawing.Color.FromArgb(226, 232, 240);
            this.lblAvatarPerfil.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lblAvatarPerfil.ForeColor = System.Drawing.Color.FromArgb(15, 39, 71);
            this.lblAvatarPerfil.Location = new System.Drawing.Point(20, 80);
            this.lblAvatarPerfil.Name = "lblAvatarPerfil";
            this.lblAvatarPerfil.Size = new System.Drawing.Size(56, 56);
            this.lblAvatarPerfil.Text = "AS";
            this.lblAvatarPerfil.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPerfilNombre
            // 
            this.lblPerfilNombre.AutoSize = true;
            this.lblPerfilNombre.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblPerfilNombre.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblPerfilNombre.Location = new System.Drawing.Point(90, 84);
            this.lblPerfilNombre.Name = "lblPerfilNombre";
            this.lblPerfilNombre.Text = "Alex Serra";
            // 
            // lblPerfilEmail
            // 
            this.lblPerfilEmail.AutoSize = true;
            this.lblPerfilEmail.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPerfilEmail.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblPerfilEmail.Location = new System.Drawing.Point(90, 108);
            this.lblPerfilEmail.Name = "lblPerfilEmail";
            this.lblPerfilEmail.Text = "alex.serra@planea.es";
            // 
            // lblPerfilRol
            // 
            this.lblPerfilRol.AutoSize = true;
            this.lblPerfilRol.BackColor = System.Drawing.Color.FromArgb(241, 245, 249);
            this.lblPerfilRol.Font = new System.Drawing.Font("Segoe UI", 8.5F);
            this.lblPerfilRol.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblPerfilRol.Location = new System.Drawing.Point(90, 130);
            this.lblPerfilRol.Name = "lblPerfilRol";
            this.lblPerfilRol.Padding = new System.Windows.Forms.Padding(6, 2, 6, 2);
            this.lblPerfilRol.Text = "Usuario";
            // 
            // lblNombreTitulo
            // 
            this.lblNombreTitulo.AutoSize = true;
            this.lblNombreTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreTitulo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblNombreTitulo.Location = new System.Drawing.Point(20, 185);
            this.lblNombreTitulo.Name = "lblNombreTitulo";
            this.lblNombreTitulo.Text = "Nombre a mostrar:";
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtNombre.Location = new System.Drawing.Point(20, 208);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(300, 25);
            this.txtNombre.Text = "Alex Serra";
            // 
            // btnGuardarNombre
            // 
            this.btnGuardarNombre.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnGuardarNombre.FlatAppearance.BorderSize = 0;
            this.btnGuardarNombre.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardarNombre.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnGuardarNombre.ForeColor = System.Drawing.Color.White;
            this.btnGuardarNombre.Location = new System.Drawing.Point(335, 206);
            this.btnGuardarNombre.Name = "btnGuardarNombre";
            this.btnGuardarNombre.Size = new System.Drawing.Size(110, 27);
            this.btnGuardarNombre.Text = "Guardar";
            this.btnGuardarNombre.UseVisualStyleBackColor = false;
            this.btnGuardarNombre.Click += new System.EventHandler(this.btnGuardarNombre_Click);
            // 
            // lblGuardado
            // 
            this.lblGuardado.AutoSize = true;
            this.lblGuardado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblGuardado.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblGuardado.Location = new System.Drawing.Point(20, 245);
            this.lblGuardado.Name = "lblGuardado";
            this.lblGuardado.Text = "";
            // 
            // lblRolTitulo
            // 
            this.lblRolTitulo.AutoSize = true;
            this.lblRolTitulo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRolTitulo.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblRolTitulo.Location = new System.Drawing.Point(20, 285);
            this.lblRolTitulo.Name = "lblRolTitulo";
            this.lblRolTitulo.Text = "Vista del rol (para comprobar las acciones disponibles):";
            // 
            // rbUsuario
            // 
            this.rbUsuario.AutoSize = true;
            this.rbUsuario.Location = new System.Drawing.Point(20, 310);
            this.rbUsuario.Name = "rbUsuario";
            this.rbUsuario.Text = "Usuario";
            this.rbUsuario.UseVisualStyleBackColor = true;
            this.rbUsuario.CheckedChanged += new System.EventHandler(this.rbUsuario_CheckedChanged);
            // 
            // rbAdministrador
            // 
            this.rbAdministrador.AutoSize = true;
            this.rbAdministrador.Location = new System.Drawing.Point(120, 310);
            this.rbAdministrador.Name = "rbAdministrador";
            this.rbAdministrador.Text = "Administrador";
            this.rbAdministrador.UseVisualStyleBackColor = true;
            this.rbAdministrador.CheckedChanged += new System.EventHandler(this.rbAdministrador_CheckedChanged);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.BackColor = System.Drawing.Color.White;
            this.btnCerrarSesion.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(203, 213, 225);
            this.btnCerrarSesion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCerrarSesion.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCerrarSesion.ForeColor = System.Drawing.Color.FromArgb(220, 38, 38);
            this.btnCerrarSesion.Location = new System.Drawing.Point(20, 350);
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(150, 30);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.UseVisualStyleBackColor = false;
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // panelOtraSeccion
            // 
            this.panelOtraSeccion.BackColor = System.Drawing.Color.White;
            this.panelOtraSeccion.Controls.Add(this.lblOtraSeccion);
            this.panelOtraSeccion.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelOtraSeccion.Location = new System.Drawing.Point(0, 0);
            this.panelOtraSeccion.Name = "panelOtraSeccion";
            this.panelOtraSeccion.Size = new System.Drawing.Size(708, 398);
            this.panelOtraSeccion.Visible = false;
            // 
            // lblOtraSeccion
            // 
            this.lblOtraSeccion.AutoSize = true;
            this.lblOtraSeccion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblOtraSeccion.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblOtraSeccion.Location = new System.Drawing.Point(20, 20);
            this.lblOtraSeccion.Name = "lblOtraSeccion";
            this.lblOtraSeccion.Text = "Esta sección todavía está en desarrollo.";
            // 
            // Form6
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(960, 708);
            this.Controls.Add(this.lblAjustesEtiqueta);
            this.Controls.Add(this.lblAjustesTitulo);
            this.Controls.Add(this.lblAjustesSub);
            this.Controls.Add(this.btnSecPerfil);
            this.Controls.Add(this.btnSecIdioma);
            this.Controls.Add(this.btnSecNotificaciones);
            this.Controls.Add(this.btnSecPreferencias);
            this.Controls.Add(this.panelSeccion);
            this.Name = "Form6";
            this.Text = "Ajustes";
            this.panelSeccion.ResumeLayout(false);
            this.panelPerfil.ResumeLayout(false);
            this.panelPerfil.PerformLayout();
            this.panelOtraSeccion.ResumeLayout(false);
            this.panelOtraSeccion.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

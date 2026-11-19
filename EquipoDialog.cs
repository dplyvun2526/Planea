using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    // Gestión del equipo de un proyecto: ver miembros, añadir usuarios con un rol y quitarlos.
    public class EquipoDialog : Form
    {
        private readonly Proyecto proyecto;
        private readonly ListBox lista = new ListBox();
        private readonly ComboBox cmbUsuario = new ComboBox();
        private readonly ComboBox cmbRol = new ComboBox();
        private List<ApiProyectoUsuarioRol> miembros = new List<ApiProyectoUsuarioRol>();
        private List<ApiUsuario> usuarios = new List<ApiUsuario>();
        private List<ApiRol> roles = new List<ApiRol>();

        public EquipoDialog(Proyecto proyecto)
        {
            this.proyecto = proyecto;
            Text = T("Equipo") + " - " + proyecto.Nombre;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 9.5F);
            ClientSize = new Size(380, 400);

            Controls.Add(new Label { Text = T("Miembros del proyecto"), Location = new Point(15, 12), AutoSize = true });
            lista.Location = new Point(15, 34);
            lista.Size = new Size(350, 140);
            Controls.Add(lista);

            Button quitar = new Button { Text = T("Quitar seleccionado"), Location = new Point(15, 180), Size = new Size(350, 28) };
            quitar.Click += Quitar_Click;
            Controls.Add(quitar);

            Controls.Add(new Label { Text = T("Usuario"), Location = new Point(15, 222), AutoSize = true });
            cmbUsuario.Location = new Point(15, 242);
            cmbUsuario.Width = 350;
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cmbUsuario);

            Controls.Add(new Label { Text = T("Rol"), Location = new Point(15, 276), AutoSize = true });
            cmbRol.Location = new Point(15, 296);
            cmbRol.Width = 350;
            cmbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            Controls.Add(cmbRol);

            Button anadir = new Button { Text = T("Añadir al equipo"), Location = new Point(15, 335), Size = new Size(170, 30) };
            anadir.Click += Anadir_Click;
            Controls.Add(anadir);
            Button cerrar = new Button { Text = T("Cerrar"), Location = new Point(195, 335), Size = new Size(170, 30), DialogResult = DialogResult.Cancel };
            Controls.Add(cerrar);
            CancelButton = cerrar;

            Recargar();
        }

        private void Recargar()
        {
            try
            {
                usuarios = Api.Lista<ApiUsuario>("api/Users");
                roles = Api.Lista<ApiRol>("api/Roles");
                miembros = Api.Lista<ApiProyectoUsuarioRol>("api/ProjectUserRoles").Where(m => m.IdProject == proyecto.Id).ToList();
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            lista.Items.Clear();
            foreach (ApiProyectoUsuarioRol m in miembros)
            {
                ApiUsuario u = usuarios.FirstOrDefault(x => x.IdUser == m.IdUsers);
                ApiRol r = roles.FirstOrDefault(x => x.IdRoles == m.IdRoles);
                lista.Items.Add((u != null ? u.NameUser + " " + u.LastnameUser : "?") + "  -  " + (r != null ? T(r.NameRoles) : "?"));
            }

            cmbUsuario.Items.Clear();
            foreach (ApiUsuario u in usuarios) cmbUsuario.Items.Add(u.NameUser + " " + u.LastnameUser + " (" + u.MailUser + ")");
            if (cmbUsuario.Items.Count > 0) cmbUsuario.SelectedIndex = 0;

            cmbRol.Items.Clear();
            foreach (ApiRol r in roles) cmbRol.Items.Add(T(r.NameRoles));
            if (cmbRol.Items.Count > 0) cmbRol.SelectedIndex = 0;
        }

        private void Anadir_Click(object sender, EventArgs e)
        {
            if (cmbUsuario.SelectedIndex < 0 || cmbRol.SelectedIndex < 0) return;
            ApiUsuario u = usuarios[cmbUsuario.SelectedIndex];
            ApiRol r = roles[cmbRol.SelectedIndex];
            if (miembros.Any(m => m.IdUsers == u.IdUser))
            {
                MessageBox.Show(T("Ese usuario ya está en el equipo."), T("Aviso"), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            try
            {
                Api.Crear("api/ProjectUserRoles", new ApiProyectoUsuarioRol { IdRoles = r.IdRoles, IdUsers = u.IdUser, IdProject = proyecto.Id });
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Recargar();
        }

        private void Quitar_Click(object sender, EventArgs e)
        {
            if (lista.SelectedIndex < 0) return;
            ApiProyectoUsuarioRol m = miembros[lista.SelectedIndex];
            try
            {
                Api.Borrar("api/ProjectUserRoles/" + m.IdRoles + "/" + m.IdUsers + "/" + m.IdProject);
            }
            catch (ApiException ex)
            {
                MessageBox.Show(ex.Message, "Planea", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            Recargar();
        }
    }
}

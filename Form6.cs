using System;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form6 : Form
    {
        private Panel[] paneles;
        private Button[] botones;
        private string[] nombres;
        private bool cargando = true;

        // Sección abierta: al cambiar de idioma la página se vuelve a crear y se sigue en la misma.
        private static string seccionAbierta = "Perfil";

        public Form6()
        {
            InitializeComponent();

            // El rol lo asigna la base de datos: aquí solo se muestra.
            rbUsuario.Enabled = false;
            rbAdministrador.Enabled = false;

            paneles = new[] { panelPerfil, panelIdioma };
            botones = new[] { btnSecPerfil, btnSecIdioma };
            nombres = new[] { "Perfil", "Idioma" };

            Traducir();
            CargarPerfil();
            CargarIdioma();
            PrepararSelectorIdioma();
            cargando = false;

            btnSeccion_Click(botones[Array.IndexOf(nombres, seccionAbierta)], EventArgs.Empty);
        }

        private void Traducir()
        {
            lblAjustesEtiqueta.Text = T("TU ESPACIO");
            lblAjustesTitulo.Text = T("Ajustes");
            lblAjustesSub.Text = T("Configura tu perfil y las opciones de Planea.");
            btnSecPerfil.Text = T("Perfil");
            btnSecIdioma.Text = T("Idioma");
            btnCerrarSesion.Text = T("Cerrar sesión");

            // Perfil
            lblPerfilTitulo.Text = T("Perfil");
            lblPerfilSub.Text = T("Información visible para el resto del equipo");
            lblNombreTitulo.Text = T("Nombre a mostrar:");
            btnGuardarNombre.Text = T("Guardar");
            lblRolTitulo.Text = T("Tu rol en Planea (lo asigna un administrador):");
            rbUsuario.Text = T("Usuario");
            rbAdministrador.Text = T("Administrador");

            // Idioma
            lblIdiomaTitulo.Text = T("Idioma");
            lblIdiomaSub.Text = T("Planea usa por defecto el idioma de tu dispositivo");
            lblIdiomaCasDetalle.Text = T("Español");
            lblIdiomaInfoTexto.Text = T("El idioma de navegación se ha actualizado.");
        }

        // ---------- Perfil ----------
        private void CargarPerfil()
        {
            txtNombre.Text = Datos.Nombre;
            lblPerfilNombre.Text = Datos.Nombre;
            lblPerfilEmail.Text = Datos.Email;
            lblAvatarPerfil.Text = Diseno.Iniciales(Datos.Nombre);
            lblPerfilRol.Text = T(Datos.Rol);
            rbUsuario.Checked = Datos.Rol == "Usuario";
            rbAdministrador.Checked = Datos.Rol == "Administrador";
        }

        private void btnGuardarNombre_Click(object sender, EventArgs e)
        {
            string nombre = txtNombre.Text.Trim();
            if (nombre == "")
            {
                lblGuardado.ForeColor = Diseno.Rojo;
                lblGuardado.Text = T("El nombre no puede estar vacío.");
                return;
            }

            Datos.Nombre = nombre;
            lblPerfilNombre.Text = nombre;
            lblAvatarPerfil.Text = Diseno.Iniciales(nombre);
            lblGuardado.ForeColor = Diseno.Azul;
            lblGuardado.Text = T("Cambios guardados. El menú se actualiza al cambiar de página.");
        }

        private void rbUsuario_CheckedChanged(object sender, EventArgs e)
        {
            if (rbUsuario.Checked && !cargando)
            {
                Datos.Rol = "Usuario";
                lblPerfilRol.Text = T(Datos.Rol);
            }
        }

        private void rbAdministrador_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAdministrador.Checked && !cargando)
            {
                Datos.Rol = "Administrador";
                lblPerfilRol.Text = T(Datos.Rol);
            }
        }

        // ---------- Idioma ----------
        private void CargarIdioma()
        {
            rbIdiomaCatala.Checked = Datos.Idioma == "Català";
            rbIdiomaCastellano.Checked = Datos.Idioma == "Castellano";
            rbIdiomaEnglish.Checked = Datos.Idioma == "English";
            ActualizarIdioma();
        }

        // Los botones de opción quedaban tapados por sus recuadros: se traen al frente
        // y además se puede hacer clic en cualquier parte del recuadro.
        private void PrepararSelectorIdioma()
        {
            Panel[] recuadros = { panelIdiomaCat, panelIdiomaCas, panelIdiomaEng };
            RadioButton[] opciones = { rbIdiomaCatala, rbIdiomaCastellano, rbIdiomaEnglish };
            for (int i = 0; i < recuadros.Length; i++)
            {
                RadioButton opcion = opciones[i];
                EventHandler elegir = (s, e) => opcion.Checked = true;
                recuadros[i].Cursor = Cursors.Hand;
                recuadros[i].Click += elegir;
                foreach (Control c in recuadros[i].Controls) c.Click += elegir;
                opcion.BringToFront();
                opcion.BackColor = recuadros[i].BackColor;
            }
        }

        private void rbIdioma_CheckedChanged(object sender, EventArgs e)
        {
            RadioButton elegido = (RadioButton)sender;
            string nuevo = (string)elegido.Tag;
            if (!elegido.Checked || nuevo == Datos.Idioma) return;

            // Cambia el idioma de toda la aplicación.
            Datos.CambiarIdioma(nuevo);
        }

        private void ActualizarIdioma()
        {
            Color seleccionado = Color.FromArgb(239, 246, 255);
            panelIdiomaCat.BackColor = Datos.Idioma == "Català" ? seleccionado : Color.White;
            panelIdiomaCas.BackColor = Datos.Idioma == "Castellano" ? seleccionado : Color.White;
            panelIdiomaEng.BackColor = Datos.Idioma == "English" ? seleccionado : Color.White;
            lblIdiomaInfoTitulo.Text = Datos.Idioma;
        }

        // ---------- Menú de secciones ----------
        private void btnSeccion_Click(object sender, EventArgs e)
        {
            Button pulsado = (Button)sender;
            string seccion = (string)pulsado.Tag;

            for (int i = 0; i < botones.Length; i++)
            {
                bool activa = botones[i] == pulsado;
                botones[i].BackColor = activa ? Color.FromArgb(219, 234, 254) : Color.White;
                botones[i].ForeColor = activa ? Color.FromArgb(37, 99, 235) : Color.FromArgb(17, 24, 39);
                botones[i].Font = new Font("Segoe UI", 9.5F, activa ? FontStyle.Bold : FontStyle.Regular);
                paneles[i].Visible = nombres[i] == seccion;
            }
            seccionAbierta = seccion;
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación. Volver al inicio de sesión se hará cuando exista la API.
            Application.Exit();
        }
    }
}

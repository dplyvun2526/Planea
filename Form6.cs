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

        public Form6()
        {
            InitializeComponent();

            paneles = new[] { panelPerfil, panelIdioma, panelNotificaciones };
            botones = new[] { btnSecPerfil, btnSecIdioma, btnSecNotificaciones };
            nombres = new[] { "Perfil", "Idioma", "Notificaciones" };

            Traducir();
            CargarPerfil();
            CargarIdioma();
            CargarNotificaciones();
            cargando = false;
        }

        private void Traducir()
        {
            lblAjustesEtiqueta.Text = T("TU ESPACIO");
            lblAjustesTitulo.Text = T("Ajustes");
            lblAjustesSub.Text = T("Configura tu perfil y las opciones de Planea.");
            btnSecPerfil.Text = T("Perfil");
            btnSecIdioma.Text = T("Idioma");
            btnSecNotificaciones.Text = T("Notificaciones");
            btnCerrarSesion.Text = T("Cerrar sesión");

            // Perfil
            lblPerfilTitulo.Text = T("Perfil");
            lblPerfilSub.Text = T("Información visible para el resto del equipo");
            lblNombreTitulo.Text = T("Nombre a mostrar:");
            btnGuardarNombre.Text = T("Guardar");
            lblRolTitulo.Text = T("Vista del rol (para comprobar las acciones disponibles):");
            rbUsuario.Text = T("Usuario");
            rbAdministrador.Text = T("Administrador");

            // Idioma
            lblIdiomaTitulo.Text = T("Idioma");
            lblIdiomaSub.Text = T("Planea usa por defecto el idioma de tu dispositivo");
            lblIdiomaCasDetalle.Text = T("Español");
            lblIdiomaInfoTexto.Text = T("El idioma de navegación se ha actualizado.");

            // Notificaciones
            lblNotifTitulo.Text = T("Notificaciones");
            lblNotifSub.Text = T("Elige qué actualizaciones quieres recibir");
            lblNotif1Titulo.Text = T("Tareas asignadas");
            lblNotif1Desc.Text = T("Cuando alguien te asigne una nueva tarea");
            lblNotif2Titulo.Text = T("Fechas límite");
            lblNotif2Desc.Text = T("Recordatorios de tareas próximas a vencer");
            lblNotif3Titulo.Text = T("Actualizaciones de proyecto");
            lblNotif3Desc.Text = T("Cambios importantes en tus proyectos");
        }

        // ---------- Perfil ----------
        private void CargarPerfil()
        {
            txtNombre.Text = Datos.Nombre;
            lblPerfilNombre.Text = Datos.Nombre;
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

        // ---------- Notificaciones ----------
        private void CargarNotificaciones()
        {
            chkNotif1.Checked = Datos.NotifTareas;
            chkNotif2.Checked = Datos.NotifFechas;
            chkNotif3.Checked = Datos.NotifProyectos;
            ActualizarTextoCasillas(chkNotif1);
            ActualizarTextoCasillas(chkNotif2);
            ActualizarTextoCasillas(chkNotif3);
        }

        private void chkNotif_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox casilla = (CheckBox)sender;
            if (casilla == chkNotif1) Datos.NotifTareas = casilla.Checked;
            if (casilla == chkNotif2) Datos.NotifFechas = casilla.Checked;
            if (casilla == chkNotif3) Datos.NotifProyectos = casilla.Checked;
            ActualizarTextoCasillas(casilla);
        }

        private static void ActualizarTextoCasillas(CheckBox casilla)
        {
            casilla.Text = casilla.Checked ? T("Activo") : T("Inactivo");
            casilla.BackColor = casilla.Checked ? Color.FromArgb(37, 99, 235) : Color.FromArgb(226, 232, 240);
            casilla.ForeColor = casilla.Checked ? Color.White : Color.FromArgb(17, 24, 39);
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
        }

        private void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Cierra la aplicación. Volver al inicio de sesión se hará cuando exista la API.
            Application.Exit();
        }
    }
}

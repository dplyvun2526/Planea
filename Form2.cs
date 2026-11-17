using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    public partial class Form2 : Form
    {
        private int[] valoresEstado = new int[3];
        private readonly Color[] coloresEstado = { Color.FromArgb(15, 39, 71), Color.FromArgb(37, 99, 235), Color.FromArgb(147, 197, 253) };

        public Form2()
        {
            InitializeComponent();
            Traducir();
            CargarDatos();
        }

        private void Traducir()
        {
            lblSubtitulo.Text = T("Aquí tienes una visión general del trabajo de tu equipo.");
            lblHorasTitulo.Text = T("Horas este mes");
            lblStat1Titulo.Text = T("Proyectos activos");
            lblStat2Titulo.Text = T("Tareas pendientes");
            lblStat3Titulo.Text = T("En progreso");
            lblStat4Titulo.Text = T("Finalizadas");
            lblRecientesTitulo.Text = T("Proyectos recientes");
            lblRecientesSub.Text = T("Progreso de los proyectos en los que participas");
            lblEstadoTitulo.Text = T("Estado de tareas");
            lblEstadoSub.Text = T("Distribución total");
            lblLeyenda1.Text = T("Pendientes");
            lblLeyenda2.Text = T("En progreso");
            lblLeyenda3.Text = T("Finalizadas");
            lblProxTitulo.Text = T("Próximas a finalizar");
            lblProxSub.Text = T("Tareas con fecha límite en los próximos días");
        }

        private void CargarDatos()
        {
            CultureInfo cultura = Cultura();
            string formatoFecha = Datos.Idioma == "English" ? "dddd, MMMM d" : "dddd, d 'de' MMMM";
            lblFecha.Text = DateTime.Now.ToString(formatoFecha, cultura).ToUpper();

            int hora = DateTime.Now.Hour;
            string saludo = hora < 12 ? T("Buenos días") : (hora < 20 ? T("Buenas tardes") : T("Buenas noches"));
            lblSaludo.Text = saludo + ", " + Datos.Nombre.Split(' ')[0];

            int pendientes = Datos.Tareas.Count(t => t.Estado == "Pendiente");
            int enProgreso = Datos.Tareas.Count(t => t.Estado == "En progreso");
            int finalizadas = Datos.Tareas.Count(t => t.Estado == "Finalizada");

            lblStat1Valor.Text = Datos.Proyectos.Count.ToString();
            lblStat2Valor.Text = pendientes.ToString();
            lblStat3Valor.Text = enProgreso.ToString();
            lblStat4Valor.Text = finalizadas.ToString();

            // Proyectos recientes (los tres primeros)
            Label[] nombres = { lblProy1Nombre, lblProy2Nombre, lblProy3Nombre };
            Label[] detalles = { lblProy1Detalle, lblProy2Detalle, lblProy3Detalle };
            ProgressBar[] barras = { pbProy1, pbProy2, pbProy3 };
            Label[] porcentajes = { lblProy1Porcentaje, lblProy2Porcentaje, lblProy3Porcentaje };
            Label[] estados = { lblProy1Estado, lblProy2Estado, lblProy3Estado };
            Label[] entregas = { lblProy1Entrega, lblProy2Entrega, lblProy3Entrega };

            for (int i = 0; i < 3 && i < Datos.Proyectos.Count; i++)
            {
                Proyecto p = Datos.Proyectos[i];
                nombres[i].Text = p.Nombre;
                detalles[i].Text = T("{0} de {1} tareas completadas", p.Completadas, p.Total);
                barras[i].Maximum = 100;
                barras[i].Value = p.Progreso;
                porcentajes[i].Text = p.Progreso + "%";
                estados[i].Text = T(p.Estado);
                estados[i].BackColor = Diseno.ColorEstado(p.Estado);
                entregas[i].Text = p.Entrega;
            }

            // Estado de tareas (gráfico y leyenda)
            valoresEstado = new[] { pendientes, enProgreso, finalizadas };
            lblLeyendaValor1.Text = pendientes.ToString();
            lblLeyendaValor2.Text = enProgreso.ToString();
            lblLeyendaValor3.Text = finalizadas.ToString();

            // Próximas a finalizar (tres primeras tareas)
            Label[] titulos = { lblProx1Titulo, lblProx2Titulo, lblProx3Titulo };
            Label[] proyectos = { lblProx1Proyecto, lblProx2Proyecto, lblProx3Proyecto };
            Label[] fechas = { lblProx1Fecha, lblProx2Fecha, lblProx3Fecha };
            Label[] iniciales = { lblProx1Iniciales, lblProx2Iniciales, lblProx3Iniciales };

            for (int i = 0; i < 3 && i < Datos.Tareas.Count; i++)
            {
                Tarea t = Datos.Tareas[i];
                bool hoy = t.Fecha == "Hoy";
                titulos[i].Text = t.Titulo;
                proyectos[i].Text = t.Proyecto;
                fechas[i].Text = hoy ? T("Hoy") : t.Fecha;
                fechas[i].ForeColor = hoy ? Diseno.Rojo : Diseno.Gris;
                iniciales[i].Text = Diseno.Iniciales(t.Responsable);
            }
        }

        private void panelDonaEstado_Paint(object sender, PaintEventArgs e)
        {
            Diseno.DibujarDona(e.Graphics, panelDonaEstado.ClientRectangle, valoresEstado, coloresEstado);
        }
    }
}

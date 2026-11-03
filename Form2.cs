using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            CultureInfo es = new CultureInfo("es-ES");
            string fecha = DateTime.Now.ToString("dddd, d 'de' MMMM", es).ToUpper();
            int hora = DateTime.Now.Hour;
            string saludo = hora < 12 ? "Buenos días" : (hora < 20 ? "Buenas tardes" : "Buenas noches");
            string primerNombre = Datos.Nombre.Split(' ')[0];

            Controls.Add(Lbl(fecha, 9F, true, 30, 20, Azul));
            Controls.Add(Lbl(saludo + ", " + primerNombre, 22F, false, 30, 40, Texto));
            Controls.Add(Lbl("Aquí tienes una visión general del trabajo de tu equipo.", 10F, false, 30, 85, Gris));

            Panel horas = Tarjeta(760, 30, 200, 70);
            horas.Controls.Add(Lbl("Horas este mes", 8.5F, false, 14, 12, Gris));
            horas.Controls.Add(Lbl("126,5 h", 14F, true, 14, 32, Texto));
            Controls.Add(horas);

            int pendientes = Datos.Tareas.Count(x => x.Estado == "Pendiente");
            int enProgreso = Datos.Tareas.Count(x => x.Estado == "En progreso");
            int finalizadas = Datos.Tareas.Count(x => x.Estado == "Finalizada");

            string[] titulos = { "Proyectos activos", "Tareas pendientes", "En progreso", "Finalizadas" };
            int[] valores = { Datos.Proyectos.Count, pendientes, enProgreso, finalizadas };
            for (int i = 0; i < 4; i++)
            {
                Panel tarjetaStat = Tarjeta(30 + i * 225, 125, 210, 80);
                tarjetaStat.Controls.Add(Lbl(titulos[i], 8.5F, false, 14, 14, Gris));
                tarjetaStat.Controls.Add(Lbl(valores[i].ToString(), 20F, true, 14, 34, Texto));
                Controls.Add(tarjetaStat);
            }

            // Proyectos recientes
            Panel recientes = Tarjeta(30, 225, 560, 330);
            recientes.Controls.Add(Lbl("Proyectos recientes", 11F, true, 15, 14, Texto));
            recientes.Controls.Add(Lbl("Progreso de los proyectos en los que participas", 8.5F, false, 15, 38, Gris));
            for (int i = 0; i < Math.Min(3, Datos.Proyectos.Count); i++)
            {
                Proyecto p = Datos.Proyectos[i];
                int y = 75 + i * 80;
                recientes.Controls.Add(Lbl(p.Nombre, 10F, true, 15, y, Texto));
                recientes.Controls.Add(Lbl(p.Completadas + " de " + p.Total + " tareas completadas", 8.5F, false, 15, y + 22, Gris));

                ProgressBar barra = new ProgressBar { Maximum = 100, Value = p.Progreso, Location = new Point(15, y + 46), Size = new Size(400, 10) };
                recientes.Controls.Add(barra);

                recientes.Controls.Add(Lbl(p.Progreso + "%", 8.5F, false, 425, y + 42, Gris));
                recientes.Controls.Add(Chip(p.Estado, 440, y));
                recientes.Controls.Add(Lbl(p.Entrega, 8.5F, false, 440, y + 26, Gris));
            }
            Controls.Add(recientes);

            // Estado de tareas
            Panel estado = Tarjeta(610, 225, 350, 330);
            estado.Controls.Add(Lbl("Estado de tareas", 11F, true, 15, 14, Texto));
            estado.Controls.Add(Lbl("Distribución total", 8.5F, false, 15, 38, Gris));
            Panel dona = new Panel { Location = new Point(20, 75), Size = new Size(170, 170) };
            estado.Controls.Add(dona);
            Dona(dona, new[] { pendientes, enProgreso, finalizadas }, new[] { Marino, Azul, AzulClaro });
            string[] nombresEstado = { "Pendientes", "En progreso", "Finalizadas" };
            Color[] coloresEstado = { Marino, Azul, AzulClaro };
            int[] cantidades = { pendientes, enProgreso, finalizadas };
            for (int j = 0; j < 3; j++)
            {
                Leyenda(estado, 210, 100 + j * 30, coloresEstado[j], nombresEstado[j], cantidades[j]);
            }
            Controls.Add(estado);

            // Próximas a finalizar
            Panel proximas = Tarjeta(30, 575, 930, 160);
            proximas.Controls.Add(Lbl("Próximas a finalizar", 11F, true, 15, 14, Texto));
            proximas.Controls.Add(Lbl("Tareas con fecha límite en los próximos días", 8.5F, false, 15, 38, Gris));
            for (int i = 0; i < Math.Min(3, Datos.Tareas.Count); i++)
            {
                Tarea tarea = Datos.Tareas[i];
                Panel tarjetaTarea = Tarjeta(15 + i * 300, 65, 285, 80);
                tarjetaTarea.Controls.Add(Lbl(tarea.Titulo, 9.5F, true, 12, 10, Texto));
                tarjetaTarea.Controls.Add(Lbl(tarea.Proyecto, 8F, false, 12, 32, Gris));
                tarjetaTarea.Controls.Add(Lbl(tarea.Fecha, 8.5F, true, 12, 52, tarea.Fecha == "Hoy" ? Rojo : Gris));
                tarjetaTarea.Controls.Add(Caja(Iniciales(tarea.Responsable), 240, 22, 32));
                proximas.Controls.Add(tarjetaTarea);
            }
            Controls.Add(proximas);
        }
    }
}

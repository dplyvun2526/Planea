using System;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using static ProyectoDeskstop.Ui;

namespace ProyectoDeskstop
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            ConstruirUI();
        }

        private void ConstruirUI()
        {
            CultureInfo es = new CultureInfo("es-ES");

            Controls.Add(Lbl("RENDIMIENTO DEL EQUIPO", 9F, true, 30, 20, Azul));
            Controls.Add(Lbl("Resumen y estadísticas", 22F, false, 30, 40, Texto));
            Controls.Add(Lbl("Analiza el avance de los proyectos y el tiempo dedicado.", 10F, false, 30, 85, Gris));

            int total = Datos.Tareas.Count;
            int fin = Datos.Tareas.Count(x => x.Estado == "Finalizada");
            int enProg = Datos.Tareas.Count(x => x.Estado == "En progreso");
            int pend = Datos.Tareas.Count(x => x.Estado == "Pendiente");
            int bloq = Datos.Tareas.Count(x => x.Estado == "Bloqueada");
            int tasa = total == 0 ? 0 : (int)Math.Round(100.0 * fin / total);

            string[] titulos = { "Total de tareas", "Tareas finalizadas", "En progreso", "Tasa de finalización" };
            string[] valores = { total.ToString(), fin.ToString(), enProg.ToString(), tasa + "%" };
            for (int i = 0; i < 4; i++)
            {
                Panel tarjeta = Tarjeta(30 + i * 235, 125, 225, 85);
                tarjeta.Controls.Add(Lbl(titulos[i], 8.5F, false, 14, 14, Gris));
                tarjeta.Controls.Add(Lbl(valores[i], 20F, true, 14, 36, i == 3 ? Azul : Texto));
                Controls.Add(tarjeta);
            }

            // Estado de las tareas
            Panel est = Tarjeta(30, 235, 430, 300);
            est.Controls.Add(Lbl("Estado de las tareas", 11F, true, 15, 14, Texto));
            est.Controls.Add(Lbl("Distribución por estado", 8.5F, false, 15, 38, Gris));
            Panel dona = new Panel { Location = new Point(20, 75), Size = new Size(170, 170) };
            est.Controls.Add(dona);
            int[] cant = { pend, enProg, bloq, fin };
            Color[] cols = { Marino, Azul, Rojo, AzulClaro };
            string[] nombres = { "Pendientes", "En progreso", "Bloqueadas", "Finalizadas" };
            Dona(dona, cant, cols);
            for (int j = 0; j < 4; j++)
            {
                Leyenda(est, 210, 95 + j * 45, cols[j], nombres[j], cant[j]);
            }
            Controls.Add(est);

            // Horas por proyecto
            Panel hp = Tarjeta(480, 235, 480, 300);
            hp.Controls.Add(Lbl("Horas por proyecto", 11F, true, 15, 14, Texto));
            hp.Controls.Add(Lbl("Reales frente a estimadas", 8.5F, false, 15, 38, Gris));
            for (int i = 0; i < Datos.Proyectos.Count; i++)
            {
                Proyecto p = Datos.Proyectos[i];
                int y = 75 + i * 55;
                hp.Controls.Add(Lbl(p.Nombre, 9F, false, 15, y, Texto));
                hp.Controls.Add(Lbl(p.HorasReales + " h / " + p.HorasEstimadas + " h", 8.5F, false, 300, y, Gris));
                ProgressBar barra = new ProgressBar
                {
                    Maximum = Math.Max(1, p.HorasEstimadas),
                    Value = Math.Min(p.HorasReales, Math.Max(1, p.HorasEstimadas)),
                    Location = new Point(15, y + 22),
                    Size = new Size(450, 10)
                };
                hp.Controls.Add(barra);
            }
            Controls.Add(hp);

            // Resumen de horas
            int uso = (int)Math.Round(100 * Datos.HorasRegistradasTotal / Datos.HorasEstimadasTotal);
            Panel res = Tarjeta(30, 555, 930, 80);
            res.Controls.Add(Lbl("Horas estimadas", 8.5F, false, 20, 14, Gris));
            res.Controls.Add(Lbl(Datos.HorasEstimadasTotal.ToString("0") + " h", 13F, true, 20, 32, Texto));
            res.Controls.Add(Lbl("Horas registradas", 8.5F, false, 260, 14, Gris));
            res.Controls.Add(Lbl(Datos.HorasRegistradasTotal.ToString("N1", es) + " h", 13F, true, 260, 32, Texto));
            res.Controls.Add(Lbl("Uso de horas", 8.5F, false, 560, 14, Gris));
            res.Controls.Add(Lbl(uso + "%", 13F, true, 840, 10, Azul));
            ProgressBar usoBarra = new ProgressBar { Maximum = 100, Value = uso, Location = new Point(560, 52), Size = new Size(260, 10) };
            res.Controls.Add(usoBarra);
            Controls.Add(res);
        }
    }
}

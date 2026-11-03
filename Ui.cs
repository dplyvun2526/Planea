using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ProyectoDeskstop
{
    // Colores y controles comunes a todas las páginas.
    public static class Ui
    {
        public static readonly Color Marino = Color.FromArgb(15, 39, 71);
        public static readonly Color MarinoActivo = Color.FromArgb(30, 64, 110);
        public static readonly Color Azul = Color.FromArgb(37, 99, 235);
        public static readonly Color AzulClaro = Color.FromArgb(147, 197, 253);
        public static readonly Color Fondo = Color.FromArgb(245, 247, 250);
        public static readonly Color Texto = Color.FromArgb(17, 24, 39);
        public static readonly Color Gris = Color.FromArgb(100, 116, 139);
        public static readonly Color Rojo = Color.FromArgb(220, 38, 38);

        public static Label Lbl(string texto, float tamano, bool negrita, int x, int y, Color color)
        {
            Label l = new Label();
            l.AutoSize = true;
            l.Text = texto;
            l.Location = new Point(x, y);
            l.ForeColor = color;
            l.Font = new Font("Segoe UI", tamano, negrita ? FontStyle.Bold : FontStyle.Regular);
            return l;
        }

        public static Panel Tarjeta(int x, int y, int ancho, int alto)
        {
            Panel p = new Panel();
            p.Location = new Point(x, y);
            p.Size = new Size(ancho, alto);
            p.BackColor = Color.White;
            p.BorderStyle = BorderStyle.FixedSingle;
            return p;
        }

        public static Button Boton(string texto, int x, int y, int ancho, int alto, bool primario)
        {
            Button b = new Button();
            b.Text = texto;
            b.Location = new Point(x, y);
            b.Size = new Size(ancho, alto);
            b.FlatStyle = FlatStyle.Flat;
            b.Font = new Font("Segoe UI", 9.5F);
            b.Cursor = Cursors.Hand;
            if (primario)
            {
                b.BackColor = Azul;
                b.ForeColor = Color.White;
                b.FlatAppearance.BorderSize = 0;
            }
            else
            {
                b.BackColor = Color.White;
                b.ForeColor = Texto;
                b.FlatAppearance.BorderColor = Color.FromArgb(203, 213, 225);
            }
            return b;
        }

        public static Button MenuBoton(string texto, int y)
        {
            Button b = new Button();
            b.Text = "   " + texto;
            b.Location = new Point(12, y);
            b.Size = new Size(216, 42);
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.BackColor = Marino;
            b.ForeColor = Color.White;
            b.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            b.TextAlign = ContentAlignment.MiddleLeft;
            b.Cursor = Cursors.Hand;
            return b;
        }

        public static Color ColorEstado(string estado)
        {
            switch (estado)
            {
                case "En progreso": return Color.FromArgb(219, 234, 254);
                case "En revisión": return Color.FromArgb(254, 243, 199);
                case "Bloqueada": return Color.FromArgb(254, 226, 226);
                case "Finalizada": return Color.FromArgb(220, 252, 231);
                default: return Color.FromArgb(241, 245, 249);
            }
        }

        public static Label Chip(string estado, int x, int y)
        {
            Label c = Lbl(estado, 8.5F, false, x, y, Texto);
            c.Padding = new Padding(6, 2, 6, 2);
            c.BackColor = ColorEstado(estado);
            return c;
        }

        public static Label Caja(string letras, int x, int y, int lado)
        {
            Label l = new Label();
            l.Location = new Point(x, y);
            l.Size = new Size(lado, lado);
            l.Text = letras;
            l.TextAlign = ContentAlignment.MiddleCenter;
            l.BackColor = Color.FromArgb(226, 232, 240);
            l.ForeColor = Marino;
            l.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            return l;
        }

        public static string Iniciales(string nombre)
        {
            string[] partes = nombre.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            string resultado = "";
            for (int i = 0; i < partes.Length && i < 2; i++)
            {
                resultado += partes[i].Substring(0, 1);
            }
            return resultado.ToUpper();
        }

        // Fila de leyenda: punto de color, nombre y valor.
        public static void Leyenda(Panel contenedor, int x, int y, Color color, string nombre, int valor)
        {
            Panel punto = new Panel();
            punto.Location = new Point(x, y + 4);
            punto.Size = new Size(10, 10);
            punto.BackColor = color;
            contenedor.Controls.Add(punto);
            contenedor.Controls.Add(Lbl(nombre, 9F, false, x + 18, y, Texto));
            contenedor.Controls.Add(Lbl(valor.ToString(), 9F, true, x + 110, y, Texto));
        }

        // Gráfico de anillo dibujado sobre un panel.
        public static void Dona(Panel panel, int[] valores, Color[] colores)
        {
            panel.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                int total = 0;
                foreach (int v in valores) total += v;

                Rectangle area = new Rectangle(4, 4, panel.Width - 8, panel.Height - 8);
                if (total > 0)
                {
                    float inicio = -90f;
                    for (int i = 0; i < valores.Length; i++)
                    {
                        float barrido = 360f * valores[i] / total;
                        using (Brush pincel = new SolidBrush(colores[i]))
                        {
                            e.Graphics.FillPie(pincel, area, inicio, barrido);
                        }
                        inicio += barrido;
                    }
                }

                int margen = area.Width / 3;
                Rectangle hueco = new Rectangle(area.X + margen, area.Y + margen, area.Width - 2 * margen, area.Height - 2 * margen);
                using (Brush blanco = new SolidBrush(Color.White))
                {
                    e.Graphics.FillEllipse(blanco, hueco);
                }

                string centro = total.ToString();
                using (Font fuente = new Font("Segoe UI", 14F, FontStyle.Bold))
                {
                    SizeF medida = e.Graphics.MeasureString(centro, fuente);
                    e.Graphics.DrawString(centro, fuente, Brushes.Black,
                        panel.Width / 2 - medida.Width / 2, panel.Height / 2 - medida.Height / 2);
                }
            };
        }
    }
}

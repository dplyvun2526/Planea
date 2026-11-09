using System;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace ProyectoDeskstop
{
    public static class Ui
    {
        public static readonly Color Marino = Color.FromArgb(15, 39, 71);
        public static readonly Color Azul = Color.FromArgb(37, 99, 235);
        public static readonly Color AzulClaro = Color.FromArgb(147, 197, 253);
        public static readonly Color Texto = Color.FromArgb(17, 24, 39);
        public static readonly Color Gris = Color.FromArgb(100, 116, 139);
        public static readonly Color Rojo = Color.FromArgb(220, 38, 38);

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

        // Dibuja un gráfico de anillo con el total en el centro.
        public static void DibujarDona(Graphics g, Rectangle zona, int[] valores, Color[] colores)
        {
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int total = 0;
            foreach (int v in valores) total += v;

            Rectangle area = new Rectangle(zona.X + 4, zona.Y + 4, zona.Width - 8, zona.Height - 8);
            if (total > 0)
            {
                float inicio = -90f;
                for (int i = 0; i < valores.Length; i++)
                {
                    float barrido = 360f * valores[i] / total;
                    using (Brush pincel = new SolidBrush(colores[i]))
                    {
                        g.FillPie(pincel, area, inicio, barrido);
                    }
                    inicio += barrido;
                }
            }

            int margen = area.Width / 3;
            Rectangle hueco = new Rectangle(area.X + margen, area.Y + margen, area.Width - 2 * margen, area.Height - 2 * margen);
            using (Brush blanco = new SolidBrush(Color.White))
            {
                g.FillEllipse(blanco, hueco);
            }

            string centro = total.ToString();
            using (Font fuente = new Font("Segoe UI", 14F, FontStyle.Bold))
            {
                SizeF medida = g.MeasureString(centro, fuente);
                g.DrawString(centro, fuente, Brushes.Black, zona.Width / 2 - medida.Width / 2, zona.Height / 2 - medida.Height / 2);
            }
        }
    }
}

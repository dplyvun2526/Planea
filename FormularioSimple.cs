using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using static ProyectoDeskstop.Idiomas;

namespace ProyectoDeskstop
{
    // Diálogo genérico creado por código: se añaden campos uno debajo de otro y se llama a Final().
    public class FormularioSimple : Form
    {
        private int y = 15;

        public FormularioSimple(string titulo)
        {
            Text = titulo;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            StartPosition = FormStartPosition.CenterParent;
            MaximizeBox = false;
            MinimizeBox = false;
            Font = new Font("Segoe UI", 9.5F);
        }

        private void Etiqueta(string texto)
        {
            Controls.Add(new Label { Text = texto, Location = new Point(15, y), AutoSize = true });
            y += 20;
        }

        private T Campo<T>(T control) where T : Control
        {
            control.Location = new Point(15, y);
            control.Width = 330;
            Controls.Add(control);
            y += control.Height + 12;
            return control;
        }

        public TextBox Texto(string etiqueta, bool contrasena = false)
        {
            Etiqueta(etiqueta);
            return Campo(new TextBox { UseSystemPasswordChar = contrasena });
        }

        public ComboBox Lista(string etiqueta, IEnumerable<string> items)
        {
            Etiqueta(etiqueta);
            ComboBox c = Campo(new ComboBox { DropDownStyle = ComboBoxStyle.DropDownList });
            foreach (string i in items) c.Items.Add(i);
            if (c.Items.Count > 0) c.SelectedIndex = 0;
            return c;
        }

        public DateTimePicker Fecha(string etiqueta, DateTime valor)
        {
            Etiqueta(etiqueta);
            return Campo(new DateTimePicker { Value = valor, Format = DateTimePickerFormat.Short });
        }

        public NumericUpDown Numero(string etiqueta, decimal valor)
        {
            Etiqueta(etiqueta);
            return Campo(new NumericUpDown { Minimum = 0, Maximum = 9999, DecimalPlaces = 2, Increment = 0.5m, Value = Math.Min(9999m, Math.Max(0m, valor)) });
        }

        public void Final(string textoOk)
        {
            Button ok = new Button { Text = textoOk, Location = new Point(150, y + 5), Size = new Size(95, 30), DialogResult = DialogResult.OK };
            Button cancelar = new Button { Text = T("Cancelar"), Location = new Point(255, y + 5), Size = new Size(95, 30), DialogResult = DialogResult.Cancel };
            Controls.Add(ok);
            Controls.Add(cancelar);
            AcceptButton = ok;
            CancelButton = cancelar;
            ClientSize = new Size(360, y + 50);
        }
    }
}

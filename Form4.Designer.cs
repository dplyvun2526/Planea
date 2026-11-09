namespace ProyectoDeskstop
{
    partial class Form4
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblOrganizacion;
        private System.Windows.Forms.Label lblTituloTareas;
        private System.Windows.Forms.Label lblSubTareas;
        private System.Windows.Forms.Button btnCrearTarea;
        private System.Windows.Forms.Button btnTodas;
        private System.Windows.Forms.Button btnPendientes;
        private System.Windows.Forms.Button btnEnProgreso;
        private System.Windows.Forms.Button btnBloqueadas;
        private System.Windows.Forms.Button btnFinalizadas;
        private System.Windows.Forms.TextBox txtBuscarTarea;
        private System.Windows.Forms.ComboBox cmbProyectoTarea;
        private System.Windows.Forms.Label lblResultadosTarea;
        private System.Windows.Forms.Button btnEliminarTarea;
        private System.Windows.Forms.DataGridView dgvTareas;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTarea;
        private System.Windows.Forms.DataGridViewTextBoxColumn colProyecto;
        private System.Windows.Forms.DataGridViewTextBoxColumn colResponsable;
        private System.Windows.Forms.DataGridViewTextBoxColumn colEstado;
        private System.Windows.Forms.DataGridViewTextBoxColumn colPrioridad;
        private System.Windows.Forms.DataGridViewTextBoxColumn colHoras;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFecha;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form4));
            this.lblOrganizacion = new System.Windows.Forms.Label();
            this.lblTituloTareas = new System.Windows.Forms.Label();
            this.lblSubTareas = new System.Windows.Forms.Label();
            this.btnCrearTarea = new System.Windows.Forms.Button();
            this.btnTodas = new System.Windows.Forms.Button();
            this.btnPendientes = new System.Windows.Forms.Button();
            this.btnEnProgreso = new System.Windows.Forms.Button();
            this.btnBloqueadas = new System.Windows.Forms.Button();
            this.btnFinalizadas = new System.Windows.Forms.Button();
            this.txtBuscarTarea = new System.Windows.Forms.TextBox();
            this.cmbProyectoTarea = new System.Windows.Forms.ComboBox();
            this.lblResultadosTarea = new System.Windows.Forms.Label();
            this.btnEliminarTarea = new System.Windows.Forms.Button();
            this.dgvTareas = new System.Windows.Forms.DataGridView();
            this.colTarea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colProyecto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colResponsable = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colEstado = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colPrioridad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colHoras = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFecha = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).BeginInit();
            this.SuspendLayout();
            // 
            // lblOrganizacion
            // 
            this.lblOrganizacion.AutoSize = true;
            this.lblOrganizacion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblOrganizacion.ForeColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.lblOrganizacion.Location = new System.Drawing.Point(30, 20);
            this.lblOrganizacion.Name = "lblOrganizacion";
            this.lblOrganizacion.Text = "ORGANIZACIÓN DEL TRABAJO";
            // 
            // lblTituloTareas
            // 
            this.lblTituloTareas.AutoSize = true;
            this.lblTituloTareas.Font = new System.Drawing.Font("Segoe UI", 22F);
            this.lblTituloTareas.ForeColor = System.Drawing.Color.FromArgb(17, 24, 39);
            this.lblTituloTareas.Location = new System.Drawing.Point(30, 40);
            this.lblTituloTareas.Name = "lblTituloTareas";
            this.lblTituloTareas.Text = "Tareas";
            // 
            // lblSubTareas
            // 
            this.lblSubTareas.AutoSize = true;
            this.lblSubTareas.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblSubTareas.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblSubTareas.Location = new System.Drawing.Point(30, 85);
            this.lblSubTareas.Name = "lblSubTareas";
            this.lblSubTareas.Text = "Consulta, filtra y actualiza las tareas asignadas.";
            // 
            // btnCrearTarea
            // 
            this.btnCrearTarea.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnCrearTarea.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCrearTarea.FlatAppearance.BorderSize = 0;
            this.btnCrearTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCrearTarea.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnCrearTarea.ForeColor = System.Drawing.Color.White;
            this.btnCrearTarea.Location = new System.Drawing.Point(760, 40);
            this.btnCrearTarea.Name = "btnCrearTarea";
            this.btnCrearTarea.Size = new System.Drawing.Size(170, 36);
            this.btnCrearTarea.Text = "+ Crear tarea";
            this.btnCrearTarea.UseVisualStyleBackColor = false;
            this.btnCrearTarea.Click += new System.EventHandler(this.btnCrearTarea_Click);
            // 
            // btnTodas
            // 
            this.btnTodas.BackColor = System.Drawing.Color.FromArgb(37, 99, 235);
            this.btnTodas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTodas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnTodas.ForeColor = System.Drawing.Color.White;
            this.btnTodas.Location = new System.Drawing.Point(30, 125);
            this.btnTodas.Name = "btnTodas";
            this.btnTodas.Size = new System.Drawing.Size(118, 30);
            this.btnTodas.Tag = "Todas";
            this.btnTodas.Text = "Todas";
            this.btnTodas.UseVisualStyleBackColor = false;
            this.btnTodas.Click += new System.EventHandler(this.Pestana_Click);
            // 
            // btnPendientes
            // 
            this.btnPendientes.BackColor = System.Drawing.Color.White;
            this.btnPendientes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPendientes.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnPendientes.Location = new System.Drawing.Point(155, 125);
            this.btnPendientes.Name = "btnPendientes";
            this.btnPendientes.Size = new System.Drawing.Size(118, 30);
            this.btnPendientes.Tag = "Pendientes";
            this.btnPendientes.Text = "Pendientes";
            this.btnPendientes.UseVisualStyleBackColor = false;
            this.btnPendientes.Click += new System.EventHandler(this.Pestana_Click);
            // 
            // btnEnProgreso
            // 
            this.btnEnProgreso.BackColor = System.Drawing.Color.White;
            this.btnEnProgreso.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEnProgreso.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEnProgreso.Location = new System.Drawing.Point(280, 125);
            this.btnEnProgreso.Name = "btnEnProgreso";
            this.btnEnProgreso.Size = new System.Drawing.Size(118, 30);
            this.btnEnProgreso.Tag = "En progreso";
            this.btnEnProgreso.Text = "En progreso";
            this.btnEnProgreso.UseVisualStyleBackColor = false;
            this.btnEnProgreso.Click += new System.EventHandler(this.Pestana_Click);
            // 
            // btnBloqueadas
            // 
            this.btnBloqueadas.BackColor = System.Drawing.Color.White;
            this.btnBloqueadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBloqueadas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnBloqueadas.Location = new System.Drawing.Point(405, 125);
            this.btnBloqueadas.Name = "btnBloqueadas";
            this.btnBloqueadas.Size = new System.Drawing.Size(118, 30);
            this.btnBloqueadas.Tag = "Bloqueadas";
            this.btnBloqueadas.Text = "Bloqueadas";
            this.btnBloqueadas.UseVisualStyleBackColor = false;
            this.btnBloqueadas.Click += new System.EventHandler(this.Pestana_Click);
            // 
            // btnFinalizadas
            // 
            this.btnFinalizadas.BackColor = System.Drawing.Color.White;
            this.btnFinalizadas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizadas.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnFinalizadas.Location = new System.Drawing.Point(530, 125);
            this.btnFinalizadas.Name = "btnFinalizadas";
            this.btnFinalizadas.Size = new System.Drawing.Size(118, 30);
            this.btnFinalizadas.Tag = "Finalizadas";
            this.btnFinalizadas.Text = "Finalizadas";
            this.btnFinalizadas.UseVisualStyleBackColor = false;
            this.btnFinalizadas.Click += new System.EventHandler(this.Pestana_Click);
            // 
            // txtBuscarTarea
            // 
            this.txtBuscarTarea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtBuscarTarea.Location = new System.Drawing.Point(30, 170);
            this.txtBuscarTarea.Name = "txtBuscarTarea";
            this.txtBuscarTarea.Size = new System.Drawing.Size(260, 25);
            this.txtBuscarTarea.TextChanged += new System.EventHandler(this.FiltrarTareas);
            // 
            // cmbProyectoTarea
            // 
            this.cmbProyectoTarea.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProyectoTarea.FormattingEnabled = true;
            this.cmbProyectoTarea.Location = new System.Drawing.Point(305, 169);
            this.cmbProyectoTarea.Name = "cmbProyectoTarea";
            this.cmbProyectoTarea.Size = new System.Drawing.Size(200, 25);
            this.cmbProyectoTarea.SelectedIndexChanged += new System.EventHandler(this.FiltrarTareas);
            // 
            // lblResultadosTarea
            // 
            this.lblResultadosTarea.AutoSize = true;
            this.lblResultadosTarea.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblResultadosTarea.ForeColor = System.Drawing.Color.FromArgb(100, 116, 139);
            this.lblResultadosTarea.Location = new System.Drawing.Point(520, 173);
            this.lblResultadosTarea.Name = "lblResultadosTarea";
            this.lblResultadosTarea.Text = "0 resultados";
            // 
            // btnEliminarTarea
            // 
            this.btnEliminarTarea.BackColor = System.Drawing.Color.White;
            this.btnEliminarTarea.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarTarea.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnEliminarTarea.Location = new System.Drawing.Point(760, 167);
            this.btnEliminarTarea.Name = "btnEliminarTarea";
            this.btnEliminarTarea.Size = new System.Drawing.Size(200, 28);
            this.btnEliminarTarea.Text = "Eliminar seleccionada";
            this.btnEliminarTarea.UseVisualStyleBackColor = false;
            this.btnEliminarTarea.Click += new System.EventHandler(this.btnEliminarTarea_Click);
            // 
            // dgvTareas
            // 
            this.dgvTareas.AllowUserToAddRows = false;
            this.dgvTareas.AllowUserToDeleteRows = false;
            this.dgvTareas.AllowUserToResizeRows = false;
            this.dgvTareas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvTareas.BackgroundColor = System.Drawing.Color.White;
            this.dgvTareas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.dgvTareas.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colTarea,
            this.colProyecto,
            this.colResponsable,
            this.colEstado,
            this.colPrioridad,
            this.colHoras,
            this.colFecha});
            this.dgvTareas.Location = new System.Drawing.Point(30, 205);
            this.dgvTareas.MultiSelect = false;
            this.dgvTareas.Name = "dgvTareas";
            this.dgvTareas.ReadOnly = true;
            this.dgvTareas.RowHeadersVisible = false;
            this.dgvTareas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTareas.Size = new System.Drawing.Size(930, 490);
            // 
            // colTarea
            // 
            this.colTarea.HeaderText = "Tarea";
            this.colTarea.Name = "colTarea";
            this.colTarea.ReadOnly = true;
            // 
            // colProyecto
            // 
            this.colProyecto.HeaderText = "Proyecto";
            this.colProyecto.Name = "colProyecto";
            this.colProyecto.ReadOnly = true;
            // 
            // colResponsable
            // 
            this.colResponsable.HeaderText = "Responsable";
            this.colResponsable.Name = "colResponsable";
            this.colResponsable.ReadOnly = true;
            // 
            // colEstado
            // 
            this.colEstado.HeaderText = "Estado";
            this.colEstado.Name = "colEstado";
            this.colEstado.ReadOnly = true;
            // 
            // colPrioridad
            // 
            this.colPrioridad.HeaderText = "Prioridad";
            this.colPrioridad.Name = "colPrioridad";
            this.colPrioridad.ReadOnly = true;
            // 
            // colHoras
            // 
            this.colHoras.HeaderText = "Horas";
            this.colHoras.Name = "colHoras";
            this.colHoras.ReadOnly = true;
            // 
            // colFecha
            // 
            this.colFecha.HeaderText = "Fecha límite";
            this.colFecha.Name = "colFecha";
            this.colFecha.ReadOnly = true;
            // 
            // Form4
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(245, 247, 250);
            this.ClientSize = new System.Drawing.Size(960, 708);
            this.Controls.Add(this.lblOrganizacion);
            this.Controls.Add(this.lblTituloTareas);
            this.Controls.Add(this.lblSubTareas);
            this.Controls.Add(this.btnCrearTarea);
            this.Controls.Add(this.btnTodas);
            this.Controls.Add(this.btnPendientes);
            this.Controls.Add(this.btnEnProgreso);
            this.Controls.Add(this.btnBloqueadas);
            this.Controls.Add(this.btnFinalizadas);
            this.Controls.Add(this.txtBuscarTarea);
            this.Controls.Add(this.cmbProyectoTarea);
            this.Controls.Add(this.lblResultadosTarea);
            this.Controls.Add(this.btnEliminarTarea);
            this.Controls.Add(this.dgvTareas);
            this.Name = "Form4";
            this.Text = "Tareas";
            ((System.ComponentModel.ISupportInitialize)(this.dgvTareas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion
    }
}

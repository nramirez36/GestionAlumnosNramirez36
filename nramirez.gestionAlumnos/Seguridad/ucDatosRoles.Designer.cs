namespace nramirez.gestionAlumnos.Seguridad
{
    partial class ucDatosRoles
    {
        /// <summary> 
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar 
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtRol = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Rol:";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(59, 23);
            this.txtRol.MaxLength = 50;
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(217, 20);
            this.txtRol.TabIndex = 1;
            // 
            // ucDatosRoles
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.label1);
            this.Name = "ucDatosRoles";
            this.Size = new System.Drawing.Size(291, 68);
            this.Load += new System.EventHandler(this.ucDatosRoles_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucDatosRoles_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRol;
    }
}

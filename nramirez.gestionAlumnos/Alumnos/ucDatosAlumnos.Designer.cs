namespace nramirez.gestionAlumnos.Alumnos
{
    partial class ucDatosAlumnos
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
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApellido = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbTipoDoc = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNroDoc = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNacionalidad = new System.Windows.Forms.TextBox();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtEdad = new System.Windows.Forms.TextBox();
            this.grbDomicilio = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.mskTelFijo = new System.Windows.Forms.MaskedTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.mskTelCel = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.ucDatosDomicilio1 = new nramirez.gestionAlumnos.Alumnos.ucDatosDomicilio();
            this.grbDomicilio.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombres:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(95, 7);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(187, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellido:";
            // 
            // txtApellido
            // 
            this.txtApellido.Location = new System.Drawing.Point(95, 33);
            this.txtApellido.Name = "txtApellido";
            this.txtApellido.Size = new System.Drawing.Size(187, 20);
            this.txtApellido.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Tipo de Doc:";
            // 
            // cmbTipoDoc
            // 
            this.cmbTipoDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoDoc.FormattingEnabled = true;
            this.cmbTipoDoc.Location = new System.Drawing.Point(95, 59);
            this.cmbTipoDoc.Name = "cmbTipoDoc";
            this.cmbTipoDoc.Size = new System.Drawing.Size(121, 21);
            this.cmbTipoDoc.TabIndex = 5;
            this.cmbTipoDoc.DropDown += new System.EventHandler(this.cmbTipoDoc_DropDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 89);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(62, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Documento";
            // 
            // txtNroDoc
            // 
            this.txtNroDoc.Location = new System.Drawing.Point(95, 86);
            this.txtNroDoc.Name = "txtNroDoc";
            this.txtNroDoc.Size = new System.Drawing.Size(121, 20);
            this.txtNroDoc.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 115);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Nacionalidad:";
            // 
            // txtNacionalidad
            // 
            this.txtNacionalidad.Location = new System.Drawing.Point(95, 112);
            this.txtNacionalidad.Name = "txtNacionalidad";
            this.txtNacionalidad.Size = new System.Drawing.Size(187, 20);
            this.txtNacionalidad.TabIndex = 9;
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(134, 138);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 20);
            this.dtpFechaNacimiento.TabIndex = 11;
            this.dtpFechaNacimiento.ValueChanged += new System.EventHandler(this.dtpFechaNacimiento_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(17, 141);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(111, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Fecha de Nacimiento:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 168);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Edad:";
            // 
            // txtEdad
            // 
            this.txtEdad.Enabled = false;
            this.txtEdad.Location = new System.Drawing.Point(95, 165);
            this.txtEdad.Name = "txtEdad";
            this.txtEdad.Size = new System.Drawing.Size(68, 20);
            this.txtEdad.TabIndex = 13;
            // 
            // grbDomicilio
            // 
            this.grbDomicilio.Controls.Add(this.ucDatosDomicilio1);
            this.grbDomicilio.Location = new System.Drawing.Point(20, 191);
            this.grbDomicilio.Name = "grbDomicilio";
            this.grbDomicilio.Size = new System.Drawing.Size(314, 195);
            this.grbDomicilio.TabIndex = 14;
            this.grbDomicilio.TabStop = false;
            this.grbDomicilio.Text = "Domicilio";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 15;
            this.label8.Text = "Tel Fijo:";
            // 
            // mskTelFijo
            // 
            this.mskTelFijo.Location = new System.Drawing.Point(95, 392);
            this.mskTelFijo.Mask = "(9999) 000-0000";
            this.mskTelFijo.Name = "mskTelFijo";
            this.mskTelFijo.Size = new System.Drawing.Size(100, 20);
            this.mskTelFijo.TabIndex = 16;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(17, 421);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 13);
            this.label9.TabIndex = 17;
            this.label9.Text = "Tel Celular:";
            // 
            // mskTelCel
            // 
            this.mskTelCel.Location = new System.Drawing.Point(95, 418);
            this.mskTelCel.Mask = "(0000) 000-000000";
            this.mskTelCel.Name = "mskTelCel";
            this.mskTelCel.Size = new System.Drawing.Size(100, 20);
            this.mskTelCel.TabIndex = 18;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 448);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 13);
            this.label10.TabIndex = 19;
            this.label10.Text = "Email:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(95, 445);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(187, 20);
            this.txtEmail.TabIndex = 20;
            // 
            // ucDatosDomicilio1
            // 
            this.ucDatosDomicilio1.DomicilioAlumno = null;
            this.ucDatosDomicilio1.Location = new System.Drawing.Point(7, 20);
            this.ucDatosDomicilio1.ModoSoloLectura = false;
            this.ucDatosDomicilio1.Name = "ucDatosDomicilio1";
            this.ucDatosDomicilio1.Size = new System.Drawing.Size(254, 166);
            this.ucDatosDomicilio1.TabIndex = 0;
            // 
            // ucDatosAlumnos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtEmail);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.mskTelCel);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.mskTelFijo);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.grbDomicilio);
            this.Controls.Add(this.txtEdad);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.dtpFechaNacimiento);
            this.Controls.Add(this.txtNacionalidad);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNroDoc);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbTipoDoc);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApellido);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNombre);
            this.Controls.Add(this.label1);
            this.Name = "ucDatosAlumnos";
            this.Size = new System.Drawing.Size(368, 474);
            this.Load += new System.EventHandler(this.ucDatosAlumnos_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ucDatosAlumnos_Paint);
            this.grbDomicilio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApellido;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbTipoDoc;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNroDoc;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNacionalidad;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtEdad;
        private System.Windows.Forms.GroupBox grbDomicilio;
        private ucDatosDomicilio ucDatosDom;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox mskTelFijo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.MaskedTextBox mskTelCel;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtEmail;
        private ucDatosDomicilio ucDatosDomicilio1;
    }
}

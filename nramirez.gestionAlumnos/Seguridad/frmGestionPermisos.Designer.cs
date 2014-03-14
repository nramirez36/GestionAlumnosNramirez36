namespace nramirez.gestionAlumnos.Seguridad
{
    partial class frmGestionPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.ddlPage = new System.Windows.Forms.ComboBox();
            this.gbControles = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.chkDisabled = new System.Windows.Forms.CheckBox();
            this.chkInvisible = new System.Windows.Forms.CheckBox();
            this.lstRoles = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tvEstado = new System.Windows.Forms.TreeView();
            this.ByRoleRB = new System.Windows.Forms.RadioButton();
            this.ByControlRB = new System.Windows.Forms.RadioButton();
            this.lstControles = new System.Windows.Forms.ListBox();
            this.gbControles.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Seleccione el formulario:";
            // 
            // ddlPage
            // 
            this.ddlPage.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlPage.FormattingEnabled = true;
            this.ddlPage.Location = new System.Drawing.Point(140, 23);
            this.ddlPage.Name = "ddlPage";
            this.ddlPage.Size = new System.Drawing.Size(187, 21);
            this.ddlPage.TabIndex = 3;
            this.ddlPage.SelectedValueChanged += new System.EventHandler(this.ddlPage_SelectedValueChanged);
            // 
            // gbControles
            // 
            this.gbControles.Controls.Add(this.lstControles);
            this.gbControles.Controls.Add(this.button2);
            this.gbControles.Controls.Add(this.btnAceptar);
            this.gbControles.Controls.Add(this.chkDisabled);
            this.gbControles.Controls.Add(this.chkInvisible);
            this.gbControles.Controls.Add(this.lstRoles);
            this.gbControles.Location = new System.Drawing.Point(12, 50);
            this.gbControles.Name = "gbControles";
            this.gbControles.Size = new System.Drawing.Size(550, 238);
            this.gbControles.TabIndex = 4;
            this.gbControles.TabStop = false;
            this.gbControles.Text = "Permisos";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(459, 208);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(459, 179);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 4;
            this.btnAceptar.Text = "Guardar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // chkDisabled
            // 
            this.chkDisabled.AutoSize = true;
            this.chkDisabled.Location = new System.Drawing.Point(459, 55);
            this.chkDisabled.Name = "chkDisabled";
            this.chkDisabled.Size = new System.Drawing.Size(86, 17);
            this.chkDisabled.TabIndex = 3;
            this.chkDisabled.Text = "Desactivado";
            this.chkDisabled.UseVisualStyleBackColor = true;
            // 
            // chkInvisible
            // 
            this.chkInvisible.AutoSize = true;
            this.chkInvisible.Location = new System.Drawing.Point(459, 32);
            this.chkInvisible.Name = "chkInvisible";
            this.chkInvisible.Size = new System.Drawing.Size(64, 17);
            this.chkInvisible.TabIndex = 2;
            this.chkInvisible.Text = "Invisible";
            this.chkInvisible.UseVisualStyleBackColor = true;
            // 
            // lstRoles
            // 
            this.lstRoles.FormattingEnabled = true;
            this.lstRoles.Location = new System.Drawing.Point(307, 19);
            this.lstRoles.Name = "lstRoles";
            this.lstRoles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstRoles.Size = new System.Drawing.Size(120, 212);
            this.lstRoles.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 322);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Estado Actual:";
            // 
            // tvEstado
            // 
            this.tvEstado.Location = new System.Drawing.Point(19, 338);
            this.tvEstado.Name = "tvEstado";
            this.tvEstado.Size = new System.Drawing.Size(535, 126);
            this.tvEstado.TabIndex = 6;
            // 
            // ByRoleRB
            // 
            this.ByRoleRB.AutoSize = true;
            this.ByRoleRB.Location = new System.Drawing.Point(492, 470);
            this.ByRoleRB.Name = "ByRoleRB";
            this.ByRoleRB.Size = new System.Drawing.Size(60, 17);
            this.ByRoleRB.TabIndex = 66;
            this.ByRoleRB.Text = "Por Rol";
            this.ByRoleRB.UseVisualStyleBackColor = true;
            this.ByRoleRB.Click += new System.EventHandler(this.ByRoleRB_Click);
            // 
            // ByControlRB
            // 
            this.ByControlRB.AutoSize = true;
            this.ByControlRB.Checked = true;
            this.ByControlRB.Location = new System.Drawing.Point(413, 470);
            this.ByControlRB.Name = "ByControlRB";
            this.ByControlRB.Size = new System.Drawing.Size(77, 17);
            this.ByControlRB.TabIndex = 65;
            this.ByControlRB.TabStop = true;
            this.ByControlRB.Text = "Por Control";
            this.ByControlRB.UseVisualStyleBackColor = true;
            this.ByControlRB.CheckedChanged += new System.EventHandler(this.ByControlRB_CheckedChanged);
            // 
            // lstControles
            // 
            this.lstControles.FormattingEnabled = true;
            this.lstControles.Location = new System.Drawing.Point(7, 20);
            this.lstControles.Name = "lstControles";
            this.lstControles.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lstControles.Size = new System.Drawing.Size(266, 212);
            this.lstControles.Sorted = true;
            this.lstControles.TabIndex = 6;
            // 
            // frmGestionPermisos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 492);
            this.Controls.Add(this.ByRoleRB);
            this.Controls.Add(this.ByControlRB);
            this.Controls.Add(this.tvEstado);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbControles);
            this.Controls.Add(this.ddlPage);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "frmGestionPermisos";
            this.Text = "Administración de Permisos";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGestionPermisos_FormClosing);
            this.Load += new System.EventHandler(this.frmGestionPermisos_Load);
            this.gbControles.ResumeLayout(false);
            this.gbControles.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ddlPage;
        private System.Windows.Forms.GroupBox gbControles;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.CheckBox chkDisabled;
        private System.Windows.Forms.CheckBox chkInvisible;
        private System.Windows.Forms.ListBox lstRoles;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TreeView tvEstado;
        private System.Windows.Forms.RadioButton ByRoleRB;
        private System.Windows.Forms.RadioButton ByControlRB;
        private System.Windows.Forms.ListBox lstControles;

    }
}
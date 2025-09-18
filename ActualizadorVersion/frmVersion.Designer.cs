namespace ActualizadorVersion
{
    partial class frmVersion
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
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btAceptar = new System.Windows.Forms.Button();
            this.btCancelar = new System.Windows.Forms.Button();
            this.lblError = new System.Windows.Forms.Label();
            this.chkActualizarTodosProyectos = new System.Windows.Forms.CheckBox();
            this.scBase = new System.Windows.Forms.SplitContainer();
            this.tProyectos = new System.Windows.Forms.TreeView();
            ((System.ComponentModel.ISupportInitialize)(this.scBase)).BeginInit();
            this.scBase.Panel1.SuspendLayout();
            this.scBase.Panel2.SuspendLayout();
            this.scBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(30, 28);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(131, 20);
            this.txtVersion.TabIndex = 0;
            this.txtVersion.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtVersion_KeyPress);
            // 
            // lblVersion
            // 
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(27, 12);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(134, 13);
            this.lblVersion.TabIndex = 4;
            this.lblVersion.Text = "Introduce la nueva Versión";
            // 
            // btAceptar
            // 
            this.btAceptar.Location = new System.Drawing.Point(247, 9);
            this.btAceptar.Name = "btAceptar";
            this.btAceptar.Size = new System.Drawing.Size(64, 23);
            this.btAceptar.TabIndex = 2;
            this.btAceptar.Text = "Aceptar";
            this.btAceptar.UseVisualStyleBackColor = true;
            this.btAceptar.Click += new System.EventHandler(this.btAceptar_Click);
            // 
            // btCancelar
            // 
            this.btCancelar.Location = new System.Drawing.Point(180, 9);
            this.btCancelar.Name = "btCancelar";
            this.btCancelar.Size = new System.Drawing.Size(64, 23);
            this.btCancelar.TabIndex = 1;
            this.btCancelar.Text = "Cancelar";
            this.btCancelar.UseVisualStyleBackColor = true;
            this.btCancelar.Click += new System.EventHandler(this.btCancelar_Click);
            // 
            // lblError
            // 
            this.lblError.AutoSize = true;
            this.lblError.ForeColor = System.Drawing.Color.Red;
            this.lblError.Location = new System.Drawing.Point(177, 38);
            this.lblError.Name = "lblError";
            this.lblError.Size = new System.Drawing.Size(113, 13);
            this.lblError.TabIndex = 5;
            this.lblError.Text = "Error versión no Valida";
            this.lblError.Visible = false;
            // 
            // chkActualizarTodosProyectos
            // 
            this.chkActualizarTodosProyectos.AutoSize = true;
            this.chkActualizarTodosProyectos.Checked = true;
            this.chkActualizarTodosProyectos.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActualizarTodosProyectos.Location = new System.Drawing.Point(30, 54);
            this.chkActualizarTodosProyectos.Name = "chkActualizarTodosProyectos";
            this.chkActualizarTodosProyectos.Size = new System.Drawing.Size(166, 17);
            this.chkActualizarTodosProyectos.TabIndex = 6;
            this.chkActualizarTodosProyectos.Text = "Actualizar todos los proyectos";
            this.chkActualizarTodosProyectos.UseVisualStyleBackColor = true;
            this.chkActualizarTodosProyectos.CheckedChanged += new System.EventHandler(this.chkActualizarTodosProyectos_CheckedChanged);
            // 
            // scBase
            // 
            this.scBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scBase.IsSplitterFixed = true;
            this.scBase.Location = new System.Drawing.Point(0, 0);
            this.scBase.Name = "scBase";
            this.scBase.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // scBase.Panel1
            // 
            this.scBase.Panel1.Controls.Add(this.txtVersion);
            this.scBase.Panel1.Controls.Add(this.chkActualizarTodosProyectos);
            this.scBase.Panel1.Controls.Add(this.lblVersion);
            this.scBase.Panel1.Controls.Add(this.lblError);
            this.scBase.Panel1.Controls.Add(this.btAceptar);
            this.scBase.Panel1.Controls.Add(this.btCancelar);
            // 
            // scBase.Panel2
            // 
            this.scBase.Panel2.Controls.Add(this.tProyectos);
            this.scBase.Size = new System.Drawing.Size(311, 617);
            this.scBase.SplitterDistance = 79;
            this.scBase.TabIndex = 7;
            // 
            // tProyectos
            // 
            this.tProyectos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tProyectos.Location = new System.Drawing.Point(0, 0);
            this.tProyectos.Name = "tProyectos";
            this.tProyectos.Size = new System.Drawing.Size(311, 534);
            this.tProyectos.TabIndex = 0;
            // 
            // frmVersion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(311, 617);
            this.Controls.Add(this.scBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Name = "frmVersion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nueva Versión";
            this.scBase.Panel1.ResumeLayout(false);
            this.scBase.Panel1.PerformLayout();
            this.scBase.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.scBase)).EndInit();
            this.scBase.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.Button btAceptar;
        private System.Windows.Forms.Button btCancelar;
        private System.Windows.Forms.Label lblError;
        private System.Windows.Forms.CheckBox chkActualizarTodosProyectos;
        private System.Windows.Forms.SplitContainer scBase;
        private System.Windows.Forms.TreeView tProyectos;
    }
}
namespace Parte1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lsbResultado = new ListBox();
            btnVerCuentas = new Button();
            btnRestaurar = new Button();
            btnResguardar = new Button();
            btnImportarCuentas = new Button();
            btnExportarCuentas = new Button();
            SuspendLayout();
            // 
            // lsbResultado
            // 
            lsbResultado.BackColor = SystemColors.Window;
            lsbResultado.FormattingEnabled = true;
            lsbResultado.ItemHeight = 15;
            lsbResultado.Location = new Point(12, 12);
            lsbResultado.Name = "lsbResultado";
            lsbResultado.ScrollAlwaysVisible = true;
            lsbResultado.Size = new Size(446, 424);
            lsbResultado.TabIndex = 0;
            // 
            // btnVerCuentas
            // 
            btnVerCuentas.Location = new Point(476, 12);
            btnVerCuentas.Name = "btnVerCuentas";
            btnVerCuentas.Size = new Size(133, 55);
            btnVerCuentas.TabIndex = 1;
            btnVerCuentas.Text = "Ver Cuentas";
            btnVerCuentas.UseVisualStyleBackColor = true;
            // 
            // btnRestaurar
            // 
            btnRestaurar.Location = new Point(476, 381);
            btnRestaurar.Name = "btnRestaurar";
            btnRestaurar.Size = new Size(133, 55);
            btnRestaurar.TabIndex = 2;
            btnRestaurar.Text = "Restaurar(Restore)";
            btnRestaurar.UseVisualStyleBackColor = true;
            // 
            // btnResguardar
            // 
            btnResguardar.Location = new Point(476, 285);
            btnResguardar.Name = "btnResguardar";
            btnResguardar.Size = new Size(133, 55);
            btnResguardar.TabIndex = 3;
            btnResguardar.Text = "Resguardad (Backup)";
            btnResguardar.UseVisualStyleBackColor = true;
            // 
            // btnImportarCuentas
            // 
            btnImportarCuentas.Location = new Point(476, 100);
            btnImportarCuentas.Name = "btnImportarCuentas";
            btnImportarCuentas.Size = new Size(133, 55);
            btnImportarCuentas.TabIndex = 4;
            btnImportarCuentas.Text = "Importar Cuentas";
            btnImportarCuentas.UseVisualStyleBackColor = true;
            btnImportarCuentas.Click += btnImportarCuentas_Click;
            // 
            // btnExportarCuentas
            // 
            btnExportarCuentas.Location = new Point(476, 190);
            btnExportarCuentas.Name = "btnExportarCuentas";
            btnExportarCuentas.Size = new Size(133, 55);
            btnExportarCuentas.TabIndex = 5;
            btnExportarCuentas.Text = "Exportar Cuentas";
            btnExportarCuentas.UseVisualStyleBackColor = true;
            btnExportarCuentas.Click += btnExportarCuentas_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(626, 450);
            Controls.Add(btnExportarCuentas);
            Controls.Add(btnImportarCuentas);
            Controls.Add(btnResguardar);
            Controls.Add(btnRestaurar);
            Controls.Add(btnVerCuentas);
            Controls.Add(lsbResultado);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ejercicio 1";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private ListBox lsbResultado;
        private Button btnVerCuentas;
        private Button btnRestaurar;
        private Button btnResguardar;
        private Button btnImportarCuentas;
        private Button btnExportarCuentas;
    }
}

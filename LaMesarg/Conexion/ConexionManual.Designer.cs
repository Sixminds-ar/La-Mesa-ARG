namespace LaMesarg.Conexion
{
    partial class ConexionManual
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
            this.Texto1 = new System.Windows.Forms.Label();
            this.Texto2 = new System.Windows.Forms.Label();
            this.Boton = new System.Windows.Forms.Button();
            this.cajatexto = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Texto1
            // 
            this.Texto1.AutoSize = true;
            this.Texto1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Texto1.Location = new System.Drawing.Point(49, 40);
            this.Texto1.Name = "Texto1";
            this.Texto1.Size = new System.Drawing.Size(316, 20);
            this.Texto1.TabIndex = 0;
            this.Texto1.Text = "Ingrese la cadena de conexion LOCAL";
            this.Texto1.Click += new System.EventHandler(this.Texto1_Click);
            // 
            // Texto2
            // 
            this.Texto2.AutoSize = true;
            this.Texto2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Texto2.Location = new System.Drawing.Point(9, 88);
            this.Texto2.Name = "Texto2";
            this.Texto2.Size = new System.Drawing.Size(530, 26);
            this.Texto2.TabIndex = 1;
            this.Texto2.Text = "Una vez que estes listo dale a \"Generar cadena de conexion\", se creara un Archivo" +
    " qu tu conexion Encryptada.\r\n Ahora tu conexion es mas Segura ante Posibles hack" +
    "ers";
            this.Texto2.Click += new System.EventHandler(this.label2_Click);
            // 
            // Boton
            // 
            this.Boton.BackColor = System.Drawing.Color.DarkGreen;
            this.Boton.FlatAppearance.BorderSize = 0;
            this.Boton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Boton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Boton.ForeColor = System.Drawing.Color.White;
            this.Boton.Location = new System.Drawing.Point(97, 214);
            this.Boton.Name = "Boton";
            this.Boton.Size = new System.Drawing.Size(423, 53);
            this.Boton.TabIndex = 3;
            this.Boton.Text = "GENERAR CADENA DE CONEXION";
            this.Boton.UseVisualStyleBackColor = false;
            this.Boton.Click += new System.EventHandler(this.Boton_Click);
            // 
            // cajatexto
            // 
            this.cajatexto.Location = new System.Drawing.Point(28, 141);
            this.cajatexto.Multiline = true;
            this.cajatexto.Name = "cajatexto";
            this.cajatexto.Size = new System.Drawing.Size(525, 37);
            this.cajatexto.TabIndex = 4;
            this.cajatexto.TextChanged += new System.EventHandler(this.cajatexto_TextChanged_1);
            // 
            // ConexionManual
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(654, 293);
            this.Controls.Add(this.cajatexto);
            this.Controls.Add(this.Boton);
            this.Controls.Add(this.Texto2);
            this.Controls.Add(this.Texto1);
            this.Name = "ConexionManual";
            this.Text = "Conexion Manual";
            this.Load += new System.EventHandler(this.ConexionManual_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Texto1;
        private System.Windows.Forms.Label Texto2;
        private System.Windows.Forms.Button Boton;
        private System.Windows.Forms.TextBox cajatexto;
    }
}
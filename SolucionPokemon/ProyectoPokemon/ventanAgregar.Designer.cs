namespace ProyectoPokemon
{
    partial class ventanAgregar
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
            this.tboxNumero = new System.Windows.Forms.TextBox();
            this.tboxNombre = new System.Windows.Forms.TextBox();
            this.tboxDescripcion = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.cboxTipo = new System.Windows.Forms.ComboBox();
            this.cboxDebilidad = new System.Windows.Forms.ComboBox();
            this.pboxImagenAgregar = new System.Windows.Forms.PictureBox();
            this.lblUrlImagen = new System.Windows.Forms.Label();
            this.tboxUrlImagen = new System.Windows.Forms.TextBox();
            this.btnCargarImagen = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pboxImagenAgregar)).BeginInit();
            this.SuspendLayout();
            // 
            // tboxNumero
            // 
            this.tboxNumero.Location = new System.Drawing.Point(108, 32);
            this.tboxNumero.Name = "tboxNumero";
            this.tboxNumero.Size = new System.Drawing.Size(121, 20);
            this.tboxNumero.TabIndex = 0;
            // 
            // tboxNombre
            // 
            this.tboxNombre.Location = new System.Drawing.Point(108, 58);
            this.tboxNombre.Name = "tboxNombre";
            this.tboxNombre.Size = new System.Drawing.Size(121, 20);
            this.tboxNombre.TabIndex = 1;
            // 
            // tboxDescripcion
            // 
            this.tboxDescripcion.Location = new System.Drawing.Point(108, 84);
            this.tboxDescripcion.Name = "tboxDescripcion";
            this.tboxDescripcion.Size = new System.Drawing.Size(121, 20);
            this.tboxDescripcion.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(37, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Numero";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nombre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "Descripcion";
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(40, 213);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 6;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(140, 213);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 7;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(53, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(28, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Tipo";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 167);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Debilidad";
            // 
            // cboxTipo
            // 
            this.cboxTipo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTipo.FormattingEnabled = true;
            this.cboxTipo.Location = new System.Drawing.Point(108, 137);
            this.cboxTipo.Name = "cboxTipo";
            this.cboxTipo.Size = new System.Drawing.Size(121, 21);
            this.cboxTipo.TabIndex = 4;
            // 
            // cboxDebilidad
            // 
            this.cboxDebilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxDebilidad.FormattingEnabled = true;
            this.cboxDebilidad.Location = new System.Drawing.Point(108, 164);
            this.cboxDebilidad.Name = "cboxDebilidad";
            this.cboxDebilidad.Size = new System.Drawing.Size(121, 21);
            this.cboxDebilidad.TabIndex = 5;
            // 
            // pboxImagenAgregar
            // 
            this.pboxImagenAgregar.Location = new System.Drawing.Point(285, 32);
            this.pboxImagenAgregar.Name = "pboxImagenAgregar";
            this.pboxImagenAgregar.Size = new System.Drawing.Size(174, 153);
            this.pboxImagenAgregar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pboxImagenAgregar.TabIndex = 14;
            this.pboxImagenAgregar.TabStop = false;
            // 
            // lblUrlImagen
            // 
            this.lblUrlImagen.AutoSize = true;
            this.lblUrlImagen.Location = new System.Drawing.Point(18, 114);
            this.lblUrlImagen.Name = "lblUrlImagen";
            this.lblUrlImagen.Size = new System.Drawing.Size(58, 13);
            this.lblUrlImagen.TabIndex = 10;
            this.lblUrlImagen.Text = "Url Imagen";
            // 
            // tboxUrlImagen
            // 
            this.tboxUrlImagen.Location = new System.Drawing.Point(108, 111);
            this.tboxUrlImagen.Name = "tboxUrlImagen";
            this.tboxUrlImagen.Size = new System.Drawing.Size(121, 20);
            this.tboxUrlImagen.TabIndex = 3;
            this.tboxUrlImagen.Leave += new System.EventHandler(this.tboxUrlImagen_Leave);
            // 
            // btnCargarImagen
            // 
            this.btnCargarImagen.Location = new System.Drawing.Point(235, 111);
            this.btnCargarImagen.Name = "btnCargarImagen";
            this.btnCargarImagen.Size = new System.Drawing.Size(18, 20);
            this.btnCargarImagen.TabIndex = 15;
            this.btnCargarImagen.Text = "¬";
            this.btnCargarImagen.UseVisualStyleBackColor = true;
            this.btnCargarImagen.Click += new System.EventHandler(this.btnCargarImagen_Click);
            // 
            // ventanAgregar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 262);
            this.Controls.Add(this.btnCargarImagen);
            this.Controls.Add(this.lblUrlImagen);
            this.Controls.Add(this.tboxUrlImagen);
            this.Controls.Add(this.pboxImagenAgregar);
            this.Controls.Add(this.cboxDebilidad);
            this.Controls.Add(this.cboxTipo);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tboxDescripcion);
            this.Controls.Add(this.tboxNombre);
            this.Controls.Add(this.tboxNumero);
            this.MaximizeBox = false;
            this.Name = "ventanAgregar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.ventanAgregar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pboxImagenAgregar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tboxNumero;
        private System.Windows.Forms.TextBox tboxNombre;
        private System.Windows.Forms.TextBox tboxDescripcion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboxTipo;
        private System.Windows.Forms.ComboBox cboxDebilidad;
        private System.Windows.Forms.PictureBox pboxImagenAgregar;
        private System.Windows.Forms.Label lblUrlImagen;
        private System.Windows.Forms.TextBox tboxUrlImagen;
        private System.Windows.Forms.Button btnCargarImagen;
    }
}
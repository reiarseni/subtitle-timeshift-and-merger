namespace WindowsFormsApplication4
{
    partial class FormularioPpal
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tb_str_es = new System.Windows.Forms.TextBox();
            this.tb_srt_en = new System.Windows.Forms.TextBox();
            this.abrirDialogoFichero = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.rtb_srt_es = new System.Windows.Forms.RichTextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.maskedTextBoxCorreccion = new System.Windows.Forms.MaskedTextBox();
            this.btn_salvar = new System.Windows.Forms.Button();
            this.btn_load_en = new System.Windows.Forms.Button();
            this.rtb_srt_en = new System.Windows.Forms.RichTextBox();
            this.btn_load_es = new System.Windows.Forms.Button();
            this.rtb_srt_result = new System.Windows.Forms.RichTextBox();
            this.btn_modif_tiempos_mas = new System.Windows.Forms.Button();
            this.btn_modif_tiempos_menos = new System.Windows.Forms.Button();
            this.btn_unir = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tb_str_es
            // 
            this.tb_str_es.Location = new System.Drawing.Point(3, 9);
            this.tb_str_es.Name = "tb_str_es";
            this.tb_str_es.Size = new System.Drawing.Size(468, 20);
            this.tb_str_es.TabIndex = 1;
            // 
            // tb_srt_en
            // 
            this.tb_srt_en.Location = new System.Drawing.Point(3, 156);
            this.tb_srt_en.Name = "tb_srt_en";
            this.tb_srt_en.Size = new System.Drawing.Size(468, 20);
            this.tb_srt_en.TabIndex = 2;
            // 
            // abrirDialogoFichero
            // 
            this.abrirDialogoFichero.FileName = "openFileDialog1";
            // 
            // rtb_srt_es
            // 
            this.rtb_srt_es.Location = new System.Drawing.Point(3, 36);
            this.rtb_srt_es.Name = "rtb_srt_es";
            this.rtb_srt_es.Size = new System.Drawing.Size(468, 114);
            this.rtb_srt_es.TabIndex = 6;
            this.rtb_srt_es.Text = "";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // maskedTextBoxCorreccion
            // 
            this.maskedTextBoxCorreccion.Location = new System.Drawing.Point(477, 50);
            this.maskedTextBoxCorreccion.Mask = "00:00:000";
            this.maskedTextBoxCorreccion.Name = "maskedTextBoxCorreccion";
            this.maskedTextBoxCorreccion.Size = new System.Drawing.Size(83, 20);
            this.maskedTextBoxCorreccion.TabIndex = 13;
            this.maskedTextBoxCorreccion.Text = "0000000";
            // 
            // btn_salvar
            // 
            this.btn_salvar.Location = new System.Drawing.Point(477, 302);
            this.btn_salvar.Name = "btn_salvar";
            this.btn_salvar.Size = new System.Drawing.Size(80, 114);
            this.btn_salvar.TabIndex = 15;
            this.btn_salvar.Text = "Salvar Subtitulos";
            this.btn_salvar.UseVisualStyleBackColor = true;
            this.btn_salvar.Click += new System.EventHandler(this.btn_salvar_Click);
            // 
            // btn_load_en
            // 
            this.btn_load_en.Location = new System.Drawing.Point(477, 156);
            this.btn_load_en.Name = "btn_load_en";
            this.btn_load_en.Size = new System.Drawing.Size(80, 24);
            this.btn_load_en.TabIndex = 16;
            this.btn_load_en.Text = "Cargar EN";
            this.btn_load_en.UseVisualStyleBackColor = true;
            this.btn_load_en.Click += new System.EventHandler(this.btn_load_en_Click);
            // 
            // rtb_srt_en
            // 
            this.rtb_srt_en.Location = new System.Drawing.Point(3, 182);
            this.rtb_srt_en.Name = "rtb_srt_en";
            this.rtb_srt_en.Size = new System.Drawing.Size(468, 114);
            this.rtb_srt_en.TabIndex = 17;
            this.rtb_srt_en.Text = "";
            // 
            // btn_load_es
            // 
            this.btn_load_es.Location = new System.Drawing.Point(477, 6);
            this.btn_load_es.Name = "btn_load_es";
            this.btn_load_es.Size = new System.Drawing.Size(83, 23);
            this.btn_load_es.TabIndex = 18;
            this.btn_load_es.Text = "Cargar ES";
            this.btn_load_es.UseVisualStyleBackColor = true;
            this.btn_load_es.Click += new System.EventHandler(this.btn_load_es_Click);
            // 
            // rtb_srt_result
            // 
            this.rtb_srt_result.Location = new System.Drawing.Point(3, 302);
            this.rtb_srt_result.Name = "rtb_srt_result";
            this.rtb_srt_result.Size = new System.Drawing.Size(468, 114);
            this.rtb_srt_result.TabIndex = 19;
            this.rtb_srt_result.Text = "";
            // 
            // btn_modif_tiempos_mas
            // 
            this.btn_modif_tiempos_mas.Location = new System.Drawing.Point(477, 96);
            this.btn_modif_tiempos_mas.Name = "btn_modif_tiempos_mas";
            this.btn_modif_tiempos_mas.Size = new System.Drawing.Size(38, 43);
            this.btn_modif_tiempos_mas.TabIndex = 21;
            this.btn_modif_tiempos_mas.Text = "+";
            this.btn_modif_tiempos_mas.UseVisualStyleBackColor = true;
            this.btn_modif_tiempos_mas.Click += new System.EventHandler(this.btn_modif_tiempos_mas_Click);
            // 
            // btn_modif_tiempos_menos
            // 
            this.btn_modif_tiempos_menos.Location = new System.Drawing.Point(518, 96);
            this.btn_modif_tiempos_menos.Name = "btn_modif_tiempos_menos";
            this.btn_modif_tiempos_menos.Size = new System.Drawing.Size(39, 43);
            this.btn_modif_tiempos_menos.TabIndex = 23;
            this.btn_modif_tiempos_menos.Text = "-";
            this.btn_modif_tiempos_menos.UseVisualStyleBackColor = true;
            this.btn_modif_tiempos_menos.Click += new System.EventHandler(this.btn_modif_tiempos_menos_Click);
            // 
            // btn_unir
            // 
            this.btn_unir.Location = new System.Drawing.Point(477, 182);
            this.btn_unir.Name = "btn_unir";
            this.btn_unir.Size = new System.Drawing.Size(80, 114);
            this.btn_unir.TabIndex = 24;
            this.btn_unir.Text = "Unir";
            this.btn_unir.UseVisualStyleBackColor = true;
            this.btn_unir.Click += new System.EventHandler(this.btn_unir_Click);
            // 
            // FormularioPpal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 423);
            this.Controls.Add(this.btn_unir);
            this.Controls.Add(this.btn_modif_tiempos_menos);
            this.Controls.Add(this.btn_modif_tiempos_mas);
            this.Controls.Add(this.rtb_srt_result);
            this.Controls.Add(this.btn_load_es);
            this.Controls.Add(this.rtb_srt_en);
            this.Controls.Add(this.btn_load_en);
            this.Controls.Add(this.btn_salvar);
            this.Controls.Add(this.maskedTextBoxCorreccion);
            this.Controls.Add(this.rtb_srt_es);
            this.Controls.Add(this.tb_srt_en);
            this.Controls.Add(this.tb_str_es);
            this.Name = "FormularioPpal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Subtítulos en 2 Idiomas";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_str_es;
        private System.Windows.Forms.TextBox tb_srt_en;
        private System.Windows.Forms.OpenFileDialog abrirDialogoFichero;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.RichTextBox rtb_srt_es;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.MaskedTextBox maskedTextBoxCorreccion;
        private System.Windows.Forms.Button btn_salvar;
        private System.Windows.Forms.Button btn_load_en;
        private System.Windows.Forms.RichTextBox rtb_srt_en;
        private System.Windows.Forms.Button btn_load_es;
        private System.Windows.Forms.RichTextBox rtb_srt_result;
        private System.Windows.Forms.Button btn_modif_tiempos_mas;
        private System.Windows.Forms.Button btn_modif_tiempos_menos;
        private System.Windows.Forms.Button btn_unir;
    }
}


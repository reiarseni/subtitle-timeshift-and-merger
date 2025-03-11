using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Text;

namespace WindowsFormsApplication4
{
    public partial class FormularioPpal : Form
    {
        // Rutas de archivos
        private string rutaSubtitulosEspanol = "";
        private string rutaSubtitulosIngles = "";
        private string rutaArchivoSalida = "C:\\Subtitulos\\SALIDA.srt";

        // Constantes para el formato
        private const string FORMATO_TIEMPO = "{0}:{1}:{2},{3}";
        private const string PATRON_TIEMPO = " --> ";

        // Lista de subtítulos
        private List<Subtitulo> listaSubtitulos = new List<Subtitulo>();

        // Tiempo a sumar o restar
        private int minutosAjuste = 0, segundosAjuste = 0, milisegundosAjuste = 0;

        public FormularioPpal()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Carga el archivo de subtítulos en español
        /// </summary>
        private void btn_load_es_Click(object sender, EventArgs e)
        {
            // Initialize the OpenFileDialog to look for SRT files.
            abrirDialogoFichero.DefaultExt = "*.srt";
            abrirDialogoFichero.Filter = "SRT Files|*.srt|All files (*.*)|*.*";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (abrirDialogoFichero.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               abrirDialogoFichero.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtb_srt_es.LoadFile(abrirDialogoFichero.FileName, RichTextBoxStreamType.PlainText);
                tb_str_es.Text = abrirDialogoFichero.FileName;
                rutaSubtitulosEspanol = tb_str_es.Text;
            }
        }

        /// <summary>
        /// Carga el archivo de subtítulos en inglés
        /// </summary>
        private void btn_load_en_Click(object sender, EventArgs e)
        {
            // Initialize the OpenFileDialog to look for SRT files.
            abrirDialogoFichero.DefaultExt = "*.srt";
            abrirDialogoFichero.Filter = "SRT Files|*.srt|All files (*.*)|*.*";

            // Determine whether the user selected a file from the OpenFileDialog. 
            if (abrirDialogoFichero.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               abrirDialogoFichero.FileName.Length > 0)
            {
                // Load the contents of the file into the RichTextBox.
                rtb_srt_en.LoadFile(abrirDialogoFichero.FileName, RichTextBoxStreamType.PlainText);
                tb_srt_en.Text = abrirDialogoFichero.FileName;
                rutaSubtitulosIngles = tb_srt_en.Text;
            }
        }

        /// <summary>
        /// Guarda el archivo de subtítulos procesado
        /// </summary>
        private void btn_salvar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(rutaArchivoSalida))
            {
                MessageBox.Show("La ruta de salida no está definida", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            rtb_srt_es.SaveFile(rutaArchivoSalida, RichTextBoxStreamType.PlainText);
        }

        /// <summary>
        /// Ajusta los tiempos de los subtítulos sumando el tiempo especificado
        /// </summary>
        private void btn_modif_tiempos_mas_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rutaSubtitulosEspanol) || !File.Exists(rutaSubtitulosEspanol))
            {
                MessageBox.Show("Debe cargar primero un archivo de subtítulos en español", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarTiempoCorreccion(1);
            corregirSubtitulosSRT();

            // Cargo el fichero modificado
            rtb_srt_result.LoadFile(rutaArchivoSalida, RichTextBoxStreamType.PlainText);
            rtb_srt_result.Update();
        }

        /// <summary>
        /// Ajusta los tiempos de los subtítulos restando el tiempo especificado
        /// </summary>
        private void btn_modif_tiempos_menos_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(rutaSubtitulosEspanol) || !File.Exists(rutaSubtitulosEspanol))
            {
                MessageBox.Show("Debe cargar primero un archivo de subtítulos en español", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            cargarTiempoCorreccion(-1);
            corregirSubtitulosSRT();

            // Cargo el fichero modificado
            rtb_srt_result.LoadFile(rutaArchivoSalida, RichTextBoxStreamType.PlainText);
            rtb_srt_result.Update();
        }

        /// <summary>
        /// Carga el tiempo de corrección desde la interfaz
        /// </summary>
        /// <param name="signo">1 para sumar, -1 para restar</param>
        /// <returns>True si los valores son válidos, false en caso contrario</returns>
        public bool cargarTiempoCorreccion(int signo)
        {
            try
            {
                minutosAjuste = int.Parse(maskedTextBoxCorreccion.Text.Substring(0, 2)) * signo;
                segundosAjuste = int.Parse(maskedTextBoxCorreccion.Text.Substring(3, 2)) * signo;
                milisegundosAjuste = int.Parse(maskedTextBoxCorreccion.Text.Substring(6, 3)) * signo;

                return (minutosAjuste <= 59 && segundosAjuste <= 59);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al procesar el tiempo de corrección: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /// <summary>
        /// Corrige los tiempos de los subtítulos en el archivo SRT
        /// </summary>
        public void corregirSubtitulosSRT()
        {
            try
            {
                System.Text.Encoding encoding = System.Text.Encoding.Default;
                
                using (StreamReader streamReader = new StreamReader(rutaSubtitulosEspanol, encoding))
                using (StreamWriter streamWriter = new StreamWriter(rutaArchivoSalida, false, encoding))
                {
                    string linea;
                    while ((linea = streamReader.ReadLine()) != null)
                    {
                        streamWriter.WriteLine(CorregirLineaSRT(linea));
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error al corregir subtítulos: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {exc.Message}\nDetalles: {exc.StackTrace}");
            }
        }

        /// <summary>
        /// Corrige una línea SRT si contiene marcas de tiempo
        /// </summary>
        /// <param name="linea">Línea de texto del archivo SRT</param>
        /// <returns>Línea corregida con los tiempos ajustados</returns>
        public string CorregirLineaSRT(string linea)
        {
            string lineaCorregida;

            // Determino si la linea tiene formato de tiempo (00:00:00,000 --> 00:00:00,000)
            if ((linea.IndexOf(":", 0) == 2) && (linea.IndexOf(" --> ", 0) == 12))
            {
                int horasInicio = 0, minutosInicio = 0, segundosInicio = 0, milisegundosInicio = 0;
                int horasFin = 0, minutosFin = 0, segundosFin = 0, milisegundosFin = 0;

                string fechaInicio, fechaFin;

                // Extraer componentes de tiempo inicial
                horasInicio = int.Parse(linea.Substring(0, 2));
                minutosInicio = int.Parse(linea.Substring(3, 2));
                segundosInicio = int.Parse(linea.Substring(6, 2));
                milisegundosInicio = int.Parse(linea.Substring(9, 3));

                // Ajustar tiempo inicial
                fechaInicio = sumarTiempo(horasInicio, minutosInicio, segundosInicio, milisegundosInicio);

                // Extraer componentes de tiempo final
                horasFin = int.Parse(linea.Substring(17, 2));
                minutosFin = int.Parse(linea.Substring(20, 2));
                segundosFin = int.Parse(linea.Substring(23, 2));
                milisegundosFin = int.Parse(linea.Substring(26, 3));

                // Ajustar tiempo final
                fechaFin = sumarTiempo(horasFin, minutosFin, segundosFin, milisegundosFin);

                // Formar la nueva línea de tiempo
                lineaCorregida = string.Format("{0} --> {1}", fechaInicio, fechaFin);
            }
            else
            {
                // No es una línea de tiempo, la devolvemos sin cambios
                lineaCorregida = linea;
            }

            return lineaCorregida;
        }

        /// <summary>
        /// Suma o resta un tiempo a una marca de tiempo
        /// </summary>
        /// <param name="horas">Horas</param>
        /// <param name="minutos">Minutos</param>
        /// <param name="segundos">Segundos</param>
        /// <param name="milisegundos">Milisegundos</param>
        /// <returns>Marca de tiempo ajustada en formato HH:MM:SS,mmm</returns>
        public string sumarTiempo(int horas, int minutos, int segundos, int milisegundos)
        {
            string horasStr = "", minutosStr = "", segundosStr = "", milisegundosStr = "";
            int acarreo = 0;

            // Ajustar milisegundos
            milisegundos += milisegundosAjuste;
            if (milisegundos > 999)
            {
                milisegundos = milisegundos - 1000;
                acarreo = 1;
            }
            else if (milisegundos < 0)
            {
                milisegundos = 1000 + milisegundos;
                acarreo = -1;
            }
            
            // Formatear milisegundos a string con 3 dígitos
            milisegundosStr = milisegundos.ToString().PadLeft(3, '0');

            // Ajustar segundos
            segundos += segundosAjuste + acarreo;
            acarreo = 0;
            if (segundos > 59)
            {
                segundos -= 60;
                acarreo = 1;
            }
            else if (segundos < 0)
            {
                segundos = 60 + segundos;
                acarreo = -1;
            }
            
            // Formatear segundos a string con 2 dígitos
            segundosStr = segundos.ToString().PadLeft(2, '0');

            // Ajustar minutos
            minutos += minutosAjuste + acarreo;
            acarreo = 0;
            if (minutos > 59)
            {
                minutos -= 60;
                acarreo = 1;
            }
            else if (minutos < 0)
            {
                minutos = 60 + minutos;
                acarreo = -1;
            }
            
            // Formatear minutos a string con 2 dígitos
            minutosStr = minutos.ToString().PadLeft(2, '0');

            // Ajustar horas (solo añadimos acarreo)
            horas += acarreo;
            
            // Formatear horas a string con 2 dígitos
            horasStr = horas.ToString().PadLeft(2, '0');

            return string.Format(FORMATO_TIEMPO, horasStr, minutosStr, segundosStr, milisegundosStr);
        }

        /// <summary>
        /// Une los subtítulos de dos archivos SRT (español e inglés) en uno solo
        /// </summary>
        private void btn_unir_Click(object sender, EventArgs e)
        {
            // Validar que existan los archivos de entrada
            if (string.IsNullOrWhiteSpace(rutaSubtitulosEspanol) || !File.Exists(rutaSubtitulosEspanol))
            {
                MessageBox.Show("Debe cargar primero un archivo de subtítulos en español", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(rutaSubtitulosIngles) || !File.Exists(rutaSubtitulosIngles))
            {
                MessageBox.Show("Debe cargar primero un archivo de subtítulos en inglés", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                // Limpiar la lista antes de procesarla de nuevo
                listaSubtitulos.Clear();
                System.Text.Encoding encoding = System.Text.Encoding.Default;
         
                // Procesar archivo de subtítulos en español
                procesarArchivoSubtitulos(rutaSubtitulosEspanol, encoding);
                
                // Procesar archivo de subtítulos en inglés
                procesarArchivoSubtitulos(rutaSubtitulosIngles, encoding);

                // Ordenar la lista de subtítulos por tiempo
                listaSubtitulos.Sort();
                
                // Escribir archivo de salida
                escribirArchivoSubtitulosUnificado(encoding);
                
                // Cargar el resultado en el control
                rtb_srt_result.LoadFile(rutaArchivoSalida, RichTextBoxStreamType.PlainText);
                rtb_srt_result.Update();
            }
            catch (Exception exc)
            {
                MessageBox.Show($"Error al unir subtítulos: {exc.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Console.WriteLine($"Error: {exc.Message}\nDetalles: {exc.StackTrace}");
            }
        }
        
        /// <summary>
        /// Procesa un archivo de subtítulos y lo añade a la lista
        /// </summary>
        /// <param name="rutaArchivo">Ruta al archivo de subtítulos</param>
        /// <param name="encoding">Codificación del archivo</param>
        private void procesarArchivoSubtitulos(string rutaArchivo, System.Text.Encoding encoding)
        {
            using (StreamReader streamReader = new StreamReader(rutaArchivo, encoding))
            {
                string linea;
                Subtitulo subtitulo = new Subtitulo();
                
                while ((linea = streamReader.ReadLine()) != null)
                {
                    // Ignorar líneas vacías
                    if (string.IsNullOrWhiteSpace(linea))
                    {
                        continue;
                    }
                    
                    // Verificar si es una línea de tiempo
                    if ((linea.IndexOf(":", 0) == 2) && (linea.IndexOf(" --> ", 0) == 12))
                    {
                        // Si hay un subtítulo en proceso, guardarlo
                        if (!subtitulo.vacio)
                        {
                            subtitulo.numeroLineas--; // Eliminar la línea de numeración
                            listaSubtitulos.Add(subtitulo);
                        }

                        // Crear nuevo subtítulo
                        subtitulo = new Subtitulo();
                        subtitulo.marcaTiempo = linea;
                        subtitulo.numeroLineas = 0;
                        
                        // Extraer componentes de tiempo para ordenamiento
                        string horas = linea.Substring(0, 2);
                        string minutos = linea.Substring(3, 2);
                        string segundos = linea.Substring(6, 2);
                        string milisegundos = linea.Substring(9, 3);
                        
                        // Calcular orden numérico para ordenamiento
                        subtitulo.orden = int.Parse(horas + minutos + segundos + milisegundos);
                        subtitulo.vacio = false;
                    }
                    else 
                    {
                        // Añadir línea de texto al subtítulo actual
                        if (subtitulo.numeroLineas == 0)
                        {
                            subtitulo.linea1 = linea;
                        }
                        else if (subtitulo.numeroLineas == 1)
                        {
                            subtitulo.linea2 = linea;
                        }
                        else if (subtitulo.numeroLineas == 2)
                        {
                            subtitulo.linea3 = linea;
                        }
                        else if (subtitulo.numeroLineas == 3)
                        {
                            subtitulo.linea4 = linea;
                        }
                        else if (subtitulo.numeroLineas == 4)
                        {
                            subtitulo.linea5 = linea;
                        }
                        subtitulo.numeroLineas++;
                    }
                }
                
                // Añadir el último subtítulo si existe
                if (!subtitulo.vacio)
                {
                    subtitulo.numeroLineas--; // Eliminar la línea de numeración
                    listaSubtitulos.Add(subtitulo);
                }
            }
        }
        
        /// <summary>
        /// Escribe un archivo SRT unificado con todos los subtítulos
        /// </summary>
        /// <param name="encoding">Codificación del archivo</param>
        private void escribirArchivoSubtitulosUnificado(System.Text.Encoding encoding)
        {
            using (StreamWriter streamWriter = new StreamWriter(rutaArchivoSalida, false, encoding))
            {
                // Escribir al fichero resultado
                for (int index = 0; index < listaSubtitulos.Count; index++)
                {
                    Subtitulo subtitulo = listaSubtitulos.ElementAt(index);

                    // Escribir número de subtítulo
                    streamWriter.WriteLine(index + 1);
                    
                    // Escribir marca de tiempo
                    streamWriter.WriteLine(subtitulo.marcaTiempo);
                    
                    // Escribir líneas de texto
                    if (subtitulo.numeroLineas >= 1)
                    {
                        streamWriter.WriteLine(subtitulo.linea1);
                    }
                    if (subtitulo.numeroLineas >= 2)
                    {
                        streamWriter.WriteLine(subtitulo.linea2);
                    }
                    if (subtitulo.numeroLineas >= 3)
                    {
                        streamWriter.WriteLine(subtitulo.linea3);
                    }
                    if (subtitulo.numeroLineas >= 4)
                    {
                        streamWriter.WriteLine(subtitulo.linea4);
                    }
                    if (subtitulo.numeroLineas >= 5)
                    {
                        streamWriter.WriteLine(subtitulo.linea5);
                    }
           
                    // Línea en blanco entre subtítulos
                    streamWriter.WriteLine();
                }
            }
        }
    }

    /// <summary>
    /// Representa un subtítulo con su marca de tiempo y contenido
    /// </summary>
    public class Subtitulo : IComparable
    {
        public bool vacio = true;
        public int orden;
        public string marcaTiempo;
        public int numeroLineas = 0;
        public string linea1 = "";
        public string linea2 = "";
        public string linea3 = "";
        public string linea4 = "";
        public string linea5 = "";

        /// <summary>
        /// Compara subtítulos por su orden (basado en tiempo) para ordenarlos cronológicamente
        /// </summary>
        int IComparable.CompareTo(object obj)
        {
            Subtitulo otroSubtitulo = (Subtitulo)obj;

            if (otroSubtitulo.orden > this.orden)
            {
                return -1;
            }
            else if (otroSubtitulo.orden == this.orden)
            {
                return 0;
            }

            return 1;
        }
    }
}

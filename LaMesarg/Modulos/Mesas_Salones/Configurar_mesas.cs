using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LaMesarg.Modulos.Mesas_Salones
{
    public partial class Configurar_mesas : Form
    {
        int id_salon;
        string estado;
        public static string nombre_mesa;
       public static int idmesa;
        public Configurar_mesas()
        {
            InitializeComponent();
        }

        private void Configurar_mesas_Load(object sender, EventArgs e)
        {
            PanelBienvenida.Dock = DockStyle.Fill;
            dibujarsalones();
        }

        private void dibujarMESAS()
        {
            try
            {
                PanelMesas.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_mesas_por_salon", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id_Salon", id_salon);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panel = new Panel();
                    int alto = Convert.ToInt32(rdr["y"].ToString());
                    int ancho = Convert.ToInt32(rdr["x"].ToString());
                    int tamanio_letra = Convert.ToInt32(rdr["Tamanio_letra"].ToString());
                    Point tamanio = new Point(ancho, alto);

                    panel.BackgroundImage = Properties.Resources.mesa_vacia;
                    panel.BackgroundImageLayout = ImageLayout.Zoom;
                    panel.Cursor = Cursors.Hand;
                    panel.Tag = rdr["Id_Mesa"].ToString();
                    panel.Size = new System.Drawing.Size(tamanio);

                    b.Text = rdr["Mesa"].ToString();
                    b.Name = rdr["Id_Mesa"].ToString();

                    if(b.Text != "NULO")
                    {
                        b.Size = new System.Drawing.Size(tamanio);
                        b.BackColor = Color.FromArgb(5, 179, 90);
                        b.Font = new System.Drawing.Font("Microsoft Sans Serif", tamanio_letra);
                        b.FlatStyle = FlatStyle.Flat;
                        b.FlatAppearance.BorderSize = 0;
                        b.ForeColor = Color.White;
                        PanelMesas.Controls.Add(b);
                    }
                    else
                    {
                        PanelMesas.Controls.Add(panel);
                    }
                    b.Click += new EventHandler(miEvento);
                    panel.Click += new EventHandler(miEventopanel_click);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
            
        }
        private void miEvento (System.Object sender, EventArgs e)
        {
            nombre_mesa = ((Button)sender).Text;
            idmesa =Convert.ToInt32 (((Button)sender).Name);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();
            frm.FormClosed += new FormClosedEventHandler(frm_agregar_mesa_FormClosed);
            frm.ShowDialog();
        }
        private void miEventopanel_click(System.Object sender, EventArgs e)
        {
            idmesa = Convert.ToInt32(((Panel)sender).Tag);
            Agregar_mesa_ok frm = new Agregar_mesa_ok();

            frm.FormClosed += new FormClosedEventHandler(frm_agregar_mesa_FormClosed);

            frm.ShowDialog();
        }

        private void frm_agregar_mesa_FormClosed(object sender, FormClosedEventArgs e)
        {
            dibujarMESAS();
        }

        private void dibujarsalones()
        {
            try
            {
                flowLayoutPanel1.Controls.Clear();
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("mostrar_SALON", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@buscar", txtsalon.Text);
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    Button b = new Button();
                    Panel panelc1 = new Panel();
                    b.Text = rdr["Salon"].ToString();
                    b.Name = rdr["Id_salon"].ToString();
                    b.Dock = DockStyle.Fill;
                    b.BackColor = Color.Transparent;
                    b.Font = new System.Drawing.Font("Microsoft Sans Serif", 12);
                    b.FlatStyle = FlatStyle.Flat;
                    b.FlatAppearance.BorderSize = 0;
                    b.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 64, 64);
                    b.FlatAppearance.MouseOverBackColor = Color.FromArgb(43, 43, 43);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Tag = rdr["Estado"].ToString();

                    panelc1.Size = new System.Drawing.Size(290, 58);
                    panelc1.Name = rdr["Id_salon"].ToString();
                    string estado;
                    estado = rdr["Estado"].ToString();
                    if (estado == "ELIMINADO")
                    {
                        b.Text = rdr["Salon"].ToString() + " - Eliminado";
                        b.ForeColor = Color.FromArgb(231, 63, 67);
                    }
                    else
                    {
                        b.ForeColor = Color.White;
                    }
                    panelc1.Controls.Add(b);
                    flowLayoutPanel1.Controls.Add(panelc1);
                    b.Click += new EventHandler(miEvento_salon_button);
                }
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void miEvento_salon_button(System.Object sender, EventArgs e)
        {
            PanelBienvenida.Visible = false;
            PanelBienvenida.Dock = DockStyle.None;
            PanelMesas.Visible = true;
            PanelMesas.Dock = DockStyle.Fill;
            id_salon = Convert.ToInt32(((Button)sender).Name);
            estado = Convert.ToString(((Button)sender).Tag);
            dibujarMESAS();

            foreach (Panel PanelC1 in flowLayoutPanel1.Controls)
            {
                if (PanelC1 is Panel)
                {
                    foreach (Button boton in PanelC1.Controls)
                    {
                        if (boton is Button)
                        {
                            boton.BackColor = Color.Transparent;
                            break;
                        }
                    }
                }
            }

            string NOMBRE = Convert.ToString(((Button)sender).Name);
            foreach (Panel PanelC1 in flowLayoutPanel1.Controls)
            {
                if (PanelC1 is Panel)
                {
                    foreach (Button boton in PanelC1.Controls)
                    {
                        if (boton is Button)
                        {
                            if (boton.Name == NOMBRE)
                            {
                                boton.BackColor = Color.OrangeRed;
                                break;      
                            }
                        }
                    }
                }
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Modulos.Mesas_Salones.Salones frm = new Modulos.Mesas_Salones.Salones();
            frm.FormClosed += new FormClosedEventHandler(frm_formClosed);
            frm.ShowDialog();
        }
        public void frm_formClosed(Object sender, FormClosedEventArgs e)
        {
            dibujarsalones();
        }
    }
}

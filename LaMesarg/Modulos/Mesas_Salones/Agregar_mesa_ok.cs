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
    public partial class Agregar_mesa_ok : Form
    {
        public Agregar_mesa_ok()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Agregar_mesa_ok_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.None;
            txmesaedicion.Text = Configurar_mesas.nombre_mesa;
        }

        private void button_Click(object sender, EventArgs e)
        {
            if(txmesaedicion.Text != "")
            {
                editar_mesa();
            }
        }
        private void editar_mesa()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("editar_mesa", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@mesa", txmesaedicion.Text);
                cmd.Parameters.AddWithValue("@id_mesa", Configurar_mesas.idmesa);
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                Close();
                        
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}

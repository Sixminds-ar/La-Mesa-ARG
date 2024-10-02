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
    public partial class Salones : Form
    {
        int idsalon;
        public Salones()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            insertar_salon();
        }
        private void insertar_mesas_vacias()
        {
            for(int i=1;i<=80; i++)
            {
                try
                {
                    Conexion.ConexionMaestra.abrir();
                    SqlCommand cmd = new SqlCommand("insertar_mesa", Conexion.ConexionMaestra.conectar);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@mesa", "NULO");
                    cmd.Parameters.AddWithValue("@idsalon", idsalon);
                    cmd.ExecuteNonQuery();
                    Conexion.ConexionMaestra.Cerrar();

                }
                catch(Exception ex)
                {
                    Conexion.ConexionMaestra.Cerrar();
                    MessageBox.Show(ex.StackTrace);
                }
            }
        }
        private void mostrar_id_salon_recien_ingresado()
        {
            SqlCommand com = new SqlCommand("mostrar_id_salon_recien_ingresado", Conexion.ConexionMaestra.conectar);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@Salon", txtSalonesedicion.Text);
            try
            {
                Conexion.ConexionMaestra.abrir();
                idsalon = Convert.ToInt32(com.ExecuteScalar());
                Conexion.ConexionMaestra.Cerrar();
            }
            catch (Exception ex)
            {
                Conexion.ConexionMaestra.Cerrar();
                MessageBox.Show(ex.StackTrace);
            }
        }
        private void insertar_salon()
        {
            try
            {
                Conexion.ConexionMaestra.abrir();
                SqlCommand cmd = new SqlCommand("insertar_SALON", Conexion.ConexionMaestra.conectar);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@SALON", txtSalonesedicion.Text);
                cmd.Parameters.AddWithValue("@ESTADO", "activo");
                cmd.ExecuteNonQuery();
                Conexion.ConexionMaestra.Cerrar();
                mostrar_id_salon_recien_ingresado();
                insertar_mesas_vacias();
                Close();
                   
            }
            catch(Exception ex)
            {
                Conexion.ConexionMaestra.conectar.Close();

                MessageBox.Show(ex.Message);
            }
        }

        private void Salones_Load(object sender, EventArgs e)
        {
            FormBorderStyle = FormBorderStyle.None;
            txtSalonesedicion.Focus();
        }
    }
}

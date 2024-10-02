using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Data.SqlClient;

namespace LaMesarg.Conexion
{
    public partial class ConexionManual : Form
    {
        private Librerias.Encryptacion encryptacion = new Librerias.Encryptacion();
        int idtabla;
        public ConexionManual()
        {
            InitializeComponent();
        }
         public void SavetoXML(object dbcnString)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("ConnectionString.xml");
            XmlElement root = doc.DocumentElement;
            root.Attributes[0].Value = Convert.ToString(dbcnString);
            XmlTextWriter writer = new XmlTextWriter("ConnectionString.xml", null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
            writer.Close();
          
        }
        string dbcnString;
        public void ReadFromXML()
        {
            try
            {

                XmlDocument doc = new XmlDocument();
                doc.Load("ConnectionString.xml");
                XmlElement root = doc.DocumentElement;
                dbcnString = root.Attributes[0].Value;
                cajatexto.Text = (encryptacion.Decrypt(dbcnString, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));

            }
            catch (System.Security.Cryptography.CryptographicException )
            {

            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void CajaTexto_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void ConexionManual_Load(object sender, EventArgs e)
        {
            ReadFromXML();
        }   

        private void Texto1_Click(object sender, EventArgs e)
        {

        }

        private void Boton_Click(object sender, EventArgs e)
        {
            comprobar_conexion();
        }
        private void comprobar_conexion()
        {
            SqlConnection con = new SqlConnection();
            try
            {
               
                con.ConnectionString = cajatexto.Text;
                SqlCommand com = new SqlCommand("select * from SALON", con);
                con.Open();
                idtabla = Convert.ToInt32 (com.ExecuteScalar());
                con.Close();
                SavetoXML(encryptacion.Encrypt(cajatexto.Text, Librerias.Desencryptacion.appPwdUnique, int.Parse("256")));
                MessageBox.Show("Conexion realizada correctamente", "conexion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Application.Exit();
            }
            catch (Exception )
            {
                con.Close();
                MessageBox.Show("Sin conexion", "conexion fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
            
            }
        }

        private void cajatexto_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}

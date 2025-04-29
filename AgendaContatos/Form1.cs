using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace AgendaContatos
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSql;

        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agenda de contatos 1.0\nFeito por: Brito", "Sobre");
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=gestorclientes;Uid=root;Pwd=password;");

                strSql = "INSERT INTO CLIENTE (NOME, EMAIL, CPF, EMPRESA) VALUES (@NOME, @EMAIL, @CPF, @EMPRESA)";

                comando = new MySqlCommand(strSql, conexao);
                comando.Parameters.AddWithValue("@NOME", txtNome);
                comando.Parameters.AddWithValue("@EMAIL", txtEmail);
                comando.Parameters.AddWithValue("@CPF", txtCpf);
                comando.Parameters.AddWithValue("@EMPRESA", txtEmpresa);

                conexao.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conexao.Close();
                conexao = null;
                comando = null;
            }
        }
    }
}

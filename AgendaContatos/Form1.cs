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
                using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=agendacontato;Uid=root;Pwd=password;"))
                {

                    string strSql = "INSERT INTO CONTATO (NOME, EMAIL, CPF, NUMERO) VALUES (@NOME, @EMAIL, @CPF, @NUMERO)";

                    using (MySqlCommand comando = new MySqlCommand(strSql, conexao))
                    {
                        comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                        comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        comando.Parameters.AddWithValue("@CPF", txtCpf.Text);
                        comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cliente registrado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=agendacontato;Uid=root;Pwd=password;"))
                {

                    string strSql = "UPDATE CONTATO SET NOME = @NOME, EMAIL = @EMAIL, CPF = @CPF, NUMERO = @NUMERO WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(strSql, conexao))
                    {
                        comando.Parameters.AddWithValue("@ID", txtId.Text);
                        comando.Parameters.AddWithValue("@NOME", txtNome.Text);
                        comando.Parameters.AddWithValue("@EMAIL", txtEmail.Text);
                        comando.Parameters.AddWithValue("@CPF", txtCpf.Text);
                        comando.Parameters.AddWithValue("@NUMERO", txtNumero.Text);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cliente editado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=agendacontato;Uid=root;Pwd=password;"))
                {

                    string strSql = "DELETE FROM CONTATO WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(strSql, conexao))
                    {
                        comando.Parameters.AddWithValue("@ID", txtId.Text);

                        conexao.Open();
                        comando.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Cliente excluído com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=agendacontato;Uid=root;Pwd=password;"))
                {

                    string strSql = "SELECT * FROM CONTATO WHERE ID = @ID";

                    using (MySqlCommand comando = new MySqlCommand(strSql, conexao))
                    {
                        comando.Parameters.AddWithValue("@ID", txtId.Text);

                        conexao.Open();
                        dr = comando.ExecuteReader();

                        while (dr.Read())
                        {
                            txtNome.Text = Convert.ToString(dr["nome"]);
                            txtEmail.Text = Convert.ToString(dr["email"]);
                            txtCpf.Text = Convert.ToString(dr["cpf"]);
                            txtNumero.Text = Convert.ToString(dr["numero"]);
                        }
                    }
                }
                MessageBox.Show("Cliente consultado com sucesso!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                using (MySqlConnection conexao = new MySqlConnection("Server=localhost;Database=agendacontato;Uid=root;Pwd=password;"))
                {

                    string strSql = "SELECT * FROM CONTATO";
                    
                    da = new MySqlDataAdapter(strSql, conexao);

                    DataTable dt = new DataTable();

                    da.Fill(dt);
                    dgvDados.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar com o banco de dados: " + ex.Message);
            }
        }
    }
}

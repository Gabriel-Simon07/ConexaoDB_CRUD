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

namespace Conexão
{
    public partial class Form1 : Form
    {
        private MySqlConnection mConn;
        private MySqlDataAdapter mAdapter;
        private DataSet mDataSet;

        public Form1()
        {
            InitializeComponent();
            mostraResultados();
        }

        private void mostraResultados()

        {

            mDataSet = new DataSet();

            mConn = new MySqlConnection("server=localhost;user id=root;sslmode=None;database=testeBd");

            mConn.Open();

            //cria um adapter utilizando a instrução SQL para aceder à tabela

            mAdapter = new MySqlDataAdapter("SELECT * FROM LIVROS ORDER BY id", mConn);

            //preenche o dataset através do adapter

            mAdapter.Fill(mDataSet, "livros");

            //atribui o resultado à propriedade DataSource da dataGridView

            tblRegistros.DataSource = mDataSet;

            tblRegistros.DataMember = "livros";

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            mostraResultados();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            // Início da Conexão com indicação de qual o servidor, nome de base de dados e utilizar

            mConn = new MySqlConnection("server=localhost;user id=root;sslmode=None;database=testeBd");

            // Abre a conexão

            mConn.Open();

            //Query SQL

            MySqlCommand command = new MySqlCommand("INSERT INTO LIVROS(titulo, descricao)" +"VALUES('" + txtTitulo.Text + "','" + txtDescricao.Text + "')", mConn);

            //Executa a Query SQL

            command.ExecuteNonQuery();

            // Fecha a conexão

            mConn.Close();

            //Mensagem de Sucesso

            MessageBox.Show("Gravado com Sucesso!", "Informação", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            // Método criado para que quando o registo é gravado, automaticamente a dataGridView efectue um "Refresh"

            mostraResultados();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Início da Conexão com indicação de qual o servidor, nome de base de dados e utilizar

            mConn = new MySqlConnection("server=localhost;user id=root;sslmode=None;database=testeBd");

            // Abre a conexão

            mConn.Open();

            //Query SQL

            MySqlCommand command = new MySqlCommand("DELETE FROM LIVROS WHERE ID =('"  + txtId.Text + "')", mConn);

            //Executa a Query SQL

            command.ExecuteNonQuery();

            // Fecha a conexão

            mConn.Close();

            //Mensagem de Sucesso

            MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            // Método criado para que quando o registo é gravado, automaticamente a dataGridView efectue um "Refresh"

            mostraResultados();
        }

        private void btnModifica_Click(object sender, EventArgs e)
        {
            // Início da Conexão com indicação de qual o servidor, nome de base de dados e utilizar

            mConn = new MySqlConnection("server=localhost;user id=root;sslmode=None;database=testeBd");

            // Abre a conexão

            mConn.Open();

            //Query SQL

            MySqlCommand command = new MySqlCommand("UPDATE LIVROS SET titulo = '" + txtTitulo.Text + "',descricao='" + txtDescricao.Text + "' WHERE ID=" + txtId.Text , mConn);
            

            //Executa a Query SQL

            command.ExecuteNonQuery();

            // Fecha a conexão

            mConn.Close();

            //Mensagem de Sucesso

            MessageBox.Show("Alterado com Sucesso!", "Informação", MessageBoxButtons.OK,
            MessageBoxIcon.Information);

            // Método criado para que quando o registo é gravado, automaticamente a dataGridView efectue um "Refresh"

            mostraResultados();
        }
    }
    }


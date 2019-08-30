using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace agenda
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //BOTÃO CADASTRAR
        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\patricia.mmribeiro\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("INSERT INTO tabela1(nome, telefone) Values ('" +textBox1.Text+ "', '" + textBox4.Text + "' )");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado cadastrado");
            conn.Close();
        }

        //botao excluir
        private void button2_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\patricia.mmribeiro\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("DELETE FROM tabela1 WHERE nome = ('" +textBox1.Text+"')");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado apagado");
            conn.Close();


        }

        //botao alterar
        private void button3_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\patricia.mmribeiro\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("UPDATE tabela1 Set nome = ('" +textBox2.Text+ "') WHERE nome = ('" + textBox1.Text + "')");
            cmd.Connection = conn;

            conn.Open();
            cmd.ExecuteNonQuery();
            MessageBox.Show("Dado atualizado");
            conn.Close();



        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            String connect = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\patricia.mmribeiro\Downloads\teste.accdb";
            conn.ConnectionString = connect;
            OleDbCommand cmd = new OleDbCommand("SELECT * FROM tabela1 WHERE nome LIKE ('" + textBox1.Text + "%') ORDER BY nome ASC");
            cmd.Connection = conn;

            conn.Open();
            OleDbDataReader aReader = cmd.ExecuteReader();
            textBox3.Text = "Os valores retornados da tabela são : ";
            while (aReader.Read())
            {
                textBox3.Text += Environment.NewLine + aReader.GetString(0) + " " + aReader.GetString(1);
            }
            conn.Close();
        }

      
    }
}

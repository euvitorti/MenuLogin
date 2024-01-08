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

namespace MenuLogin
{
    public partial class frm_login : Form
    {
        MySqlConnection Conexao;

        public frm_login()
        {
            InitializeComponent();
            //COLOCAR [*], PARA DEIXAR A SENHA IMPOSSIBILITADA DE SER LIDA.
            txt_senha.PasswordChar = '*';
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btn_entrar_Click(object sender, EventArgs e)
        {
            try
            {
                string data_source = "server=127.0.0.1;username=root;password=;database=usuario;SslMode=none";
                //CRIAR CONEXAÕ
                Conexao = new MySqlConnection(data_source);
                var comando = Conexao.CreateCommand();
                MySqlCommand query = new MySqlCommand("select count(*) from sistema where nome = '" + txt_nome.Text + "' and senha = '" + txt_senha.Text + "'", Conexao);
                Conexao.Open();
                DataTable dataTable = new DataTable();
                MySqlDataAdapter da = new MySqlDataAdapter(query);
                da.Fill(dataTable);
                
                foreach(DataRow list in dataTable.Rows)
                {
                    if (Convert.ToInt32(list.ItemArray[0]) > 0) 
                    {
                        Frm_Creditos frm = new Frm_Creditos();
                        frm.Show();
                    }
                    else
                    {
                        MessageBox.Show("USUÁRIO OU SENHA INVÁLIDA.");
                    }
                }

                
            }
            catch(Exception) 
            {
                MessageBox.Show("USUÁRIO OU SENHA INCORRETA." +  MessageBoxButtons.OK);
            }

            Conexao.Close();
        }

        private void txt_senha_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_nome_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}


using System.Windows.Forms;
using System.Data;
using System;
using MySql.Data.MySqlClient;


namespace CRUDRastreador
{
    public partial class Form1 : Form
    {
        MySqlConnection conexao;
        MySqlCommand comando;
        MySqlDataAdapter da;
        MySqlDataReader dr;
        string strSQL;


        public Form1()
        {
            InitializeComponent();
        }


        private void btnNovo_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=rastreador;Uid=root;pwd=;");

                conexao.Open();

                strSQL = "INSERT INTO RASTREADOR (modelo, ICCID, IMEI) VALUES (@modelo, @ICCID, @IMEI)";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@ICCID", txtICCID.Text);
                comando.Parameters.AddWithValue("@IMEI", txtIMEI.Text);

                

                comando.ExecuteNonQuery();

                MessageBox.Show("Modelo de Rastreador adicionado!");

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

        private void btnEditar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=rastreador;Uid=root;pwd=;");

                strSQL = "UPDATE RASTREADOR SET MODELO = @MODELO, ICCID = @ICCID, IMEI = @IMEI WHERE idRastreador = @idRastreador";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@modelo", txtModelo.Text);
                comando.Parameters.AddWithValue("@ICCID", txtICCID.Text);
                comando.Parameters.AddWithValue("@IMEI", txtIMEI.Text);

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

        private void btnExcluir_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=rastreador;Uid=root;pwd=;");

                strSQL = "DELETE FROM RASTREADOR WHERE MODELO = @modelo";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@modelo", txtModelo.Text);

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

        private void btnConsultar_Click_1(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=rastreador;Uid=root;pwd=;");

                strSQL = "SELECT * FROM RASTREADOR WHERE MODELO = @MODELO";

                comando = new MySqlCommand(strSQL, conexao);

                comando.Parameters.AddWithValue("@MODELO", txtBuscar.Text);

                conexao.Open();

                dr = comando.ExecuteReader();

                while (dr.Read())
                {
                    txtModelo.Text = Convert.ToString(dr["modelo"]);
                    txtICCID.Text = Convert.ToString(dr["ICCID"]);
                    txtIMEI.Text = Convert.ToString(dr["IMEI"]);
                }
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

        private void btnExibir_Click(object sender, EventArgs e)
        {
            try
            {
                conexao = new MySqlConnection("Server=localhost;Database=rastreador;Uid=root;pwd=;");

                strSQL = "SELECT * FROM RASTREADOR";

                da = new MySqlDataAdapter(strSQL, conexao);

                DataTable dt = new DataTable();

                da.Fill(dt);

                listRastreador.DataSource = dt;

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
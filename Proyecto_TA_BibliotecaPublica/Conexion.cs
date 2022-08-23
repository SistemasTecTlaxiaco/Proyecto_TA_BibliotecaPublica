using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Proyecto_TA_BibliotecaPublica
{
    internal class Conexion
    {
        MySqlConnection Biblioconex = new MySqlConnection();

        string HOST = "localhost";
        string USER = "root";
        string PASS = "";
        string DB = "biblioteca";

        public Conexion()
        {
            this.Connect();
        }

        public void Connect()
        {
            if (Biblioconex.State == ConnectionState.Closed)
            {
                Biblioconex.ConnectionString = String.Format(@"Server={0}; Database={1}; User ID={2}; Password={3}; Pooling=false;", HOST, DB, USER, PASS);
                Biblioconex.Open();
            }
        }

        public int Query(string sql)
        {
            MySqlCommand command = new MySqlCommand(sql, Biblioconex);
            return command.ExecuteNonQuery();
        }

        public DataTable getData(string sql)
        {
            this.Connect();
            DataTable table = new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter(sql, Biblioconex);
            adapter.Fill(table);
            return table;
        }


        public DataRow getRow(string sql)
        {
            DataRow row = null;
            if (this.getData(sql).Rows.Count == 0)
            {
                return null;
            }
            row = this.getData(sql).Rows[0];
            return row;
        }

        public void CargarCombo(ComboBox cbo, String sql, String mostrar, String seleccionar)
        {
            this.Connect();
            DataTable datos = this.getData(sql);

            if (datos.Rows.Count > 0)
            {
                cbo.DataSource = null;
                cbo.DataSource = datos;
                cbo.DisplayMember = mostrar;
                cbo.ValueMember = seleccionar;
            }
            else
            {
                cbo.Text = "No hay registros";
                cbo.SelectedIndex = -1;
            }

        }
    }
}

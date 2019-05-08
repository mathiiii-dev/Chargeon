/*
 *  Mathias MICHELI
 *  Chargeon E4 - Bornes
 *  BTS SIO - 2019
 */

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

namespace Chargeon
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //Initialisation de la BDD
            string connStr = "server=localhost;database=chargeon_e4;user=root;password=";
            string query = "SELECT boId, boNumSerie, boType, boRef, boPuissance, boConcu, boLong, boLat FROM borne";
            using (MySqlConnection conn = new MySqlConnection(connStr))
            {
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                {
                    //Insertion des données dans le datagridview
                    DataSet ds = new DataSet();
                    adapter.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];

                    dataGridView1.CellClick += (s, e) =>
                    {
                        //Affichage des données du dataGridView dans les textBox apres avoir cliquez dessus
                        foreach (DataGridViewRow row in dataGridView1.SelectedRows)
                        {
                            tbId.Text = row.Cells[1].Value.ToString();
                            tbNumSerie.Text = row.Cells[1].Value.ToString();
                            tbType.Text = row.Cells[2].Value.ToString();
                            tbRef.Text = row.Cells[3].Value.ToString();
                            tbPuissance.Text = row.Cells[4].Value.ToString();
                            tbConcu.Text = row.Cells[5].Value.ToString();
                            tbLong.Text = row.Cells[6].Value.ToString();
                            tbLat.Text = row.Cells[7].Value.ToString();
                        }
                    };


                }
            }


        }

        //CRUD
        //Create
        private void BtAjout_Click(object sender, EventArgs e)
        {
            try
            {
                //Requete pour insérer les données dans la base
                string MyConnection2 = "server=localhost;database=chargeon_e4;user=root;password=";
                string Query = "insert into chargeon_e4.borne(boNumSerie, boType, boRef, boPuissance, boConcu, boLong, boLat) values" +
                    "('" + this.tbNumSerie.Text + "','" + this.tbType.Text + "','" + this.tbRef.Text + "','" + this.tbPuissance.Text + "','"
                    + this.tbConcu.Text + "','"  + this.tbLong.Text + "','" + this.tbLat.Text + "') where boId = '" + this.tbId.Text + "';" ;
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();    
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Update
        private void btModif_Click(object sender, EventArgs e)
        {
            try
            {
                //Requete pour modifier les données
                string MyConnection2 = "server=localhost;database=chargeon_e4;user=root;password=";
                string Query = "update chargeon_e4.borne set boNumSerie='" + this.tbNumSerie.Text + "',boType='" + this.tbType.Text + 
                    "',boRef='" + this.tbRef.Text + "',boPuissance='" + this.tbPuissance.Text + 
                    "',boConcu='" + this.tbConcu.Text + "' ,boLong='" + this.tbLong.Text + "',boLat='" + this.tbLat.Text + "'where boId = '" + this.tbId.Text + "';'";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Bornes mises à jour");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close(); 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //Delete
        private void BtSuppr_Click(object sender, EventArgs e)
        {
            try
            {
                //Requete pour la suppréssion des sonnées 
                string MyConnection2 = "server=localhost;database=chargeon_e4;user=root;password=";
                string Query = "delete from chargeon_e4.borne where boId='" + this.tbId.Text + "';";
                MySqlConnection MyConn2 = new MySqlConnection(MyConnection2);
                MySqlCommand MyCommand2 = new MySqlCommand(Query, MyConn2);
                MySqlDataReader MyReader2;
                MyConn2.Open();
                MyReader2 = MyCommand2.ExecuteReader();
                MessageBox.Show("Bornes Supprimées");
                while (MyReader2.Read())
                {
                }
                MyConn2.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        
    }
       
    
}

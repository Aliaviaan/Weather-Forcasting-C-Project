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


namespace lab_11
{
    public partial class Form1 : Form
    {
        //to build a connection with database
        string connectionstring = @"server=localhost;Database=weather_forcasting;Uid=root;pwd=root";
       
        public Form1()
        {
            InitializeComponent();
        }

        //code of a display button
        private void display_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                //opens a connection
                con.Open();
                //first it will show the message box then requires data from database by applying query stored in a variable da.
                MessageBox.Show("This is all the data of weather");
                MySqlDataAdapter da = new MySqlDataAdapter("select*from weather", con);
                //rtb box also shows the query as well
                rtb.Text = "select * from weather";
                //this fills the data in datagridview and shows to user
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgv1.DataSource = dt;
                //and then query is invisible by clear command
                rtb.Clear();

            }
        }


       
        private void button2_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlCommand cmd;
                con.Open();
                MessageBox.Show("This is all the data of weather");
                cmd = con.CreateCommand();
                cmd.CommandText = "select region,date,windSpeedMph,windSpeedKmph from weather where region like '" + region.Text + "%'and date ='" + date.Text + "'";
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    adapt.Fill(dt);
                }
                catch (Exception ex) {
                    region.Clear();
                    date.Clear();
                }
                region.Clear();
                date.Clear();
                MessageBox.Show("done");
                dgv1.DataSource = dt;
               
            }
        }

        //this works for fetching data for windspeed button
        private void windspeed_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlCommand cmd;
                con.Open();
                cmd = con.CreateCommand();
                //opens a connection
                //first it will show the message box then requires data from database by applying query stored in a variable da.
                cmd.CommandText = "select region,date,WindSpeedMph,WindSpeedKmph from weather where region like '" + region.Text + "%'and date ='" + date.Text + "'";
                //rtb box also shows the query as well
                //rtb.Text = "select region, date, WindSpeedMph, WindSpeedKmph from weather where region like '" + region.Text + "'and date ='" + date.Text + "'";
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    //this checks if the condition is true then it will show the data otherwise it will show exception/error
                    if (region.Text == "uk" || region.Text == "france" || region.Text == "china" || region.Text == "russia" || region.Text == "germany")
                    {
                        MessageBox.Show("result shown for region " + region.Text.ToString()
                        + " and date " + date.Text.ToString());
                        adapt.Fill(dt);
                    }
                    else
                    {
                        MessageBox.Show("enter both correctlty \n" +
                         "country can be UK, russia,france,germany,china \n " +
                         "date format is yyyy-mm-dd");
                        region.Clear();
                        date.Clear();
                        rtb.Clear();
                    }
                }
                //cath any exception also in case of wrong data or blanked space
                catch (Exception ex)
                {
                    MessageBox.Show("enter both correctlty \n" +
                        "country can be UK, russia,france,germany,china \n " +
                        "date format is yyyy-mm-dd");
                    region.Clear();
                    date.Clear();
                    rtb.Clear();
                }
                //after all, it clears the textboxes of date, region and query
                region.Clear();
                date.Clear();
                rtb.Clear();
                dgv1.DataSource = dt;
            }
        }

        private void date_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter("select * from weather where date like '" + date.Text + "%'", con);
                DataTable dt = new DataTable();
                adapt.Fill(dt);
                dgv1.DataSource = dt;
                con.Close();
            }
        }

        private void region_TextChanged(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                con.Open();
                MySqlDataAdapter adapt = new MySqlDataAdapter("select * from weather where region like '" + region.Text + "%'", con);
                DataTable dt = new DataTable();
                try
                {
                    adapt.Fill(dt);
                }
                catch (Exception ex) { };
                dgv1.DataSource = dt;
                con.Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlDataAdapter db = new MySqlDataAdapter("select * from weather", con);
                DataTable dg = new DataTable();
                db.Fill(dg);
                dgv1.DataSource = db;
                con.Close();
            }
        }

        private void temperature_Click(object sender, EventArgs e)
        {
            using (MySqlConnection con = new MySqlConnection(connectionstring))
            {
                MySqlCommand cmd;
                con.Open();
                //opens a connection
                //first it will show the message box then requires data from database by applying query stored in a variable da.
                cmd = con.CreateCommand();
                //rtb box also shows the query as well
                //rtb.Text = "select region, date, WindSpeedMph, WindSpeedKmph from weather where region like '" + region.Text + "'and date ='" + date.Text + "'";
                cmd.CommandText = "select region,date,temperatureCel,temeratureFarenhite from weather where region like '" + region.Text + "%'and date ='" + date.Text + "'";
                rtb.Text = "select region, date, WindSpeedMph,WindSpeedKmph from weather where region like '" + region.Text + "' and date ='" + date.Text + "'";
                MySqlDataAdapter adapt = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                try
                {
                    //this checks if the condition is true then it will show the data otherwise it will show exception/error
                    if (region.Text == "uk" || region.Text == "france" || region.Text == "china" || region.Text == "russia" || region.Text == "germany")
                    {

                        MessageBox.Show("result shown for region " + region.Text.ToString()
                        + " and date " + date.Text.ToString());
                        adapt.Fill(dt);
                    }
                    else
                    {
                        MessageBox.Show("enter both correctlty \n" +
                         "country can be UK, russia,france,germany,china \n " +
                         "date format is yyyy-mm-dd");
                        region.Clear();
                        date.Clear();
                        rtb.Clear();
                    }
                }
                //cath any exception also in case of wrong data or blanked space

                catch (Exception ex) 
                {
                    MessageBox.Show("enter both correctlty \n" +
                        "country can be UK, russia,france,germany,china \n " +
                        "date format is yyyy-mm-dd");
                    region.Clear();
                    date.Clear();
                    rtb.Clear();
                }
                //after all, it clears the textboxes of date, region and query
                region.Clear();
                date.Clear();
                rtb.Clear();
                dgv1.DataSource = dt;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        { 
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}

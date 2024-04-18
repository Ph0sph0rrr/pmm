using Npgsql;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pm
{
    public partial class Form2 : Form
    {
        Database db = new Database();

        public Form2()
        {
            


            InitializeComponent();
            



            



        }

        private void btnEnt_Click(object sender, EventArgs e)
        {
            List<int> reqs = new List<int>();

            db.openConnection();

            NpgsqlCommand comm = new NpgsqlCommand("SELECT id FROM users WHERE stat = 'Подано'", db.getConnection());
            NpgsqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                reqs.Add(reader.GetInt32(0));
            }

            db.closeConnection();










            
        }

        private int countReqs()
        {
            List<int> reqs = new List<int>();

            db.openConnection();

            NpgsqlCommand comm = new NpgsqlCommand("SELECT id FROM users WHERE stat = 'Подано'", db.getConnection());
            NpgsqlDataReader reader = comm.ExecuteReader();

            while (reader.Read())
            {
                reqs.Add(reader.GetInt32(0));
            }

            db.closeConnection();

            return reqs.Count();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {
            
            


        }

        private void regCl_Click(object sender, EventArgs e)
        {
            db.openConnection();

            NpgsqlCommand updateDatFin = new NpgsqlCommand($"UPDATE users SET fio = '{tBxIoRg.Text}',  WHERE id = '{idd.Text}'", db.getConnection());
            updateDatFin.ExecuteNonQuery();

            db.closeConnection();

            MessageBox.Show("Дата окончания изменена");
        }
    }
}

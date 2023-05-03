using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Bioskop
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_visibility_Click(object sender, EventArgs e)
        {
            if (textBox_sifra.PasswordChar == '*')
            {
                textBox_sifra.PasswordChar = '\0';
                button_visibility.Text = "O";
            }
            else
            {
                textBox_sifra.PasswordChar = '*';
                button_visibility.Text = "Ø";
            }
        }

        public static string email;

        public void button_log_in_Click(object sender, EventArgs e)
        {
            string naredba = "select sifra from Radnik ";
            naredba += "where email = '" + textBox_email.Text + "'";
            SqlConnection konekcija = Konekcija.Konekcija.KonektujSe();
            SqlCommand komanda = new SqlCommand(naredba, konekcija);
            string tacna_sifra = "";
            try
            {
                konekcija.Open();
                tacna_sifra = (string)komanda.ExecuteScalar();
                konekcija.Close();
            }
            catch 
            {
                MessageBox.Show("Doslo je do greske, pokusajte ponovo.", "Greska");
                return;
            }
            if (textBox_sifra.Text == tacna_sifra)
            {
                email = textBox_email.Text;
                Pocetna nova = new Pocetna();
                nova.Show();
            }
            else 
            {
                MessageBox.Show("Doslo je do greske, pokusajte ponovo.", "Greska");
            }
        }

        private void linkLabel_sign_up_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SignUp nova = new SignUp();
            nova.Show();
        }
    }
}

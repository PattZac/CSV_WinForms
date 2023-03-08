using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace CSV_WinForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Osoba> ListaOsoba = new List<Osoba>();
            try
            {
                Osoba osoba = new Osoba(tbIme.Text, tbPrezime.Text, tbEmail.Text, Convert.ToInt16(tbGod.Text));
                tbIme.Clear();
                tbPrezime.Clear();
                tbEmail.Clear();
                tbGod.Clear();

                DialogResult upit = MessageBox.Show("Želite li unesti još podataka", "Upit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (upit)
                {
                    case DialogResult.Yes:
                        
                        ListaOsoba.Add(osoba);
                        break;
                        
                    case DialogResult.No:
                        
                        ListaOsoba.Add(osoba);
                        //Upis podataka u datoteku
                        String file = @"C:\winforms";
                        if (!Directory.Exists(file))
                        {
                            Directory.CreateDirectory(file);
                        }
                        file = @"C:\winforms\OsobaLisr.css";
                        StringBuilder output = new StringBuilder();
                        String separator = ",";
                        String[] headings = { "Ime", "Prezime", "Email", "Godina rođenja" };
                        output.AppendLine(string.Join(separator, headings));

                        foreach (Osoba os in ListaOsoba)
                        {
                            String[] newLine = { os.ToString() };
                            output.AppendLine(string.Join(separator, newLine));
                        }
                        try
                        {
                            File.AppendAllText(file, output.ToString());
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Pogrešan u .csv file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        break;
                }
            }
            catch (Exception greska)
            {
                MessageBox.Show(greska.Message, "Pogrešan unos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

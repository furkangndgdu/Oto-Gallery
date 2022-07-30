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

namespace AutoGallery7
{
    public partial class Form1 : Form
    {
        OleDbConnection baglantim = new OleDbConnection("Provider = Microsoft.ACE.OleDb.12.0;Data Source="+Application.StartupPath+"\\otogaleri7.accdb");
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            kayitlarilistele();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            string marka = comboBox1.SelectedItem.ToString();
            if (marka== "BMW")
            {
                string[] model = { "Sedan", "Turismo", "Coupé" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Volkswagen")
            {
                string[] model = { "Taigo", "Passat", "T-Cross" };
                comboBox2.Items.AddRange(model);
            }
            if (marka == "Mercedes")
            {
                string[] model = { "GLA", "CLS", "SLC" };
                comboBox2.Items.AddRange(model);
            }
        }
        private void kayitlarilistele()
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter listele = new OleDbDataAdapter("select * from araclar", baglantim);
                DataSet dshafiza = new DataSet();
                listele.Fill(dshafiza);
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbDataAdapter eklekomutu = new OleDbDataAdapter("insert into araclar (ruhsatno,marka,model,yakittipi,kasatipi,kilometre,fiyat) " +
                    "values('" + textBox1.Text + "','" + comboBox1.SelectedItem.ToString() + "','" + comboBox2.SelectedItem.ToString() + "','" +
                    comboBox3.SelectedItem.ToString() + "','" + comboBox4.SelectedItem.ToString() + "','" + textBox2.Text + "','" + textBox3.Text + "')", baglantim);
                DataSet dshafiza = new DataSet();
                eklekomutu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç Veri Tabanına Eklendi");
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                kayitlarilistele();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                DataSet dshafiza=new DataSet();
                OleDbDataAdapter silkomutu = new OleDbDataAdapter("delete from araclar where ruhsatno='" + textBox1.Text + "'", baglantim);
                silkomutu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç Veri Tabanından Silindi");
                kayitlarilistele();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                DataSet dshafiza = new DataSet();
                OleDbDataAdapter guncellekomutu = new OleDbDataAdapter("update araclar set fiyat='" + textBox3.Text + "' where ruhsatno='" + textBox1.Text + "'", baglantim);
                guncellekomutu.Fill(dshafiza);
                baglantim.Close();
                MessageBox.Show("Araç Güncellendi");
                baglantim.Close();
                kayitlarilistele();

            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
               
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                DataSet dshafiza = new DataSet();
                OleDbDataAdapter aramakomutu=new OleDbDataAdapter("select * from araclar where ruhsatno='"+textBox1.Text+"'",baglantim);
                aramakomutu.Fill(dshafiza); 
                dataGridView1.DataSource = dshafiza.Tables[0];
                baglantim.Close();
            }
            catch (Exception hatamsj)
            {
                MessageBox.Show(hatamsj.Message);
                baglantim.Close();
            }
        }
    }
}

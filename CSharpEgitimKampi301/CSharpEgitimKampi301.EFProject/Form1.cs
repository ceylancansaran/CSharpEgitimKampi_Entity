﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        EgitimKampiEFDbEntities1 db = new EgitimKampiEFDbEntities1();

        private void btnListele_Click(object sender, EventArgs e)
        {
            var values = db.Guide.ToList();
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Guide guide = new Guide();
            guide.GuideName = txtAd.Text;
            guide.GuideSurname = txtSoyad.Text;
            db.Guide.Add(guide);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla eklendi.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var removeValue = db.Guide.Find(id);
            db.Guide.Remove(removeValue);
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla silindi.");

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id=int.Parse(txtID.Text);
            var updateValue = db.Guide.Find(id);
            updateValue.GuideName = txtAd.Text;
            updateValue.GuideSurname= txtSoyad.Text;
            db.SaveChanges();
            MessageBox.Show("Rehber başarıyla güncellendi","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtID.Text);
            var values = db.Guide.Where(x=>x.GuideId==id).ToList();
            dataGridView1.DataSource= values;
        }
    }
}

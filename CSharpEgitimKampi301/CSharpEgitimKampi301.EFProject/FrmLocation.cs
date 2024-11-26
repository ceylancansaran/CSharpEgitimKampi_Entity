using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EFProject
{
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
        }

        EgitimKampiEFDbEntities1 db = new EgitimKampiEFDbEntities1();
        private void FrmLocation_Load(object sender, EventArgs e)
        {
            var guides = db.Guide.Select(x => new
            {
                FullName = x.GuideName + " " + x.GuideSurname,
                x.GuideId
            }).ToList();
            comboBox1.ValueMember = "GuideId";
            comboBox1.DisplayMember = "FullName";
            comboBox1.DataSource = guides;
        }

        private void btnListele_Click(object sender, EventArgs e)
        {
            var locations = (from x in db.Location select new { x.LocationId, x.City, x.Country, x.Price, x.Capacity, x.DayNight, x.GuideId }).ToList();
            dataGridView1.DataSource = locations;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Location location = new Location();
            location.City = txtCity.Text;
            location.Country = txtCountry.Text;
            location.Price = decimal.Parse(txtPrice.Text);
            location.DayNight = txtDayNight.Text;
            location.Capacity = Convert.ToByte(numericUpDown1.Value);
            location.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.Location.Add(location);
            db.SaveChanges();
            MessageBox.Show("Lokasyon başarıyla eklendi.");
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationID.Text) ;
            var deletedvalue = db.Location.Find(id);
            db.Location.Remove(deletedvalue);
            db.SaveChanges();
            MessageBox.Show("Lokasyon başarıyla silindi.");
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationID.Text);
            var updatedvalue = db.Location.Find(id);
            updatedvalue.City = txtCity.Text;
            updatedvalue.Country = txtCountry.Text;
            updatedvalue.Price = decimal.Parse(txtPrice.Text);
            updatedvalue.DayNight = txtDayNight.Text;
            updatedvalue.Capacity = Convert.ToByte(numericUpDown1.Value);
            updatedvalue.GuideId = int.Parse(comboBox1.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Lokasyon Bilgileri Başarıyla Güncellendi.");

        }

        private void btnGetByID_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtLocationID.Text);
            var location = db.Location.Where(x=>x.LocationId==id).ToList();
            dataGridView1.DataSource = location;
        }
    }
}

using System;
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
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }
        EgitimKampiEFDbEntities1 db = new EgitimKampiEFDbEntities1();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {

            var locationCount = db.Location.Count();
            lblLocationNumber.Text = locationCount.ToString();

            var capasitySum = db.Location.Sum(x => x.Capacity).ToString();
            lblSumCapasity.Text = capasitySum.ToString();

            lblGuideCount.Text = db.Guide.Count().ToString();

            //var avarageCapasity = db.Location.Sum(x=> x.Capacity) / db.Location.Count();
            //lblAvarageCapasity.Text = avarageCapasity.ToString();

            decimal avgCapacity = Convert.ToDecimal(db.Location.Average(x => x.Capacity));
            avgCapacity = Math.Round(avgCapacity, 2);
            lblAvarageCapasity.Text = avgCapacity.ToString();

            decimal avgPrice = Convert.ToDecimal(db.Location.Average(x => x.Price));
            avgPrice = Math.Round(avgPrice,2);
            lblAvgLocationPrice.Text = avgPrice.ToString() + " ₺";

            int lastCountryId = db.Location.Max(x => x.LocationId);
            lblAddLastCountry.Text = db.Location.Where(x => x.LocationId == lastCountryId).Select(y => y.Country).FirstOrDefault();

            lblUskupCapasity.Text = db.Location.Where(x=>x.City == "Üsküp").Select(y=>y.Capacity).FirstOrDefault().ToString();


            decimal avgConuntryCapacity = Convert.ToDecimal(db.Location.Where(x => x.Country == "Makedonya").Average(y => y.Capacity));
            avgConuntryCapacity = Math.Round(avgConuntryCapacity, 2);
            lblCountryCapacity.Text = avgConuntryCapacity.ToString();


            var ohriGuideId = db.Location.Where(x => x.City == "Ohri").Select(y => y.GuideId).FirstOrDefault();
            lblOhriGuideName.Text = db.Guide.Where(x=>x.GuideId == ohriGuideId).Select(y=>y.GuideName + " " + y.GuideSurname).FirstOrDefault().ToString();


            //lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Country == "Makedonya").Max(y=>y.Capacity).ToString();

            var maxCapasity = db.Location.Max(x => x.Capacity);
            lblMaxCapacityLocation.Text = db.Location.Where(x=>x.Capacity == maxCapasity).Select(y=>y.City).FirstOrDefault().ToString();

            var maxPrice = db.Location.Max(x => x.Price);
            lblMaxPrice.Text = db.Location.Where(x=>x.Price == maxPrice).Select(y=>y.City).FirstOrDefault().ToString();


            var guideId = db.Guide.Where(x => x.GuideName == "Fatma" & x.GuideSurname == "Can").Select(y => y.GuideId).FirstOrDefault();
            lblTurNumber.Text = db.Location.Where(x=>x.GuideId == guideId).Count().ToString();

        }
    }
}

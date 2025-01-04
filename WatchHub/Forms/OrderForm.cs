using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WatchHub.Forms
{
    
    public partial class OrderForm : Form
    {
        private Database dataBase;
        public OrderForm(
         string brand, string title, string watchVersion, string mechanismType,
         string housingMaterial, string beltMaterial, decimal price, double caseDiameter,
         string caseColor, string caseShape, string waterResistance, string dialColor,
         string glassType, string indicationType, string indicationView, string description,
         string gender,int quantity)
        {
            InitializeComponent();

            // Присвоюємо значення до кожного Label
            brand_label.Text = brand;
            title_label.Text = title;
            watch_version_label.Text = watchVersion;
            mechanism_type_label.Text = mechanismType;
            housing_material_label.Text = housingMaterial;
            belt_material_label.Text = beltMaterial;
            price_label.Text = price.ToString();
            case_diametr_label.Text = caseDiameter.ToString();
            case_color_label.Text = caseColor;
            case_shape_label.Text = caseShape;
            water_resistance_label.Text = waterResistance;
            dial_color_label.Text = dialColor;
            glass_type_label.Text = glassType;
            indication_type_label.Text = indicationType;
            indication_view_label.Text = indicationView;
            description_label.Text = description;
            gender_label.Text = gender;
            quantity_label.Text = quantity.ToString();
        }

        private void OrderForm_Load(object sender, EventArgs e)
        {

        }

        private void orderWatch_btn_Click(object sender, EventArgs e)
        {

            
        }
    }
}

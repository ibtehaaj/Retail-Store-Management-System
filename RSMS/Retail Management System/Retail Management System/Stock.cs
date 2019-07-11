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

namespace Retail_Management_System
{
    public partial class Stock : Form
    {
        public Stock()
        {
            InitializeComponent();
            var grid_control = new data_grid_controls();
            grid_control.show_grid_view(dataGridView1);
            grid_control.combo_box_suggestions(comboBox1);
            grid_control.product_suggestions(comboBox2);
            grid_control.product_suggestions(comboBox3);
            grid_control.supplier_suggestions(comboBox5);

        }
        public DataGridView Products_Data_GridView { get { return this.dataGridView1; } }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Stock_Load(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var grid_control = new data_grid_controls();
            grid_control.search_grid(dataGridView1, comboBox1);
        }

        private void ComboBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
     
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var grid_control = new data_grid_controls();
            if (string.IsNullOrWhiteSpace(textBox1.Text) || string.IsNullOrWhiteSpace(textBox2.Text) || string.IsNullOrWhiteSpace(comboBox5.Text))
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                grid_control.add_product(textBox1, textBox2, comboBox5);
            }
            this.Controls.Clear();
            InitializeComponent();
            grid_control.show_grid_view(dataGridView1);
            grid_control.combo_box_suggestions(comboBox1);
            grid_control.product_suggestions(comboBox2);
            grid_control.product_suggestions(comboBox3);
            grid_control.supplier_suggestions(comboBox5);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            var grid_controls = new data_grid_controls();
            grid_controls.remove_product(comboBox3);
            this.Controls.Clear();
            InitializeComponent();
            grid_controls.show_grid_view(dataGridView1);
            grid_controls.combo_box_suggestions(comboBox1);
            grid_controls.product_suggestions(comboBox2);
            grid_controls.product_suggestions(comboBox3);
            grid_controls.supplier_suggestions(comboBox5);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            var grid_controls = new data_grid_controls();
            if (string.IsNullOrWhiteSpace(textBox3.Text) || string.IsNullOrWhiteSpace(comboBox2.Text) )
            {
                MessageBox.Show("Please fill all the fields");
            }
            else
            {
                grid_controls.update_quantity(comboBox2, textBox3);
            }
            this.Controls.Clear();
            InitializeComponent();
            grid_controls.show_grid_view(dataGridView1);
            grid_controls.combo_box_suggestions(comboBox1);
            grid_controls.product_suggestions(comboBox2);
            grid_controls.product_suggestions(comboBox3);
            grid_controls.supplier_suggestions(comboBox5);

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            var grid_controls = new data_grid_controls();
            this.Controls.Clear();
            InitializeComponent();
            grid_controls.show_grid_view(dataGridView1);
            grid_controls.combo_box_suggestions(comboBox1);
            grid_controls.product_suggestions(comboBox2);
            grid_controls.product_suggestions(comboBox3);
            grid_controls.supplier_suggestions(comboBox5);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var dashboard = new Dashboard();
            this.Hide();
            dashboard.ShowDialog();
            this.Close();
        }
    }
}

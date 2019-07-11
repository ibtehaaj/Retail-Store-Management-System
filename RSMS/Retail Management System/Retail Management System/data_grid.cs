using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Data;
using FileHelpers;

namespace Retail_Management_System
{

    class data_grid_controls
    {

        //class for controlling grid_view

        //data table corresponding to the grid view
        DataTable table = new DataTable();

        //method for displaying grid view
        public void show_grid_view(DataGridView obj)
        {

            table.Columns.Add("Product");
            table.Columns.Add("Supplier");
            table.Columns.Add("Quantity");
            string line;
            //for reading data from text file
            using (StreamReader reader = new StreamReader(@"D:\RSMS\Files\Stock\Product_Details.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    DataRow dr = table.NewRow();
                    string[] values = line.Split(',');
                    for (int i = 0; i < values.Length; i++)
                    {
                        dr[i] = values[i];
                    }
                    table.Rows.Add(dr);
                }
            }

            obj.DataSource = table;
         }


        //method for populating combo box suggestion list
        public void combo_box_suggestions(ComboBox cb)
        {
            string[] lineOfContents = File.ReadAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt");

            foreach (var line in lineOfContents)
            {
                string[] items = line.Split(',');
                cb.Items.Add(items[0]);
                if(cb.Items.Contains(items[1]))
                {

                }
                else
                {
                    cb.Items.Add(items[1]);
                }
            }

         }

        public void product_suggestions(ComboBox cb)
        {
            string[] lineOfContents = File.ReadAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt");

            foreach (var line in lineOfContents)
            {
                string[] items = line.Split(',');
                cb.Items.Add(items[0]);
            }

        }

        public void supplier_suggestions(ComboBox cb)
        {
            string[] lineOfContents = File.ReadAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt");

            foreach (var line in lineOfContents)
            {
                string[] items = line.Split(',');
                if(cb.Items.Contains(items[1]))
                {

                }
                else
                {
                    cb.Items.Add(items[1]);
                }
            }

        }


        //method for filtering the grid view
        public void search_grid(DataGridView obj,ComboBox cb)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = obj.DataSource;
            bs.Filter = String.Format("[Product] LIKE '%{0}%' OR [Supplier] LIKE '%{0}%'", cb.Text);
            obj.DataSource = bs;
        }

        //add and validates new products to the file.
        public void add_product(TextBox tb1,TextBox tb2,ComboBox cb)
        {
            //using FileHelpers package to read and write to file.
            var engine = new FileHelperEngine<products>();
            var product = new List<products>();
            var x = new products();
            if (x.validate_record(tb1, cb) == true)
            {
                MessageBox.Show("Product is already stocked.");
            }
            else
            {
                product.Add(new products()
                {
                    product_name = tb1.Text.ToUpper(),
                    supplier_name = cb.Text.ToUpper(),
                    quantity = tb2.Text.ToUpper(),

                }
                );
                engine.AppendToFile(@"D:\RSMS\Files\Stock\Product_Details.txt", product);
                MessageBox.Show("Successfully Added");
            }
        }

        //removes product from the file.
        public void remove_product(ComboBox cb)
        {
            string record_to_be_deleted = cb.Text;
            string[] lines = File.ReadAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt");

            string[] remaining = lines.Where(x => !x.Contains(record_to_be_deleted.ToString())).ToArray();
            File.WriteAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt", remaining);

        }

        public void update_quantity(ComboBox cb,TextBox tb)
        {
            string record_to_be_updated = cb.Text;
            string[] lines = File.ReadAllLines(@"D:\RSMS\Files\Stock\Product_Details.txt");
            string[] target = lines.Where(x => x.Contains(record_to_be_updated.ToString())).ToArray();
            remove_product(cb);

            string update = target[0];
            string[] modify = update.Split(',');
            modify[2] = tb.Text;
            update = string.Join(",", modify);
            File.AppendAllText(@"D:\RSMS\Files\Stock\Product_Details.txt", update);
            MessageBox.Show("Quantity Updates Sucessfully");
            
        }

    }

    //using FileHelpers package to read and write to file
    [DelimitedRecord(",")]
    public class products
    {
        public string product_name;
        public string supplier_name;
        public string quantity;

        public bool validate_record(TextBox tb1, ComboBox cb)
        {
            var engine = new FileHelperEngine<products>();
            var records = engine.ReadFile(@"D:\RSMS\Files\Stock\Product_Details.txt");
            bool check = false;
            foreach (var record in records)
            {
                if(tb1.Text.ToUpper() == record.product_name && cb.Text.ToUpper() == record.supplier_name)
                {
                    check = true;
                }
            }
            return check;
        }

    }

}

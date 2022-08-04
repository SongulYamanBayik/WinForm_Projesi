using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Adonet
{
    public partial class ProductForm : Form
    {
        public ProductForm()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DB_IstanbulAkademi;Integrated Security=True");
        void ProductList()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TblProduct", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dtgProduct.DataSource = dataTable;
            connection.Close();
        }
        private void btnList_Click(object sender, EventArgs e)
        {

            ProductList();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Tblproduct (ProductName, ProductStock, PurchasePrice, SalePrice,CategoryID, Status) values (@p1, @p2,@p3,@p4,@p5,@p6)", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurchasePrice.Text);
            command.Parameters.AddWithValue("@p4", txtSalePrice.Text);
            command.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            if (radioButton1.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "True");
            }
            if (radioButton2.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "False");
            }
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı bir şekilde sisteme kaydedildi");
            connection.Close();
            ProductList();

        }

        private void ProductForm_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("select * from TblCategory", connection);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            comboBox1.DisplayMember = "CategoryName";
            comboBox1.ValueMember = "CategoryID";
            comboBox1.DataSource = dataTable;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete from TblProduct Where ProductID=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı şekilde silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            connection.Close();
            ProductList();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Update Tblproduct set ProductName=@p1, ProductStock=@p2, PurchasePrice=@p3, SalePrice=@p4,CategoryID=@p5, Status=@p6 where ProductId=@p7", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            command.Parameters.AddWithValue("@p2", txtStock.Text);
            command.Parameters.AddWithValue("@p3", txtPurchasePrice.Text);
            command.Parameters.AddWithValue("@p4", txtSalePrice.Text);
            command.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            if (radioButton1.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "True");
            }
            if (radioButton2.Checked == true)
            {
                command.Parameters.AddWithValue("@p6", "False");
            }
            command.Parameters.AddWithValue("@p7", txtID.Text);
            command.ExecuteNonQuery();
            MessageBox.Show("Ürün başarılı şekilde güncellendi", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
            ProductList();
        }

        private void btnSearchName_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TblProduct where ProductName=@p1", connection);
            command.Parameters.AddWithValue("@p1", txtName.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dtgProduct.DataSource = dataTable;
            connection.Close();
        }

        private void btnSearchStockLess_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TblProduct where ProductStock<@p1", connection);
            command.Parameters.AddWithValue("@p1", txtStock.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dtgProduct.DataSource = dataTable;
            connection.Close();
        }

        private void btnSeacrhStockMore_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("select * from TblProduct where Productstock>@p1", connection);
            command.Parameters.AddWithValue("@p1", txtStock.Text);
            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            dtgProduct.DataSource = dataTable;
            connection.Close();
        }
    }
}

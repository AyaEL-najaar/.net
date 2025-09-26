using EFWD2.Models;
using System;
using System.Linq;
using System.Windows.Forms;
namespace EFWD2
{
    public partial class Form1 : Form
    {
        private CompanyTaskContext _context = new CompanyTaskContext();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();

        }
        private void LoadData()
        {
            // Select only the fields you want to show in the grid
            dataGridView1.DataSource = _context.Employees
                .Select(emp => new
                {
                    emp.Id,
                    emp.FirstName,
                    emp.LastName,
                    emp.Address,
                    emp.Salary
                })
                .ToList();
        }
        // Add a new employee
        private void btnAdd_Click(object sender, EventArgs e)
        {
            var emp = new Employee
            {
                Id = int.Parse(txtId.Text),       // Employee ID
                FirstName = txtFirstName.Text,    // First Name
                LastName = txtLastName.Text,      // Last Name
                Address = txtAddress.Text,        // Address
                Salary = decimal.Parse(txtSalary.Text) // Salary
            };

            _context.Employees.Add(emp);
            _context.SaveChanges();
            LoadData(); // Refresh grid
            ClearFields();
        }
        // Clear all textboxes
        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        // Reusable method to clear fields
        private void ClearFields()
        {
            txtId.Clear();
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtSalary.Clear();
        }

        // Fill textboxes when selecting a row in the grid
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dataGridView1.Rows[e.RowIndex];
                txtId.Text = row.Cells["Id"].Value.ToString();
                txtFirstName.Text = row.Cells["FirstName"].Value.ToString();
                txtLastName.Text = row.Cells["LastName"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                // Special check for Salary
                if (row.Cells["Salary"].Value != null && !string.IsNullOrWhiteSpace(row.Cells["Salary"].Value.ToString()))
                {
                    txtSalary.Text = row.Cells["Salary"].Value.ToString();
                }
                else
                {
                    txtSalary.Text = "0"; // or leave it empty ""
                }

            }
        }
        // Update selected employee
        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (emp != null)
            {
                emp.FirstName = txtFirstName.Text;
                emp.LastName = txtLastName.Text;
                emp.Address = txtAddress.Text;
                emp.Salary = decimal.Parse(txtSalary.Text);

                _context.SaveChanges();
                LoadData(); // Refresh grid
                ClearFields();
            }
        }
        // Delete selected employee
        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtId.Text);
            var emp = _context.Employees.FirstOrDefault(x => x.Id == id);

            if (emp != null)
            {
                _context.Employees.Remove(emp);
                _context.SaveChanges();
                LoadData(); // Refresh grid
                ClearFields();
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

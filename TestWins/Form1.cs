using System;
using System.Windows.Forms;
using TestWins.Controller;
using TestWins.Model;

namespace TestWins;

public partial class Form1 : Form
{
    private readonly StudentController controller = new StudentController();
    private TextBox txtStudentId;

    public Form1()
    {
        InitializeComponent();
        txtStudentId = new TextBox(); // Initialize StudentId textbox (hidden)
        txtStudentId.Visible = false; // Hidden field for updates/deletes
        Controls.Add(txtStudentId);
        loadData();
    }

    private void loadData()
    {
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = controller.getAll();
    }

    private void btnAdd_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtName.Text) ||
            string.IsNullOrWhiteSpace(txtAge.Text) ||
            string.IsNullOrWhiteSpace(txtCourse.Text))
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        Student s = new Student
        {
            Name = txtName.Text,
            age = int.Parse(txtAge.Text),
            course = txtCourse.Text
        };

        controller.createStudent(s);
        MessageBox.Show("Student added successfully!");
        ClearFields();
        loadData();
    }

    private void btnUpdate_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            MessageBox.Show("Select a student to update.");
            return;
        }

        Student s = new Student
        {
            studentId = txtStudentId.Text,
            Name = txtName.Text,
            age = int.Parse(txtAge.Text),
            course = txtCourse.Text
        };

        controller.update(s);
        MessageBox.Show("Student updated successfully!");
        ClearFields();
        loadData();
    }

    private void btnDelete_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtStudentId.Text))
        {
            MessageBox.Show("Select a student to delete.");
            return;
        }

        controller.delete(txtStudentId.Text);
        MessageBox.Show("Student deleted successfully!");
        ClearFields();
        loadData();
    }

    private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
    {
        if (e.RowIndex >= 0)
        {
            var row = dataGridView1.Rows[e.RowIndex];
            txtStudentId.Text = row.Cells["studentId"].Value.ToString();
            txtName.Text = row.Cells["Name"].Value.ToString();
            txtAge.Text = row.Cells["age"].Value.ToString();
            txtCourse.Text = row.Cells["course"].Value.ToString();
        }
    }

    private void ClearFields()
    {
        txtStudentId.Text = "";
        txtName.Text = "";
        txtAge.Text = "";
        txtCourse.Text = "";
    }
}

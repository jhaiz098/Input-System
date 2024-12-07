using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Input_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddStudentForm addStudentForm = new AddStudentForm();
            addStudentForm.Show();
        }

        public void UpdateStudentsInfo()
        {
            dataGridView1.Rows.Clear();

            foreach (Student student in MainClass.students)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = student.firstName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = student.middleName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = student.lastName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[3].Value = student.collegeName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[4].Value = student.courseName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[5].Value = student.id;
            }
        }
    }
}

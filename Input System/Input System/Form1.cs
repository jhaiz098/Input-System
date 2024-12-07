using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Input_System
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e) 
        {
            // Edit button

            List<Student> filteredStudents = new List<Student>();

            if (string.IsNullOrEmpty(textBox1.Text))
            {
                // If the textbox is empty
                // display all students info
                UpdateStudentsInfo(MainClass.students);
            }
            else
            {
                if (comboBox1.SelectedIndex == 0)
                {
                    // if the selected section to search is all or index 0,
                    // search all section
                    for (int i = 0; i < MainClass.students.Count; i++)
                    {
                        if (MainClass.students[i].firstName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }

                        if (MainClass.students[i].middleName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }

                        if (MainClass.students[i].lastName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }

                        if (MainClass.students[i].collegeName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }

                        if (MainClass.students[i].courseName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }

                        if (MainClass.students[i].studentID.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                            continue;
                        }
                    }
                }
                else
                {
                    //if the selected section to search in not all or index 0
                    switch (comboBox1.SelectedIndex)
                    {
                        case 1:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].firstName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                        case 2:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].middleName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                        case 3:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].lastName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                        case 4:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].collegeName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                        case 5:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].courseName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                        case 6:
                                for (int i = 0; i < MainClass.students.Count; i++)
                                {
                                    if (MainClass.students[i].studentID.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                    {
                                        filteredStudents.Add(MainClass.students[i]);
                                    }
                                }
                            break;
                    }
                }


                if(filteredStudents.Count == 0)
                {
                    MessageBox.Show("No students match the entered information", "Search result messages");
                }
                else
                {
                    UpdateStudentsInfo(filteredStudents);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Edit button

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string firstName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[1].Value);
                string middleName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[2].Value);
                string lastName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[3].Value);
                string college = Convert.ToString(dataGridView1.SelectedRows[i].Cells[4].Value);
                string course = Convert.ToString(dataGridView1.SelectedRows[i].Cells[5].Value);
                string id = Convert.ToString(dataGridView1.SelectedRows[i].Cells[6].Value);

                // Find the student in the list by matching all properties
                Student studentToEdit = MainClass.students.FirstOrDefault(s =>
                    s.firstName == firstName &&
                    s.middleName == middleName &&
                    s.lastName == lastName &&
                    s.collegeName == college &&
                    s.courseName == course &&
                    s.studentID == id); // Comparing all properties to identify the student

                EditStudentForm editStudentForm = new EditStudentForm(studentToEdit, this);
                editStudentForm.Show();
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            // Add button

            AddStudentForm addStudentForm = new AddStudentForm(this);
            addStudentForm.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            // Delete button

            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                string firstName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[1].Value);
                string middleName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[2].Value);
                string lastName = Convert.ToString(dataGridView1.SelectedRows[i].Cells[3].Value);
                string college = Convert.ToString(dataGridView1.SelectedRows[i].Cells[4].Value);
                string course = Convert.ToString(dataGridView1.SelectedRows[i].Cells[5].Value);
                string id = Convert.ToString(dataGridView1.SelectedRows[i].Cells[6].Value);

                // Find the student in the list by matching all properties
                Student studentToRemove = MainClass.students.FirstOrDefault(s =>
                    s.firstName == firstName &&
                    s.middleName == middleName &&
                    s.lastName == lastName &&
                    s.collegeName == college &&
                    s.courseName == course &&
                    s.studentID == id); // Comparing all properties to identify the student

                if (studentToRemove != null)
                {
                    MainClass.students.Remove(studentToRemove);
                    MessageBox.Show("Deleted successfully");
                }
                else
                {
                    MessageBox.Show("Failed to delete. Student not found.");
                }
            }

            // Refresh the DataGridView after deletion
            UpdateStudentsInfo(MainClass.students);

            // Reset input fields after deletion
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
        }

        public void UpdateStudentsInfo(List<Student> students)
        {
            dataGridView1.Rows.Clear();
            int i = 0;
            foreach (Student student in students)
            {
                i++;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = i;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[1].Value = student.firstName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[2].Value = student.middleName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[3].Value = student.lastName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[4].Value = student.collegeName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[5].Value = student.courseName;
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[6].Value = student.studentID;
            }
        }
    }
}

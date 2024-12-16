using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Input_System
{
    public partial class Form1 : Form
    {
        // Constructor for the form
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0; // Set default selected index of comboBox1 to 0 (All sections)
        }

        // Event handler for the "Search" button click
        private void button1_Click(object sender, EventArgs e)
        {
            // List to store filtered students based on search criteria
            List<Student> filteredStudents = new List<Student>();

            // If the search textbox is empty, display all students
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                UpdateStudentsInfo(MainClass.students); // Display all students info
            }
            else
            {
                // If comboBox1 is set to "All" (index 0), search across all fields
                if (comboBox1.SelectedIndex == 0)
                {
                    for (int i = 0; i < MainClass.students.Count; i++)
                    {
                        // Search for the entered text in each student property
                        if (MainClass.students[i].firstName.Trim().ToLower().Contains(textBox1.Text.ToLower()) ||
                            MainClass.students[i].middleName.Trim().ToLower().Contains(textBox1.Text.ToLower()) ||
                            MainClass.students[i].lastName.Trim().ToLower().Contains(textBox1.Text.ToLower()) ||
                            MainClass.students[i].collegeName.Trim().ToLower().Contains(textBox1.Text.ToLower()) ||
                            MainClass.students[i].courseName.Trim().ToLower().Contains(textBox1.Text.ToLower()) ||
                            MainClass.students[i].studentID.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                        {
                            filteredStudents.Add(MainClass.students[i]);
                        }
                    }
                }
                else
                {
                    // If comboBox1 is set to a specific field, filter based on that
                    switch (comboBox1.SelectedIndex)
                    {
                        case 1: // Search by First Name
                            foreach (var student in MainClass.students)
                            {
                                if (student.firstName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                        case 2: // Search by Middle Name
                            foreach (var student in MainClass.students)
                            {
                                if (student.middleName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                        case 3: // Search by Last Name
                            foreach (var student in MainClass.students)
                            {
                                if (student.lastName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                        case 4: // Search by College Name
                            foreach (var student in MainClass.students)
                            {
                                if (student.collegeName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                        case 5: // Search by Course Name
                            foreach (var student in MainClass.students)
                            {
                                if (student.courseName.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                        case 6: // Search by Student ID
                            foreach (var student in MainClass.students)
                            {
                                if (student.studentID.Trim().ToLower().Contains(textBox1.Text.ToLower()))
                                {
                                    filteredStudents.Add(student);
                                }
                            }
                            break;
                    }
                }

                // If no matching students found, show a message
                if (filteredStudents.Count == 0)
                {
                    MessageBox.Show("No students match the entered information", "Search result messages");
                }
                else
                {
                    // Display the filtered students
                    UpdateStudentsInfo(filteredStudents);
                }
            }
        }

        // Event handler for the "Edit" button click
        private void button2_Click(object sender, EventArgs e)
        {
            // Loop through each selected row in the DataGridView
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                // Extract the student details from the selected row
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
                    s.studentID == id); // All properties must match

                // Open the EditStudentForm with the selected student
                EditStudentForm editStudentForm = new EditStudentForm(studentToEdit, this);
                editStudentForm.Show();
            }
        }

        // Event handler for the "Add" button click
        private void button3_Click(object sender, EventArgs e)
        {
            // Open the AddStudentForm
            AddStudentForm addStudentForm = new AddStudentForm(this);
            addStudentForm.Show();
        }

        // Event handler for the "Delete" button click
        private void button4_Click(object sender, EventArgs e)
        {
            // Loop through each selected row in the DataGridView for deletion
            for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
            {
                // Extract student details from the selected row
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
                    s.studentID == id); // All properties must match

                // If student found, remove from the list and show a message
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

            // Reset the search textbox and combobox after deletion
            textBox1.Text = string.Empty;
            comboBox1.SelectedIndex = 0;
        }

        // Method to update the DataGridView with the provided list of students
        public void UpdateStudentsInfo(List<Student> students)
        {
            dataGridView1.Rows.Clear(); // Clear existing rows
            int i = 0;

            // Add rows for each student in the list
            foreach (Student student in students)
            {
                i++;
                dataGridView1.Rows.Add();
                dataGridView1.Rows[dataGridView1.RowCount - 1].Cells[0].Value = i; // Row number
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

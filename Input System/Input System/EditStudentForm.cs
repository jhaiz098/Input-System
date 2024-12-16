using System;
using System.Linq;
using System.Windows.Forms;

namespace Input_System
{
    public partial class EditStudentForm : Form
    {
        // Declare a student object and a reference to the main form
        Student student;
        Form1 mainForm;

        // Constructor that initializes the form with data from the student and main form
        public EditStudentForm(Student student, Form1 mainForm)
        {
            InitializeComponent();  // Initialize the form components
            this.student = student;  // Store the student object
            this.mainForm = mainForm;  // Store the reference to the main form

            // Set the form fields to the student's existing data
            textBox1.Text = student.firstName;  // First name
            textBox2.Text = student.middleName; // Middle name
            textBox3.Text = student.lastName;   // Last name
            comboBox1.SelectedItem = student.collegeName;  // Set the selected college
            comboBox2.SelectedItem = student.courseName;   // Set the selected course
            textBox4.Text = student.studentID;  // Student ID
        }

        // Close the form when button1 is clicked
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();  // Close the form
        }

        // Handle updating the student details when button2 is clicked
        private void button2_Click(object sender, EventArgs e)
        {
            // Find the student in the list based on their original details
            Student studentToUpdate = MainClass.students.FirstOrDefault(s =>
                s.firstName == student.firstName &&
                s.middleName == student.middleName &&
                s.lastName == student.lastName &&
                s.collegeName == student.collegeName &&
                s.courseName == student.courseName &&
                s.studentID == student.studentID);

            // Update the found student's details with the new values from the form
            studentToUpdate.firstName = textBox1.Text;
            studentToUpdate.middleName = textBox2.Text;
            studentToUpdate.lastName = textBox3.Text;
            studentToUpdate.collegeName = Convert.ToString(comboBox1.SelectedItem);
            studentToUpdate.courseName = Convert.ToString(comboBox2.SelectedItem);
            studentToUpdate.studentID = textBox4.Text;

            // Update the main form with the new student list
            mainForm.UpdateStudentsInfo(MainClass.students);

            // Close the form after updating
            this.Close();
        }

        // Handle the event when the college selection changes in comboBox1
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            // Clear and reset the course comboBox based on the selected college
            comboBox2.Items.Clear();
            comboBox2.Text = string.Empty;

            // Enable or disable the course comboBox depending on the college chosen
            switch (comboBox1.SelectedIndex)
            {
                case -1: // No college selected
                    comboBox2.Enabled = false;
                    break;
                case 0: // College of Architecture and Allied Discipline
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Science in Architecture (BSAr)");
                    comboBox2.Items.Add("Bachelor of Science in Interior Design (BSID)");
                    break;
                case 1: // College of Arts and Sciences
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Science in Economics");
                    comboBox2.Items.Add("Batsilyer ng Sining sa Filipino");
                    comboBox2.Items.Add("Bachelor of Arts in English Language (BAEL)");
                    comboBox2.Items.Add("Bachelor of Science in Mathematics (BSMath)");
                    comboBox2.Items.Add("Bachelor of Science in Environmental Science (BSES)");
                    comboBox2.Items.Add("Bachelor of Science in Chemistry (BSChem)");
                    comboBox2.Items.Add("Bachelor of Science in Statistics (BSStat)");
                    break;
                case 2: // College of Business and Entrepreneurship
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Science in Entrepreneurship (BSE)");
                    comboBox2.Items.Add("Bachelor of Science in Office Administration (BSOA)");
                    comboBox2.Items.Add("Bachelor of Science in Accountancy (BSA)");
                    comboBox2.Items.Add("Bachelor of Science in Marketing (BSM)");
                    break;
                case 3: // College of Education
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Secondary Education (BSEd) major in Mathematics");
                    comboBox2.Items.Add("Bachelor of Secondary Education (BSEd) major in Science");
                    comboBox2.Items.Add("Bachelor of Culture & Arts Education (BCAEd)");
                    comboBox2.Items.Add("Bachelor of Physical Education (BPEd)");
                    comboBox2.Items.Add("Bachelor in Elementary Education (BEED)");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Food and Service Management (FSM)");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Civil and Construction");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Automotive Technology (AT)");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Electrical Technology (ET)");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Garments, Fashion & Design (GFD)");
                    comboBox2.Items.Add("Bachelor of Technical-Vocational Teacher Education (BTVTEd) major in Heating, Ventilating, Air-Conditioning and Refrigeration Technology");
                    comboBox2.Items.Add("Bachelor of  Technology & Livelihood Education (BTLEd) major in Industrial Arts (IA)");
                    comboBox2.Items.Add("Bachelor of  Technology & Livelihood Education (BTLEd) major in Home Economics (HE)");
                    comboBox2.Items.Add("Diploma in Teaching Secondary (DTS)");
                    break;
                case 4: // College of Engineering
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Science in Chemical Engineering (BSChE)");
                    comboBox2.Items.Add("Bachelor of Science in Civil Engineering (BSCE)");
                    comboBox2.Items.Add("Bachelor of Science in Electrical Engineering (BSEE)");
                    comboBox2.Items.Add("Bachelor of Science in Electronics Engineering (BSECE)");
                    comboBox2.Items.Add("Bachelor of Science in Geodetic Engineering (BSGE)");
                    comboBox2.Items.Add("Bachelor of Science in Mechanical Engineering (BSME)");
                    comboBox2.Items.Add("Bachelor of Science in Industrial Engineering (BSIE)");
                    comboBox2.Items.Add("Bachelor of Science in Information Technology (BSIT)");
                    break;
                case 5: // College of Technology
                    comboBox2.Enabled = true;
                    comboBox2.Items.Add("Bachelor of Science in Hospitality Management (BSHM)");
                    comboBox2.Items.Add("Bachelor of Science in Nutrition & Dietetics (BSND)");
                    comboBox2.Items.Add("Bachelor of Industrial Technology (BIndTech)");
                    comboBox2.Items.Add("Bachelor of Science in Mechanical Technology with major in Automotive");
                    comboBox2.Items.Add("Bachelor of Science in Mechanical Technology with major in Metallurgy");
                    comboBox2.Items.Add("Bachelor of Science in Mechanical Technology with major in Machine Shop");
                    comboBox2.Items.Add("Bachelor of Science in Mechanical Technology with major in Welding and Fabrication");
                    break;
            }
        }

        // Method to validate the inputs when adding or updating a student
        private bool ValidateAddStudentInputs()
        {
            bool isValid = true;  // Assume inputs are valid initially

            // Check if the first name is empty or whitespace
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the student's first name", "Error");
                isValid = false;
            }

            // Check if the middle name is empty or whitespace
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the student's middle name", "Error");
                isValid = false;
            }

            // Check if the last name is empty or whitespace
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter the student's last name", "Error");
                isValid = false;
            }

            // Check if a college has been selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's college", "Error");
                isValid = false;
            }

            // Check if a course has been selected
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's course", "Error");
                isValid = false;
            }

            // Check if the student ID is empty or whitespace
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter the student's student ID", "Error");
                isValid = false;
            }

            return isValid;  // Return whether the inputs are valid
        }
    }
}

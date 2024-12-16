using System;
using System.Windows.Forms;

namespace Input_System
{
    public partial class AddStudentForm : Form
    {
        // Reference to the main form, which will be used to update the student list
        Form1 mainForm;

        // Constructor that takes the parent Form (Form1) as a parameter
        public AddStudentForm(Form1 parentForm)
        {
            InitializeComponent();  // Initializes the form's components (auto-generated code)
            mainForm = parentForm;  // Assigns the main form reference
        }

        // Close button click event: simply closes the current form
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();  // Closes the AddStudentForm
        }

        // Add student button click event: validates inputs and adds a new student to the list
        private void button2_Click(object sender, EventArgs e)
        {
            // Validate the inputs before proceeding
            if (ValidateAddStudentInputs()) // If all inputs are valid
            {
                // Get the student's details from the form controls
                string firstName = textBox1.Text;
                string middleName = textBox2.Text;
                string lastName = textBox3.Text;
                string college = Convert.ToString(comboBox1.SelectedItem);
                string course = Convert.ToString(comboBox2.SelectedItem);
                string id = textBox4.Text;

                // Add the new student to the global student list (MainClass.students)
                MainClass.students.Add(new Student(firstName, middleName, lastName, college, course, id));

                // Update the main form with the updated list of students
                mainForm.UpdateStudentsInfo(MainClass.students);

                // Close the current form (AddStudentForm)
                this.Close();
            }
        }

        // College combo box selection change event: adjusts the course options based on the selected college
        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();  // Clear the existing course options
            comboBox2.Text = string.Empty;  // Clear the selected course (if any)

            // Enable/Disable and populate the course options based on the selected college
            switch (comboBox1.SelectedIndex)
            {
                case -1: // No college selected
                    comboBox2.Enabled = false;  // Disable the course combo box
                    break;
                case 0: // College of Architecture and Allied Discipline
                    comboBox2.Enabled = true;  // Enable the course combo box
                    comboBox2.Items.Add("Bachelor of Science in Architecture (BSAr)");
                    comboBox2.Items.Add("Bachelor of Science in Interior Design (BSID)");
                    break;
                case 1: // College of Arts and Sciences
                    comboBox2.Enabled = true;  // Enable the course combo box
                    comboBox2.Items.Add("Bachelor of Science in Economics");
                    comboBox2.Items.Add("Batsilyer ng Sining sa Filipino");
                    comboBox2.Items.Add("Bachelor of Arts in English Language (BAEL)");
                    comboBox2.Items.Add("Bachelor of Science in Mathematics (BSMath)");
                    comboBox2.Items.Add("Bachelor of Science in Environmental Science (BSES)");
                    comboBox2.Items.Add("Bachelor of Science in Chemistry (BSChem)");
                    comboBox2.Items.Add("Bachelor of Science in Statistics (BSStat)");
                    break;
                case 2: // College of Business and Entrepreneurship
                    comboBox2.Enabled = true;  // Enable the course combo box
                    comboBox2.Items.Add("Bachelor of Science in Entrepreneurship (BSE)");
                    comboBox2.Items.Add("Bachelor of Science in Office Administration (BSOA)");
                    comboBox2.Items.Add("Bachelor of Science in Accountancy (BSA)");
                    comboBox2.Items.Add("Bachelor of Science in Marketing (BSM)");
                    break;
                case 3: // College of Education
                    comboBox2.Enabled = true;  // Enable the course combo box
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
                    comboBox2.Enabled = true;  // Enable the course combo box
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
                    comboBox2.Enabled = true;  // Enable the course combo box
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

        // Validate the inputs entered in the form
        private bool ValidateAddStudentInputs()
        {
            bool isValid = true;  // Assume the inputs are valid initially

            // Check if the first name is empty or contains only whitespaces
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the student's first name", "Error");
                isValid = false;  // Invalid input
            }

            // Check if the middle name is empty or contains only whitespaces
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the student's middle name", "Error");
                isValid = false;  // Invalid input
            }

            // Check if the last name is empty or contains only whitespaces
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter the student's last name", "Error");
                isValid = false;  // Invalid input
            }

            // Check if the college is selected
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's college", "Error");
                isValid = false;  // Invalid input
            }

            // Check if the course is selected
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's course", "Error");
                isValid = false;  // Invalid input
            }

            // Check if the student ID is empty or contains only whitespaces
            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter the student's student ID", "Error");
                isValid = false;  // Invalid input
            }

            return isValid;  // Return the result of the validation
        }
    }
}

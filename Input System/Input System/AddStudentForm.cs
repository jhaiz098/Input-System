using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Input_System
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm(Form1 parentForm)
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (ValidateAddStudentInputs()) // if all inputs are valid
            {
                string firstName = textBox1.Text;
                string middleName = textBox2.Text;
                string lastName = textBox3.Text;
                string college = Convert.ToString(comboBox1.SelectedItem);
                string course = Convert.ToString(comboBox2.SelectedItem);
                string id = textBox4.Text;

                MainClass.students.Add(new Student(firstName, middleName, lastName, college, course, id));

                Form1 d = new Form1();
                d.UpdateStudentsInfo();

                MessageBox.Show("Student Added");
                this.Close();
            }

        }

        private void comboBox1_TextChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            comboBox2.Text = string.Empty;

            switch (comboBox1.SelectedIndex)
            {
                case -1: // no selected items
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
    
        private bool ValidateAddStudentInputs()
        {
            bool isValid = true;

            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Please enter the student's first name", "Error");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                MessageBox.Show("Please enter the student's middle name", "Error");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                MessageBox.Show("Please enter the student's last name", "Error");
                isValid = false;
            }

            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's college", "Error");
                isValid = false;
            }

            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Please choose the student's course", "Error");
                isValid = false;
            }

            if (string.IsNullOrWhiteSpace(textBox4.Text))
            {
                MessageBox.Show("Please enter the student's student ID", "Error");
                isValid = false;
            }

            return isValid;
        }
    }
}

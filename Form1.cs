using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _6labac_
{
    public partial class Form1 : Form
    {
        StudentCollection collection = new StudentCollection();

        public Form1()
        {
            InitializeComponent();
            collection.AddStudent(new Student("Smith", "Group A", "Платна", 95));
            collection.AddStudent(new Student("Johnson", "Group B", "Бюджетна", 99));
            collection.AddStudent(new Student("Williams", "Group A", "Платна", 100));
            collection.AddStudent(new Student("Jones", "Group B", "Платна", 97));
            collection.AddStudent(new Student("Brown", "Group A", "Платна", 98));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            collection.DisplayStudents();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            collection.DisplayScholarshipStudents();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            collection.SortStudentsByGradeDescending();
            collection.DisplayStudents();
        }
    }
}

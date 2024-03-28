using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;



namespace _6labac_
{
    public class Student : IComparable<Student>
    {
        public string LastName { get; set; }
        public string Group { get; set; }
        public string EnrollmentForm { get; set; }
        private double _averageGrade;

        public double AverageGrade
        {
            get { return _averageGrade; }
            set
            {
                if (value < 0 || value > 100)
                    throw new ArgumentOutOfRangeException("Average grade must be between 0 and 100.");
                _averageGrade = value;
            }
        }

        

        public Student(string lastName, string group, string enrollmentForm, double averageGrade)
        {
            LastName = lastName;
            Group = group;
            EnrollmentForm = enrollmentForm;
            AverageGrade = averageGrade;
            if (enrollmentForm == "Платна" && averageGrade > 98)
                EnrollmentForm = "За рахунок іменної стипендії";
        }

        public int CompareTo(Student other)
        {
            if (other == null) return 1;
            return _averageGrade.CompareTo(other._averageGrade);
        }

        public override string ToString()
        {
            return $"{LastName}, {Group}, {EnrollmentForm}, Average Grade: {_averageGrade}";
        }
    }

    public class StudentCollection
    {
        private List<Student> students = new List<Student>();

        public void AddStudent(Student student)
        {
            students.Add(student);
        }

        public void DisplayStudents()
        {
            string message = "";
            foreach (var student in students)
            {
                message += student + "\n";
            }
            MessageBox.Show(message, "Список студентів");
        }
        public void DisplayScholarshipStudents()
        {
            string message = "Студенти, які вчаться за рахунок іменної стипендії:\n";
            foreach (var student in students)
            {
                if (student.EnrollmentForm == "За рахунок іменної стипендії")
                {
                    message += student + "\n";
                }
            }
            MessageBox.Show(message, "Студенти на іменній стипендії");
        }
        public void SortStudentsByGradeDescending()
        {
            students.Sort((x, y) => y.AverageGrade.CompareTo(x.AverageGrade));
        }
        public void SortStudentsByGrade()
        {
            students.Sort();
        }

        public void DisplayGroups()
        {
            var groups = students.Select(s => s.Group).Distinct();
            foreach (var group in groups)
            {
                Console.WriteLine($"Group: {group}");
                foreach (var student in students.Where(s => s.Group == group))
                {
                    Console.WriteLine(student);
                }
            }
        }

        public void WriteToFile(string filename)
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (var student in students)
                {
                    writer.WriteLine(student);
                }
            }
        }

        public void ReadFromFile(string filename)
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length == 4)
                    {
                        string lastName = parts[0].Trim();
                        string group = parts[1].Trim();
                        string enrollmentForm = parts[2].Trim();
                        double averageGrade = double.Parse(parts[3].Split(':')[1].Trim());
                        students.Add(new Student(lastName, group, enrollmentForm, averageGrade));
                    }
                }
            }
        }
    }
}

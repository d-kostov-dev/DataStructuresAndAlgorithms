namespace Students
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// Reads a file with students information and adds it to SortedDictionary.
    /// </summary>
    public class StudentsDatabase
    {
        private const char StudentParamsSeparator = '|';

        private string dataFilePath;
        private SortedDictionary<string, ICollection<Student>> studentsData;

        public StudentsDatabase(string pathToData)
        {
            this.dataFilePath = pathToData;
            this.studentsData = new SortedDictionary<string, ICollection<Student>>();
            this.GetStudentsData();
        }

        /// <summary>
        /// Gets all students ordered by course, last name and first name.
        /// </summary>
        /// <returns>String with formated data.</returns>
        public string ShowStudentsByCourse()
        {
            StringBuilder result = new StringBuilder();

            foreach (var studentsList in this.studentsData)
            {
                result.Append(studentsList.Key);
                result.Append(": ");

                var studentsInCourse = studentsList.Value
                                                   .OrderBy(s => s.LastName)
                                                   .ThenBy(s => s.FirstName);

                result.AppendLine(string.Join(", ", studentsInCourse));
            }

            return result.ToString();
        }

        /// <summary>
        /// Gets the students data from the specified file.
        /// </summary>
        private void GetStudentsData()
        {
            StreamReader dataReader = new StreamReader(this.dataFilePath);

            using (dataReader)
            {
                while (true)
                {
                    string dataLine = dataReader.ReadLine();

                    if (dataLine == null)
                    {
                        break;
                    }

                    var student = this.ParseStudent(dataLine);
                    this.AddStudentToDatabase(student);
                }
            }
        }

        /// <summary>
        /// Parses a single line of student data to Student instance.
        /// </summary>
        /// <param name="dataLine">String holding student information.</param>
        /// <returns>Student class instance.</returns>
        private Student ParseStudent(string dataLine)
        {
            var studentParams = dataLine.Split(StudentParamsSeparator)
                                .Select(s => s.Trim())
                                .ToArray();

            string firstName = studentParams[0];
            string lastName = studentParams[1];
            string courseName = studentParams[2];

            var currentStudent = new Student()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    CourseName = courseName
                };

            return currentStudent;
        }

        /// <summary>
        /// Adds the parsed students to the "database".
        /// </summary>
        /// <param name="student">Student instance.</param>
        private void AddStudentToDatabase(Student student)
        {
            if (!this.studentsData.ContainsKey(student.CourseName))
            {
                this.studentsData.Add(student.CourseName, new List<Student>());
            }

            this.studentsData[student.CourseName].Add(student);
        }
    }
}

namespace Students
{
    /// <summary>
    /// Student class. Just to hold the information about the parsed student.
    /// </summary>
    public class Student
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CourseName { get; set; }

        public override string ToString()
        {
            return this.FirstName + " " + this.LastName;
        }
    }
}

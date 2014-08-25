﻿namespace Students
{
    using System;

    /// <summary>
    /// A text file students.txt holds information about students and their courses in the following format:
    /// Kiril  | Ivanov   | C#
    /// Stefka | Nikolova | SQL
    /// Stela  | Mineva   | Java
    /// Milena | Petrova  | C#
    /// Ivan   | Grigorov | C#
    /// Ivan   | Kolev    | SQL
    /// 
    /// Using SortedDictionary<K,T> print the courses in alphabetical order 
    /// and for each of them prints the students ordered by family and then by name:
    /// C#: Ivan Grigorov, Kiril Ivanov, Milena Petrova
    /// Java: Stela Mineva
    /// SQL: Ivan Kolev, Stefka Nikolova
    /// </summary>
    public class EntryPoint
    {
        public static void Main()
        {
            var studentsDatabase = new StudentsDatabase("../../studentsData.txt");
            Console.WriteLine(studentsDatabase.ShowStudentsByCourse());
        }
    }
}

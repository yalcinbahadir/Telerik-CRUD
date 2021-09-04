using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContextMenuDemo.Data
{
    public static class DataProvider
    {
        private static List<Student> _students = new List<Student>
        {
            new Student{Id=1, Name="Ali", Age=18},
             new Student{Id=2, Name="Tarik", Age=16}
        };

        public static List<Student> GetStudents()
        {
            return _students;
        }
        public static void Remove(List<Student> students)
        {
            foreach (var item in students)
            {
                _students.Remove(item);
            }
        }

        public static void Update(Student student)
        {
            var studentToUpdate=_students.FirstOrDefault(s=>s.Id==student.Id);
            studentToUpdate.Name = student.Name;
            studentToUpdate.Age = student.Age;
        }

        public static void Create(Student student)
        {
            _students.Add(student);
        }
    }
}

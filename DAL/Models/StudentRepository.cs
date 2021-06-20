using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class StudentRepository : IStudentRepository
    {
        public AppDbContext context { get; }
        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<CommonStudent> GetAllStudent()
        {
            List<CommonStudent> lstStudents = new List<CommonStudent>();
            IEnumerable<Student> students = null;
            try
            {
                students = context.Students;

                foreach (var student in students)
                {
                    CommonStudent cStudent = new CommonStudent();

                    cStudent.Email = student.Email;
                    cStudent.Id = student.Id;
                    cStudent.Name = student.Name;
                    cStudent.City = student.City;
                    lstStudents.Add(cStudent);
                }
            }
            catch (Exception ex)
            {
                lstStudents = null;
            }
            return lstStudents;

        }

    }
}

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

        public bool EditStudent(CommonStudent cstudent)
        {
            bool status = false;
            try
            {
                Student student = context.Students.Find(cstudent.Id);
                student.Email = student.Email;
                student.Id = student.Id;
                student.Name = student.Name;
                student.City = student.City;
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public bool EditTution(CommonTution ctution)
        {
            bool status = false;
            try
            {
                Tution tution = context.Tutions.Find(ctution.Id);
                tution.Id = ctution.Id;
                tution.City = ctution.City;
                tution.Description = ctution.Description;
                tution.CreaterId = ctution.CreaterId;
                tution.Status = ctution.Status;
                context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}

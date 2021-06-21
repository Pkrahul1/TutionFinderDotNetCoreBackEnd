using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class TeacherRepository : ITeacherRepository
    {
        public AppDbContext context { get; }
        public TeacherRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool EditTeacher(CommonTeacher cteacher)
        {
            bool status = false;
            try
            {
                Teacher teacher = context.Teachers.Find(cteacher.Email);
                teacher.Name = cteacher.Name;
                teacher.Email = cteacher.Email;
                teacher.City = cteacher.City;
                teacher.Gender = (Gender)cteacher.Gender;
                teacher.About = cteacher.About;
                teacher.Skills = cteacher.Skills;
                teacher.Password = cteacher.Password;
                teacher.ConfirmPassword = cteacher.ConfirmPassword;
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public bool AddTeacher(CommonTeacher cteacher)
        {
            bool status = false;
            try
            {
                Teacher teacher = new Teacher();
                teacher.Name = cteacher.Name;
                teacher.Email = cteacher.Email;
                teacher.City = cteacher.City;
                teacher.Gender = (Gender)cteacher.Gender;
                teacher.About = cteacher.About;
                teacher.Skills = cteacher.Skills;
                teacher.Password = cteacher.Password;
                teacher.ConfirmPassword = cteacher.ConfirmPassword;
                context.Teachers.Add(teacher);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

        public bool Deleteteacher(string email)
        {
            bool status = false;
            try
            {
                Teacher teacher = context.Teachers.Find(email);

                context.Teachers.Remove(teacher);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;

        }
    }
}

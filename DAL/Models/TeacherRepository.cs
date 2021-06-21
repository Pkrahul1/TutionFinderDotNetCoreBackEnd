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
                Teacher teacher = context.Teachers.Find(cteacher.Id);
                teacher.Id = cteacher.Id;
                teacher.Name = cteacher.Name;
                teacher.Email = cteacher.Email;
                teacher.City = cteacher.City;
                teacher.Gender = (Gender)cteacher.Gender;
                teacher.About = cteacher.About;
                teacher.Skills = cteacher.Skills;
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

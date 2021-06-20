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
        public List<CommonTeacher> GetAllTeacher()
        {
            List<CommonTeacher> lstTeacher = new List<CommonTeacher>();
            IEnumerable<Teacher> teachers = null;
            try
            {
                teachers = context.Teachers;

                foreach (var teacher in teachers)
                {
                    CommonTeacher cTeacher = new CommonTeacher();
                    cTeacher.Id = teacher.Id;
                    cTeacher.Name = teacher.Name;
                    cTeacher.Email = teacher.Email;
                    cTeacher.City = teacher.City;
                    cTeacher.Gender = (CALforDataTransfer.Models.Gender)teacher.Gender;
                    cTeacher.About = teacher.About;
                    cTeacher.Skills = teacher.Skills;
                    lstTeacher.Add(cTeacher);
                }
            }
            catch (Exception ex)
            {
                lstTeacher = null;
            }
            return lstTeacher;

        }
    }
}

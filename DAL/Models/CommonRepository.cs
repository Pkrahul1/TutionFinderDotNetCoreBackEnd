using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CommonRepository:ICommonRepository
    {

        public AppDbContext context { get; }
        public CommonRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<CommonTution> GetAllTution()
        {
            List<CommonTution> lstTution = new List<CommonTution>();
            IEnumerable<Tution> tutions = null;
            try
            {
                tutions = context.Tutions;

                foreach (var tution in tutions)
                {
                    CommonTution cTution = new CommonTution();

                    cTution.Id = tution.Id;
                    cTution.City = tution.City;
                    cTution.Description = tution.Description;
                    cTution.CreaterId = tution.CreaterId;
                    cTution.Status = tution.Status;
                    lstTution.Add(cTution);
                }
            }
            catch (Exception ex)
            {
                lstTution = null;
            }
            return lstTution;

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

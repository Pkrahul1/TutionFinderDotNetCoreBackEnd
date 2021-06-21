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
                    CommonTution cTution = FormTution(tution);
                    lstTution.Add(cTution);
                }
            }
            catch (Exception ex)
            {
                lstTution = null;
            }
            return lstTution;

        }
        /// <summary>
        /// common code to form commontution from tution
        /// </summary>
        /// <param name="tution"></param>
        /// <returns></returns>
        private static CommonTution FormTution(Tution tution)
        {
            CommonTution cTution = new CommonTution();

            cTution.Id = tution.Id;
            cTution.City = tution.City;
            cTution.Description = tution.Description;
            cTution.CreaterId = tution.CreaterId;
            cTution.Status = tution.Status;
            return cTution;
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
                    CommonStudent cStudent = FormStudent(student);
                    lstStudents.Add(cStudent);
                }
            }
            catch (Exception ex)
            {
                lstStudents = null;
            }
            return lstStudents;

        }
        /// <summary>
        /// commmon code used to form commonstudent from student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static CommonStudent FormStudent(Student student)
        {
            CommonStudent cStudent = new CommonStudent();

            cStudent.Email = student.Email;
            cStudent.Id = student.Id;
            cStudent.Name = student.Name;
            cStudent.City = student.City;
            return cStudent;
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
                    CommonTeacher cTeacher = FormTeacher(teacher);
                    lstTeacher.Add(cTeacher);
                }
            }
            catch (Exception ex)
            {
                lstTeacher = null;
            }
            return lstTeacher;

        }

        /// <summary>
        /// Common Code used to form commonteacher from teacher 
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        private static CommonTeacher FormTeacher(Teacher teacher)
        {
            CommonTeacher cTeacher = new CommonTeacher();
            cTeacher.Id = teacher.Id;
            cTeacher.Name = teacher.Name;
            cTeacher.Email = teacher.Email;
            cTeacher.City = teacher.City;
            cTeacher.Gender = (CALforDataTransfer.Models.Gender)teacher.Gender;
            cTeacher.About = teacher.About;
            cTeacher.Skills = teacher.Skills;
            return cTeacher;
        }

        public CommonTeacher GetTeacher(int id)
        {
            CommonTeacher cteacher = null;
            try
            {
                Teacher teacher = context.Teachers.Find(id);
                cteacher = FormTeacher(teacher);
            }
            catch (Exception ex)
            {
                cteacher = null;
            }
            return cteacher;
        }
        public CommonStudent GetStudent(int id)
        {
            CommonStudent cstudent = null;
            try
            {
                Student student = context.Students.Find(id);
                cstudent = FormStudent(student);
            }
            catch (Exception ex)
            {
                cstudent = null;
            }
            return cstudent;
        }
        public CommonTution GetTution(int id)
        {
            CommonTution ctution = null;
            try
            {
                Tution tution = context.Tutions.Find(id);
                ctution = FormTution(tution);
            }
            catch (Exception ex)
            {
                ctution = null;
            }
            return ctution;
        }
    }
}

using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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

        #region [privates methods to covert context classes to common classes]
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
            cTution.AppliedBy = tution.AppliedBy;
            cTution.ApprovedTo = tution.ApprovedTo;
            return cTution;
        }

        /// <summary>
        /// Common Code used to form commonteacher from teacher 
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        private static CommonTeacher FormTeacher(Teacher teacher)
        {
            CommonTeacher cTeacher = new CommonTeacher();
            cTeacher.Name = teacher.Name;
            cTeacher.Email = teacher.Email;
            cTeacher.City = teacher.City;
            cTeacher.Gender = (CALforDataTransfer.Models.Gender)teacher.Gender;
            cTeacher.About = teacher.About;
            cTeacher.Skills = teacher.Skills;
            return cTeacher;
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
            cStudent.Name = student.Name;
            cStudent.City = student.City;
            return cStudent;
        }

        #endregion
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
        public List<CommonNotification> GetAllNotification(string email)
        {
            List<CommonNotification> lstNotification = new List<CommonNotification>();
            IEnumerable<Notification> notifications = null;
            try
            {
                notifications = context.Notifications;
                notifications = notifications.Where(e => e.To == email || e.From == email);
                foreach (var notification in notifications)
                {
                    CommonNotification cNotification = new CommonNotification();
                    cNotification.To = notification.To;
                    cNotification.From = notification.From;
                    cNotification.Msg = notification.Msg;
                    lstNotification.Add(cNotification);
                }
            }
            catch (Exception ex)
            {
                lstNotification = null;
            }
            return lstNotification;

        }
        public CommonTeacher GetTeacher(string email)
        {
            CommonTeacher cteacher = null;
            try
            {
                Teacher teacher = context.Teachers.Find(email);
                cteacher = FormTeacher(teacher);
            }
            catch (Exception ex)
            {
                cteacher = null;
            }
            return cteacher;
        }
        public CommonStudent GetStudent(string email)
        {
            CommonStudent cstudent = null;
            try
            {
                Student student = context.Students.Find(email);
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
        public bool AddNotification(CommonNotification cnotification)
        {
            bool status = false;
            try
            {
                IEnumerable<Notification> notifications = context.Notifications;
                Notification notification = new Notification();
                notification.Id = 0;
                //if (notifications.Any())
                //{
                //    notification.Id = notifications.Max(e => e.Id) + 1;
                //}
                notification.To = cnotification.To;
                notification.From = cnotification.From;
                notification.Msg = cnotification.Msg;
                context.Notifications.Add(notification);
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

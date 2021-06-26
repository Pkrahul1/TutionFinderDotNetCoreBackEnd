using CALforDataTransfer.Models;
using CALforDataTransfer.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class CommonRepository:ICommonRepository
    {
        private readonly UserManager<AppUser> userManager;
        private readonly SignInManager<AppUser> signInManager;

        public AppDbContext context { get; }
        public CommonRepository(AppDbContext context, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager) 
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
        private static CommonUser FormTeacher(AppUser teacher)
        {
            CommonUser cTeacher = new CommonUser();
            cTeacher.Name = teacher.Name;
            cTeacher.Email = teacher.Email;
            cTeacher.City = teacher.City;
            cTeacher.Gender = teacher.Gender;
            cTeacher.About = teacher.About;
            cTeacher.Skills = teacher.Skills;
            return cTeacher;
        }
        /// <summary>
        /// commmon code used to form commonstudent from student
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private static CommonUser FormStudent(AppUser student)
        {
            CommonUser cStudent = new CommonUser();

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
        public List<CommonUser> GetAllStudent()
        {
            IEnumerable<AppUser> students = null;
            List<CommonUser> lstStudents = new List<CommonUser>();
            try
            {
                students = userManager.Users;
                foreach (var student in students)
                {
                    CommonUser cStudent = FormStudent(student);
                    lstStudents.Add(cStudent);
                }
            }
            catch (Exception ex)
            {
                lstStudents = null;
            }
            return lstStudents;

        }
        public List<CommonUser> GetAllTeacher()
        {
            IEnumerable<AppUser> teachers = null;
            List<CommonUser> lstTeachers = new List<CommonUser>();
            try
            {
                teachers = userManager.Users;
                foreach (var teacher in teachers)
                {
                    CommonUser cStudent = FormTeacher(teacher);
                    lstTeachers.Add(cStudent);
                }
            }
            catch (Exception ex)
            {
                lstTeachers = null;
            }
            return lstTeachers;

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
        public async Task<CommonUser> GetTeacher(string email)
        {
            CommonUser cteacher = null;
            try
            {
                AppUser teacher = await userManager.FindByEmailAsync(email);
                cteacher = FormTeacher(teacher);
            }
            catch (Exception ex)
            {
                cteacher = null;
            }
            return cteacher;
        }
        public async Task<CommonUser> GetStudent(string email)
        {
            CommonUser cstudent = null;
            try
            {
                AppUser student = await userManager.FindByEmailAsync(email);
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
        public async Task<bool> Update(UpdateViewModel updateViewModel)
        {
            bool status = false;
            try
            {
                AppUser user = await userManager.FindByEmailAsync(updateViewModel.Email);
                user.Email = updateViewModel.Email;
                user.Name = updateViewModel.Name;
                user.City = updateViewModel.City;
                user.About = updateViewModel.About;
                user.Skills = updateViewModel.Skills;
                user.Gender = updateViewModel.Gender;
                var result = await userManager.UpdateAsync(user);
                if (result.Succeeded)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public async Task<bool> Register(RegisterViewModel registerViewModel)
        {
            bool status = false;
            try
            {
                var user = new AppUser { UserName = registerViewModel.Email, Email = registerViewModel.Email, Name = registerViewModel.Name, City = registerViewModel.City };
                var result = await userManager.CreateAsync(user, registerViewModel.Password);
                if(result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }

    }
}

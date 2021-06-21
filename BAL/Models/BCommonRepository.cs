using CALforDataTransfer.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BAL.Models
{
    public class BCommonRepository
    {
        public ICommonRepository icommon;
        public BCommonRepository(ICommonRepository iCommon)
        {
            this.icommon = iCommon;
        }
        public List<CommonTution> GetAllTution()
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = icommon.GetAllTution();
            }
            catch
            {
                lstTution = null;
            }
            return lstTution;
        }
        public List<CommonStudent> GetAllStudent()
        {
            List<CommonStudent> lstStudent = null;
            try
            {
                lstStudent = icommon.GetAllStudent();
            }
            catch
            {
                lstStudent = null;
            }
            return lstStudent;
        }
        public List<CommonTeacher> GetAllTacher()
        {
            List<CommonTeacher> lstTeacher = null;
            try
            {
                lstTeacher = icommon.GetAllTeacher();
            }
            catch
            {
                lstTeacher = null;
            }
            return lstTeacher;
        }
        public List<CommonTution> ViewHistory(string email)
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = icommon.GetAllTution();
                lstTution = lstTution.FindAll(e => e.CreaterId == email.ToString());
            }
            catch
            {
                lstTution = null;
            }
            return lstTution;
        }
        public CommonTeacher GetTeacher(string email)
        {
            CommonTeacher teacher = null;
            try
            {
                teacher = icommon.GetTeacher(email);
            }
            catch
            {
                teacher = null;
            }
            return teacher;
        }
        public CommonStudent GetStudent(string email)
        {
            CommonStudent student = null;
            try
            {
                student = icommon.GetStudent(email);
            }
            catch
            {
                student = null;
            }
            return student;
        }
        public CommonTution GetTution(string email)
        {
            CommonTution tution = null;
            try
            {
                tution = icommon.GetTution(email);
            }
            catch
            {
                tution = null;
            }
            return tution;
        }
    }
}

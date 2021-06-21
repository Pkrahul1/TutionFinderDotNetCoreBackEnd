using CALforDataTransfer.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class BTeacherRepository
    {
        public ITeacherRepository iteacher;
        public BTeacherRepository(ITeacherRepository iTeacher)
        {
            this.iteacher = iTeacher;
        }
        public bool UpdateTeacher(CommonTeacher cteacher)
        {
            bool status = false;
            try
            {
                status = iteacher.EditTeacher(cteacher);
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool RegisterStudent(CommonTeacher cteacher)
        {
            bool status = false;
            try
            {
                status = iteacher.AddTeacher(cteacher);
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool DeleteTeacher(string email)
        {
            bool status = false;
            try
            {
                status = iteacher.Deleteteacher(email);
            }
            catch
            {
                status = false;
            }
            return status;
        }
    }
}

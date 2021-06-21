using DAL.Models;
using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class BStudentRepository
    {
        public IStudentRepository iStudent;
        public BStudentRepository(IStudentRepository iStudent)
        {
            this.iStudent = iStudent;     
        }
        public bool UpdateStudent(CommonStudent cstudent)
        {
            bool status=false;
            try
            {
                status = iStudent.EditStudent(cstudent);
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool UpdateTution(CommonTution ctution)
        {
            bool status = false;
            try
            {
                status = iStudent.EditTution(ctution);
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool RegisterStudent(CommonStudent cstudent)
        {
            bool status = false;
            try
            {
                status = iStudent.AddStudent(cstudent);
            }
            catch
            {
                status = false;
            }
            return status;
        }
        public bool DeleteStudent(string email)
        {
            bool status = false;
            try
            {
                status = iStudent.DeleteStudent(email);
            }
            catch
            {
                status = false;
            }
            return status;

        }
        public bool DeleteTution(string email)
        {
            bool status = false;
            try
            {
                status = iStudent.DeleteTution(email);
            }
            catch
            {
                status = false;
            }
            return status;

        }
        public bool CreateTution(CommonTution ctution)
        {
            bool status = false;
            try
            {
                status = iStudent.CreateTution(ctution);
            }
            catch
            {
                status = false;
            }
            return status;

        }
    }
}

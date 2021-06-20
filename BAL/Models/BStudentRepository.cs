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
        public List<CommonStudent> GetAllStudent()
        {
            List<CommonStudent> lstStudent = null;
            try
            {
                lstStudent = iStudent.GetAllStudent();
            }
            catch
            {
                lstStudent = null;
            }
            return lstStudent;
        }
    }
}

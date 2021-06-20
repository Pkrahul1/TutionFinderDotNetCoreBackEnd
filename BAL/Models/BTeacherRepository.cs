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
        public List<CommonTeacher> GetAllTacher()
        {
            List<CommonTeacher> lstTeacher = null;
            try
            {
                lstTeacher = iteacher.GetAllTeacher();
            }
            catch
            {
                lstTeacher = null;
            }
            return lstTeacher;
        }

    }
}

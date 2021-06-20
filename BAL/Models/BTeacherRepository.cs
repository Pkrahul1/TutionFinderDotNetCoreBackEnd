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
      

    }
}

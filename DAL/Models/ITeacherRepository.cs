using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface ITeacherRepository
    {
        bool EditTeacher(CommonTeacher cteacher);
    }
}

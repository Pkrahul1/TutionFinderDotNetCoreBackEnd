using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface ITeacherRepository
    {
        bool EditTeacher(CommonTeacher cteacher);
        bool AddTeacher(CommonTeacher cteacher);
        bool Deleteteacher(string email);
        bool ApplyTution(int id,string email);
    }
}

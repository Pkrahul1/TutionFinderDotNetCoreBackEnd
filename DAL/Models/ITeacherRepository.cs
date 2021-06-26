using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface ITeacherRepository
    {
        bool ApplyTution(int id,string email);
    }
}

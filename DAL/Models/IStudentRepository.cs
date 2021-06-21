using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IStudentRepository
    {
        bool EditStudent(CommonStudent cstudent);
        bool EditTution(CommonTution ctution);
    }
}

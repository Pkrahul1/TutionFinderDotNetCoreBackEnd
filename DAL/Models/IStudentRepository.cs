using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface IStudentRepository
    {
        bool EditTution(CommonTution ctution);
        bool DeleteTution(string email);
        bool CreateTution(CommonTution ctution);
    }
}

using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public interface ICommonRepository
    {
        List<CommonTution> GetAllTution();
        List<CommonStudent> GetAllStudent();
        List<CommonTeacher> GetAllTeacher();
        CommonTeacher GetTeacher(string email);
        CommonStudent GetStudent(string email);
        CommonTution GetTution(string email);
    }
}

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
        List<CommonNotification> GetAllNotification(string email);
        CommonTeacher GetTeacher(string email);
        CommonStudent GetStudent(string email);
        CommonTution GetTution(int id);
        bool AddNotification(CommonNotification notification);

    }
}

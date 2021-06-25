using CALforDataTransfer.Models;
using CALforDataTransfer.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        Task<bool> Register(RegisterViewModel registerViewModel);

    }
}

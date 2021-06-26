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
        List<CommonUser> GetAllStudent();
        List<CommonUser> GetAllTeacher();
        List<CommonNotification> GetAllNotification(string email);
        Task<CommonUser> GetTeacher(string email);
        Task<CommonUser> GetStudent(string email);
        CommonTution GetTution(int id);
        bool AddNotification(CommonNotification notification);
        Task<bool> Update(UpdateViewModel updateViewModel);
        Task<bool> Register(RegisterViewModel registerViewModel);

    }
}

using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class TeacherRepository : ITeacherRepository
    {
        public AppDbContext context { get; }
        public TeacherRepository(AppDbContext context)
        {
            this.context = context;
        }
        public bool ApplyTution(int id,string email)
        {
            bool status = false;
            try
            {
                Tution tution = context.Tutions.Find(id);
                tution.Status = "Applied";
                tution.AppliedBy=tution.AppliedBy+";"+email;
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
    }
}

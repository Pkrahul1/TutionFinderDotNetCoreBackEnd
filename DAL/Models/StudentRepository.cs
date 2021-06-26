using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class StudentRepository : IStudentRepository
    {
        public AppDbContext context { get; }
        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }

        public bool EditTution(CommonTution ctution)
        {
            bool status = false;
            try
            {
                Tution tution = context.Tutions.Find(ctution.Id);
                tution.City = ctution.City;
                tution.Description = ctution.Description;
                tution.CreaterId = ctution.CreaterId;
                tution.Status = ctution.Status;
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public bool DeleteTution(string email)
        {
            bool status = false;
            try
            {
                Tution tution = context.Tutions.Find(email);

                context.Tutions.Remove(tution);
                context.SaveChanges();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
            }
            return status;
        }
        public bool CreateTution(CommonTution ctution)
        {
            bool status = false;
            try
            {
                IEnumerable<Tution> tutions = context.Tutions;
                Tution tution = new Tution();
                //tution id will be added by db as it is an identity key
                //tution.Id = 0;
                //if (tutions.Any())
                //{
                //    tution.Id = tutions.Max(e => e.Id) + 1;
                //}
                tution.City = ctution.City;
                tution.Description = ctution.Description;
                tution.CreaterId = ctution.CreaterId;
                tution.Status = ctution.Status;
                context.Tutions.Add(tution);
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

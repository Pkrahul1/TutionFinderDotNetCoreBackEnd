using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class StudentRepository : IStudentRepository
    {
        public AppDbContext context { get; }
        public StudentRepository(AppDbContext context)
        {
            this.context = context;
        }
    }
}

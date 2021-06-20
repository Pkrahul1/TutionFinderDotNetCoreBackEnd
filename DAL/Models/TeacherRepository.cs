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
        
    }
}

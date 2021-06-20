using CALforDataTransfer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CommonRepository:ICommonRepository
    {

        public AppDbContext context { get; }
        public CommonRepository(AppDbContext context)
        {
            this.context = context;
        }

        public List<CommonTution> GetAllTution()
        {
            List<CommonTution> lstTution = new List<CommonTution>();
            IEnumerable<Tution> tutions = null;
            try
            {
                tutions = context.Tutions;

                foreach (var tution in tutions)
                {
                    CommonTution cTution = new CommonTution();

                    cTution.Id = tution.Id;
                    cTution.City = tution.City;
                    cTution.Description = tution.Description;
                    cTution.CreaterId = tution.CreaterId;
                    cTution.Status = tution.Status;
                    lstTution.Add(cTution);
                }
            }
            catch (Exception ex)
            {
                lstTution = null;
            }
            return lstTution;

        }
    }
}

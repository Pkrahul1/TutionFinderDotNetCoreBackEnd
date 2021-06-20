using CALforDataTransfer.Models;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BAL.Models
{
    public class BCommonRepository
    {
        public ICommonRepository icommon;
        public BCommonRepository(ICommonRepository iCommon)
        {
            this.icommon = iCommon;
        }
        public List<CommonTution> GetAllTution()
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = icommon.GetAllTution();
            }
            catch
            {
                lstTution = null;
            }
            return lstTution;
        }
    }
}

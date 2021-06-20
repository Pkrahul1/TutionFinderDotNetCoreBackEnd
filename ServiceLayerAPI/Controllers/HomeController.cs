using BAL.Models;
using CALforDataTransfer.Models;
using DAL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayerAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HomeController: Controller
    {
        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public HomeController(IStudentRepository iUser,ITeacherRepository iTeacher,ICommonRepository iCommon)
        {
            bsObj = new BStudentRepository(iUser);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
        }
        [HttpGet]
        public JsonResult GetAllTeacher()
        {
            List<CommonTeacher> lstTeacher = null;
            try
            {
                lstTeacher = btObj.GetAllTacher();
            }
            catch
            {
                lstTeacher = null;
            }
            return Json(lstTeacher);
        }
        [HttpGet]
        public JsonResult GetAllStudent()
        {
            List<CommonStudent> lstStudent = null;
            try
            {
                lstStudent = bsObj.GetAllStudent();
            }
            catch
            {
                lstStudent = null;
            }
            return Json(lstStudent);
        }
        [HttpGet]
        public JsonResult GetAllTution()
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = bcObj.GetAllTution();
            }
            catch(Exception ex)
            {
                lstTution = null;
            }
            return Json(lstTution);
        }
        [HttpGet]
        public JsonResult Index()
        {
            return Json("Rahul Kumar");
        }
    }
}

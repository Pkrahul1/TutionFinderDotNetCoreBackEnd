using BAL.Models;
using CALforDataTransfer.Models;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayerAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
    public class HomeController : Controller
    {
        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public HomeController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
        }
        #region [Get Methods]
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTeacher()
        {
            List<CommonUser> lstTeacher = null;
            try
            {
                lstTeacher = bcObj.GetAllTacher();
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
            List<CommonUser> lstStudent = null;
            try
            {
                lstStudent = bcObj.GetAllStudent();
            }
            catch
            {
                lstStudent = null;
            }
            return Json(lstStudent);
        }
        [HttpGet]
        [AllowAnonymous]
        public JsonResult GetAllTution()
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = bcObj.GetAllTution();
            }
            catch (Exception ex)
            {
                lstTution = null;
            }
            return Json(lstTution);
        }

        [HttpGet("{email}")]
        public JsonResult GetAllNotification(string email)
        {
            List<CommonNotification> lstNotification = null;
            try
            {
                lstNotification = bcObj.GetAllNotification(email);
            }
            catch (Exception ex)
            {
                lstNotification = null;
            }
            return Json(lstNotification);
        }
        [HttpGet("{email}")]
        public async Task<JsonResult> GetTeacher(string email)
        {
            CommonUser teacher = null;
            try
            {
                teacher = await bcObj.GetTeacher(email);
            }
            catch (Exception ex)
            {
                teacher = null;
            }
            return Json(teacher);
        }
        [HttpGet("{email}")]
        public async Task<JsonResult> GetStudent(string email)
        {
            CommonUser student = null;
            try
            {
                student = await bcObj.GetStudent(email);
            }
            catch (Exception ex)
            {
                student = null;
            }
            return Json(student);
        }
        [HttpGet("{id}")]
        public JsonResult GetTution(int id)
        {
            CommonTution tution = null;
            try
            {
                tution = bcObj.GetTution(id);
            }
            catch (Exception ex)
            {
                tution = null;
            }
            return Json(tution);
        }

        [HttpGet("{email}")]
        public JsonResult ViewHistory(string email)
        {
            List<CommonTution> lstTution = null;
            try
            {
                lstTution = bcObj.ViewHistory(email);
            }
            catch (Exception ex)
            {
                lstTution = null;
            }
            return Json(lstTution);
        }
        #endregion

        #region [Post Methods]

        [HttpPost]
        public JsonResult CreateTution(CommonTution tution)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = bsObj.CreateTution(tution);
                }
            }
            catch
            {
                status = false;
            }
            return Json(status);
        }


        [HttpPost]
        public JsonResult EditTution(CommonTution tution)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = bsObj.UpdateTution(tution);
                }
            }
            catch
            {
                status = false;
            }
            return Json(status);
        }

        [HttpPost]
        public JsonResult AddNotification(CommonNotification notification)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = bcObj.AddNotification(notification);
                }
            }
            catch
            {
                status = false;
            }
            return Json(status);
        }
        #endregion

        [HttpGet]
        public JsonResult Index()
        {
            return Json("Rahul Kumar"); 
        }
    }
}

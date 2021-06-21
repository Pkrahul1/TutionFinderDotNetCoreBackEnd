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
    public class HomeController : Controller
    {
        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public HomeController(IStudentRepository iUser, ITeacherRepository iTeacher, ICommonRepository iCommon)
        {
            bsObj = new BStudentRepository(iUser);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
        }
        #region [Get Methods]
        [HttpGet]
        public JsonResult GetAllTeacher()
        {
            List<CommonTeacher> lstTeacher = null;
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
            List<CommonStudent> lstStudent = null;
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
        [HttpGet("{id}")]
        public JsonResult GetTeacher(int id)
        {
            CommonTeacher teacher = null;
            try
            {
                teacher = bcObj.GetTeacher(id);
            }
            catch (Exception ex)
            {
                teacher = null;
            }
            return Json(teacher);
        }
        [HttpGet("{id}")]
        public JsonResult GetStudent(int id)
        {
            CommonStudent student = null;
            try
            {
                student = bcObj.GetStudent(id);
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

        [HttpGet("{id}")]
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
        public JsonResult EditStudent(CommonStudent student)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = bsObj.UpdateStudent(student);
                }
            }
            catch
            {
                status = false;
            }
            return Json(status);
        }
        [HttpPost]
        public JsonResult EditTeacher(CommonTeacher teacher)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = btObj.UpdateTeacher(teacher);
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
        #endregion

        [HttpGet]
        public JsonResult Index()
        {
            return Json("Rahul Kumar");
        }

    }
}

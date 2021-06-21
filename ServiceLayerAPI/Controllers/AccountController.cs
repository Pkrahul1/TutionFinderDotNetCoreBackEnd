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
    public class AccountController:Controller
    {
        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public AccountController(IStudentRepository iUser, ITeacherRepository iTeacher, ICommonRepository iCommon)
        {
            bsObj = new BStudentRepository(iUser);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
        }
        [HttpPost]
        public JsonResult RegisterStudent(CommonStudent student)
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
        public JsonResult RegisterTeacher(CommonTeacher teacher)
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

    }
}

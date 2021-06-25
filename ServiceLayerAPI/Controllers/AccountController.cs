using BAL.Models;
using CALforDataTransfer.Models;
using CALforDataTransfer.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
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
        public AccountController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
        }
        #region [Methods without Using Identity]
        [HttpPost]
        public JsonResult RegisterStudent(CommonStudent student)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = bsObj.RegisterStudent(student);
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
                    status = btObj.RegisterTeacher(teacher);
                }
            }
            catch
            {
                status = false;
            }
            return Json(status);
        }
        #endregion
        [HttpPost]
        public async Task<JsonResult> Register(RegisterViewModel registerViewModels)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = await bcObj.Register(registerViewModels);   
                }
            }
            catch(Exception ex)
            {
                status = false;
                ModelState.AddModelError("Error:",ex.ToString());
            }
            return Json(status);
        }

    }
}

using BAL.Models;
using CALforDataTransfer.Models;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayerAPI.ViewModels;
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
        private readonly IStudentRepository iUser;
        private readonly ITeacherRepository iTeacher;
        private readonly ICommonRepository iCommon;
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public AccountController(IStudentRepository iUser, ITeacherRepository iTeacher, ICommonRepository iCommon,
                                    UserManager<IdentityUser> userManager,SignInManager<IdentityUser> signInManager)
        {
            this.iUser = iUser;
            this.iTeacher = iTeacher;
            this.iCommon = iCommon;
            this.userManager = userManager;
            this.signInManager = signInManager;
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
                    var user = new IdentityUser { UserName = registerViewModels.Email, Email = registerViewModels.Email };
                    var result = await userManager.CreateAsync(user, registerViewModels.Password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        status = true;
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("Error While Registering", error.Description);
                        //this modelsate can be used to show error on UI
                        status = false;
                    }
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

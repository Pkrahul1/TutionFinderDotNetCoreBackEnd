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
        private readonly SignInManager<IdentityUser> signInManager;

        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public AccountController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon,SignInManager<IdentityUser> signInManager)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
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
        public async Task<JsonResult> Register(RegisterViewModel registerViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = await bcObj.Register(registerViewModel);   
                }
            }
            catch(Exception ex)
            {
                status = false;
                ModelState.AddModelError("Error:",ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> Login(LoginViewModel loginViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure: false);
                    if(result.Succeeded)
                    {
                        status = true;
                        return Json(status);
                    }
                    ModelState.AddModelError("SignedIn Error:","SignedIn Failed");
                }
            }
            catch (Exception ex)
            {
                status = false;
                ModelState.AddModelError("Error:", ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> Logout()
        {
            bool status = false;
            try
            {
                await signInManager.SignOutAsync();
                status = true;
            }
            catch (Exception ex)
            {
                status = false;
                ModelState.AddModelError("Error:", ex.ToString());
            }
            return Json(status);
        }

        [HttpGet]
        public  JsonResult IsSignedIn()
        {
            bool status = false;
            try
            {
                status=signInManager.IsSignedIn(User);
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
    }
}

using BAL.Models;
using CALforDataTransfer.Models;
using CALforDataTransfer.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    public class AccountController:Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;

        public BStudentRepository bsObj { get; }
        public BTeacherRepository btObj { get; }
        public BCommonRepository bcObj { get; }
        public AccountController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon,SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        #region[HttpPost Methods]
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel registerViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = await bcObj.Register(registerViewModel);
                    if (status == false)
                    {
                        ModelState.AddModelError("Error", "error while Registering and signing");
                    }
                }
            }
            catch(Exception ex)
            {
                status = false;
                ModelState.AddModelError("Exception:",ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> Update(UpdateViewModel updateViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    status = await bcObj.Update(updateViewModel);
                    if (status == false)
                    {
                        ModelState.AddModelError("Error","error while Updating");
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
                ModelState.AddModelError("Exception:", ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        [AllowAnonymous]
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
                    ModelState.AddModelError("SignedIn Error:","SignedIn Failed,check your password");
                }
            }
            catch (Exception ex)
            {
                status = false;
                ModelState.AddModelError("Exception:", ex.ToString());
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
        [HttpPost]
        public async Task<JsonResult> Delete()
        {
            bool status = false;
            try
            {
                var user = await userManager.GetUserAsync(User);
                var result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    status = true;
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }

        #endregion
        [HttpGet]
        public  JsonResult IsSignedIn  ()
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

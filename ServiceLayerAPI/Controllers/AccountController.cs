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
        private readonly RoleManager<IdentityRole> roleManager;
        public BStudentRepository bsObj;
        public BTeacherRepository btObj;
        public BCommonRepository bcObj;
        public AccountController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon,SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        #region[HttpPost Methods]
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel registerViewModel)
        {
            bool status = false;
            try
            {
                if(ModelState.IsValid)
                {
                    var user = new AppUser { UserName = registerViewModel.Email, Email = registerViewModel.Email, Name = registerViewModel.Name, City = registerViewModel.City };
                    var result = await userManager.CreateAsync(user, registerViewModel.Password);
                    if (result.Succeeded)
                    {
                        await signInManager.SignInAsync(user, isPersistent: false);
                        status = true;
                        return Json(status);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("Errors:", error.Description);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
       
        [HttpGet][HttpPost]
        //[AcceptVerbs("Get","Post")]
        [AllowAnonymous]
        public async Task<JsonResult> IsEmailRegistered(string email)
        {
            try
            {
                var user = await userManager.FindByEmailAsync(email);
                if (user == null)
                {
                    return Json(true);
                }
                return Json(false);
            }
            catch(Exception ex)
            {
                return Json(false);
            }
        }
        [HttpPost]
        public async Task<JsonResult> Update(UpdateViewModel updateViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser user = await userManager.FindByEmailAsync(updateViewModel.Email);
                    user.Email = updateViewModel.Email;
                    user.Name = updateViewModel.Name;
                    user.City = updateViewModel.City;
                    user.About = updateViewModel.About;
                    user.Skills = updateViewModel.Skills;
                    user.Gender = updateViewModel.Gender;
                    var result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        status = true;
                        return Json(status);
                    }
                    foreach(var error in result.Errors)
                    {
                        ModelState.AddModelError("Errors:", error.Description);
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
                    if(result.IsLockedOut || result.IsNotAllowed) 
                    { 
                        ModelState.AddModelError("SignedIn Error:","Account is locked");
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
        public JsonResult IsSignedIn()
        {
            bool status = false;
            try
            {
                status = this.signInManager.IsSignedIn(User);     
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpGet]
        public async Task<JsonResult> IsInRole()
        {
            IList<string> roles = null;
            try
            {
                if(signInManager.IsSignedIn(User))
                {
                    var user = await userManager.GetUserAsync(User);
                    roles = await userManager.GetRolesAsync(user);
                    return Json(roles);
                }
            }
            catch (Exception ex)
            {
                roles = null;
            }
            return Json(roles);
        }
    }
}

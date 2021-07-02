using BAL.Models;
using CALforDataTransfer.Models;
using CALforDataTransfer.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServiceLayerAPI.Customize;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceLayerAPI.Controllers
{

    [Route("api/[controller]/[Action]")]
    [ApiController]
    //[Authorize]
    public class AccountController:Controller
    {
        private readonly SignInManager<AppUser> signInManager;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDataProtector protector;
        public BStudentRepository bsObj;
        public BTeacherRepository btObj;
        public BCommonRepository bcObj;
        public AccountController(IStudentRepository iStudent, ITeacherRepository iTeacher, ICommonRepository iCommon,SignInManager<AppUser> signInManager,
                                    UserManager<AppUser> userManager,RoleManager<IdentityRole> roleManager,IDataProtectionProvider dataProtectionProvider,
                                        DataProtectionPurposeStrings dataProtectionPurposeStrings)
        {
            bsObj = new BStudentRepository(iStudent);
            btObj = new BTeacherRepository(iTeacher);
            bcObj = new BCommonRepository(iCommon);
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.roleManager = roleManager;
            protector = dataProtectionProvider.CreateProtector(dataProtectionPurposeStrings.Id);
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
                        var token = await userManager.GenerateEmailConfirmationTokenAsync(user);
                        string id = protector.Protect(user.Id);
                        var confirmEmailLink = Url.Action("CofirmEmail","Account",new {userId = id, token = token },Request.Scheme);
                        ///send email with token
                        if (signInManager.IsSignedIn(User) && (User.IsInRole("Admin") || User.IsInRole("Owner")))
                        {
                            status = true;
                            return Json(status);
                        }
                        //await signInManager.SignInAsync(user, isPersistent: false);
                        
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
                    var user = await userManager.FindByEmailAsync(loginViewModel.Email);
                    if( user != null && !user.EmailConfirmed && (await userManager.CheckPasswordAsync(user,loginViewModel.Password)))
                    {
                        ModelState.AddModelError("", "Email not confirmed");
                        return Json(status);
                    }
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
        public async Task<JsonResult> LoginExternal(LoginViewModel loginViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, isPersistent: loginViewModel.RememberMe, lockoutOnFailure: false);
                    if (result.Succeeded)
                    {
                        status = true;
                        return Json(status);
                    }
                    if (result.IsLockedOut || result.IsNotAllowed)
                    {
                        ModelState.AddModelError("SignedIn Error:", "Account is locked");
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
        [HttpGet]
        public async Task<JsonResult> ConfirmEmail(string userId, string token)
        {
            bool status = false;
            try
            {
                if (userId != null && token != null)
                {
                    string decryptedId = protector.Unprotect(userId);
                    var user = await userManager.FindByIdAsync(decryptedId);
                    if (user != null)
                    {
                        var result = await userManager.ConfirmEmailAsync(user, token);
                        if (result.Succeeded)
                        {
                            status = true;
                            return Json(status);
                        }
                    }
                    return Json(status);
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> ForgetPassword(string email)
        {
            bool status = false;
            try
            {
                if(ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(email);
                    if (user != null && (await userManager.IsEmailConfirmedAsync(user)))
                    {
                        var token = await userManager.GeneratePasswordResetTokenAsync(user);
                        var confirmEmailLink = Url.Action("ResetPassword", "Account", new { email = user.Email, token = token }, Request.Scheme);
                        if (user != null)
                        {
                            var result = await userManager.ConfirmEmailAsync(user, token);
                            if (result.Succeeded)
                            {
                                status = true;
                                return Json(status);
                            }
                        }
                        return Json(status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> ResetPassword(ResetPasswordViewModel resetPasswordViewModel)
        {
            bool status = false; 
            try 
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.FindByEmailAsync(resetPasswordViewModel.Email);
                    if (user!=null)
                    {
                        var result = await userManager.ResetPasswordAsync(user,resetPasswordViewModel.Token,resetPasswordViewModel.Password);
                        
                        if (result.Succeeded)
                        {
                            status = true;
                            return Json(status);
                        }
                        foreach( var error in result.Errors)
                        {
                            ModelState.AddModelError("",error.Description);
                        }
                        return Json(status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        var result = await userManager.ChangePasswordAsync(user,changePasswordViewModel.CurrentPassword,changePasswordViewModel.NewPassword);

                        if (result.Succeeded)
                        {
                            await signInManager.RefreshSignInAsync(user);
                            status = true;
                            return Json(status);
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return Json(status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> AddPassword(string password)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await userManager.GetUserAsync(User);
                    if (user != null)
                    {
                        //var doespswdExist = await userManager.HasPasswordAsync(user);
                        var result = await userManager.AddPasswordAsync(user,password);
                        if (result.Succeeded)
                        {
                            await signInManager.RefreshSignInAsync(user);
                            status = true;
                            return Json(status);
                        }
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }
                        return Json(status);
                    }
                }
            }
            catch (Exception ex)
            {
                status = false;
            }
            return Json(status);
        }
        [HttpGet]
        public async Task<JsonResult> DoesPasswordExist()
        {
            bool status = false;
            try
            {
                var user = await userManager.GetUserAsync(User);
                if( user != null)
                {
                    var doespswdExist = await userManager.HasPasswordAsync(user);
                    if (doespswdExist)
                    {
                        status = true;
                        return Json(status);
                    }
                }
                return Json(status);
                
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

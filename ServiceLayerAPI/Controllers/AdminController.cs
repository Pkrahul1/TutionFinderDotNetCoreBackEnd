using BAL.Models;
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
    public class AdminController:Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<AppUser> userManager;
        public BAdminRepository baObj;

        public AdminController(IAdminRepository iAdmin,RoleManager<IdentityRole> roleManager,UserManager<AppUser> userManager)
        {
            this.roleManager = roleManager;
            this.userManager = userManager;
            baObj = new BAdminRepository(iAdmin);
        }
        [HttpGet]
        //[Authorize(Roles ="Admin")]
        public async Task<JsonResult> GetUser(string email)
        {
            IList<string> roles;
            //IList<string> claims = null;
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        roles = await userManager.GetRolesAsync(user);
                        //claims = await userManager.GetClaimsAsync(user);
                        ManageUserViewModel manageUserViewModel = new ManageUserViewModel()
                        {
                            Roles=roles
                            //Claims=
                        };
                        return Json(manageUserViewModel); 
                    }
                }
            }
            catch (Exception ex)
            {
                Json(null);
                ModelState.AddModelError("Exception:", ex.ToString());
            }
            return Json(null);
        }
        [HttpPost]
        public async Task<JsonResult> CreateUser(RegisterViewModel registerViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    var user = new AppUser { UserName = registerViewModel.Email, Email = registerViewModel.Email, Name = registerViewModel.Name, City = registerViewModel.City };
                    var result = await userManager.CreateAsync(user, registerViewModel.Password);
                    if (result.Succeeded)
                    {
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
                ModelState.AddModelError("Exception:", ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteUser(string email)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        await userManager.DeleteAsync(user);
                        status = true;
                        return Json(status);
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
        public async Task<JsonResult> DeleteUserRoles(CreateRoleViewModel[] lstCreateRoleViewModel, string email)
        {
            bool status = false;
            IList<string> rolesToDelete = null;
            try
            {
                if (ModelState.IsValid)
                {
                    
                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        foreach (CreateRoleViewModel createRoleViewModel in lstCreateRoleViewModel)
                        {
                            var isInRole = await userManager.IsInRoleAsync(user, createRoleViewModel.RoleName);
                            if (isInRole)
                            {
                                rolesToDelete.Add(createRoleViewModel.RoleName);
                            }
                        }
                        if (rolesToDelete.Count > 0)
                        {
                            var result = await userManager.RemoveFromRolesAsync(user, rolesToDelete);

                            if (result.Succeeded)
                            {
                                status = true;
                                return Json(status);
                            }
                            foreach (IdentityError error in result.Errors)
                            {
                                ModelState.AddModelError("ErrorDeletingRoles", error.Description);
                            }
                        }
                        return Json(false);
                    }
                    return Json(false);
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
        public async Task<JsonResult> AddUserRoles(CreateRoleViewModel[] lstCreateRoleViewModel, string email)
        {
            bool status = false;
            IList<string> rolesToAdd = null;
            try
            {
                if (ModelState.IsValid)
                {

                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        foreach (CreateRoleViewModel createRoleViewModel in lstCreateRoleViewModel)
                        {
                            var isInRole = await userManager.IsInRoleAsync(user, createRoleViewModel.RoleName);
                            if (isInRole)
                            {
                                rolesToAdd.Add(createRoleViewModel.RoleName);
                            }
                        }
                        if (rolesToAdd.Count > 0)
                        {
                            var result = await userManager.AddToRolesAsync(user, rolesToAdd);

                            if (result.Succeeded)
                            {
                                status = true;
                                return Json(status);
                            }
                            foreach (IdentityError error in result.Errors)
                            {
                                ModelState.AddModelError("ErrorAddingRoles", error.Description);
                            }
                        }
                        return Json(false);
                    }
                    return Json(false);
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
        public async Task<JsonResult> CreateRole(CreateRoleViewModel createRoleViewModel)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    IdentityRole identityRole = new IdentityRole { Name = createRoleViewModel.RoleName };
                    var result = await roleManager.CreateAsync(identityRole);
                    if (result.Succeeded)
                    {
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
                ModelState.AddModelError("Exception:", ex.ToString());
            }
            return Json(status);
        }
        [HttpPost]
        public async Task<JsonResult> DeleteRole(string role)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {
                    if (await roleManager.RoleExistsAsync(role))
                    {
                        IdentityRole identityRole = await roleManager.FindByNameAsync(role);
                        var result = await roleManager.DeleteAsync(identityRole);
                        if (result.Succeeded)
                        {
                            status = true;
                            return Json(status);
                        }
                        foreach (IdentityError error in result.Errors)
                        {
                            ModelState.AddModelError("ErrorInDeletingRole", error.Description);
                        }
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
        
        
        [HttpGet]
        public JsonResult GetAllRole()
        {
            IEnumerable<IdentityRole> roles = null;
            List<CreateRoleViewModel> lstRoles = new List<CreateRoleViewModel>();
            try
            {
                roles = roleManager.Roles;
                foreach (var role in roles)
                {
                    CreateRoleViewModel crole = new CreateRoleViewModel();
                    crole.RoleName = role.Name;
                    lstRoles.Add(crole);
                }
            }
            catch (Exception ex)
            {
                lstRoles = null;
            }
            return Json(lstRoles);
        }
    }
}

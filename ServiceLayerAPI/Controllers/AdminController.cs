using BAL.Models;
using CALforDataTransfer.Claims;
using CALforDataTransfer.ViewModels;
using DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ServiceLayerAPI.Controllers
{
    [Route("api/[controller]/[Action]")]
    [ApiController]
   // [Authorize]
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
        //[Authorize(Policy ="ABC,CD")]
        //[Authorize(Roles ="Admin,Owner")]
        public async Task<JsonResult> GetUser(string email)
        {
            List<string> roles = null;
            List<string> claims = null;
            try
            {
                if (ModelState.IsValid)
                {
                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var lstRoles = await userManager.GetRolesAsync(user);
                        var lstClaims = await userManager.GetClaimsAsync(user);
                        foreach(var claim in lstClaims)
                        {
                            claims.Add(claim.Type.ToString());
                        }
                        foreach(var role in lstRoles)
                        {
                            roles.Add(role.ToString());
                        }
                        //claims = await userManager.GetClaimsAsync(user);
                        ManageUserViewModel manageUserViewModel = new ManageUserViewModel()
                        {
                            Roles = roles,
                            Claims = claims
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
        public async Task<JsonResult> DeleteUserRoles(List<CreateRoleViewModel> lstCreateRoleViewModel, string email)
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
        public async Task<JsonResult> DeleteUserClaims(Dictionary<string,bool> kvpClm, string email)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var claimsOfUser = await userManager.GetClaimsAsync(user);
                        var claimsToDelete = kvpClm.Where(d => (AllClaims.Claims.Any(c => c.Type.ToString() == d.Key.ToString()) &&
                                                            !claimsOfUser.Any(c => c.Type.ToString() == d.Key.ToString()) &&
                                                            d.Value == false)).Select(e => e);
                        if (claimsToDelete.Any())
                        {
                            IEnumerable<Claim> claims = claimsToDelete.Select(e => new Claim(e.Key.ToString(), e.Value.ToString()));
                            var result = await userManager.RemoveClaimsAsync(user, claims);

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
        //[Authorize(Policy ="CreateRolePolicy")]
        public async Task<JsonResult> AddUserRoles(List<CreateRoleViewModel> lstCreateRoleViewModel, string email)
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
        public async Task<JsonResult> AddUserClaims(Dictionary<string,bool> kvpClm, string email)
        {
            bool status = false;
            try
            {
                if (ModelState.IsValid)
                {

                    AppUser user = await this.userManager.FindByEmailAsync(email);
                    if (user != null)
                    {
                        var claimsOfUser = await userManager.GetClaimsAsync(user);
                        var claimsToAdd = kvpClm.Where(d=> (AllClaims.Claims.Any(c => c.Type.ToString() == d.Key.ToString()) &&
                                                            !claimsOfUser.Any(c => c.Type.ToString() == d.Key.ToString()) &&
                                                            d.Value == true)).Select(e=>e);
                         
                        if (claimsToAdd.Any())
                        {
                            IEnumerable<Claim> claims = claimsToAdd.Select(e => new Claim(e.Key.ToString(), e.Value.ToString()));
                            var result = await userManager.AddClaimsAsync(user, claims);

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
       // [Authorize(Policy ="OwnerRolePolicy")]
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
            IEnumerable<IdentityRole> roles;
            List<string> lstRoles = new List<string>();
            try
            {
                roles = roleManager.Roles;
                foreach (var role in roles)
                {
                    lstRoles.Add(role.Name.ToString());
                }
            }
            catch (Exception ex)
            {
                lstRoles = null;
            }
            return Json(lstRoles);
        }

        [HttpGet]
        public JsonResult GetAllClaim()
        {
            List<string> lstClaims = null;
            var claims = AllClaims.Claims;
            foreach(var claim in claims)
            {
                lstClaims.Add(claim.Type.ToString());
            }
            return Json(lstClaims);
        }
    }
}
 
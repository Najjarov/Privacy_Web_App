using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Rewrite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Data;

namespace Privacy_Web_App.Controllers
{
    [Authorize(Roles = "Admin, Owner")]
    public class AdminController : Controller
    {
        private readonly dbContext _dbcontext;
        private readonly IMapper _mapper;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AdminController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            _dbcontext = new dbContext();
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult dashboard()
        {
            return View();
        }
        public async Task<IActionResult> UserList()
        {
            var Users = await _userManager.Users.ToListAsync();
            var Roles = await _roleManager.Roles.ToListAsync();
            var UserRoles = new List<UserListViewModel>();

            foreach (var user in Users)
            {
                var rolesForUser = await _userManager.GetRolesAsync(user);
                UserRoles.Add(new UserListViewModel
                {
                    user_id = user.Id,
                    user_name = user.UserName,

                    Role_Name = rolesForUser.FirstOrDefault(),


                });
            }

            return View(UserRoles);

        }
        public IActionResult User_Access()
        {



            var accsessview = new ViewsAccessModel();


            var views = _dbcontext.views.ToList();
            var mappedviews = _mapper.Map<IEnumerable<view>, IEnumerable<ViewsModel>>(views);

            var access = _dbcontext.viewsaccesses.ToList();
            var mappedaccess = _mapper.Map<IEnumerable<viewsaccess>, IEnumerable<UserAccess>>(access);


            accsessview.views = mappedviews;

            accsessview.access = mappedaccess;



            return View(accsessview);
        }
        [HttpGet]
        public IActionResult Register()
        {



            var vm = new RegisterViewModel();

            var allRoles = _roleManager.Roles.ToList();
            vm.RolesList = new SelectList(allRoles, "Name");


            return View(vm);





        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = model.UserName,

                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                  //await _signInManager.SignInAsync(user, isPersistent: false);
                  var userdata = await _userManager.FindByNameAsync(model.UserName);
                    //var roleid = model.RoleName;
                    //var role = _roleManager.FindByIdAsync(roleid);




                     await _userManager.AddToRoleAsync(userdata, model.RoleName);

                    return RedirectToAction("userlist", "Admin");
                    //AddtoRole(userdata, model.RoleName);
                }
                foreach (var error in result.Errors)
                {
                   model.message= error.Description;
                 }



            }
            return View(model);
        }

        
        [HttpGet]
        public async Task<IActionResult> EditUser(string id)
        {
            if (id == null)
            {
                return RedirectToAction("dashboard", "Admin");
            }

            var currentuser = await _userManager.FindByIdAsync(id);
            var rolename = await _userManager.GetRolesAsync(currentuser);
            var role = rolename.FirstOrDefault();


            var vm = new UpdateUserViewModel();
            vm.UserId = currentuser.Id;
            vm.UserName = currentuser.UserName;
            vm.RoleName = role;


            var currentrole = await _roleManager.FindByNameAsync(role);







            var allRoles = _roleManager.Roles.ToList();
            allRoles.Remove(currentrole);
            vm.RolesList = new SelectList(allRoles, "Name");





            return View(vm);





        }

        public async Task<IActionResult> EditUser(UpdateUserViewModel model)
        {

            var user = await _userManager.FindByIdAsync(model.UserId);

            if (user == null)
            {
                // User not found
                return NotFound();
            }

            // Update username
            user.UserName = model.UserName;
           

            var result = await  _userManager.UpdateAsync(user);

            var currentrole = await _userManager.GetRolesAsync(user);

            if(result.Succeeded) { 


            ViewData.Add("nameupdateresult", "Username Updated Successfully!");
            }
            else
            {
                ViewData.Add("nameupdateresulter", "error");
                ViewData.Add("nameupdateresult", "Error While Updating Username!");
            }

            if (currentrole.FirstOrDefault()== model.RoleName)
            {


            }
            else {
                await _userManager.RemoveFromRoleAsync(user,currentrole.FirstOrDefault());

                var roleresult = await _userManager.AddToRoleAsync(user,model.RoleName);
                if (roleresult.Succeeded)
                {


                    ViewData.Add("roleupdateresult", "User Role Updated Successfully!");
                }
                else
                {
                    ViewData.Add("roleupdateresulter", "error");
                    ViewData.Add("roleupdateresult", "Error While Updating User Role!");
                }
                return RedirectToAction("userlist", "Admin");
            }

            // Update password
            if (model.Password != null)
            {

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var passresult = await _userManager.ResetPasswordAsync(user, token, model.Password);
                if (passresult.Succeeded)
                {


                    ViewData.Add("passupdateresult", "User Password Updated Successfully!");
                }
                else
                {
                    ViewData.Add("passupdateresulter", "error");
                    ViewData.Add("passupdateresult", "Error While Updating User Password!");

                   
                }
                return RedirectToAction("userlist", "Admin");
            }


            return RedirectToAction("userlist", "Admin");
        }
        public async Task<IActionResult> ViewAccess(int id)
        {
            var viewdata = _dbcontext.views.Find(id);
            var mappedviewdata = _mapper.Map<view, ViewsModel>(viewdata);
            var accessdata = _dbcontext.viewsaccesses.Where(x=>x.view_id == id).ToList();
           
            var mappedaccessdata = _mapper.Map<IEnumerable<viewsaccess>, IEnumerable<UserAccess>>(accessdata);
            var roles = _roleManager.Roles.ToList();
            var ownerrole =  await _roleManager.FindByNameAsync("Owner");
            var adminrole = await _roleManager.FindByNameAsync("Admin");
            roles.Remove(ownerrole);
            roles.Remove(adminrole);


            foreach(var access in accessdata)
            {

                
                roles.Remove(await _roleManager.FindByNameAsync(access.role_name));
            };




            var editmodel = new ViewsAccessEditModel
             
            {
                view = mappedviewdata,
                UserAccess = mappedaccessdata,
                RolesList = new SelectList(roles, "Name"),


        };




            return View(editmodel);
        }

        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                // Handle the case where the user wasn't found
                ViewBag.ErrorMessage = $"User with Id = {id} cannot be found";
                return View("NotFound");
            }
            else
            {
                //Delete the User Using DeleteAsync Method of UserManager Service
                var result = await _userManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    // Handle a successful delete
                    return RedirectToAction("UserList");
                }
                else
                {
                    // Handle failure
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }
                }

                return RedirectToAction("UserList");
            }
        }

        

        public IActionResult AddViewAccess(int viewid, string role)
        {
            var found = _dbcontext.viewsaccesses.Where(x=>x.view_id==viewid&&x.role_name==role).FirstOrDefault();
          
            if(found == null) { 

            var addedrole = new viewsaccess
            {
                view_id = viewid,
                role_name = role,
            };

            _dbcontext.viewsaccesses.Add(addedrole);
            _dbcontext.SaveChanges();
            return RedirectToAction("ViewAccess", "Admin", new { id = viewid });
            }
            return RedirectToAction("ViewAccess", "Admin", new { id = viewid });
        }
        public async Task<IActionResult> AddRole(string rolename)
        {



            var role = new IdentityRole(rolename);
            await _roleManager.CreateAsync(role);

            return RedirectToAction("Rolelist", "Admin");
            
            
        }



        public IActionResult RemoveViewAccess(int viewid,string role)
        {
            var roledelete = _dbcontext.viewsaccesses.Where(x=>x.view_id==viewid && x.role_name==role).FirstOrDefault();

            _dbcontext.viewsaccesses.Remove(roledelete);
            _dbcontext.SaveChanges();
            return RedirectToAction("ViewAccess","Admin" , new { id = viewid });
        }
        public async Task<IActionResult> RoleList()
        {
           
            var Roles = await _roleManager.Roles.ToListAsync();

            var UserRoles = new List<RoleListViewModel>();


            foreach (var user in Roles)
            {
               
                UserRoles.Add(new RoleListViewModel
                {
                   

                    Role_Name = user.Name,


                });
            }


            return View(UserRoles);

        }

    }


}

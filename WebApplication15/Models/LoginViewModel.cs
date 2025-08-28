using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Privacy_Web_App.Models
{
    public class RegisterViewModel
    {
      
        public  string UserName {  get; set; }

        public  string Password { get; set; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public  string ConfirmPassword { get; set; }

        public string RoleName { get; set; }

        public  string? message{ get; set; }

        [ValidateNever]
        public virtual IEnumerable<SelectListItem> RolesList { get; set; }
    }
    public class UserListViewModel
    {
        public string user_id { get; set; }
        public string user_name { get; set;}
        public string Role_Name { get; set; }


    }
    public class LoginViewModel
    {

        public required string UserName { get; set; }

        public required string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public class Role
    {
        
        public string RoleName { get; set; } = string.Empty;
    }

    public class UserAccess
    {
        public int id { get; set; }
        public int view_id { get; set; }
        
        public string role_name { get; set; }

        
    }

    public class ViewsModel
    {
        public int id { get; set; }
        public string view_name { get; set; }

        public string section { get; set; }
        public string action_name { get; set; }
        public string controller { get; set; }

        public string? status { get; set; }
    }
   
    public class ViewsAccessModel
    {
        public IEnumerable<UserAccess> access { get; set; }
        public IEnumerable<ViewsModel> views { get; set; }

    }
    public class ViewsAccessEditModel
    {
        public IEnumerable<UserAccess> UserAccess { get; set; }
        public ViewsModel view { get; set; }
        public virtual IEnumerable<SelectListItem> RolesList { get; set; }

    }
    public class UpdateUserViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }

        public string Password { get; set; }
        [Compare("Password")]
        [DisplayName("Confirm Password")]
        public string ConfirmPassword { get; set; }

        public string RoleName { get; set; }
        [ValidateNever]
        public virtual IEnumerable<SelectListItem> RolesList { get; set; }
    }


    public class RoleListViewModel
    {
       
        public string Role_Name { get; set; }


    }


}

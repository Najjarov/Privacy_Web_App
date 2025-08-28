using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Privacy_Web_App.DataContext;
using Privacy_Web_App.Models;
using System.Data;
namespace Privacy_Web_App.Services
{
    //public interface IViewService
    //{

    //    List<ViewsModel> getTabs(string viewName, IdentityUser user);


    //    List<int> getmenusaccess(string Role);
    //}

    //public class ViewService : IViewService
    //{

    //    private readonly dbContext db;
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly SignInManager<IdentityUser> _signInManager;
    //    private readonly RoleManager<IdentityRole> _roleManager;

    //    public ViewService(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, RoleManager<IdentityRole> roleManager,)
    //    {
    //        db = new dbContext();
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //        _roleManager = roleManager;
    //    }

    //    public List<ViewsModel> getTabs(string viewName, IdentityUser user)
    //    {
    //        var viewno = 5;
    //        //var user =  _userManager.GetUserAsync(User);

    //        var roles = _userManager.GetRolesAsync(user);


    //        var menu = getmenusaccess(roles.FirstOrDefault());

    //        foreach (var menuitem in menu)
    //        {


    //            string str = "menu" + menuitem;

    //            ViewData.Add(str, menuitem.ToString());
    //        }
    //        throw new NotImplementedException();
    //    }

    //    public List<int> getmenusaccess(string Role)
    //    {

    //        if (Role == "Owner" || Role == "Admin")
    //        {
    //            var viewList2 = new List<int>();
    //            var list2 = _dbContext.views.ToList();
    //            foreach (var item in list2)
    //            {
    //                viewList2.Add(item.Id);
    //            }
    //            return viewList2;
    //        }


    //        var list = _dbContext.viewsaccesses.Where(x => x.role_name == Role).ToList();
    //        var viewList = new List<int>();

    //        foreach (var item in list)
    //        {
    //            viewList.Add(item.view_id);
    //        }
    //        return viewList;

    //    }


    //}
}

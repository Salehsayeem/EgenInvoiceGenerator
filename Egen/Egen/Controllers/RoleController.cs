using Egen.Models;
using Egen.ViewModel;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Egen.Controllers
{
    [Authorize(Roles = "Admin")]
    public class RoleController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        public ActionResult RoleList()
        {
            var role = db.Roles.ToList();
            return View(role);
        }

        public ActionResult Create()
        {
            var role = new IdentityRole();
            return View(role);
        }

        [HttpPost]
        public ActionResult Create(IdentityRole role)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("RoleList");
        }

        //public List<SelectListItem> GetRoles()
        //{
        //    List<SelectListItem> listrole = new List<SelectListItem>();
        //    listrole.Add(new SelectListItem
        //    {
        //        Text = "select",
        //        Value = "0"
        //    });
        //    foreach (var item in db.Roles)
        //    {
        //        listrole.Add(new SelectListItem
        //        {
        //            Text = item.Name,
        //            Value = Convert.ToString(item.Id)
        //        });
        //    }
        //    return listrole;
        //}
        //public List<SelectListItem> GetUsers()
        //{
        //    List<SelectListItem> listuser = new List<SelectListItem>();
        //    listuser.Add(new SelectListItem
        //    {
        //        Text = "Select",
        //        Value = "0"
        //    });
        //    foreach (var item in db.Users)
        //    {
        //        listuser.Add(new SelectListItem
        //        {
        //            Text = item.UserName,
        //            Value = Convert.ToString(item.Id)
        //        });
        //    }
        //    return listuser;
        //}
        //[HttpGet]
        //public ActionResult AssignRolesToUsers()
        //{
        //    AssignRoleVm _addignroles = new AssignRoleVm();
        //    _addignroles.RoleList = GetRoles();
        //    _addignroles.UserList = GetUsers();
        //    return View(_addignroles);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult AssignRolesToUsers(AssignRoleVm _assignRole)
        //{
        //    if (_assignRole.Role == "0")
        //    {
        //        ModelState.AddModelError("RoleName", " select UserRoleName");
        //    }
        //    if (_assignRole.User == "0")
        //    {
        //        ModelState.AddModelError("UserName", " select Username");
        //    }
        //    if (ModelState.IsValid)
        //    {
                
                
        //            var UserName = GetUserName_BY_UserID(_assignRole.User);
        //            ViewBag.UserName = UserName;
        //            var UserRoleName = GetRoleNameByRoleID(_assignRole.Role);
        //            ViewBag.UserRoleName = UserRoleName;
        //            Roles.AddUserToRole(UserName, UserRoleName);
        //            ViewBag.ResultMessage = ViewBag.UserName + " has been added to " + ViewBag.UserRoleName + " Successfully";
                
        //        _assignRole.RoleList = GetRoles();
        //        _assignRole.UserList = GetUsers();
        //        return View(_assignRole);
        //    }
        //    else
        //    {
        //        _assignRole.RoleList = GetRoles();
        //        _assignRole.UserList = GetUsers();
        //    }
        //    return View(_assignRole);
        //}
        //public string GetUserName_BY_UserID(string UserId)
        //{
        //    var userName = (from u in db.Users where u.Id == UserId select u.UserName)
        //        .SingleOrDefault();
        //        return userName;
        //}
        //public string GetRoleNameByRoleID(string RoleId)
        //{
        //        var roleName = (from UP in db.Roles where UP.Id == RoleId select UP.Name).SingleOrDefault();
        //        return roleName;
        //}
        
    }
}
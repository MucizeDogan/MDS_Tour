﻿using DataAccessLayer.Concrete;
using EntityLayer.Concrete;
using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    // [AllowAnonymous]
    [Authorize(Roles = "Admin")]
    public class RoleController : BaseController
    {
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        [Route("Index")]
        public IActionResult Index()
        {
            var data = _roleManager.Roles.ToList();
            return View(data);
        }
        [HttpGet]
        [Route("CreateRole")]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateRole")]
        public async Task<IActionResult> CreateRole(CreateRoleModel createRoleModel)
        {
            if (!ModelState.IsValid)
            {
                return View(createRoleModel);
            }
            AppRole appRole = new AppRole()
            {
                Name = createRoleModel.RoleName
            };
            var data = _roleManager.CreateAsync(appRole);
            if (data.IsCompletedSuccessfully)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }
        [Route("DeleteRole/{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            await _roleManager.DeleteAsync(data);
            return RedirectToAction("Index");
        }
        [HttpGet]
        [Route("UpdateRole/{id}")]
        public IActionResult UpdateRole(int id)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            UpdateRoleModel updateRoleModel = new UpdateRoleModel()
            {
                RoleId = data.Id,
                RoleName = data.Name
            };
            return View(updateRoleModel);
        }
        [HttpPost]
        [Route("UpdateRole/{id}")]
        public async Task<IActionResult> UpdateRole(UpdateRoleModel updateModel)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == updateModel.RoleId);
            data.Name = updateModel.RoleName;
            await _roleManager.UpdateAsync(data);
            return RedirectToAction("Index");
        }

        [Route("UserList")]
        public IActionResult UserList()
        {
            var data = _userManager.Users.ToList();
            return View(data);
        }
        [HttpGet]
        [Route("AssignRole/{id}")]
        public async Task<IActionResult> AssignRole(int id)
        {
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id); //Rol ata butonuna tıkladığım zaman tıkladığım kullancının bilgileri gelcek
            TempData["Userid"] = user.Id;
            var roles = _roleManager.Roles.ToList();
            var userRoles = await _userManager.GetRolesAsync(user);
            List<RoleAssignModel> roleAssignModel = new List<RoleAssignModel>();
            foreach (var item in roles)
            {
                RoleAssignModel model = new RoleAssignModel();
                model.RoleId = item.Id;
                model.RoleName = item.Name;
                model.RoleExist = userRoles.Contains(item.Name);      //Kullanıcının rolleri içerisinde  item dan gelen name değeri var mı? Eğer varsa exist True dönecek
                roleAssignModel.Add(model);
            }
            ViewBag.RoleAssignModel = JsonConvert.SerializeObject(roleAssignModel);
            return View(roleAssignModel);
        }
        [HttpPost]
        [Route("AssignRole/{id}")]
        //List<int> SelectedRoles
        public async Task<IActionResult> AssignRole(List<string> SelectedRoles)   //Aynı anda birden fazla rol göndermek istediğimiz için List<RoleAssginModel> dedik
        {
            var userid = (int)TempData["Userid"];
            var user = _userManager.Users.FirstOrDefault(x => x.Id == userid);
            var userRoles = await _userManager.GetRolesAsync(user);
            Context context = new Context();
            var roles = context.Roles.ToList();


            await _userManager.RemoveFromRolesAsync(user, userRoles);

            var tmp = new List<string>();
            foreach (var item in SelectedRoles)
            {
                tmp.Add(roles.First(x => x.Id.ToString() == item).Name);
            }


            await _userManager.AddToRolesAsync(user, tmp);

            var result = await _userManager.UpdateAsync(user);
            //}
            return RedirectToAction("UserList");
        }
    }
}

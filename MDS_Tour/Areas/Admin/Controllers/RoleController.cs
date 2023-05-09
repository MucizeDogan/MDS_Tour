using EntityLayer.Concrete;
using MDS_Tour.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MDS_Tour.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Role")]
    [AllowAnonymous]
    public class RoleController : Controller
    {
        private readonly RoleManager<AppRole> _roleManager;

        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
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
        public async Task <IActionResult> CreateRole(CreateRoleModel createRoleModel)
        {
            AppRole appRole = new AppRole()
            {
                Name = createRoleModel.RoleName
            };
            var data = _roleManager.CreateAsync(appRole); 
            if(data.IsCompletedSuccessfully)
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
        public async Task <IActionResult> UpdateRole(UpdateRoleModel updateModel)
        {
            var data = _roleManager.Roles.FirstOrDefault(x => x.Id == updateModel.RoleId);
            data.Name = updateModel.RoleName;
            await _roleManager.UpdateAsync(data);
            return RedirectToAction("Index");
        }
    }
}

﻿using NorthLion.Zero.PaginatedModel;
using NorthLion.Zero.Users;
using NorthLion.Zero.Web.Controllers;
using System.Threading.Tasks;
using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;
using NorthLion.Zero.Authorization;

namespace NorthLion.Zero.Web.Areas.AdminMpa.Controllers
{
    [AbpMvcAuthorize(PermissionNames.Pages_Users)]
    public class UsersController : ZeroControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UsersController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        public async Task<ActionResult> Index(PaginatedInputDto input)
        {
            var output = await _userAppService.GetUsers(input);
            return View(output);
        }
        //[WrapResult(false)]
        //public async Task<JsonResult> GetUsers(PaginatedInputDto input)
        //{
        //    //I DONT WANT TO GET IN THE WAY WITH YOUR TABLE PLUGIN SO...
        //    input.GetAll = true;
        //    // input.Page = input.Page - 1;
        //    var output = await _userAppService.GetUsers(input);
        //    return Json(new { data = output.Users }, JsonRequestBehavior.AllowGet);
        //}
        public async Task<ActionResult> EditUser(int id)
        {
            var user = await _userAppService.GetUserForEdit(id);
            return View(user);
        }

        public async Task<ActionResult> SetPermissions(int id)
        {
            var userPermissions = await _userAppService.GetUserPermissions(id);
            return View(userPermissions);
        }

        public async Task<ActionResult> SetRoles(int id)
        {
            var roles = await _userAppService.GetRolesForUser(id);
            return View(roles);
        }

        public async Task<ActionResult> ChangePassword(int id)
        {
            var user = await _userAppService.GetUserForEdit(id);
            return View(user);
        }
    }
}
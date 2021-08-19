using Luxica_Store.Application.Services.Users.Command.EditUser;
using Luxica_Store.Application.Services.Users.Command.RegisterUser;
using Luxica_Store.Application.Services.Users.Command.RemoveUser;
using Luxica_Store.Application.Services.Users.Command.UserStatusChange;
using Luxica_Store.Application.Services.Users.Queries.GetRoles;
using Luxica_Store.Application.Services.Users.Queries.GetUsers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EndPoint.Site.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly IGetUsersService _getUsersService;
        private readonly IGetRolesService _getRolesService;
        private readonly IRegisterUserService _registerUserService;
        private readonly IRemoveUserService _removeUserService;
        private readonly IUserSatusChangeService _userSatusChangeService;
        private readonly IEditUserService _editUserService;


        public UsersController(IGetUsersService getUsersService,
                               IGetRolesService getRolesService,
                               IRegisterUserService registerUserService,
                               IRemoveUserService removeUserService,
                               IUserSatusChangeService userSatusChangeService,
                               IEditUserService editUserService)
        {
            _getUsersService = getUsersService;
            _getRolesService = getRolesService;
            _registerUserService = registerUserService;
            _removeUserService = removeUserService;
            _userSatusChangeService = userSatusChangeService;
            _editUserService = editUserService;
        }


        public IActionResult Index(string searchKey, int page = 1)
        {
            return View(_getUsersService.Exceute(new ReuestGetUserDto
            { 
                Page = page,
                SearchKey = searchKey
            }));
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Roles =new SelectList( _getRolesService.Execute().Data , "Id", "Name");
            return View();
        }

        [HttpPost]
        public IActionResult Create(string Email, string FullName, long RoleId, string Password, string RePassword)
        {
            var result = _registerUserService.Execute(new RequestRegisterUserDto
            { 
                Email = Email,
                FullName = FullName,
                Roles = new List<RolesInRegisterUserDto>()
                {
                    new RolesInRegisterUserDto
                    {
                        Id = RoleId
                    }
                },
                Password = Password,
                RePassword = RePassword,
            });

            return Json(result);
        }
   
        [HttpPost]
        public IActionResult Delete(long userId)
        {
            return Json(_removeUserService.Execute(userId));
        }

        [HttpPost]
        public IActionResult UserSatusChange(long userId)
        {
            return Json(_userSatusChangeService.Execute(userId));
        }


        [HttpPost]
        public IActionResult Edit(long userId, string fullname)
        {
            return Json(_editUserService.Execute(new RequestEdituserDto
            {
                Fullname = fullname,
                UserId = userId,
            }));
        }
    }
}

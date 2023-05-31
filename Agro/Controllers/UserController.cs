using Agro.DataAccess.Entities;
using Agro.Models;
using Agro.Pagination;
using Agro.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Agro.Controllers
{

    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IUserRoleService userRoleService, IMapper mapper)
        {
            _userService = userService;
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Index(int? pageNumber, string sortOrder, string filter, int? userRoleId)
        {
            var userRoles = await _userRoleService.GetAllUserRoles();
            ViewBag.UserRoles = userRoles;

            var users = await _userService.GetAllUsers();

            if (filter != null)
                users = users.Where(x => x.FullName.ToLower().Contains(filter.ToLower())
                    || x.UserName.ToLower().Contains(filter.ToLower())).ToList();

            if (userRoleId != null)
                users = users.Where(x => x.UserRoleId.Equals(userRoleId)).ToList();

            ViewBag.FullNameSortParam = String.IsNullOrEmpty(sortOrder) ? "fullName_desc" : "";

            switch (sortOrder)
            {
                case "fullName_desc":
                    users = users.OrderByDescending(s => s.FullName).ToList();
                    break;
                default:
                    users = users.OrderBy(s => s.FullName).ToList();
                    break;
            }
            
            var model = _mapper.Map<IEnumerable<User>, IList<UserViewModel>>(users);
            var pagedList = PaginatedList<UserViewModel>.Create(model, pageNumber ?? 1, 10);
            return View(pagedList);
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = await _userService.GetAllUsers();
                var validUser = users.Where(x => x.UserName.Equals(model.UserName)).FirstOrDefault();
                
                if (validUser == null)
                {
                    ModelState.AddModelError("Login", "Пользователь не найден.");
                }

                if (validUser != null && !BCrypt.Net.BCrypt.Verify(model.Password, validUser.PasswordHash))
                {
                    ModelState.AddModelError("Password", "Неверный пароль.");
                }

                if (validUser != null && BCrypt.Net.BCrypt.Verify(model.Password, validUser.PasswordHash))
                {
                    var role = await _userRoleService.GetUserRole(validUser.UserRoleId);
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Name, validUser.FullName),
                        new Claim(ClaimTypes.Role, validUser.UserRole.Name)
                    };
                    var id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
                    return RedirectToAction("Index", "Home");
                }
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Create()
        {
            var userRoles = await _userRoleService.GetAllUserRoles();
            ViewBag.UserRoles = userRoles;
            
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Create(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var users = await _userService.GetAllUsers();
                
                if (users.Any(x => x.UserName == model.UserName))
                {
                    ModelState.AddModelError("UserName", "Имя пользователя повторяется.");
                }
                else
                {
                    var user = _mapper.Map<User>(model);
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    await _userService.CreateUser(user);
                    return RedirectToAction("Index", "User");
                }
            }

            var userRoles = await _userRoleService.GetAllUserRoles();
            ViewBag.UserRoles = userRoles;
            
            return View(model);
        }

        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Edit(int id)
        {
            TempData["returnUrl"] = Request.Headers["Referer"].ToString();
            
            var userRoles = await _userRoleService.GetAllUserRoles();
            ViewBag.UserRoles = userRoles;
            
            var user = await _userService.GetUser(id);
            var model = _mapper.Map<UserViewModel>(user);
            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Edit(UserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                await _userService.UpdateUser(user);
                return Redirect(TempData["returnUrl"].ToString());
            }

            var userRoles = await _userRoleService.GetAllUserRoles();
            ViewBag.UserRoles = userRoles;

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "Администратор")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userService.GetUser(id);
            await _userService.DeleteUser(user);
            return Redirect(Request.Headers["Referer"].ToString());
        }

    }
}
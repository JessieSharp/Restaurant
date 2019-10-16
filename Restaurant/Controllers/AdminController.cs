using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Restaurant.Areas.Identity.Data;
using Restaurant.Areas.Identity.Pages.Account;
using Restaurant.Models;

namespace Restaurant.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly SignInManager<RestaurantUser> _signInManager;
        private readonly UserManager<RestaurantUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;
        private readonly ILogger<RegisterModel> _logger;
        private RestaurantContext _context;

        public AdminController(UserManager<RestaurantUser> userManager, SignInManager<RestaurantUser> signInManager, ILogger<RegisterModel> logger, RoleManager<IdentityRole> roleManager, RestaurantContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _context = context;
            _roleManager = roleManager;
        }

        private async Task CreateRoles()
        {
            string[] roleNames = { "Admin", "Manager", "Member" };

            foreach (var roleName in roleNames)
            {
                var roleExist = await _roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    var s = await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }

            var usr = await _userManager.FindByEmailAsync("nynov3@gmail.com");
            await _userManager.AddToRoleAsync(usr, "Admin");
        }

        public async Task<IActionResult> Index()
        {
            //await CreateRoles(); //that was only need one time to create the roles
            return View();
        }

        public IActionResult Reservations()
        {
            return View(GetReservationViewModels());
        }

        public IActionResult Events()
        {
            return View();
        }

        public IActionResult Menu()
        {
            return View();
        }

        public IActionResult DeleteReservation(ReservationViewModel model)
        {
            _context.Reservations.First(x => x.Id == model.Id).IsDeleted = true;
            _context.SaveChanges();
            return View("Reservations", GetReservationViewModels());
        }

        private List<ReservationViewModel> GetReservationViewModels()
        {
            return _context.Reservations.ToList();
        }
    }
}
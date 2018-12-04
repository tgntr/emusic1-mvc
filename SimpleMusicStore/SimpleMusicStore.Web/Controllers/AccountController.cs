﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SimpleMusicStore.Data;
using SimpleMusicStore.Models;
using SimpleMusicStore.Web.Models.BindingModels;
using SimpleMusicStore.Web.Services;

namespace SimpleMusicStore.Web.Controllers
{
    public class AccountController : Controller
    {

        private UserManager<SimpleUser> _userManager;
        private SignInManager<SimpleUser> _signInManager;
        private RoleManager<IdentityRole> _roleManager;
        private AddressService _addressService;

        public AccountController(
           UserManager<SimpleUser> userManager,
           SignInManager<SimpleUser> signInManager,
           SimpleDbContext context,
           RoleManager<IdentityRole> roleManager
           )
        {
            _addressService = new AddressService(context);
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;

        }
        

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new SimpleUser { UserName = model.Email, Email = model.Email };
                
                var result = await _userManager.CreateAsync(user, model.Password);



                if (result.Succeeded)
                {
                    var address = new Address { Country = model.Country, City = model.City, Street = model.Street, User = user };
                    _addressService.AddAddress(address);

                    await MakeFirstUserAdmin(user);


                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return Redirect("/");
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login (LoginBindingModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: true);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }

        private async Task MakeFirstUserAdmin(SimpleUser user)
        {
            bool x = await _roleManager.RoleExistsAsync("Admin");
            if (!x)
            {
                var role = new IdentityRole();
                role.Name = "Admin";
                await _roleManager.CreateAsync(role);

                var result1 = await _userManager.AddToRoleAsync(user, "Admin");
            }
        }
    }
}
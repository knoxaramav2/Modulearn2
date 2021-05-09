using System;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Modulearn2A.Models;
using Modulearn2A.Utility;

namespace Modulearn2A.Controllers
{
    public class UserController : Controller
    {
        private readonly ModulearnDbContext _context;

        public UserController(ModulearnDbContext context)
        {
            _context = context;
        }

        // GET: User
        public IActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);

            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("UserName,Password")] LoginModel userModel)
        {
            string userNameOrEmail = userModel.UserName;
            bool isEmail = Format.IsEmailFormat(userNameOrEmail);

            if (ModelState.IsValid)
            {
                UserModel user = null;

                if (isEmail)
                {
                    user = _context.Users.Where(x =>
                        x.Email == userModel.UserName).FirstOrDefault();
                } else
                {
                    user = _context.Users.Where(x =>
                        x.UserName == userModel.UserName).FirstOrDefault();
                }

                //TODO Error note for user not found
                if (user == null ||
                    !Security.VerifyPassword(user.PasswordHash, userModel.Password, user.Salt)
                    )
                {
                    //TODO return with errors
                    return View();
                }

                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        //[Bind("UserName,Password")] UserModel userModel
        // GET: User/Login
        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Logout()
        {
            TempData.Put<UserModel>("User", null);
            return RedirectToAction("Index", "Home");
        }

        // GET: User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Email,UserName,Password,ConfirmPassword")] 
            ConfirmUserModel userModel)
        {
            if (ModelState.IsValid)
            {
                string passwordHash = Security.HashPassword(userModel.Password, out byte[] salt);

                var userData = new UserModel()
                {
                    UserName = userModel.UserName,
                    Email = userModel.Email,
                    PasswordHash = passwordHash,
                    Salt = salt,
                    RegistrationDate = DateTime.Now,
                };

                _context.Add(userData);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login");
            }
            return View(userModel);
        }

        // GET: User/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users.FindAsync(id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Email,UserName,Password")] UserModel userModel)
        {
            if (id != userModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(userModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserModelExists(userModel.ID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(userModel);
        }

        // GET: User/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var userModel = await _context.Users
                .FirstOrDefaultAsync(m => m.ID == id);
            if (userModel == null)
            {
                return NotFound();
            }

            return View(userModel);
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var userModel = await _context.Users.FindAsync(id);
            _context.Users.Remove(userModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        //Utils

        private bool UserModelExists(int id)
        {
            return _context.Users.Any(e => e.ID == id);
        }     
        
        
    }
}

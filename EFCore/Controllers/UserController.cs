using EFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplicationDBContext context;
        UsersCRUD db;
        public UserController(ApplicationDBContext context) { 
            this.context = context;
            db = new UsersCRUD(this.context);
        }
        // GET: UserController
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(User user)
        {
            try
            {
                User emailRes = db.GetUserByEmail(user.Email);
                if (emailRes != null)
                {
                    
                    if (emailRes.Password.Equals(user.Password))
                    {
                        ViewBag.Result = "Success";
                        return View();
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Wrong Password";
                        return View();
                    }
                }
                else
                {
                    
                    ViewBag.ErrorMsg = "Email not registered ,Sign up First!";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }


        // GET: UserController/Details/5
        //public ActionResult Details(int id)
        //{
        //    return View();
        //}

        // GET: UserController/Register
        public ActionResult Register()
        {
            return View();
        }

        // POST: UserController/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            try
            {
                User emailRes = db.GetUserByEmail(user.Email);
                if (emailRes != null)
                {
                    ViewBag.ErrorMsg = "Email Already Registered with another user, try login";
                    return View();
                }
                else
                {
                    int response = db.AddUser(user);
                    if (response >= 1)
                    {
                        return RedirectToAction(nameof(Login));
                    }
                    else
                    {
                        ViewBag.ErrorMsg = "Something went wrong";
                        return View();
                    }
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }

        //// GET: UserController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: UserController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: UserController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}

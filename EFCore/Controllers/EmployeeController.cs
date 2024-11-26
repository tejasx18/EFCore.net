﻿using EFCore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDBContext context;
        EmployeeCRUD db;

        public EmployeeController(ApplicationDBContext context)
        {
            this.context = context;
            db = new EmployeeCRUD(this.context);
        }

        // All Employees
        public ActionResult Index()
        {
            var response = db.GetEmployees();
            return View(response);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee emp)
        {
            try
            {
                int response = db.AddEmployee(emp);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);

        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee emp)
        {
            try
            {
                int response = db.UpdateEmployee(emp);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }


        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            var res = db.GetEmployeeById(id);
            return View(res);

        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                int response = db.DeleteEmployee(id);
                if (response >= 1)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.ErrorMsg = "Something went wrong";
                    return View();
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMsg = ex.Message;
                return View();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using MVC_EF1.Models;
using Microsoft.AspNetCore.Mvc;
using MVC_EF1.Services;
using Microsoft.Extensions.DependencyInjection;

namespace MVC_EF1.Controllers
{
    public class StudentController : Controller
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        public IActionResult List([FromServices]StudentService studentService)
        {
            return View(_studentService.GetStudentsList());
        }

        public IActionResult Edit(int num)
        {
            return View(_studentService.GetStudent(num));
        }
        

        [HttpPost]
        public IActionResult Edit(StudentDBModel student)
        {
            int num = student.Id;
            if (!ModelState.IsValid)
            {
                return Edit(num);
            }
            var service = HttpContext.
                RequestServices.
                GetService<StudentService>();
            service.EditStudent(student);

            return RedirectToAction("List", "Student", new { num = student.Id });
        }
        public IActionResult Remove(StudentDBModel student, int studentId)
        {
            var service = HttpContext.RequestServices.GetService<StudentService>();
            var instance = ActivatorUtilities.CreateInstance<Remover>(HttpContext.RequestServices, service);
            instance._studentService.RemoveStudent(studentId);
            return View("List",instance._studentService.GetStudentsList());
        }

        public IActionResult Add(int num)
        {
            return View(_studentService.GetStudent(num));
        }

        [HttpPost]
        public IActionResult Add(StudentDBModel student)
        {
            var newStudent = _studentService.AddStudent(student);
            return View("List", _studentService.GetStudentsList());
        }
    }

    public class Remover
    {
        public StudentService _studentService;
        public Remover(StudentService studentService)
        {
            _studentService = studentService;
        }
    }
}

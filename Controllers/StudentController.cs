using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
// using System.Web.Mvc; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using nmprojects.Models;

namespace nmprojects.Controllers
{
    public class StudentController : Controller
    {
        ModelContext context;
        public StudentController(ModelContext context){
            this.context = context;
        }
        public async Task<IActionResult> Index(){
            var model = this.context.Students.ToList();
            return View(model);
        }
        //Get Page
        [HttpGet]
        public IActionResult create(){
            return View();
        }
        //Create  New Student
        [HttpPost]
        public async Task<IActionResult> Create([Bind("firstName, lastName, course")] Student student){
             
                 this.context.Add(student);
                await context.SaveChangesAsync();
                return RedirectToAction("Index");
        }
         
         //Update Student
         [HttpPost, ActionName("Edit")]
         public async Task<IActionResult> Update(int? id){
              if (id == null)
                   {
                       return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                     }

                   var updateStudent = this.Students.get(id);
         }

         //Delete Student

         [HttpDelete]
         public async Task<IActionResult> Delete([Bind("studentId")] Student student){
                  try{
                      this.Delete(student);
                  }
                  catch{}
         }

    }
}
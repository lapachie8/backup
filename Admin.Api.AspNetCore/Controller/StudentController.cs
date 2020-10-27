using Admin.Common.Commands;
using Admin.Common.Dtos;
using Admin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Api.AspNetCore.Controller
{
    [AllowAnonymous]
    [Route("[Controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService studentService;

        public StudentController(IStudentService studentService)
        {
            this.studentService = studentService;
        }

        [HttpPost]
        public IActionResult RegisterNewStudent([FromBody] AddStudentCommand command)
        {
            return Ok(studentService.RegisterNewStudent(command));
        }
        [HttpGet]
        [Route("{name}")]
        public ActionResult<StudentDto> GetStudenByName(string name)
        {
            return Ok(studentService.GetStudentByName(name));
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<StudentDto> GetStudenById(int id)
        {
            return Ok(studentService.GetStudentById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateStudent ([FromBody] AddStudentCommand command, int id)
        {
            studentService.UpdateStudentData(id, command);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            studentService.DeleteStudent(id);
            return Ok();
        }
    }
}

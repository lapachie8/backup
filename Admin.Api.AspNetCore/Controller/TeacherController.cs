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
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherService teacherService;

        public TeacherController(ITeacherService teacherService)
        {
            this.teacherService = teacherService;
        }

        [HttpPost]
        public IActionResult RegisterNewTeacher([FromBody] AddTeacherCommand command)
        {
            return Ok(teacherService.RegisterNewTeacher(command));
        }
        [HttpGet]
        [Route("{name}")]
        public ActionResult<TeacherDto> GetStudenByName(string name)
        {
            return Ok(teacherService.GetTeacherByName(name));
        }
        [HttpGet]
        [Route("{id}")]
        public ActionResult<TeacherDto> GetStudenById(int id)
        {
            return Ok(teacherService.GetTeacherById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateTeacher([FromBody] AddTeacherCommand command, int id)
        {
            teacherService.UpdateTeacherData(id, command);
            return Ok();
        }
        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteTeacher(int id)
        {
            teacherService.DeleteTeacher(id);
            return Ok();
        }
    }
}

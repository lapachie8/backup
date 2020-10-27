using Admin.Common.Commands;
using Admin.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;

namespace Admin.Api.AspNetCore.Controller
{
    [AllowAnonymous]
    [Route("Controller")]
    [ApiController]
    public class MapelController : ControllerBase
    {
        private readonly IMapelService mapelService;

        public MapelController(IMapelService mapelService)
        {
            this.mapelService = mapelService;
        }

        [HttpPost]
        public IActionResult AddNilai([FromBody] AddMapel mapel)
        {
            return Ok(mapelService.AddMapel(mapel));
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult GetNilaiById(int id)
        {
            return Ok(mapelService.GetNilaiById(id));
        }

        [HttpPut]
        [Route("{id}")]
        public IActionResult UpdateNilai(int id, [FromBody] AddMapel mapel)
        {
            mapelService.UpdateNilaiData(id, mapel);
            return Ok();
        }

        [HttpDelete]
        [Route("{id}")]
        public IActionResult DeleteNilai(int id)
        {
            mapelService.DeleteNilai(id);
            return Ok();
        }
    }
}

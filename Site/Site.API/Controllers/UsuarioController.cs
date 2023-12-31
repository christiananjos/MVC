﻿using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetAll()
        {
            var usuarios = await _usuarioService.GetAllActives();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Usuario>> GetById(Guid id)
        {
            var usuario = await _usuarioService.GetById(id);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<Usuario>> Create([FromBody] Usuario usuario)
        {
            var userExiste = await _usuarioService.GetByName(usuario.Usernaname);

            if (userExiste != null)
            {
                return StatusCode(409, $"Usuario '{usuario.Usernaname}' Já está em uso.");
            }

            var usuarioCreated = await _usuarioService.Add(usuario);

            return Ok(usuarioCreated);
        }

        [HttpPut]
        public async Task<ActionResult<Usuario>> Update([FromBody] Usuario usuario)
        {
            var usuarioUpdated = await _usuarioService.Update(usuario);

            return Ok(usuarioUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Usuario>> Delete(Guid id)
        {

            var user = await _usuarioService.GetById(id);

            if (user == null)
                return NotFound("Usuario não encontrado");

            if (user != null)
            {
                var userDeleted = await _usuarioService.LogicalRemove(user);
                return Ok(userDeleted);
            }

            return Ok();
        }
    }
}

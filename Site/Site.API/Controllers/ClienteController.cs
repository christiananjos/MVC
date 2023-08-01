﻿using Microsoft.AspNetCore.Mvc;
using Site.Models;
using Site.Services;
using Site.Services.Interfaces;

namespace Site.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService) => _clienteService = clienteService;

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetAll()
        {
            var Clientes = await _clienteService.GetAll();
            return Ok(Clientes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetById(Guid id)
        {
            var cliente = await _clienteService.GetById(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente cliente)
        {
            var clienteExist = await _clienteService.GetByName(cliente.Nome);

            if (clienteExist != null)
            {
                return StatusCode(409, $"Cliente '{cliente.Nome}' Já está em uso.");
            }

            var ClienteCreated = await _clienteService.Add(cliente);

            return Ok(ClienteCreated);
        }

        [HttpPut]
        public async Task<ActionResult<Cliente>> Update([FromBody] Cliente cliente)
        {
            var clienteUpdated = await _clienteService.Update(cliente);

            return Ok(clienteUpdated);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cliente>> Delete(Guid id)
        {

            var user = await _clienteService.GetById(id);

            if (user == null)
                return NotFound("Cliente não existe");

            if (user != null)
            {
                var userDeleted = await _clienteService.LogicalRemove(user);
                return Ok(userDeleted);
            }

            return Ok();
        }
    }
}
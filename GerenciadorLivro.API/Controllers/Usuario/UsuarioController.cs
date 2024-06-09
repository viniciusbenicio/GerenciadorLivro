﻿using GerenciadorLivro.Application.Commands.UsuarioCQRS.CreateUsuario;
using GerenciadorLivro.Application.Commands.UsuarioCQRS.RemoveUsuario;
using GerenciadorLivro.Application.Commands.UsuarioCQRS.UpdateUsuario;
using GerenciadorLivro.Application.Queries.UsuarioQueries.GetAllUsuarios;
using GerenciadorLivro.Application.Queries.UsuarioQueries.GetByIdUsuario;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GerenciadorLivro.API.Controllers.Usuario
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var getAllUsuarios = new GetAllUsuariosQuery(query);
            var allUsuarios = await _mediator.Send(getAllUsuarios);

            return Ok(allUsuarios);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetByIdUsuarioQuery(id);

            var usuario = await _mediator.Send(query);

            return Ok(usuario);

        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] UpdateUsuarioCommand command)
        {
            await _mediator.Send(command);

            return Ok("Atualizado com sucesso.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromBody] RemoveUsuarioCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok(id);
        }
    }
}
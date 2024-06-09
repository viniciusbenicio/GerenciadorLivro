﻿using MediatR;

namespace GerenciadorLivro.Application.Commands.UpdateUsuario
{
    public class UpdateUsuarioCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
    }
}

﻿using MediatR;

namespace GerenciadorLivro.Application.Commands.LivroCQRS.CreateLivro
{
    public class CreateLivroCommand : IRequest<int>
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string ISBN { get; set; }
        public int AnoPublicacao { get; set; }
    }
}

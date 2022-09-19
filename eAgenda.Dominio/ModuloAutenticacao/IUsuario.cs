using System;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public interface IUsuario
    {
        Guid Id { get; }

        string Nome { get; }        

        string Email { get; }
        
        bool EstaAutenticado { get; }
    }
}

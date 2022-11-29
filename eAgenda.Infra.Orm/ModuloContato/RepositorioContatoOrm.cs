using eAgenda.Dominio;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace eAgenda.Infra.Orm.ModuloContato
{
    public class RepositorioContatoOrm : RepositorioBase<Contato>, IRepositorioContato
    {       

        public RepositorioContatoOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Contato SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Compromissos)
                .SingleOrDefault(x => x.Id == id);
        }

        public List<Contato> SelecionarTodos(FavoritoEnum contatosFavoritos, Guid usuarioId = default)
        {
            if (contatosFavoritos == FavoritoEnum.Todos)
                return registros                    
                    .Where(x => x.UsuarioId == usuarioId)
                    .ToList();

            else if (contatosFavoritos == FavoritoEnum.Sim)
                return registros
                    .Where(x => x.Favorito == true)
                    .Where(x => x.UsuarioId == usuarioId)
                    .ToList();
            else
                return registros
                   .Where(x => x.Favorito == false)
                   .Where(x => x.UsuarioId == usuarioId)
                   .ToList();            
        }
    }
}

using eAgenda.Dominio;
using eAgenda.Dominio.ModuloContato;
using eAgenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
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
    }
}

using eAgenda.Dominio;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eAgenda.Infra.Orm.ModuloDespesa
{
    public class RepositorioCategoriaOrm : RepositorioBase<Categoria>, IRepositorioCategoria
    {       
        public RepositorioCategoriaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {            
        }

        public override Categoria SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Despesas)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}

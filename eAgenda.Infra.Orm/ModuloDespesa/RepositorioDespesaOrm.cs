using eAgenda.Dominio;
using eAgenda.Dominio.ModuloDespesa;
using eAgenda.Infra.Orm.Compartilhado;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace eAgenda.Infra.Orm.ModuloDespesa
{
    public class RepositorioDespesaOrm : RepositorioBase<Despesa>, IRepositorioDespesa
    {
        public RepositorioDespesaOrm(IContextoPersistencia contextoPersistencia) : base(contextoPersistencia)
        {
        }

        public override Despesa SelecionarPorId(Guid id)
        {
            return registros
                .Include(x => x.Categorias)
                .SingleOrDefault(x => x.Id == id);
        }
    }
}
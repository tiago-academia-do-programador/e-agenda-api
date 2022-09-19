using eAgenda.Dominio.ModuloTarefa;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ModuloAutenticacao
{
    public class Usuario : IdentityUser<Guid>
    {
        public List<Tarefa> Tarefas { get; set; }

        public string Estado { get; set; }

        public string Cidade { get; set; }
    }
}
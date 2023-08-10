using DDD.Domain.Value_objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Domain.entities
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }

        public bool Ativo { get; set; }

        public Endereco Endereco { get; set; }
    }
}

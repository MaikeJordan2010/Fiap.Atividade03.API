using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Dominio.DTOs
{
    [Table("TabContatos")]
    public class Contato
    {
        [Key]
        public string Guid { get; set; }
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? DDD { get; set; }
        public string? Telefone { get; set; }
        public string? Estado { get; set; }
        public string? Municipio { get; set; }

        public Contato(string nome, string email, string ddd, string telefone, string municipio, string estado, string guid)
        {
            this.Guid = guid;
            this.Nome = nome;
            this.Email = email;
            this.DDD = ddd;
            this.Telefone = telefone;
            this.Estado = estado;
            this.Municipio = municipio;
        }
        public Contato()
        {

        }
    }
}

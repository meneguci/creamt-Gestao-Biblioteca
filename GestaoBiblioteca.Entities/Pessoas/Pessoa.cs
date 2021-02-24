using GestaoBiblioteca.Common;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GestaoBiblioteca.Entities.Pessoa
{
    [Table("Pessoas")]
    public class Pessoa
    {
        [Key]
        public Int32 Id { get; set; }
        public String Nome { get; set; }

        public String Cpf { get; set; }
        public String Rg { get; set; }
        public String Logradouro { get; set; }
        public String Numero { get; set; }
        public String Complemento { get; set; }
        public String Bairro { get; set; }
        public String Cidade { get; set; }
        public String Estado { get; set; }
        public PessoaTipo Tipo { get; set; }
        public Boolean Ativo { get; set; }
    }
}
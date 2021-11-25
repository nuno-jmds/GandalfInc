using GandalfInc.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DataAccessLayer.Entidades
{
    public abstract class Pessoa : Entidade
    {
        [Required,MaxLength(9,ErrorMessage ="Nif con tamanho errado"),MinLength(9, ErrorMessage = "Nif con tamanho errado")]
        public string NumeroFiscal { get; set; }
        public Morada Morada { get; set; }
        public string Telefone { get; set; }
        public string Telemovel { get; set; }
        [EmailAddress,MaxLength(255)]
        public string Email { get; set; }

        public Pessoa()
        {
            Morada = new Morada();
        }
    }
}

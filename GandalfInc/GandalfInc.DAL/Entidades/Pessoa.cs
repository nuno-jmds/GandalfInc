using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public abstract class Pessoa:Entidade
    {
        public string NumeroFiscal { get; set; }
        public Morada Morada { get; set; }
        public string Telefone { get; set; }
        public string Telemovel { get; set; }
        public string Email { get; set; }

        public Pessoa()
        {
                Morada = new Morada(); 
        }
    }
}

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
        public Contacto Contacto { get; set; }

    }
}

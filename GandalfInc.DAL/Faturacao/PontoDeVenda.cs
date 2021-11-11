using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public class PontoDeVenda
    {

        public PontoDeVenda()
        {
            Identificador= new Guid();
        }
        public Guid Identificador { get; set; }
        public Loja Loja { get; set; }

        
    }
}

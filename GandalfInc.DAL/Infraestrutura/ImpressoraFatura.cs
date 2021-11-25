using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.BusinessLogicLayer.Infraestrutura
{
    class ImpressoraFatura : IImpressora
    {
        public void GerarRecibo()
        {
            Console.WriteLine("Imprimir Fatura");
        }
    }
}

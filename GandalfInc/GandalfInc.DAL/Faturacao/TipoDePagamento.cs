using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DAL.Entidades
{
    public enum TipoDePagamento
    {
        [Description("Indefinido")]
        Indefinido = 0,
        [Description("Multibanco")]
        Multibanco = 1,
        [Description("Dinheiro")]
        Dinheiro = 2,
        [Description("MbWay")]
        MbWay = 3
    }
}

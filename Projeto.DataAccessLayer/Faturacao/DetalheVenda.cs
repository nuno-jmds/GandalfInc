using GandalfInc.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DataAccessLayer.Faturacao
{
    public class DetalheVenda
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public List<Produto> Produtos { get; set; }
    }
}

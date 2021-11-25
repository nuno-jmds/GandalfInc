using Projeto.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GandalfInc.DataAccessLayer.Faturacao
{
    public class PontoDeVenda
    {

        public PontoDeVenda()
        {
            Identificador= new Guid();
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identificador { get; set; }
        public Loja Loja { get; set; }

        
    }
}

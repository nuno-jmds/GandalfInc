using GandalfInc.DataAccessLayer.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.DataAccessLayer.Entidades
{
    public class Funcionario : Entidade
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}

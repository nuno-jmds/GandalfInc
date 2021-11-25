using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace GandalfInc.DataAccessLayer.Entidades
{
    public class Morada
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Rua { get; set; }
        public string CodigoPostal { get; set; }
        public string Distrito { get; set; }
        public string Concelho { get; set; }
        public string Complemento { get; set; }

    }
}
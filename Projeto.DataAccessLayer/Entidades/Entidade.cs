using Projeto.DataAccessLayer.Utils;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GandalfInc.DataAccessLayer.Entidades
{
    public abstract class Entidade
    {
        protected Entidade()
        {
            Identificador = Guid.NewGuid();
            DataRegisto= DateTime.Now;
            dataAlteracao = DateTime.Now;
            Ativo = true;
        }

        protected Entidade(string nome)
        {
            Identificador = Guid.NewGuid();
            DataRegisto = DateTime.Now;
            dataAlteracao = DateTime.Now;
            Ativo = true;
            Nome = nome;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Identificador { get; set; }
        

        private string nome;
        [Required, MaxLength(255)]
        public virtual string Nome
        {
            get { return nome; }
            set { //nome =  StringUtils.ToTitleCase(value);
                nome = value.ToTitleCase();
            }
        }


        public bool Ativo { get; set; }

        private DateTime dataRegisto;
        public DateTime? DataRegisto 
        { 
            get { return dataRegisto; }
            set { dataRegisto=DateTime.Now; } 
        }

        private DateTime dataAlteracao;

        public DateTime DataAlteracao
        {
            get { return dataAlteracao; }
            set { if (dataAlteracao == new DateTime())
                {
                    dataAlteracao = DateTime.Now;
                }
                dataAlteracao = value;
            }
        }
        public override string ToString()
        {
            return $"Identificador: {Identificador} \n Nome: {Nome}";
        }

    }
}

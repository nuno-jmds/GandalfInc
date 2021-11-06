using System;

namespace GandalfInc.DAL.Entidades
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

        public Guid Identificador { get; set; }
        public string Nome { get; set; }

        public bool Ativo { get; set; }

        public DateTime DataRegisto { get;}

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

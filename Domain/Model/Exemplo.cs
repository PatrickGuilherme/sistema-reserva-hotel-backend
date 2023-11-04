using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    /// <summary>
    /// Classe de exemplo
    /// </summary>
    public class Exemplo
    {
        //Atributos
        public int ID { get; set; }
        public string Nome { get; set; }
        public double Valor { get; set; }
        public bool Ativo { get; set; }
        public DateTime? DataCriacao { get; set; }
        public DateTime? DataExclusao { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        //Construtor 1
        public Exemplo() { }

        //Contrutor 2
        public Exemplo(string nome, double valor, bool ativo) 
        {
            this.Nome = nome;
            this.Valor = valor;
            this.Ativo = ativo;
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = null;
            this.DataExclusao = null;
        }

        //Contrutor 3
        public Exemplo(int id, string nome, double valor, bool ativo)
        {
            this.ID = id;
            this.Nome = nome;
            this.Valor = valor;
            this.Ativo = ativo;
            this.DataCriacao = DateTime.Now;
            this.DataAtualizacao = null;
            this.DataExclusao = null;
        }

    }
}

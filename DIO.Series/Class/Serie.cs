using System;

namespace DIO.Series
{
    public class Serie : EntityBase
    {
        private Genre Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool IsDeleted { get; set; }

        public Serie(int id, Genre genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.IsDeleted = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Titulo: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano;
            return retorno;
        }

        public string GetTitle()
        {
            return this.Titulo;
        }

        public int ReturnId()
        {
            return this.Id;
        }

        public void Delete()
        {
            this.IsDeleted = true;
        }
    }
}
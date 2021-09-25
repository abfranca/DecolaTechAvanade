using System;

namespace OrganizadorSeries
{
    public class Serie : Programa
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
        }

        public override string ToString()
        {
            var resumo = "";
            resumo += "Título: " + this.Titulo + Environment.NewLine;
            resumo += "Gênero: " + this.Genero + ". Ano de lançamento: " + this.Ano + Environment.NewLine;
            resumo += "Descrição: " + this.Descricao;
            return resumo;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool getExcluido()
        {
            return this.Excluido;
        }

        public Genero GetGenero()
        {
            return this.Genero;
        }

        public int getAno()
        {
            return this.Ano;
        }

        public string getDescricao()
        {
            return this.Descricao;
        }
    }
}
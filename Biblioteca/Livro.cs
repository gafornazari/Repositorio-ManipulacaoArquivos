using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca
{
    public class Livro
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Categoria { get; set; }

        public Livro() { }

        public Livro(string titulo, string autor, string categoria)
        {
            Titulo = titulo;
            Autor = autor;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"Título: {Titulo}, Autor: {Autor}, Categoria: {Categoria}";
        }
    }
}

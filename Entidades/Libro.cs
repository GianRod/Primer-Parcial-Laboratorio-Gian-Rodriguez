using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Libro : Documento
    {
        private int numPaginas;

        public int NumPaginas { get => numPaginas; }
        public string ISBN { get => NumNormalizado; }
        public Libro(string titulo, string autor, int anio, string numNormalizado, string codebar, int numPaginas) : base (titulo, autor, anio, numNormalizado, codebar)
        {
            this.numPaginas = numPaginas;
        }

        /// <summary>
        /// Función que compara mapas iguales mediante su barcode, su ISBN o si comparte título y autor
        /// </summary>
        /// <param name="a">Primer libro</param>
        /// <param name="b">Segundo libro</param>
        /// <returns>Retorna "true" en el caso de ser iguales o "false" en caso de no serlo</returns>
        public static bool operator ==(Libro a, Libro b)
        {
            bool retorno = false;

            if (a.Barcode == b.Barcode || a.ISBN == b.ISBN || (a.Autor == b.Autor && a.Titulo == b.Titulo))
            {
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Función que compara mapas diferentes mediante su barcode, su ISBN o si comparte título y autor
        /// </summary>
        /// <param name="a">Primer libro</param>
        /// <param name="b">Segundo libro</param>
        /// <returns>Retorna "true" en el caso de no ser iguales o "false" en caso de serlo</returns>
        public static bool operator !=(Libro a, Libro b)
        {

            return !(a==b);
        }

        /// <summary>
        /// Función que pasa todos sus datos a ToString
        /// </summary>
        /// <returns>Muestra todos los detalles del libro</returns>
        public override string ToString()
        {
            StringBuilder detallesLibro = new StringBuilder();
            detallesLibro.Append($"{base.ToString()}");
            detallesLibro.AppendLine($"ISBN: {this.ISBN}");
            detallesLibro.AppendLine($"Cód. de Barras: {this.Barcode}");
            detallesLibro.AppendLine($"Número de Páginas: {this.numPaginas}");

            return detallesLibro.ToString();
        }


    }
}

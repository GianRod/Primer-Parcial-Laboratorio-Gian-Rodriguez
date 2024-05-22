using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Mapa : Documento
    {
        private int alto;
        private int ancho;


        public int Alto { get => alto;}
        public int Ancho { get => ancho;}
        public int Superficie { get => alto * ancho; }
        public Mapa(string titulo, string autor, int anio, string numNormalizado, string codebar, int ancho, int alto) : base(titulo, autor, anio, numNormalizado, codebar)
        {
            this.ancho = ancho;
            this.alto = alto;
        }

        /// <summary>
        /// Función que compara mapas mediante su barcode o si comparte título, autor, año y superficie para saber si son el mismo
        /// </summary>
        /// <param name="a">Primer mapa</param>
        /// <param name="b">Segundo mapa</param>
        /// <returns>Retorna "true" en el caso de ser iguales o "false" en caso de no serlo</returns>
        public static bool operator ==(Mapa a, Mapa b)
        {
            bool retorno = false;
            if(a.Barcode == b.Barcode || (a.Titulo == b.Titulo && a.Autor == b.Autor && a.Anio == b.Anio && a.Superficie == b.Superficie) )
            {
                retorno = true;
            }
            return retorno;
        }

        /// <summary>
        /// Función que compara mapas mediante su barcode o si comparte título, autor, año y superficie para saber si son diferentes
        /// </summary>
        /// <param name="a">Primer mapa</param>
        /// <param name="b">Segundo mapa</param>
        /// <returns>Retorna "true" en el caso de no ser iguales o "false" en caso de serlo</returns>
        public static bool operator !=(Mapa a, Mapa b)
        {
            return !(a == b);
        }

        /// <summary>
        /// Función que pasa todos sus datos a ToString
        /// </summary>
        /// <returns>Muestra todos los detalles del Mapa</returns>
        public override string ToString() 
        {
            StringBuilder detallesMapa = new StringBuilder();

            detallesMapa.Append($"{base.ToString()}");
            detallesMapa.AppendLine($"Cód. de Barras: {this.Barcode}");
            detallesMapa.AppendLine($"Superficie: {this.Superficie}cm²");

            return detallesMapa.ToString();
        }
    }
}

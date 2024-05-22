using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Entidades.Documento;

namespace Entidades
{
    
    public static class Informes
    {
        /// <summary>
        /// Método para mostrar los elementos que se encuentran distribuidos
        /// </summary>
        /// <param name="e">El escaner a testear</param>
        /// <param name="extension">Cantidad de páginas o superficie total</param>
        /// <param name="cantidad">Cantidad de elementos en estado Distribuidos en el escaner</param>
        /// <param name="resumen">Muestra la cantidad de elementos total y su superficie/páginas totales</param>
        public static void MostrarDistribuidos(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Distribuido, out extension, out cantidad, out resumen);
        }

        /// <summary>
        /// Método para mostrar los elementos en el estado deseado
        /// </summary>
        /// <param name="e">El escaner a testear</param>
        /// <param name="estado">El estado en el cuál se encuentran los elementos a buscar</param>
        /// <param name="extension">Cantidad de páginas o superficie total</param>
        /// <param name="cantidad">Cantidad de elementos en el estado deseado en el escaner</param>
        /// <param name="resumen">Muestra la cantidad de elementos total y su superficie/páginas totales</param>
        private static void MostrarDocumentosPorEstado(Escaner e, Paso estado, out int extension, out int cantidad, out string resumen)
        {
            extension = 0;
            cantidad = 0;
            resumen = "";

            if (e.Tipo == Escaner.TipoDoc.libro)
            {
                foreach (Libro doc in e.ListaDocumentos)
                {
                    if (doc.Estado == estado)
                    {
                        extension += doc.NumPaginas;
                        cantidad++;
                        resumen+=($"{doc.ToString()}");
                    }
                }
                Console.WriteLine(resumen);
            }

            if (e.Tipo == Escaner.TipoDoc.mapa)
            {
                foreach (Mapa doc in e.ListaDocumentos)
                {
                    if (doc.Estado == estado)
                    {
                        extension += doc.Superficie;
                        cantidad++;
                        //Console.WriteLine(doc.ToString());
                        resumen += ($"{doc.ToString()}");
                    }
                }
                Console.WriteLine(resumen);
            }
        }



        /// <summary>
        /// Método para mostrar los elementos que se encuentran en el escaner
        /// </summary>
        /// <param name="e">El escaner a testear</param>
        /// <param name="extension">Cantidad de páginas o superficie total</param>
        /// <param name="cantidad">Cantidad de elementos en estado Distribuidos en el escaner</param>
        /// <param name="resumen">Muestra la cantidad de elementos total y su superficie/páginas totales</param>
        public static void MostrarEnEscaner(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnEscaner, out extension, out cantidad, out resumen);
        }



        /// <summary>
        /// Método para mostrar los elementos que se encuentran en revisión
        /// </summary>
        /// <param name="e">El escaner a testear</param>
        /// <param name="extension">Cantidad de páginas o superficie total</param>
        /// <param name="cantidad">Cantidad de elementos en estado Distribuidos en el escaner</param>
        /// <param name="resumen">Muestra la cantidad de elementos total y su superficie/páginas totales</param>
        public static void MostrarEnRevision(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.EnRevision, out extension, out cantidad, out resumen);
        }



        /// <summary>
        /// Método para mostrar los elementos que han terminado de ser escaneados
        /// </summary>
        /// <param name="e">El escaner a testear</param>
        /// <param name="extension">Cantidad de páginas o superficie total</param>
        /// <param name="cantidad">Cantidad de elementos en estado Distribuidos en el escaner</param>
        /// <param name="resumen">Muestra la cantidad de elementos total y su superficie/páginas totales</param>
        public static void MostrarTerminados(Escaner e, out int extension, out int cantidad, out string resumen)
        {
            MostrarDocumentosPorEstado(e, Paso.Terminado, out extension, out cantidad, out resumen);
        }
    }
    
}

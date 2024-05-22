using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Escaner
    {
        public enum Departamento
        {
            nulo,
            mapoteca,
            procesosTecnicos
        }

        public enum TipoDoc
        {
            libro = 0,
            mapa = 1,
        }

        private List<Documento> listaDocumentos;
        private Departamento locacion;
        private string marca;
        private TipoDoc tipo;
        public List<Documento> ListaDocumentos { get => listaDocumentos;}
        public Departamento Locacion { get => locacion; }
        public string Marca { get => marca;}
        public TipoDoc Tipo { get => tipo;}

        public bool CambiarEstadoDocumento(Documento d)
        {
            bool retorno = false;

            d.AvanzarEstado();

            return retorno;
        }

        public Escaner(string marca, TipoDoc tipo)
        {
            this.marca = marca;
            this.tipo = tipo;
            this.listaDocumentos = new List<Documento>();

            if(this.tipo == TipoDoc.libro)
            {
                this.locacion = Departamento.procesosTecnicos;
            }
            else
            {
                this.locacion = Departamento.mapoteca;
            }
        }

        /// <summary>
        /// Compara el Documento entrante comprobando que sea del mismo tipo y que no se encuentre en la lista
        /// </summary>
        /// <param name="e">El escaner al que se va a agregar el documento</param>
        /// <param name="d">El documento a ser agregado</param>
        /// <returns>Retorna "true" en el caso de encontrar uno igual, "false" en el caso de no encontrarlo</returns>
        public static bool operator ==(Escaner e, Documento d)
        {
            bool retorno = false;

            if(e.Tipo == TipoDoc.libro && d.GetType() == typeof(Libro))
            {
                foreach(Documento doc in e.ListaDocumentos)
                {
                    if((Libro)doc == (Libro)d)
                    {
                        return true;
                    }
                }
            }
            else if (e.Tipo == TipoDoc.mapa && d.GetType() == typeof(Mapa))
            {
                foreach (Mapa doc in e.ListaDocumentos)
                {
                    if (doc == (Mapa)d)
                    {
                        return true;
                    }
                }
            }
            return retorno;

        }

        /// <summary>
        /// Compara el Documento entrante comprobando que no sea del mismo tipo y que no se encuentre en la lista
        /// </summary>
        /// <param name="e">El escaner al que se va a agregar el documento</param>
        /// <param name="d">El documento a ser agregado</param>
        /// <returns>Retorna "false" en el caso de encontrar uno igual, "true" en el caso de no encontrarlo</returns>
        public static bool operator !=(Escaner e, Documento d)
        {
            return !(e==d);
        }

        /// <summary>
        /// Añade un documento a la lista de documentos comprobando que no se repita el documento y que corresponda al tipo de escaner
        /// </summary>
        /// <param name="e">Escaner al que se añadirá el documento</param>
        /// <param name="d">Documento que se quiere añadir</param>
        /// <returns>Retorna "true" en el caso de ser añadido exitosamente o "false" si no se puede añadir a la lista</returns>
        public static bool operator +(Escaner e, Documento d)
        {
            bool retorno = false;

            if ((e.Tipo == TipoDoc.libro && d.GetType() == typeof(Libro)) || (e.Tipo == TipoDoc.mapa && d.GetType() == typeof(Mapa)))
            {
                if (e != d && d.Estado == Documento.Paso.Inicio)
                {
                    d.AvanzarEstado();
                    e.ListaDocumentos.Add(d);
                    retorno = true;
                }
            }

            return retorno;
        }

    }


}

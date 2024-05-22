using System.Text;

namespace Entidades
{
    public abstract class Documento
    {

        public enum Paso
        {
            Inicio,
            Distribuido,
            EnEscaner,
            EnRevision,
            Terminado
        }

        private string autor;
        private int anio;
        private string barcode;
        private Paso estado;
        private string numNormalizado;
        private string titulo;


        public int Anio { get => anio; }
        public string Autor { get => autor;}
        public string Barcode { get => barcode; }
        public Paso Estado { get => estado;}
        protected string NumNormalizado { get => numNormalizado;}
        public string Titulo { get => titulo; }
 
        public Documento(string titulo, string autor, int anio, string numNormalizado, string barcode)
        {
            this.titulo = titulo;
            this.autor = autor;
            this.anio = anio;
            this.numNormalizado = numNormalizado;
            this.barcode = barcode;
            this.estado = Paso.Inicio;
        }

        /// <summary>
        /// Avanza el estado del documento siempre y cuando no esté en estado Terminado
        /// </summary>
        /// <returns>Devuelve "true" en caso de poder avanzar al siguiente estado y "false" en el caso de que no se pueda</returns>
        public bool AvanzarEstado()
        {
            bool retorno = false;

            if(this.estado != Paso.Terminado)
            {
                this.estado++;
                retorno = true;
            }

            return retorno;
        }

        /// <summary>
        /// Pasa a ToString los parámetros base de las clases heredadas
        /// </summary>
        /// <returns>Retorna los detalles de la clase base</returns>
        public override string ToString()
        {
            StringBuilder detallesDocumento = new StringBuilder();
            detallesDocumento.AppendLine($"Titulo: {this.titulo}");
            detallesDocumento.AppendLine($"Autor: {this.autor}");
            detallesDocumento.AppendLine($"Año: {this.anio}");


            return detallesDocumento.ToString();
        }


    }
}
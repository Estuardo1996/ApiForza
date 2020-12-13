using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiForza.SLL.Helpers
{
    public class Mensaje
    {
        /// <summary>
        /// "Constantes para los mensajes a usuarios"
        /// </summary>
        public const string MSG_TITULO_SEGURIDAD = "Seguridad - ",
            MSG_GUARDAR = "Se ha guardado los cambios exitosamente.",
            MSG_GUARDAR_ERROR = "No se ha podido guardar por el siguiente error: ",
            MSG_ELIMINAR = "Se ha eliminado exitosamente.",
            MSG_FACTURAESPECIAL = "Se ha guardado exitosamente",
            MSG_TRANSACCION = "Se ha completado la transaccion",
            MSG_ELIMINAR_ERROR = "No se ha podido eliminar porel siguiente error: ";

        public enum TipoMensaje
        {
            Ninguno = 0,
            Confirmacion = 1,
            Alerta = 2,
            Error = 3
        }

        private TipoMensaje _tipoMensaje;
        public TipoMensaje Tipo
        {
            get { return _tipoMensaje; }
            set
            {
                if (_tipoMensaje != value)
                    _tipoMensaje = value;
            }
        }

        private string _texto;
        public string Texto
        {
            get { return _texto; }
            set
            {
                if (_texto != value)
                    _texto = value;
            }
        }

        private string _titulo;
        public string Titulo
        {
            get { return _titulo; }
            set
            {
                if (_titulo != value)
                    _titulo = value;
            }
        }

        public Mensaje(string mensaje, string titulo, TipoMensaje tipo = TipoMensaje.Confirmacion)
        {
            this._titulo = titulo;
            this._texto = mensaje;
            this._tipoMensaje = tipo;
        }

        public Mensaje(string mensaje, TipoMensaje tipo)
        {
            this._texto = mensaje;
            this._tipoMensaje = tipo;
        }

        public Mensaje()
        {
            this._texto = string.Empty;
            this._tipoMensaje = TipoMensaje.Ninguno;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(_titulo))
                return string.Format("{0} - {1}", _titulo, _texto);
            else
                return _texto;
        }

    }
}

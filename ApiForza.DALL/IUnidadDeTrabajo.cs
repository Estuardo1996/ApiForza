using ApiForza.DALL.Entidades;
using ApiForza.DALL.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ApiForza.DALL
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorio<T> ObtenerRepositorio<T> () where T : EntidadBase, new();
        DbContextTransaction BeginTransaction();
        void GuardarCambios();

    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;
using ApiForza.DAL.Entidades;
using ApiForza.DAL.Repositorios;

namespace ApiForza.DAL
{
    public interface IUnidadDeTrabajo : IDisposable
    {
        IRepositorio<T> ObtenerRepositorio<T> where T : EntidadBase, new();
        DbContextTransaction BeginTransaction();
        void GuardarCambios();

    }
}

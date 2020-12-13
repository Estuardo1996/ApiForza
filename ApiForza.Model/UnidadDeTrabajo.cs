using ApiForza.DAL.Repositorios;
using System;
using System.Collections.Generic;
using System.Text;
using static ApiForza.DAL.Repositorios.IRepositorio;

namespace ApiForza.DAL
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo, IDisposable
    {
        private bool disposed = false;
        private Contexto _contexto;
        private Dictionary<string, object> _repositorios;

        public UnidadDeTrabajo()
        {
            _contexto = (Contexto)Activator.CreateInstance(typeof(Contexto));
            _contexto.Configuration.AutoDetectChangesEnabled = false;
        }

        public DbContextTransaction BeginTransaction()
        {
            return _contexto.Database.BeginTransaction();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _contexto.Dispose();
                }
            }
            this.disposed = true;
        }

        public void GuardarCambios()
        {
            _contexto.SaveChanges();
        }

        public IRepositorio<T> ObtenerRepositorio<T>() where T : EntidadBase, new()
        {
            var instancia = new Object();

            if (_repositorios == null)
                _repositorios = new Dictionary<string, object>();

            var tipo = typeof(T).Name;

            if (!_repositorios.ContainsKey(tipo))
            {
                instancia = Activator.CreateInstance(typeof(Repositorio<>).MakeGenericType(typeof(T)), _contexto);
                _repositorios.Add(tipo, instancia);
            }

            return (Repositorio<T>)_repositorios[tipo];
        }
    }
}

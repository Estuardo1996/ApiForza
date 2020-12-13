using ApiForza.DAL.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApiForza.DAL.Repositorios
{
    public partial class Repositorio<T> : IRepositorio<T> where T : EntidadBase, new()
    {
        protected readonly DbContext _contexto;
        protected readonly DbSet<T> _tabla;

        public DbSet<T> Tabla { get => this._tabla; }

        public Repositorio(DbContext contexto)
        {
            _contexto = null;
            _tabla = null;
            _contexto = contexto;
            _tabla = contexto.Set<T>();
        }
        public void Actualizar(T entidad)
        {
            _contexto.Entry(ObtenerPorId(entidad.Codigo)).CurrentValues.SetValues(entidad);
        }

        public void Actualizar(IEnumerable<T> lista)
        {
            foreach (var item in lista)
                this.Actualizar(item);
        }

        public void Eliminar(T entidad)
        {
            _contexto.Entry(ObtenerPorId(entidad.Codigo)).State = EntityState.Deleted;
        }

        public void Eliminar(object id)
        {
            var resultado = this.ObtenerPorId(id);
            this.Eliminar(resultado);
        }

        public void Eliminar(IEnumerable<T> lista)
        {
            foreach (var item in lista)
                this.Eliminar(item);
        }

        public void Insertar(T entidad)
        {
            _tabla.Add(entidad);
        }

        public void Insertar(IEnumerable<T> lista)
        {
            foreach (var item in lista)
                this.Insertar(item);
        }

        public IEnumerable<T> Obtener(Expression<Func<T, bool>> where,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                      int totalRegistros = 0)
        {
            IQueryable<T> query = _tabla.Where(where);
            if (totalRegistros > 0)
                query = _tabla.Take(totalRegistros);

            if (orderBy != null)
                return orderBy(query);
            else
                return query;
        }

        public T ObtenerPorId(object id)
        {
            var ent = _tabla.Find(id);
            if (ent != null)
                return ent;
            else
                return null;
        }

        public IEnumerable<T> ObtenerTodos()
        {
            return _tabla.AsEnumerable();
        }

        public int TotalRegistros()
        {
            return _tabla.Count();
        }

        public object UltimoInsertado()
        {
            return _tabla.Max().Codigo;
        }

        public T ClonarEntidad(T origen)
        {
            var nuevoT = new T();

            var propiedadesOrigen = typeof(T)
                .GetProperties()
                .Where(p => p.CanRead
                    && p.CanWrite
                    && p.GetCustomAttributes(typeof(System.ComponentModel.DataAnnotations.Schema.NotMappedAttribute), true).Length == 0);

            var propiedadesNoVirtuales = propiedadesOrigen.Where(p => !p.GetGetMethod().IsVirtual);

            propiedadesNoVirtuales.ToList().ForEach(propiedad =>
            {
                propiedad.SetValue(nuevoT, propiedad.GetValue(origen, null), null);
            });

            return nuevoT;
        }
    }
}

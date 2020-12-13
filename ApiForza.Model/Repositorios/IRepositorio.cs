using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ApiForza.DAL.Repositorios
{

        public interface IRepositorio<T> where T : class
        {
            DbSet<T> Tabla { get; }
            int TotalRegistros();
            IEnumerable<T> Obtener(Expression<Func<T, bool>> where,
                                   Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                   int totalRegistros = 0);
            IEnumerable<T> ObtenerTodos();
            T ObtenerPorId(object id);
            void Insertar(T entidad);
            void Insertar(IEnumerable<T> lista);
            void Eliminar(T entidad);
            void Eliminar(object id);
            void Eliminar(IEnumerable<T> lista);
            void Actualizar(T entidad);
            void Actualizar(IEnumerable<T> lista);
            object UltimoInsertado();
            T ClonarEntidad(T origen);
        }
    
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BlogCore.AccesoDatos.Data.Repository
{
    public interface IRepository<T> where T : class
    {
        //este es el repositorio general por lo tanto no va el update (ese metodo en cada repositorio)

        //metodo obtener un registro//
        T Get(int id);

        //Obtener registros todos o filtrados 
        IEnumerable<T> GetAll(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null,
            string includeProperties =null
        );

        //Obtener el primer regristro
        T GetFirstOrDefault(
            Expression<Func<T, bool>> filter = null,
            string includeProperties = null
        );

        //agregar registro
        void Add(T entity);

        //remover por id
        void Remove(int id);

        //remover x identidad pasando toda la identidad
        void Remove(T entity);
    }
}

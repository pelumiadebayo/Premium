using System;
using System.Linq.Expressions;

namespace IntranetApi.Repository.Interfaces
{
	public interface IBaseRepo<T>
	{
        void Create(T entity);
        void CreateRange(IEnumerable<T> entities);
        IQueryable<T> FindAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression);
        T GetSingle(int id);
        T GetSingleByCondition(Expression<Func<T, bool>> expression);
        void Update(T entity);
        void SoftDelete(T entity);
        void DeletePermanently(T entity);

    }
}


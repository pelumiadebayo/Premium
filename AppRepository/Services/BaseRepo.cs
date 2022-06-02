using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using IntranetApi.Repository.Interfaces;

namespace IntranetApi.Repository.Services
{
	public class BaseRepo<T>: IBaseRepo<T> where T:class
	{
        protected RepositoryContext RepositoryContext { get; set; }

        public BaseRepo(RepositoryContext repositoryContext)
		{
			RepositoryContext = repositoryContext;
		}

        public void Create(T entity) => RepositoryContext.Set<T>().Add(entity);
        public void CreateRange(IEnumerable<T> entities)=> RepositoryContext.AddRange(entities);
        public IQueryable<T> FindAll() => RepositoryContext.Set<T>().AsNoTracking();
		public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).AsNoTracking();
		public void Update(T entity) => RepositoryContext.Set<T>().Update(entity);
        public void SoftDelete(T entity) => Update(entity);
        public void DeletePermanently(T entity) => RepositoryContext.Set<T>().Remove(entity);
        public T GetSingle(int id) => RepositoryContext.Find<T>(id);
        public T GetSingleByCondition(Expression<Func<T, bool>> expression) => RepositoryContext.Set<T>().Where(expression).FirstOrDefault();
    }
}


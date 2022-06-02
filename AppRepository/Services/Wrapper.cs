using IntranetApi.Repository.Interfaces;

namespace IntranetApi.Repository.Services
{
	public class Wrapper: IWrapper
	{
		private RepositoryContext Connection;

		public Wrapper(RepositoryContext context)
		{
            Connection = context;
			User = new UserRepo(Connection);

		}

        public void BeginTransaction()
        {
            if (Connection != null)
            {
                Connection.Database.BeginTransaction();
            }
        }

        public void Save()
        {
            Connection.SaveChanges();
        }

        public void Rollback()
        {
            Connection.Database.RollbackTransaction();
        }


        public IUserRepo User { get; private set; }

	}
}


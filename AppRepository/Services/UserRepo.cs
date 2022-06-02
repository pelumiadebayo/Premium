using IntranetApi.CoreObjects.Models;
using IntranetApi.Repository.Interfaces;

namespace IntranetApi.Repository.Services
{
	public class UserRepo : BaseRepo<User>, IUserRepo
	{
		public UserRepo(RepositoryContext repositoryContext) : base(repositoryContext)
		{
		}
	}
}


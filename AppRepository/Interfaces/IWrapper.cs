using System;
namespace IntranetApi.Repository.Interfaces
{
	public interface IWrapper
	{
		IUserRepo User { get; }
		void Save();
		void BeginTransaction();
		void Rollback();
	}
}


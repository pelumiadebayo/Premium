using System;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.Models;
using IntranetApi.CoreObjects.ResponseModel;

namespace IntranetApi.BusinessCore.Interfaces
{
	public interface IUser
	{
		GenericResponse CreateUser(UserRequest req);
	}
}


using System;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.ResponseModel;

namespace IntranetApi.BusinessCore.Interfaces
{
	public interface ICheckBookRequest
	{
		Task<GenericResponse<IEnumerable<CheckBookUser>>> GetCheckBookRequestAsync(DateTime startDate, DateTime endDate);
	}
}


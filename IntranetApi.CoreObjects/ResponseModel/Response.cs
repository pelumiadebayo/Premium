using System;
namespace IntranetApi.CoreObjects.ResponseModel
{
	public class GenericResponse
	{
        public string? ResponseMessage { get; set; }
        public bool Succeeded { get; set; }
    }
}


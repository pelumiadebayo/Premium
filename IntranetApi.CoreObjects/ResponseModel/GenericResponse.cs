using System;
namespace IntranetApi.CoreObjects.ResponseModel
{
    public class GenericResponse<T>
    {
        public bool Succeeded { get; set; }
        public string ResponseMessage { get; set; }
        public T Data { get; set; }
    }
    
}


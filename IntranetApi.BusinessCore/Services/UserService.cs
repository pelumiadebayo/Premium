using System;
using System.DirectoryServices.Protocols;
using System.Net;
using AutoMapper;
using IntranetApi.BusinessCore.Interfaces;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.Models;
using IntranetApi.CoreObjects.ResponseModel;
using IntranetApi.Repository.Interfaces;
using Microsoft.Extensions.Logging;

namespace IntranetApi.BusinessCore.Services
{
	public class UserService: IUser
	{
        private readonly IWrapper Repository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;


        public UserService(IWrapper repository, IMapper mapper, ILogger<UserService> logger)
		{
            Repository = repository;
            _mapper = mapper;
            _logger = logger;
        }

        public GenericResponse CreateUser(UserRequest req)
        {
            Repository.BeginTransaction();
            _logger.LogInformation("CREATE USER STARTED...", req);
                GenericResponse response = new GenericResponse();
                try
                {
                    //req.BirthDate = DateTime.Now;
                    var user = new User();
                    _mapper.Map(req, user);
                var client = new Client("Premiumplus", "PremiumTrustBank.net", "321M@zzle*%*", "Ldap://192.168.201.5:389");

               

                //Validating credentials
                if (client.validateUser("pelumi.adebayo", "password321"))
                {
                    Console.WriteLine("Valid credentials");
                }
                else
                {
                    Console.WriteLine("Invalid credentials");
                }
                Repository.User.Create(user);
                    //response
                    response.Succeeded = true;
                    response.ResponseMessage = "success";
                    _logger.LogInformation("USER CREATED", user);
                Repository.Save();
                }
                catch (Exception ex)
                {
                    response.Succeeded = false;
                    response.ResponseMessage = ex.Message;
                    _logger.LogError(message: ex.Message, exception: ex);
                Repository.Rollback();
                }            
            return response;
        }

        
    }
}


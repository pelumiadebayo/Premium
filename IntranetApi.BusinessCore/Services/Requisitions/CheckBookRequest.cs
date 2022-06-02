using System;
using System.Collections.ObjectModel;
using System.Data.Common;
using AutoMapper;
using IntranetApi.BusinessCore.Helpers;
using IntranetApi.BusinessCore.Interfaces;
using IntranetApi.CoreObjects.DTOs;
using IntranetApi.CoreObjects.ResponseModel;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Oracle.ManagedDataAccess.Client;

namespace IntranetApi.BusinessCore.Services.Requisitions
{
	public class CheckBookRequest: ICheckBookRequest
	{

        private readonly ILogger<CheckBookRequest> _logger;
        private readonly IConfiguration _configuration;

        public CheckBookRequest(ILogger<CheckBookRequest> logger, IConfiguration configuration)
		{
            _logger = logger;
            _configuration = configuration;
		}

        public async Task<GenericResponse<IEnumerable<CheckBookUser>>> GetCheckBookRequestAsync(DateTime startDate, DateTime endDate)
        {
            using (OracleConnection conn = new OracleConnection(_configuration.GetConnectionString("checkBookConnection")))
            {
                var response = new GenericResponse<IEnumerable<CheckBookUser>>();
                try
                {
                    if (startDate!=null && endDate!=null)
                    {
                        startDate = startDate.Date;
                        startDate = endDate.Date;
                    }else if (endDate == null && startDate!=null)
                    {
                        endDate = startDate.Date;
                    }else if(startDate==null && endDate != null)
                    {
                        startDate = endDate.Date;
                    }
                    else
                    {
                        startDate = DateTime.Now.Date;
                        endDate = DateTime.Now.Date;
                    }

                    //startDate = new DateTime(2022, 02, 21);
                    //endDate = new DateTime(2022, 03, 30);
                    await conn.OpenAsync();
                    OracleCommand cmd = conn.CreateCommand();
                    cmd.CommandText = Constant.CheckBookRequestQuery;
                    cmd.BindByName = true;
                    cmd.Parameters.Add(new OracleParameter(":STARTDATE", startDate));
                    cmd.Parameters.Add(new OracleParameter(":ENDDATE", endDate));
                    DbDataReader reader = await cmd.ExecuteReaderAsync();
                    ICollection<CheckBookUser> requests = new Collection<CheckBookUser>();
                    while (await reader.ReadAsync())
                    {
                        if (reader.HasRows)
                        {
                            CheckBookUser c = new CheckBookUser();
                            c.Name = await reader.IsDBNullAsync(0) ? null : reader.GetString(0);
                            c.AccountNumber = await reader.IsDBNullAsync(1) ? null : reader.GetString(1);
                            c.Oderdate = await reader.IsDBNullAsync(2) ? null : reader.GetString(2);
                            c.BranchCode = await reader.IsDBNullAsync(3) ? null : reader.GetString(3);
                            c.BranchName = await reader.IsDBNullAsync(4) ? null : reader.GetString(4);
                            c.BranchAddress = await reader.IsDBNullAsync(5) ? null : reader.GetString(5);
                            c.NumberOfleaves = await reader.IsDBNullAsync(6) ? null : reader.GetString(6);
                            c.DeliveryBranch = await reader.IsDBNullAsync(7) ? null : reader.GetString(7);
                            c.SortCode = await reader.IsDBNullAsync(8) ? null : reader.GetString(8);
                            c.Currency = await reader.IsDBNullAsync(9) ? null : reader.GetString(9);
                            c.RangeStart = await reader.IsDBNullAsync(10) ? null : reader.GetString(10);
                            c.RangeEnd = await reader.IsDBNullAsync(11) ? null : reader.GetString(11);
                            c.CheckType = await reader.IsDBNullAsync(12) ? null : reader.GetString(12);
                            c.ShemeCode = await reader.IsDBNullAsync(13) ? null : reader.GetString(13);
                            requests.Add(c);
                        }
                        
                    }
                    await reader.DisposeAsync();

                    response.Succeeded = true;
                    response.ResponseMessage = "Sucess";
                    response.Data = requests;
                    return response;
                }
                catch (Exception e)
                {
                    _logger.LogError(message: "Got an error while retrieving data", exception: e);
                }
                response.Succeeded = false;
                return response;
            }
        }
    }
}


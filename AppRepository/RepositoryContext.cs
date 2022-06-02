using System;
using IntranetApi.CoreObjects.Models;
using Microsoft.EntityFrameworkCore;

namespace IntranetApi.Repository
{
	public class RepositoryContext : DbContext
    {
        //protected readonly IConfiguration Configuration;

        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }

        DbSet<User> Users { get; set; }
    }
}

